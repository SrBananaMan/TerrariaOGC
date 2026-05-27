using System;
using System;
using System.IO;
using TCCS.EndianUtils;
using TCCS.Handlers;
using static TCCS.Handlers.XWBHandler;

namespace TCCS
{
    public static class TccsConverter
    {
        public static ushort BlockSetting { get; private set; } = 128;

        public static void Run(
            string contentDir,
            string prereqDir,
            string toolsDir,
            byte version,
            ushort blockAlignment = 128,
            Action<int, string> progress = null)
        {
            BlockSetting = blockAlignment;

            Report(progress, 0, "Starting TCCS conversion...");

            if (version > 0)
            {
                Report(progress, 5, "Decompressing content files...");
                DecompressContent(contentDir, toolsDir);
            }

            Report(progress, 40, "Reading music files...");
            WBEntry[] entries;
            string[] songNames;
            ReadWaveBank(contentDir, out entries, out songNames);

            Report(progress, 60, "Extracting music...");
            string extMusicDir = Path.Combine(contentDir, "ExtMusic");

            if (Directory.Exists(extMusicDir))
                Directory.Delete(extMusicDir, true);

            Directory.CreateDirectory(extMusicDir);

            for (int i = 0; i < entries.Length; i++)
            {
                WBEntry entry = entries[i];
                var writer = new WaveWriter(
                    entry.Format,
                    entry.Name,
                    entry.Header,
                    entry.Metadata,
                    entry.Data,
                    entry.Dpds,
                    entry.Seek,
                    toolsDir,
                    EndianReader.Endianness.Little);

                string songName =
                    (i < songNames.Length && !string.IsNullOrEmpty(songNames[i]))
                        ? songNames[i]
                        : (!string.IsNullOrEmpty(entry.Name)
                            ? entry.Name
                            : string.Format("Track_{0}", i + 1));

                writer.Write(songName, extMusicDir);
                Report(progress, 60 + ((i + 1) * 20 / entries.Length), string.Format("Converting track {0}/{1}: {2}", i + 1, entries.Length, songName));
            }

            Report(progress, 85, "Copying prerequisite assets...");
            CopyAssets(contentDir, prereqDir);

            Report(progress, 100, "Conversion complete.");
        }

        private static void Report(Action<int, string> progress, int percent, string message)
        {
            if (progress != null) progress(percent, message);
        }

        private static void DecompressContent(string contentDir, string toolsDir)
        {
            string[] compressedExts = new string[]
                { ".xpr", ".txt", ".str", ".ps", ".vs", ".xma", ".xsb", ".xgs", ".xwb", ".fnt" };

            string[] files = Directory.GetFiles(contentDir, "*", SearchOption.AllDirectories);

            foreach (string filePath in files)
            {
                var file = new FileInfo(filePath);
                if (Array.IndexOf(compressedExts, file.Extension) < 0) continue;

                RunTool(toolsDir, "xbdecompress.exe",
                    string.Format("/Y \"{0}\" \"{1}\"", file.FullName, file.Directory));

                if (file.Extension == ".xpr")
                {
                    try
                    {
                        RunTool(toolsDir, "unbundler.exe",
                            string.Format("\"{0}\"", file.FullName));

                        string tga = Path.GetFileNameWithoutExtension(file.FullName) + ".tga";
                        string dest = file.FullName.Substring(0, file.FullName.Length - 3) + "tga";
                        if (File.Exists(tga))
                        {
                            File.Move(tga, dest);
                            File.Delete(file.FullName);
                        }
                    }
                    catch (FileNotFoundException) { }
                }

                if (file.Extension == ".xma")
                {
                    string wav = file.FullName.Substring(0, file.FullName.Length - 3) + "wav";
                    RunTool(toolsDir, "xma2encode.exe",
                        string.Format("\"{0}\" /DecodeToPCM \"{1}\"", file.FullName, wav));
                    File.Delete(file.FullName);
                }
            }
        }

        private static void ReadWaveBank(string contentDir, out WBEntry[] entries, out string[] songNames)
        {
            entries = null;
            songNames = null;

            string[] files = Directory.GetFiles(contentDir, "*", SearchOption.AllDirectories);

            foreach (string filePath in files)
            {
                var file = new FileInfo(filePath);

                if (file.Extension == ".xsb")
                {
                    using (var stream = File.OpenRead(filePath))
                    using (var handler = new XSBHandler(stream))
                    {
                        songNames = new string[handler.Names.Length];
                        Array.Copy(handler.Names, songNames, handler.Names.Length);
                    }
                }

                if (file.Extension == ".xwb")
                {
                    using (var stream = File.OpenRead(filePath))
                    using (var handler = new XWBHandler(stream))
                    {
                        entries = new WBEntry[handler.Count];

                        for (uint id = 0; id < handler.Count; id++)
                        {
                            WaveFormat fmt = handler.GetWaveFormat(id);

                            var headerStream = new MemoryStream();
                            var headerWriter = new EndianWriter(headerStream, EndianWriter.Endianness.Little);
                            headerWriter.Write((ushort)fmt.Encoding);
                            headerWriter.Write((ushort)fmt.Channels);
                            headerWriter.Write(fmt.SampleRate);
                            headerWriter.Write(fmt.AvgBytesPerSecond);
                            headerWriter.Write((ushort)fmt.BlockAlignment);
                            headerWriter.Write((ushort)fmt.BitDepth);
                            headerWriter.Write((ushort)fmt.ExtraSize.Length);

                            byte[] headerArr = headerStream.ToArray();
                            byte[] fullHeader = new byte[headerArr.Length + fmt.ExtraSize.Length];
                            Buffer.BlockCopy(headerArr, 0, fullHeader, 0, headerArr.Length);
                            Buffer.BlockCopy(fmt.ExtraSize, 0, fullHeader, headerArr.Length, fmt.ExtraSize.Length);

                            uint[] seek = new uint[0];
                            if (fmt.Encoding >= EncodingType.WMAudio2 && fmt.Encoding <= EncodingType.XMA2)
                                seek = handler.GetSeekTable(id) ?? new uint[0];

                            entries[id] = new WBEntry(
                                fmt,
                                handler.GetName(id) ?? string.Empty,
                                fullHeader,
                                handler.GetMetadata(id),
                                handler.GetWaveData(id),
                                handler.GetDpds(id),
                                seek);
                        }
                    }
                }
            }

            if (entries == null || songNames == null)
                throw new InvalidOperationException(
                    "Could not find .xwb and .xsb files in the Content directory.");

            // Warn if array sizes don't match but allow processing to continue
            if (entries.Length != songNames.Length)
            {
                string warning = string.Format(
                    "Warning: Wave bank has {0} entries but sound bank has {1} names. " +
                    "Using fallback names where necessary.",
                    entries.Length, songNames.Length);
                Report(null, 0, warning); // Log warning if progress callback exists
            }
        }

        private static void CopyAssets(string contentDir, string prereqDir)
        {
            string prereqContent = Path.Combine(prereqDir, "Content");

            string fonts = Path.Combine(contentDir, "Fonts");
            string fontsOld = Path.Combine(contentDir, "FontsOld");
            if (Directory.Exists(fonts) && !Directory.Exists(fontsOld))
                Directory.Move(fonts, fontsOld);

            CopyDirectory(Path.Combine(prereqContent, "Fonts"), Path.Combine(contentDir, "Fonts"));
            CopyDirectory(Path.Combine(prereqContent, "Achievements"), Path.Combine(contentDir, "Achievements"));
            CopyDirectory(Path.Combine(prereqContent, "Images"), Path.Combine(contentDir, "Images"));
            CopyDirectory(Path.Combine(prereqContent, "UI"), Path.Combine(contentDir, "UI"));

            File.Copy(Path.Combine(prereqContent, "ACB.tga"), Path.Combine(contentDir, "ACB.tga"), true);
            File.Copy(Path.Combine(prereqContent, "PEGI.xnb"), Path.Combine(contentDir, "PEGI.xnb"), true);
            File.Copy(Path.Combine(prereqContent, "USK.xnb"), Path.Combine(contentDir, "USK.xnb"), true);
        }

        private static void RunTool(string toolsDir, string exe, string args)
        {
            var info = new System.Diagnostics.ProcessStartInfo
            {
                FileName = Path.Combine(toolsDir, exe),
                Arguments = args,
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true
            };
            using (var p = System.Diagnostics.Process.Start(info))
                p.WaitForExit();
        }

        private static void CopyDirectory(string src, string dst)
        {
            Directory.CreateDirectory(dst);
            foreach (FileInfo file in new DirectoryInfo(src).GetFiles())
                file.CopyTo(Path.Combine(dst, file.Name), true);
            foreach (DirectoryInfo sub in new DirectoryInfo(src).GetDirectories())
                CopyDirectory(sub.FullName, Path.Combine(dst, sub.Name));
        }

        public struct WBEntry
        {
            public string Name;
            public byte[] Dpds;
            public byte[] Header;
            public byte[] Data;
            public uint[] Seek;
            public WaveFormat Format;
            public MetaData Metadata;

            internal WBEntry(WaveFormat fmt, string name, byte[] header, MetaData meta,
                byte[] data, byte[] dpds, uint[] seek)
            {
                Format = fmt;
                Name = name;
                Header = header;
                Metadata = meta;
                Data = data;
                Dpds = dpds;
                Seek = seek;
            }
        }
    }
}