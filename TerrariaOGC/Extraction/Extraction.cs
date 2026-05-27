using ExtractIso;
using ExtractStfs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Media;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using TCCS;

namespace TerrariaOGC
{
    public partial class Extraction : Form
    {
        private Dictionary<UiSound, SoundPlayer> sounds;
        private PrivateFontCollection privateFonts;
        private FontFamily andyFontFamily;
        private string tccsExePath;
        private const string TccsVersion = "1.01";
        private readonly string baseDir = AppDomain.CurrentDomain.BaseDirectory;
        private string tccsDir;

        private TableLayoutPanel filesPanel;
        private TextBox isoTextBox;
        private Label browseIsoButton;
        private Button extractButton;
        private ProgressBar progressBar;
        private Label statusLabel;

        private string selectedIsoPath;
        private TextBox[] fileTextBoxes;
        private Control[] fileBrowseButtons;
        private BackgroundWorker extractionWorker;

        private readonly string[] requiredFiles =
        {
            "msvcp71.dll", "msvcr71.dll", "xWMAEncode.exe",
            "unbundler.exe", "xbdecompress.exe", "xbdm.dll"
        };

        private enum UiSound { Click, Hover, Success }

        public Extraction()
        {
            Icon = Properties.Resources.TerrariaOGC;
            tccsDir = Path.Combine(baseDir, "tools", "TCCS");
            tccsExePath = Path.Combine(tccsDir, "TCCS.exe");
            fileBrowseButtons = new Control[requiredFiles.Length];
            fileTextBoxes = new TextBox[requiredFiles.Length];
            LoadEmbeddedAndyFont();
            LoadSounds();
            BuildUi();
            LoadExistingFiles();
            UpdateExtractButton();
        }

        private void LoadSounds()
        {
            sounds = new Dictionary<UiSound, SoundPlayer>();
            LoadSound(UiSound.Click, "Click.wav");
            LoadSound(UiSound.Hover, "Hover.wav");
            LoadSound(UiSound.Success, "Success.wav");
        }

        private void PlaySound(UiSound sound)
        {
            try { sounds?[sound].Play(); } catch { }
        }

        private void LoadSound(UiSound sound, string fileName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            string resourceName = null;

            foreach (var name in assembly.GetManifestResourceNames())
            {
                if (name.EndsWith("." + fileName, StringComparison.OrdinalIgnoreCase))
                {
                    resourceName = name;
                    break;
                }
            }

            if (resourceName == null) return;

            var stream = assembly.GetManifestResourceStream(resourceName);
            if (stream == null) return;

            var player = new SoundPlayer(stream);
            player.Load();
            sounds[sound] = player;
        }

        private Font AndyFont(float size) =>
            andyFontFamily != null
                ? new Font(andyFontFamily, size, FontStyle.Bold)
                : new Font("Segoe UI", size, FontStyle.Bold);

        private void LoadEmbeddedAndyFont()
        {
            privateFonts = new PrivateFontCollection();
            var assembly = Assembly.GetExecutingAssembly();

            using (var fontStream = assembly.GetManifestResourceStream("TerrariaOGC.Assets.AndyBold.ttf"))
            {
                if (fontStream == null)
                    throw new FileNotFoundException("Embedded font resource was not found: TerrariaOGC.Assets.AndyBold.ttf");

                byte[] fontData = new byte[fontStream.Length];
                fontStream.Read(fontData, 0, fontData.Length);

                IntPtr fontPtr = Marshal.AllocCoTaskMem(fontData.Length);
                try
                {
                    Marshal.Copy(fontData, 0, fontPtr, fontData.Length);
                    privateFonts.AddMemoryFont(fontPtr, fontData.Length);
                }
                finally
                {
                    Marshal.FreeCoTaskMem(fontPtr);
                }
            }

            andyFontFamily = privateFonts.Families[0];
        }

        private void BuildUi()
        {
            Text = "TerrariaOGC";
            Width = 800;
            Height = 580;
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            BackColor = Color.FromArgb(240, 240, 245);

            var headerPanel = new Panel
            {
                Width = 800,
                Height = 80,
                BackColor = Color.FromArgb(46, 204, 113),
                Dock = DockStyle.Top
            };
            headerPanel.Controls.Add(new Label
            {
                Text = "Content Extraction",
                Left = 20,
                Top = 30,
                Width = 760,
                Height = 50,
                Font = AndyFont(20),
                ForeColor = Color.White,
                BackColor = Color.Transparent
            });

            var prereqLabel = new Label
            {
                Text = "Required Prerequisite Files:",
                Left = 30,
                Top = 100,
                Width = 740,
                Height = 22,
                Font = AndyFont(14),
                ForeColor = Color.FromArgb(52, 73, 94)
            };

            filesPanel = new TableLayoutPanel
            {
                Left = 30,
                Top = 130,
                Width = 740,
                Height = 240,
                ColumnCount = 3,
                RowCount = requiredFiles.Length,
                BackColor = Color.White,
                Padding = new Padding(10),
                BorderStyle = BorderStyle.FixedSingle
            };
            filesPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150));
            filesPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 470));
            filesPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100));

            for (int i = 0; i < requiredFiles.Length; i++)
                AddRequiredFileRow(i, requiredFiles[i]);

            var isoPanel = new Panel
            {
                Left = 30,
                Top = 410,
                Width = 740,
                Height = 40,
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle
            };

            isoTextBox = new TextBox
            {
                Left = 10,
                Top = 8,
                Width = 600,
                Height = 24,
                ReadOnly = true,
                BorderStyle = BorderStyle.None,
                BackColor = Color.White,
                Font = AndyFont(9)
            };

            browseIsoButton = new Label
            {
                Text = "Browse",
                Left = 620,
                Top = 6,
                Width = 110,
                Height = 28,
                ForeColor = Color.FromArgb(52, 73, 94),
                BackColor = Color.Transparent,
                Font = AndyFont(10),
                Cursor = Cursors.Hand,
                TextAlign = ContentAlignment.MiddleCenter
            };
            browseIsoButton.Click += BrowseIsoButton_Click;
            browseIsoButton.MouseEnter += (s, e) => { PlaySound(UiSound.Hover); browseIsoButton.ForeColor = Color.Gold; };
            browseIsoButton.MouseLeave += (s, e) => browseIsoButton.ForeColor = Color.FromArgb(52, 73, 94);

            isoPanel.Controls.Add(isoTextBox);
            isoPanel.Controls.Add(browseIsoButton);

            extractButton = new Button
            {
                Text = "Extract Content",
                Left = 30,
                Top = 470,
                Width = 740,
                Height = 42,
                Enabled = false,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(46, 204, 113),
                ForeColor = Color.White,
                Font = AndyFont(14),
                Cursor = Cursors.Hand,
                TextAlign = ContentAlignment.MiddleCenter,
                UseCompatibleTextRendering = true,
                Padding = new Padding(0, 4, 0, 0)
            };
            extractButton.FlatAppearance.BorderSize = 0;
            extractButton.Click += ExtractButton_Click;

            progressBar = new ProgressBar
            {
                Left = 30,
                Top = 465,
                Width = 740,
                Height = 42,
                Style = ProgressBarStyle.Marquee,
                Minimum = 0,
                Maximum = 100,
                Value = 0,
                Visible = false
            };

            statusLabel = new Label
            {
                Left = 30,
                Top = 515,
                Width = 740,
                Height = 20,
                Font = AndyFont(9),
                ForeColor = Color.FromArgb(52, 73, 94),
                TextAlign = ContentAlignment.MiddleCenter,
                Visible = false
            };

            Controls.Add(headerPanel);
            Controls.Add(prereqLabel);
            Controls.Add(filesPanel);
            Controls.Add(new Label
            {
                Text = "Xbox 360 Game ISO:",
                Left = 30,
                Top = 385,
                Width = 740,
                Height = 25,
                Font = AndyFont(14),
                ForeColor = Color.FromArgb(52, 73, 94)
            });
            Controls.Add(isoPanel);
            Controls.Add(extractButton);
            Controls.Add(progressBar);
            Controls.Add(statusLabel);
        }

        private void AddRequiredFileRow(int rowIndex, string fileName)
        {
            var nameLabel = new Label
            {
                Text = fileName,
                Width = 145,
                Height = 30,
                Font = AndyFont(9),
                ForeColor = Color.FromArgb(52, 73, 94),
                TextAlign = ContentAlignment.MiddleLeft,
                Margin = new Padding(0, 4, 5, 4)
            };

            var pathBox = new TextBox
            {
                Width = 455,
                Height = 24,
                ReadOnly = true,
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.White,
                Font = AndyFont(8),
                Margin = new Padding(0, 4, 5, 4)
            };

            var browseLabel = new Label
            {
                Text = "Browse",
                Width = 90,
                Height = 28,
                ForeColor = Color.FromArgb(52, 73, 94),
                BackColor = Color.Transparent,
                Font = AndyFont(8),
                Cursor = Cursors.Hand,
                Tag = rowIndex,
                TextAlign = ContentAlignment.MiddleLeft,
                Margin = new Padding(0, 3, 0, 3)
            };
            browseLabel.Click += BrowseRequiredFileButton_Click;
            browseLabel.MouseEnter += (s, e) => { PlaySound(UiSound.Hover); browseLabel.ForeColor = Color.Gold; };
            browseLabel.MouseLeave += (s, e) => browseLabel.ForeColor = Color.FromArgb(52, 73, 94);

            fileTextBoxes[rowIndex] = pathBox;
            fileBrowseButtons[rowIndex] = browseLabel;

            filesPanel.Controls.Add(nameLabel, 0, rowIndex);
            filesPanel.Controls.Add(pathBox, 1, rowIndex);
            filesPanel.Controls.Add(browseLabel, 2, rowIndex);
        }

        private void LoadExistingFiles()
        {
            Directory.CreateDirectory(tccsDir);

            for (int i = 0; i < requiredFiles.Length; i++)
            {
                string path = Path.Combine(tccsDir, requiredFiles[i]);
                fileTextBoxes[i].Text = File.Exists(path) ? path : "";
            }
        }

        private void BrowseRequiredFileButton_Click(object sender, EventArgs e)
        {
            PlaySound(UiSound.Click);
            var button = sender as Control;
            if (button == null) return;

            int index = (int)button.Tag;
            string requiredFile = requiredFiles[index];

            using (var dialog = new OpenFileDialog())
            {
                dialog.Title = "Select " + requiredFile;
                dialog.Filter = requiredFile + "|" + requiredFile + "|All files (*.*)|*.*";
                dialog.CheckFileExists = true;

                if (dialog.ShowDialog(this) != DialogResult.OK) return;

                string selectedPath = dialog.FileName;
                string selectedName = Path.GetFileName(selectedPath);

                if (!string.Equals(selectedName, requiredFile, StringComparison.OrdinalIgnoreCase))
                {
                    var result = MessageBox.Show(this,
                        $"You selected:\n\n{selectedName}\n\nExpected:\n\n{requiredFile}\n\nUse this file anyway?",
                        "Filename Mismatch", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result != DialogResult.Yes) return;
                }

                Directory.CreateDirectory(tccsDir);
                string destination = Path.Combine(tccsDir, requiredFile);
                File.Copy(selectedPath, destination, true);
                fileTextBoxes[index].Text = destination;
                UpdateExtractButton();
            }
        }

        private void BrowseIsoButton_Click(object sender, EventArgs e)
        {
            PlaySound(UiSound.Click);
            using (var dialog = new OpenFileDialog())
            {
                dialog.Title = "Select Xbox 360 Game ISO";
                dialog.Filter = "Xbox 360 ISO (*.iso)|*.iso|All files (*.*)|*.*";
                dialog.CheckFileExists = true;

                if (dialog.ShowDialog(this) != DialogResult.OK) return;

                selectedIsoPath = dialog.FileName;
                isoTextBox.Text = selectedIsoPath;
                UpdateExtractButton();
            }
        }

        private void UpdateExtractButton()
        {
            bool allFilesReady = true;
            for (int i = 0; i < requiredFiles.Length; i++)
            {
                if (!File.Exists(Path.Combine(tccsDir, requiredFiles[i])))
                {
                    allFilesReady = false;
                    break;
                }
            }

            bool isoReady = !string.IsNullOrEmpty(selectedIsoPath) && File.Exists(selectedIsoPath);
            extractButton.Enabled = allFilesReady && isoReady;
            extractButton.BackColor = extractButton.Enabled
                ? Color.FromArgb(46, 204, 113)
                : Color.FromArgb(149, 165, 166);

            statusLabel.Text = !allFilesReady ? "Provide every TCCS file to continue."
                             : !isoReady ? "Select an Xbox 360 ISO to continue."
                                              : "Ready to extract.";
            statusLabel.Visible = true;
        }

        private void ExtractButton_Click(object sender, EventArgs e)
        {
            PlaySound(UiSound.Click);
            SetUiExtracting(true);

            extractionWorker = new BackgroundWorker { WorkerReportsProgress = true };
            extractionWorker.DoWork += ExtractionWorker_DoWork;
            extractionWorker.ProgressChanged += ExtractionWorker_ProgressChanged;
            extractionWorker.RunWorkerCompleted += ExtractionWorker_RunWorkerCompleted;
            extractionWorker.RunWorkerAsync(selectedIsoPath);
        }

        private void ExtractionWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = Math.Max(progressBar.Minimum, Math.Min(progressBar.Maximum, e.ProgressPercentage));

            if (e.UserState is string msg && !string.IsNullOrEmpty(msg))
                statusLabel.Text = msg;
        }
        private static readonly string[] ValidIsoHashes =
        {
            "B8920EA80780C9E778CB8DEA4754F21A984A5746"
        };

        private static string ComputeSha1(string path)
        {
            using (var sha1 = System.Security.Cryptography.SHA1.Create())
            using (var stream = File.OpenRead(path))
            {
                byte[] buffer = new byte[1024 * 1024]; // 1MB buffer

                // Hash the header region
                stream.Position = 0;
                sha1.TransformBlock(buffer, 0, stream.Read(buffer, 0, buffer.Length), null, 0);

                // Hash around the Xbox media header
                stream.Position = 0x10000;
                sha1.TransformBlock(buffer, 0, stream.Read(buffer, 0, buffer.Length), null, 0);

                // Hash the end of the file
                stream.Position = Math.Max(0, stream.Length - buffer.Length);
                sha1.TransformFinalBlock(buffer, 0, stream.Read(buffer, 0, buffer.Length));

                var sb = new System.Text.StringBuilder();
                foreach (byte b in sha1.Hash)
                    sb.AppendFormat("{0:X2}", b);
                return sb.ToString();
            }
        }
        private void ExtractionWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var worker = sender as BackgroundWorker;
            string iso = e.Argument as string;

            worker?.ReportProgress(3, "Verifying ISO...");

            string isoHash = ComputeSha1(iso);
            bool validHash = false;

            foreach (string hash in ValidIsoHashes)
            {
                if (string.Equals(isoHash, hash, StringComparison.OrdinalIgnoreCase))
                {
                    validHash = true;
                    break;
                }
            }

            if (!validHash)
                throw new InvalidDataException(
                    $"ISO hash mismatch.\n\nComputed: {isoHash}\nThis may be the wrong game or version.");
            
            

            worker?.ReportProgress(0, "Starting extraction...");

            if (!Directory.Exists(Path.Combine(baseDir, "Prerequisites"))) 
            throw new DirectoryNotFoundException("The Prerequisites folder was not found.");

            string extractedIsoDir = Path.Combine(baseDir, "extractedISO");
            string extractedContentDir = Path.Combine(baseDir, "extractedContent");
            string finalContentDir = Path.Combine(baseDir, "Content");
            string stfsPackagePath = Path.Combine(
                extractedIsoDir, "Content", "0000000000000000",
                "5841128F", "000D0000",
                "A6A68560509F43FCD231E4D1147E7902BDC9C30B58");

            worker?.ReportProgress(5, "Cleaning old extraction folders...");
            DeleteDirectoryIfExists(extractedIsoDir);
            DeleteDirectoryIfExists(extractedContentDir);

            var outputWriter = new StringWriter();
            var errorWriter = new StringWriter();

            TextWriter oldOut = Console.Out;
            TextWriter oldError = Console.Error;
            Console.SetOut(outputWriter);
            Console.SetError(errorWriter);
            bool success = false;
            try
            {
                worker?.ReportProgress(10, "Extracting Xbox 360 ISO...");
                int isoExitCode = ExtractIsoApp.Run(iso, extractedIsoDir);

                if (isoExitCode != 0)
                    throw new ApplicationException(
                        $"ISO extraction failed with exit code {isoExitCode}.\n\n" +
                        $"Output:\n{outputWriter}\n\nError:\n{errorWriter}");

                worker?.ReportProgress(45, "Finding STFS content package...");

                if (!File.Exists(stfsPackagePath))
                    throw new FileNotFoundException("The STFS content package was not found after ISO extraction.", stfsPackagePath);

                worker?.ReportProgress(50, "Extracting STFS content package...");
                StfsExtractor.Extract(stfsPackagePath, extractedContentDir);

                worker?.ReportProgress(75, "Cleaning extracted ISO folder...");
                DeleteDirectoryIfExists(extractedIsoDir);

                string extractedContentContentDir = Path.Combine(extractedContentDir, "Content");

                if (!Directory.Exists(extractedContentContentDir))
                    throw new DirectoryNotFoundException(
                        "STFS extraction completed, but extractedContent\\Content was not found: " + extractedContentContentDir);

                worker?.ReportProgress(80, "Moving Content folder...");
                DeleteDirectoryIfExists(finalContentDir);
                Directory.Move(extractedContentContentDir, finalContentDir);
                DeleteDirectoryIfExists(extractedContentDir);

                worker?.ReportProgress(90, "Running TCCS conversion...");
                TccsConverter.Run(contentDir: Path.Combine(baseDir, "Content"), prereqDir: Path.Combine(baseDir, "Prerequisites"), toolsDir: tccsDir, version: 1, blockAlignment: 128, progress: (pct, msg) => worker?.ReportProgress(90 + pct / 10, msg));

                worker?.ReportProgress(100, "Extraction complete.");
                success = true;
            }
            finally
            {
                Console.SetOut(oldOut);
                Console.SetError(oldError);
                outputWriter.Dispose();
                errorWriter.Dispose();

                if (!success)
                {
                    DeleteDirectoryIfExists(extractedIsoDir);
                    DeleteDirectoryIfExists(extractedContentDir);
                    DeleteDirectoryIfExists(finalContentDir);
                }
            }
        }

        private void RunTccs()
        {
            string contentDir = Path.Combine(baseDir, "Content");

            var startInfo = new ProcessStartInfo
            {
                FileName = tccsExePath,
                Arguments = $"--version {TccsVersion} --decompress no --block 128 --content {Quote(contentDir)} --yes",
                WorkingDirectory = tccsDir,
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true
            };
            startInfo.EnvironmentVariables["PATH"] = tccsDir + ";" + startInfo.EnvironmentVariables["PATH"];

            using (var process = Process.Start(startInfo))
            {
                string output = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();
                process.WaitForExit();

                if (process.ExitCode != 0)
                    throw new ApplicationException(
                        $"TCCS failed with exit code {process.ExitCode}.\n\nOutput:\n{output}\n\nError:\n{error}");
            }
        }

        private static void DeleteDirectoryIfExists(string path)
        {
            if (Directory.Exists(path))
                Directory.Delete(path, true);
        }

        private static string Quote(string value) =>
            "\"" + (value ?? "").Replace("\"", "\\\"") + "\"";

        private void ExtractionWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            SetUiExtracting(false);

            if (e.Error != null)
            {
                statusLabel.Text = "Extraction failed.";
                MessageBox.Show(this, e.Error.Message, "Extraction Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            PlaySound(UiSound.Success);
            statusLabel.Text = "Extraction completed successfully.";

            extractButton.Text = "Start Game";
            extractButton.BackColor = Color.FromArgb(46, 204, 113);
            extractButton.Enabled = true;
            extractButton.Visible = true;
            extractButton.Click -= ExtractButton_Click;
            extractButton.Click += (s, ev) =>
            {
                DialogResult = DialogResult.OK;
                Close();
            };
        }
        private void SetUiExtracting(bool extracting)
        {
            extractButton.Visible = !extracting;
            progressBar.Visible = extracting;
            statusLabel.Visible = true;
            statusLabel.Text = extracting ? "Starting extraction..." : "";

            if (extracting)
            {
                progressBar.Style = ProgressBarStyle.Blocks;
                progressBar.Value = 0;
            }

            browseIsoButton.Enabled = !extracting;
            extractButton.Enabled = !extracting;

            foreach (var btn in fileBrowseButtons)
                btn.Enabled = !extracting;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Extraction
            // 
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Name = "Extraction";
            this.Load += new System.EventHandler(this.Extraction_Load);
            this.ResumeLayout(false);

        }

        private void Extraction_Load(object sender, EventArgs e)
        {

        }
    }
}