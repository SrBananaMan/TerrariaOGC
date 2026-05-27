using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ExtractStfs
{
    public sealed class StfsOptions
    {
        public string Path { get; set; }
        public string OutputDirectory { get; set; }
        public bool ListOnly { get; set; }
        public TextWriter Output { get; set; }
        public TextWriter Error { get; set; }

        public StfsOptions()
        {
            Output = Console.Out;
            Error = Console.Error;
        }
    }

    internal sealed class StfsEntry
    {
        public int Index;
        public string Name;
        public bool IsDirectory;
        public bool IsConsecutive;
        public int NumBlocks;
        public int FirstBlock;
        public int PathIndicator;
        public int FileSize;

        public StfsEntry()
        {
            Name = string.Empty;
        }
    }

    public static class StfsExtractor
    {
        private const int BlockSize = 0x1000;
        private const int EntriesPerBlock = 64;
        private const int EntrySize = 0x40;

        private static int _shift;
        private static long _firstHashTableAddress;

        public static int Run(string[] args)
        {
            try
            {
                StfsOptions options = ParseArgs(args);
                Extract(options);
                return 0;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                return 1;
            }
        }

        public static void Extract(string path, string outputDirectory)
        {
            Extract(new StfsOptions
            {
                Path = path,
                OutputDirectory = outputDirectory,
                ListOnly = false
            });
        }

        public static void List(string path)
        {
            Extract(new StfsOptions
            {
                Path = path,
                ListOnly = true
            });
        }

        public static void Extract(StfsOptions options)
        {
            if (options == null)
            {
                throw new ArgumentNullException("options");
            }

            if (string.IsNullOrEmpty(options.Path))
            {
                throw new ArgumentException("Path is required.");
            }

            if (!options.ListOnly && string.IsNullOrEmpty(options.OutputDirectory))
            {
                throw new ArgumentException("OutputDirectory is required unless ListOnly is true.");
            }

            TextWriter output = options.Output ?? Console.Out;
            TextWriter error = options.Error ?? Console.Error;

            using (FileStream stfsFile = File.Open(options.Path, FileMode.Open, FileAccess.Read, FileShare.Read))
            using (BinaryReader reader = new BinaryReader(stfsFile))
            {
                string magic = Encoding.ASCII.GetString(reader.ReadBytes(4));
                if (magic != "CON " && magic != "LIVE" && magic != "PIRS")
                {
                    throw new InvalidDataException("Not an STFS file (magic: " + magic + ")");
                }

                output.WriteLine("Package type: " + magic.Trim());

                reader.BaseStream.Position = 0x340;
                int headerSize = ReadInt32BE(reader.ReadBytes(4));
                _firstHashTableAddress = (headerSize + 0xFFF) & unchecked((int)0xFFFFF000);

                output.WriteLine(
                    "Header size: 0x" + headerSize.ToString("X") +
                    ", first hash table: 0x" + _firstHashTableAddress.ToString("X"));

                reader.BaseStream.Position = 0x379;
                int volDescSize = reader.ReadByte();
                reader.ReadByte(); // reserved
                int blockSeparation = reader.ReadByte();

                // Female: blockSeparation bit set => shift 0
                // Male:   blockSeparation bit clear => shift 1
                _shift = (blockSeparation & 1) != 0 ? 0 : 1;

                int fileTableBlockCount = ReadInt16LE(reader.ReadBytes(2));
                int fileTableBlockNum = ReadInt24LE(reader.ReadBytes(3));

                output.WriteLine("Block separation: " + blockSeparation + " (shift=" + _shift + ")");
                output.WriteLine("File table: block " + fileTableBlockNum + ", " + fileTableBlockCount + " block(s)");

                reader.BaseStream.Position = 0x0411;
                byte[] displayNameBytes = reader.ReadBytes(128);
                string displayName = Encoding.BigEndianUnicode.GetString(displayNameBytes).TrimEnd('\0');
                output.WriteLine("Display name: " + displayName);

                long fileTableOffset = BlockToAddress(fileTableBlockNum);
                output.WriteLine("File table offset: 0x" + fileTableOffset.ToString("X"));

                List<StfsEntry> entries = ReadFileTable(reader, stfsFile, fileTableBlockNum, fileTableBlockCount);

                Dictionary<int, StfsEntry> directories = new Dictionary<int, StfsEntry>();
                for (int i = 0; i < entries.Count; i++)
                {
                    if (entries[i].IsDirectory)
                    {
                        directories[entries[i].Index] = entries[i];
                    }
                }

                output.WriteLine();
                output.WriteLine("Found " + entries.Count + " entries:");

                if (options.ListOnly)
                {
                    ListEntries(entries, directories, output);
                }
                else
                {
                    ExtractEntries(reader, stfsFile, entries, directories, options.OutputDirectory, output, error);
                    output.WriteLine();
                    output.WriteLine("Extraction complete to: " + options.OutputDirectory);
                }
            }
        }

        private static List<StfsEntry> ReadFileTable(BinaryReader reader, FileStream stfsFile, int fileTableBlockNum, int fileTableBlockCount)
        {
            List<StfsEntry> entries = new List<StfsEntry>();
            int entryIndex = 0;
            int currentBlock = fileTableBlockNum;
            int blocksRead = 0;

            while (blocksRead < fileTableBlockCount)
            {
                long blockOffset = BlockToAddress(currentBlock);

                for (int i = 0; i < EntriesPerBlock; i++)
                {
                    long entryOffset = blockOffset + (i * EntrySize);
                    if (entryOffset + EntrySize > stfsFile.Length)
                    {
                        break;
                    }

                    reader.BaseStream.Position = entryOffset;
                    byte[] entryData = reader.ReadBytes(EntrySize);
                    if (entryData.Length < EntrySize)
                    {
                        break;
                    }

                    int nameLen = entryData[0x28] & 0x3F;
                    if (nameLen == 0)
                    {
                        continue;
                    }

                    bool validName = true;
                    for (int k = 0; k < nameLen; k++)
                    {
                        if (entryData[k] < 0x20 || entryData[k] > 0x7E)
                        {
                            validName = false;
                            break;
                        }
                    }

                    if (!validName)
                    {
                        continue;
                    }

                    StfsEntry entry = new StfsEntry();
                    entry.Index = entryIndex;
                    entry.Name = Encoding.ASCII.GetString(entryData, 0, nameLen);
                    entry.IsDirectory = (entryData[0x28] & 0x80) != 0;
                    entry.IsConsecutive = (entryData[0x28] & 0x40) != 0;
                    entry.NumBlocks = ReadInt24LE(entryData[0x29], entryData[0x2A], entryData[0x2B]);
                    entry.FirstBlock = ReadInt24LE(entryData[0x2F], entryData[0x30], entryData[0x31]);

                    int pathIndicator = (entryData[0x32] << 8) | entryData[0x33];
                    entry.PathIndicator = pathIndicator == 0xFFFF ? -1 : pathIndicator;

                    entry.FileSize = ReadInt32BE(entryData[0x34], entryData[0x35], entryData[0x36], entryData[0x37]);

                    entries.Add(entry);
                    entryIndex++;
                }

                blocksRead++;
                if (blocksRead < fileTableBlockCount)
                {
                    int nextBlock = GetNextBlock(reader, currentBlock);
                    if (nextBlock == -1)
                    {
                        break;
                    }

                    currentBlock = nextBlock;
                }
            }

            return entries;
        }

        private static void ListEntries(List<StfsEntry> entries, Dictionary<int, StfsEntry> directories, TextWriter output)
        {
            foreach (StfsEntry entry in entries)
            {
                string relativePath = BuildRelativePath(entry, directories);

                if (entry.IsDirectory)
                {
                    output.WriteLine("  DIR:  " + relativePath);
                }
                else
                {
                    output.WriteLine("  FILE: " + relativePath + " (" + entry.FileSize + " bytes)");
                }
            }
        }

        private static void ExtractEntries(
            BinaryReader reader,
            FileStream stfsFile,
            List<StfsEntry> entries,
            Dictionary<int, StfsEntry> directories,
            string outputDirectory,
            TextWriter output,
            TextWriter error)
        {
            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            foreach (StfsEntry entry in entries)
            {
                string relativePath = BuildRelativePath(entry, directories);

                if (entry.IsDirectory)
                {
                    string dirPath = SafeCombine(outputDirectory, relativePath);
                    if (!Directory.Exists(dirPath))
                    {
                        Directory.CreateDirectory(dirPath);
                    }

                    output.WriteLine("  DIR:  " + relativePath);
                    continue;
                }

                string filePath = SafeCombine(outputDirectory, relativePath);
                string fileDir = Path.GetDirectoryName(filePath);
                if (!string.IsNullOrEmpty(fileDir) && !Directory.Exists(fileDir))
                {
                    Directory.CreateDirectory(fileDir);
                }

                output.WriteLine("  FILE: " + relativePath + " (" + entry.FileSize + " bytes)");

                using (FileStream outStream = File.Create(filePath))
                {
                    int remaining = entry.FileSize;
                    int currentBlock = entry.FirstBlock;
                    int blocksExtracted = 0;

                    while (remaining > 0 && blocksExtracted < entry.NumBlocks)
                    {
                        long blockOffset = BlockToAddress(currentBlock);

                        if (blockOffset + BlockSize > stfsFile.Length + BlockSize)
                        {
                            error.WriteLine(
                                "WARNING: Block " + currentBlock +
                                " offset 0x" + blockOffset.ToString("X") +
                                " exceeds file size for " + entry.Name);
                            break;
                        }

                        reader.BaseStream.Position = blockOffset;
                        int toRead = Math.Min(remaining, BlockSize);
                        byte[] data = reader.ReadBytes(toRead);

                        if (data.Length == 0)
                        {
                            error.WriteLine("WARNING: Could not read block " + currentBlock + " for " + entry.Name);
                            break;
                        }

                        outStream.Write(data, 0, data.Length);
                        remaining -= data.Length;
                        blocksExtracted++;

                        if (remaining > 0)
                        {
                            if (entry.IsConsecutive)
                            {
                                currentBlock++;
                            }
                            else
                            {
                                int nextBlock = GetNextBlock(reader, currentBlock);
                                if (nextBlock == -1)
                                {
                                    error.WriteLine("WARNING: Block chain ended early for " + entry.Name);
                                    break;
                                }

                                currentBlock = nextBlock;
                            }
                        }
                    }
                }
            }
        }

        private static string BuildRelativePath(StfsEntry entry, Dictionary<int, StfsEntry> directories)
        {
            List<string> parts = new List<string>();
            parts.Add(entry.Name);

            int pi = entry.PathIndicator;
            while (pi != -1 && directories.ContainsKey(pi))
            {
                parts.Insert(0, directories[pi].Name);
                pi = directories[pi].PathIndicator;
            }

            return string.Join(Path.DirectorySeparatorChar.ToString(), parts.ToArray());
        }

        private static string SafeCombine(string root, string relativePath)
        {
            string combined = Path.GetFullPath(Path.Combine(root, relativePath));
            string fullRoot = Path.GetFullPath(root);

            if (!fullRoot.EndsWith(Path.DirectorySeparatorChar.ToString()))
            {
                fullRoot += Path.DirectorySeparatorChar;
            }

            if (!combined.StartsWith(fullRoot, StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidDataException("Invalid package path escapes output directory: " + relativePath);
            }

            return combined;
        }

        private static int ComputeBackingDataBlockNumber(int blockNum)
        {
            int toReturn = (((blockNum + 0xAA) / 0xAA) << _shift) + blockNum;

            if (blockNum < 0xAA)
            {
                return toReturn;
            }

            if (blockNum < 0x70E4)
            {
                return toReturn + ((((blockNum + 0x70E4) / 0x70E4) << _shift));
            }

            return (1 << _shift) + (toReturn + ((((blockNum + 0x70E4) / 0x70E4) << _shift)));
        }

        private static long BlockToAddress(int blockNum)
        {
            return ((long)ComputeBackingDataBlockNumber(blockNum) << 0xC) + _firstHashTableAddress;
        }

        private static int ComputeLevel0BackingHashBlockNumber(int blockNum)
        {
            if (blockNum < 0xAA)
            {
                return 0;
            }

            int step0 = _shift == 0 ? 0xAB : 0xAC;
            int num = (blockNum / 0xAA) * step0;
            num += ((blockNum / 0x70E4) + 1) << _shift;

            if ((blockNum / 0x70E4) == 0)
            {
                return num;
            }

            return num + (1 << _shift);
        }

        private static int GetNextBlock(BinaryReader reader, int currentBlock)
        {
            int hashBlockNum = ComputeLevel0BackingHashBlockNumber(currentBlock);
            long hashAddr = ((long)hashBlockNum << 0xC) + _firstHashTableAddress;
            int recordIndex = currentBlock % 0xAA;
            long recordOffset = hashAddr + (recordIndex * 0x18);

            reader.BaseStream.Position = recordOffset + 0x14;
            reader.ReadByte(); // status

            byte[] nextBlockBytes = reader.ReadBytes(3);
            if (nextBlockBytes.Length < 3)
            {
                return -1;
            }

            int nextBlock = ReadInt24BE(nextBlockBytes);
            if (nextBlock >= 0xFFFFFF || nextBlock == 0xFFFFFE)
            {
                return -1;
            }

            return nextBlock;
        }

        private static int ReadInt24BE(byte[] b)
        {
            return ((int)b[0] << 16) | ((int)b[1] << 8) | b[2];
        }

        private static int ReadInt32BE(byte[] b)
        {
            return ((int)b[0] << 24) | ((int)b[1] << 16) | ((int)b[2] << 8) | b[3];
        }

        private static int ReadInt24LE(byte[] b)
        {
            return b[0] | (b[1] << 8) | (b[2] << 16);
        }

        private static int ReadInt24LE(byte b0, byte b1, byte b2)
        {
            return b0 | (b1 << 8) | (b2 << 16);
        }

        private static int ReadInt16LE(byte[] b)
        {
            return b[0] | (b[1] << 8);
        }

        private static int ReadInt32BE(byte b0, byte b1, byte b2, byte b3)
        {
            return ((int)b0 << 24) | ((int)b1 << 16) | ((int)b2 << 8) | b3;
        }

        private static StfsOptions ParseArgs(string[] args)
        {
            if (args == null || args.Length == 0)
            {
                throw new ArgumentException(
                    "Usage: ExtractStfs -Path <container> [-OutputDir <directory>] [-ListOnly]");
            }

            StfsOptions options = new StfsOptions();

            for (int i = 0; i < args.Length; i++)
            {
                string arg = args[i];

                if (string.Equals(arg, "-Path", StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(arg, "--path", StringComparison.OrdinalIgnoreCase))
                {
                    i++;
                    if (i >= args.Length) throw new ArgumentException("-Path requires a value.");
                    options.Path = args[i];
                }
                else if (string.Equals(arg, "-OutputDir", StringComparison.OrdinalIgnoreCase) ||
                         string.Equals(arg, "--outputdir", StringComparison.OrdinalIgnoreCase) ||
                         string.Equals(arg, "-o", StringComparison.OrdinalIgnoreCase))
                {
                    i++;
                    if (i >= args.Length) throw new ArgumentException("-OutputDir requires a value.");
                    options.OutputDirectory = args[i];
                }
                else if (string.Equals(arg, "-ListOnly", StringComparison.OrdinalIgnoreCase) ||
                         string.Equals(arg, "--listonly", StringComparison.OrdinalIgnoreCase) ||
                         string.Equals(arg, "-l", StringComparison.OrdinalIgnoreCase))
                {
                    options.ListOnly = true;
                }
                else if (!arg.StartsWith("-", StringComparison.Ordinal) && string.IsNullOrEmpty(options.Path))
                {
                    options.Path = arg;
                }
                else
                {
                    throw new ArgumentException("Unknown argument: " + arg);
                }
            }

            if (string.IsNullOrEmpty(options.Path))
            {
                throw new ArgumentException("-Path is required.");
            }

            if (!options.ListOnly && string.IsNullOrEmpty(options.OutputDirectory))
            {
                throw new ArgumentException("-OutputDir is required unless -ListOnly is specified.");
            }

            return options;
        }
    }
}
