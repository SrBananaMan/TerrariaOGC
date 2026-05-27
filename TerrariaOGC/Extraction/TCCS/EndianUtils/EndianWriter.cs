using System;
using System.IO;
using System.Text;

namespace TCCS.EndianUtils
{
    public class EndianWriter : System.IDisposable
    {
        public enum Endianness { Little, Big }

        private readonly Endianness _endian;
        private readonly BinaryWriter _writer;

        public Stream BaseStream { get { return _writer.BaseStream; } }

        public EndianWriter(Stream output) : this(output, Endianness.Little) { }

        public EndianWriter(Stream output, Endianness endian)
        {
            _writer = new BinaryWriter(output, Encoding.ASCII);
            _endian = endian;
        }

        public void Dispose() { _writer.Close(); }

        public void Write(byte[] data) { _writer.Write(data); }
        public void Write(byte value) { _writer.Write(value); }
        public void Write(sbyte value) { _writer.Write(value); }

        public void Write(short value) { Write(value, _endian); }
        public void Write(short value, Endianness endian)
        {
            byte[] b = new byte[2];
            if (endian == Endianness.Little) { b[0] = (byte)value; b[1] = (byte)(value >> 8); }
            else { b[0] = (byte)(value >> 8); b[1] = (byte)value; }
            _writer.Write(b);
        }

        public void Write(ushort value) { Write(value, _endian); }
        public void Write(ushort value, Endianness endian)
        {
            byte[] b = new byte[2];
            if (endian == Endianness.Little) { b[0] = (byte)value; b[1] = (byte)(value >> 8); }
            else { b[0] = (byte)(value >> 8); b[1] = (byte)value; }
            _writer.Write(b);
        }

        public void Write(int value) { Write(value, _endian); }
        public void Write(int value, Endianness endian)
        {
            byte[] b = new byte[4];
            if (endian == Endianness.Little)
            {
                b[0] = (byte)value; b[1] = (byte)(value >> 8);
                b[2] = (byte)(value >> 16); b[3] = (byte)(value >> 24);
            }
            else
            {
                b[0] = (byte)(value >> 24); b[1] = (byte)(value >> 16);
                b[2] = (byte)(value >> 8); b[3] = (byte)value;
            }
            _writer.Write(b);
        }

        public void Write(uint value) { Write(value, _endian); }
        public void Write(uint value, Endianness endian)
        {
            byte[] b = new byte[4];
            if (endian == Endianness.Little)
            {
                b[0] = (byte)value; b[1] = (byte)(value >> 8);
                b[2] = (byte)(value >> 16); b[3] = (byte)(value >> 24);
            }
            else
            {
                b[0] = (byte)(value >> 24); b[1] = (byte)(value >> 16);
                b[2] = (byte)(value >> 8); b[3] = (byte)value;
            }
            _writer.Write(b);
        }

        public void Write(long value) { Write(value, _endian); }
        public void Write(long value, Endianness endian)
        {
            byte[] b = new byte[8];
            if (endian == Endianness.Little)
            {
                b[0] = (byte)value; b[1] = (byte)(value >> 8);
                b[2] = (byte)(value >> 16); b[3] = (byte)(value >> 24);
                b[4] = (byte)(value >> 32); b[5] = (byte)(value >> 40);
                b[6] = (byte)(value >> 48); b[7] = (byte)(value >> 56);
            }
            else
            {
                b[0] = (byte)(value >> 56); b[1] = (byte)(value >> 48);
                b[2] = (byte)(value >> 40); b[3] = (byte)(value >> 32);
                b[4] = (byte)(value >> 24); b[5] = (byte)(value >> 16);
                b[6] = (byte)(value >> 8); b[7] = (byte)value;
            }
            _writer.Write(b);
        }

        public void Write(ulong value) { Write(value, _endian); }
        public void Write(ulong value, Endianness endian)
        {
            byte[] b = new byte[8];
            if (endian == Endianness.Little)
            {
                b[0] = (byte)value; b[1] = (byte)(value >> 8);
                b[2] = (byte)(value >> 16); b[3] = (byte)(value >> 24);
                b[4] = (byte)(value >> 32); b[5] = (byte)(value >> 40);
                b[6] = (byte)(value >> 48); b[7] = (byte)(value >> 56);
            }
            else
            {
                b[0] = (byte)(value >> 56); b[1] = (byte)(value >> 48);
                b[2] = (byte)(value >> 40); b[3] = (byte)(value >> 32);
                b[4] = (byte)(value >> 24); b[5] = (byte)(value >> 16);
                b[6] = (byte)(value >> 8); b[7] = (byte)value;
            }
            _writer.Write(b);
        }

        public void Write(float value) { Write(value, _endian); }
        public void Write(float value, Endianness endian)
        {
            byte[] b = BitConverter.GetBytes(value);
            if ((endian == Endianness.Little) != BitConverter.IsLittleEndian)
                Array.Reverse(b);
            _writer.Write(b);
        }
    }
}