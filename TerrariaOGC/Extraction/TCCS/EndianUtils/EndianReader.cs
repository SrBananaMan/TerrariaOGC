using System;
using System.IO;
using System.Text;

namespace TCCS.EndianUtils
{
    public class EndianReader : System.IDisposable
    {
        public enum Endianness { Little, Big }

        private readonly Endianness _endian;
        private readonly BinaryReader _reader;

        public Stream BaseStream { get { return _reader.BaseStream; } }

        public EndianReader(Stream input) : this(input, Endianness.Little) { }

        public EndianReader(Stream input, Endianness endian)
        {
            _reader = new BinaryReader(input, Encoding.ASCII);
            _endian = endian;
        }

        public void Dispose() { _reader.Close(); }

        public byte ReadByte() { return _reader.ReadByte(); }
        public byte[] ReadBytes(int count) { return _reader.ReadBytes(count); }
        public char[] ReadChars(int count) { return _reader.ReadChars(count); }
        public int PeekChar() { return _reader.PeekChar(); }
        public char ReadChar() { return _reader.ReadChar(); }

        public short ReadInt16() { return ReadInt16(_endian); }
        public short ReadInt16(Endianness endian)
        {
            byte[] b = Handle(2, endian);
            return (short)(b[0] | (b[1] << 8));
        }

        public ushort ReadUInt16() { return ReadUInt16(_endian); }
        public ushort ReadUInt16(Endianness endian)
        {
            byte[] b = Handle(2, endian);
            return (ushort)(b[0] | (b[1] << 8));
        }

        public int ReadInt32() { return ReadInt32(_endian); }
        public int ReadInt32(Endianness endian)
        {
            byte[] b = Handle(4, endian);
            return b[0] | (b[1] << 8) | (b[2] << 16) | (b[3] << 24);
        }

        public uint ReadUInt32() { return ReadUInt32(_endian); }
        public uint ReadUInt32(Endianness endian)
        {
            byte[] b = Handle(4, endian);
            return (uint)(b[0] | (b[1] << 8) | (b[2] << 16) | (b[3] << 24));
        }

        public long ReadInt64() { return ReadInt64(_endian); }
        public long ReadInt64(Endianness endian)
        {
            byte[] b = Handle(8, endian);
            return (long)b[0] | ((long)b[1] << 8) | ((long)b[2] << 16) | ((long)b[3] << 24)
                 | ((long)b[4] << 32) | ((long)b[5] << 40) | ((long)b[6] << 48) | ((long)b[7] << 56);
        }

        public ulong ReadUInt64() { return ReadUInt64(_endian); }
        public ulong ReadUInt64(Endianness endian)
        {
            byte[] b = Handle(8, endian);
            return (ulong)b[0] | ((ulong)b[1] << 8) | ((ulong)b[2] << 16) | ((ulong)b[3] << 24)
                 | ((ulong)b[4] << 32) | ((ulong)b[5] << 40) | ((ulong)b[6] << 48) | ((ulong)b[7] << 56);
        }

        public float ReadSingle() { return ReadSingle(_endian); }
        public float ReadSingle(Endianness endian) { return BitConverter.ToSingle(Handle(4, endian), 0); }

        private byte[] Handle(int count, Endianness endian)
        {
            byte[] bytes = _reader.ReadBytes(count);
            if ((endian == Endianness.Little) != BitConverter.IsLittleEndian)
                Array.Reverse(bytes);
            return bytes;
        }
    }
}