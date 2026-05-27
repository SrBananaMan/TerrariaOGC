using System;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TCCS.EndianUtils;

namespace TCCS.Handlers
{
    public class XSBHandler : System.IDisposable
    {
        private readonly EndianReader _reader;
        private static readonly byte[] LittleMagic = Encoding.ASCII.GetBytes("SDBK");
        private EndianReader.Endianness _endian;

        public string[] Names = new string[0];

        public XSBHandler(Stream stream)
        {
            _reader = new EndianReader(stream);
            _endian = EndianReader.Endianness.Little;
            Read();
        }

        public void Dispose() => _reader.Dispose();

        private void Read()
        {
            byte[] sig = _reader.ReadBytes(LittleMagic.Length);
            bool match = true;
            for (int i = 0; i < LittleMagic.Length; i++)
                if (sig[i] != LittleMagic[i]) { match = false; break; }

            if (!match) _endian = EndianReader.Endianness.Big;

            _reader.ReadUInt16(_endian); // Version
            _reader.ReadUInt16(_endian); // Header Version
            _reader.ReadUInt16(_endian); // CRC
            _reader.ReadUInt32(_endian); // LowBuild
            _reader.ReadUInt32(_endian); // HighBuild
            _reader.ReadByte();          // Platform ID

            uint cueSet1Count = _reader.ReadUInt16(_endian);
            uint cueSet2Count = _reader.ReadUInt16(_endian);
            _reader.ReadUInt16(_endian); // Unknown
            _reader.ReadUInt16(_endian); // Cue Name Hash Count
            _reader.ReadByte();          // Wave Banks
            _reader.ReadUInt16(_endian); // Sounds

            uint cueNamesLen = _reader.ReadUInt32(_endian);

            int cueSet1Offset = _reader.ReadInt32(_endian);
            int cueSet2Offset = _reader.ReadInt32(_endian);
            int cueNamesOffset = _reader.ReadInt32(_endian);
            _reader.ReadInt32(_endian);
            _reader.ReadInt32(_endian);
            _reader.ReadInt32(_endian);
            _reader.ReadInt32(_endian);

            uint totalCues = cueSet1Count + cueSet2Count;
            if (cueNamesLen > 0 && totalCues > 0)
            {
                _reader.BaseStream.Seek(cueNamesOffset, SeekOrigin.Begin);

                Names = new string[totalCues];
                for (int i = 0; i < totalCues; i++)
                {
                    List<byte> nameBytes = new List<byte>();
                    byte b;
                    while ((b = _reader.ReadByte()) != 0)
                    {
                        nameBytes.Add(b);
                    }
                    Names[i] = Encoding.ASCII.GetString(nameBytes.ToArray());
                }
            }
        }
    }
}