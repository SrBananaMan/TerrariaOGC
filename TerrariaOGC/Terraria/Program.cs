using System;
using System.Diagnostics;
using System.IO;
#if !VERSION_INITIAL && !USE_ORIGINAL_CODE
using System.Security.Cryptography;
#endif
using System.Windows.Forms;
using TerrariaOGC;

namespace Terraria
{
    internal static class Program
    {
#if !VERSION_INITIAL && !USE_ORIGINAL_CODE
        private static bool CheckContentVersion()
        {
            string contentDir = Path.GetFullPath("Content");
            string imagesDir = Path.Combine(contentDir, "Images");
            string sprites = Path.Combine(imagesDir, "_sheetSprites.xnb");
            string tiles = Path.Combine(imagesDir, "_sheetTiles.xnb");

#if VERSION_101
            const string version = "1.01";
#elif VERSION_103
            const string version = "1.03";
#elif VERSION_FINAL
            const string version = "1.09";
#else
            const string version = "this version";
#endif

            string problem;
            try
            {
                if (!File.Exists(sprites) || !File.Exists(tiles))
                {
                    problem = "The sprite or tile sheet is missing.";
                }
                else if (MatchesInitialAtlas(sprites, "8CC2DA34C7DB91DE4EF795102D84B45761A7C07677B020B6191D5D6B5EF9DDD9") ||
                         MatchesInitialAtlas(tiles, "1C368A599F04BDDDA744B9342260DF40E2A3E1ED59747E25303E286B0EDBABF8"))
                {
                    problem = "This Content folder contains an Initial Release sprite or tile sheet.";
                }
                else
                {
                    return true;
                }
            }
            catch (IOException ex)
            {
                problem = ex.Message;
            }
            catch (UnauthorizedAccessException ex)
            {
                problem = ex.Message;
            }

            System.Windows.Forms.MessageBox.Show(
                $"{problem}\n\nUse the matching {version} game assets in:\n{contentDir}\n\n" +
                "The built-in ISO extractor supplies Initial Release assets.",
                "Matching Game Content Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        private static bool MatchesInitialAtlas(string path, string expectedHash)
        {
            using (var sha256 = SHA256.Create())
            using (var stream = File.OpenRead(path))
            {
                string hash = BitConverter.ToString(sha256.ComputeHash(stream)).Replace("-", "");
                return hash == expectedHash;
            }
        }
#endif

        [STAThread]
        private static void Main(string[] args)
        {
#if USE_ORIGINAL_CODE
			Marshal.PrelinkAll(typeof(Main));
			ThreadPool.SetMinThreads(0, 0);
			ThreadPool.SetMaxThreads(0, 0);
#else
            Environment.SetEnvironmentVariable("FNA3D_FORCE_DRIVER", "opengl"); // Found to not cause issues on Win11 if you had D3D11 set.
            Environment.SetEnvironmentVariable("FNA3D_BACKBUFFER_SCALE_NEAREST", "1");
#endif

#if !VERSION_INITIAL && !USE_ORIGINAL_CODE
            if (!CheckContentVersion())
                return;
#endif

            using (Main TheGame = new Main())
            {
                try
                {
                    TheGame.Run();
                }
                catch (Exception Ex)
                {
                    using (StreamWriter ErrorWriter = new StreamWriter("client-crashlog.txt", append: true))
                    {
                        ErrorWriter.WriteLine(DateTime.Now);
                        ErrorWriter.WriteLine(Ex);

                        var Tracer = new StackTrace(Ex, true);
                        for (int i = 0; i < Tracer.FrameCount; i++)
                        {
                            StackFrame frame = Tracer.GetFrame(i);
                            ErrorWriter.WriteLine(frame.GetMethod());
                            ErrorWriter.WriteLine(frame.GetFileLineNumber());
                        }

                        ErrorWriter.WriteLine("");
                    }

#if !USE_ORIGINAL_CODE
                    if (!Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "Content")))
                    {
                        using (var extractionForm = new Extraction())
                        {
                            if (extractionForm.ShowDialog() != DialogResult.OK)
                                return;
                        }
                    }

                    using (Main game = new Main())
                    {
                        game.Run();
                    }
#endif
                }
            }
        }
    }
}
