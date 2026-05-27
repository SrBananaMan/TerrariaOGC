using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ExtractIso
{
    internal sealed class XisoEntry
    {
        public ushort LeftOffsetDwords { get; set; }
        public ushort RightOffsetDwords { get; set; }
        public uint StartSector { get; set; }
        public uint FileSize { get; set; }
        public byte Attributes { get; set; }
        public string FileName { get; set; } = string.Empty;

        public bool IsDirectory => (Attributes & 0x10) != 0;
    }

    internal static class XisoConstants
    {
        public const long HeaderOffset = 0x10000L;
        public const long SectorSize = 2048;
        public const long FileTimeSize = 8;
        public const long UnusedSize = 0x7C8;
        public const long BufferSize = 0x00200000;
        public const ushort PadShort = 0xFFFF;

        public static readonly long[] SeekOffsets =
        {
            0,
            0x0FD90000L,
            0x02080000L,
            0x18300000L
        };
    }

    public static class ExtractIsoApp
    {
        public static int Run(string isoPath, string outputDirectory)
        {
            try
            {
                new XisoTool().Extract(isoPath, outputDirectory);
                return 0;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Extraction failed: " + ex.Message);
                return 1;
            }
        }
    }

    internal sealed class XisoTool
    {
        private readonly byte[] _buffer = new byte[XisoConstants.BufferSize];
        private long _seekOffset;

        public void Extract(string isoPath, string outputDirectory)
        {
            using (var xiso = File.Open(isoPath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                FindHeader(xiso, Path.GetFileName(isoPath), out uint rootSector, out uint rootSize);

                if (rootSector == 0 && rootSize == 0) return;

                Directory.CreateDirectory(outputDirectory);

                long rootStart = rootSector * XisoConstants.SectorSize + _seekOffset;
                TraverseDirectory(xiso, rootStart, outputDirectory, new HashSet<long>());
            }
        }

        private void FindHeader(FileStream xiso, string name, out uint rootSector, out uint rootSize)
        {
            foreach (long offset in XisoConstants.SeekOffsets)
            {
                xiso.Position = XisoConstants.HeaderOffset + offset;

                if (Encoding.ASCII.GetString(ReadExact(xiso, 20)) == "MICROSOFT*XBOX*MEDIA")
                {
                    _seekOffset = offset;
                    rootSector = ReadUInt32(xiso);
                    rootSize = ReadUInt32(xiso);
                    return;
                }
            }

            throw new InvalidDataException(name + " is not a valid Xbox ISO.");
        }

        private void TraverseDirectory(FileStream xiso, long dirStart, string outputDir, HashSet<long> visited)
        {
            ProcessNode(xiso, dirStart, 0, outputDir, visited);
        }

        private void ProcessNode(FileStream xiso, long dirStart, ushort offsetDwords, string outputDir, HashSet<long> visited)
        {
            long pos = dirStart + offsetDwords * 4L;
            if (!visited.Add(pos)) return;

            xiso.Position = pos;
            var entry = ReadEntry(xiso);
            if (entry == null) return;

            if (entry.LeftOffsetDwords != 0) ProcessNode(xiso, dirStart, entry.LeftOffsetDwords, outputDir, visited);

            ProcessEntry(xiso, entry, outputDir, visited);

            if (entry.RightOffsetDwords != 0) ProcessNode(xiso, dirStart, entry.RightOffsetDwords, outputDir, visited);
        }

        private void ProcessEntry(FileStream xiso, XisoEntry entry, string outputDir, HashSet<long> visited)
        {
            string entryPath = Path.Combine(outputDir, entry.FileName);

            if (entry.IsDirectory)
            {
                Directory.CreateDirectory(entryPath);

                if (entry.FileSize > 0)
                {
                    long subStart = entry.StartSector * XisoConstants.SectorSize + _seekOffset;
                    TraverseDirectory(xiso, subStart, entryPath, visited);
                }
            }
            else
            {
                ExtractFile(xiso, entry, entryPath);
            }
        }

        private void ExtractFile(FileStream xiso, XisoEntry entry, string outPath)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(outPath));
            xiso.Position = entry.StartSector * XisoConstants.SectorSize + _seekOffset;

            using (var output = File.Open(outPath, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                uint remaining = entry.FileSize;
                while (remaining > 0)
                {
                    int toRead = (int)Math.Min((uint)_buffer.Length, remaining);
                    int read = xiso.Read(_buffer, 0, toRead);
                    if (read <= 0) break;

                    output.Write(_buffer, 0, read);
                    remaining -= (uint)read;
                }
            }
        }

        private static XisoEntry ReadEntry(FileStream xiso)
        {
            ushort left = ReadUInt16(xiso);
            if (left == XisoConstants.PadShort) return null;

            ushort right = ReadUInt16(xiso);
            uint startSector = ReadUInt32(xiso);
            uint fileSize = ReadUInt32(xiso);
            int attributes = xiso.ReadByte();
            int nameLength = xiso.ReadByte();

            if (attributes < 0 || nameLength < 0)
                throw new EndOfStreamException("Unexpected end of file reading directory entry.");

            string fileName = Encoding.GetEncoding(28591).GetString(ReadExact(xiso, nameLength));
            ValidateFileName(fileName);

            return new XisoEntry
            {
                LeftOffsetDwords = left,
                RightOffsetDwords = right,
                StartSector = startSector,
                FileSize = fileSize,
                Attributes = (byte)attributes,
                FileName = fileName
            };
        }

        private static void ValidateFileName(string name)
        {
            if (name == "." || name == ".." || name.IndexOfAny(new[] { '/', '\\' }) >= 0)
                throw new InvalidDataException("Invalid filename: " + name);

            foreach (char c in Path.GetInvalidFileNameChars())
                if (name.IndexOf(c) >= 0)
                    throw new InvalidDataException("Invalid filename: " + name);
        }

        private static byte[] ReadExact(Stream stream, int count)
        {
            byte[] buf = new byte[count];
            int offset = 0;
            while (offset < count)
            {
                int read = stream.Read(buf, offset, count - offset);
                if (read <= 0) throw new EndOfStreamException("Unexpected end of file.");
                offset += read;
            }
            return buf;
        }

        private static ushort ReadUInt16(Stream s)
        {
            byte[] b = ReadExact(s, 2);
            return (ushort)(b[0] | (b[1] << 8));
        }

        private static uint ReadUInt32(Stream s)
        {
            byte[] b = ReadExact(s, 4);
            return (uint)(b[0] | (b[1] << 8) | (b[2] << 16) | (b[3] << 24));
        }
    }
}