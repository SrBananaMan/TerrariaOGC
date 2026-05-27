using System;
using System.IO;

namespace TCCS { 

    /// Simple WAV file reader for PCM WAV file reading compatible with .NET Framework 4.0.
    internal class SimpleWaveReader : IDisposable
    {
        private FileStream _fileStream;
        private BinaryReader _reader;
        private long _dataStartPosition;
        private long _dataLength;

        public int SampleRate { get; private set; }
        public int Channels { get; private set; }
        public int BitsPerSample { get; private set; }
        public int BlockAlign { get; private set; }

        public SimpleWaveReader(string fileName)
        {
            _fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
            _reader = new BinaryReader(_fileStream);

            ReadWaveHeader();
        }

        private void ReadWaveHeader()
        {
            // Read RIFF header
            string riff = new string(_reader.ReadChars(4));
            if (riff != "RIFF")
                throw new FormatException("Not a valid WAV file - missing RIFF header");

            _reader.ReadInt32(); // File size - 8

            string wave = new string(_reader.ReadChars(4));
            if (wave != "WAVE")
                throw new FormatException("Not a valid WAV file - missing WAVE header");

            // Read fmt chunk
            while (true)
            {
                string chunkId = new string(_reader.ReadChars(4));
                int chunkSize = _reader.ReadInt32();

                if (chunkId == "fmt ")
                {
                    int audioFormat = _reader.ReadInt16();
                    Channels = _reader.ReadInt16();
                    SampleRate = _reader.ReadInt32();
                    _reader.ReadInt32(); // Byte rate
                    BlockAlign = _reader.ReadInt16();
                    BitsPerSample = _reader.ReadInt16();

                    // Skip any extra format bytes
                    int extraSize = chunkSize - 16;
                    if (extraSize > 0)
                        _reader.ReadBytes(extraSize);
                }
                else if (chunkId == "data")
                {
                    _dataLength = chunkSize;
                    _dataStartPosition = _fileStream.Position;
                    break;
                }
                else
                {
                    // Skip unknown chunk
                    _reader.ReadBytes(chunkSize);
                }
            }
        }

        public int Read(byte[] buffer, int offset, int count)
        {
            if (_fileStream.Position >= _dataStartPosition + _dataLength)
                return 0;

            long remaining = _dataStartPosition + _dataLength - _fileStream.Position;
            int toRead = (int)Math.Min(count, remaining);

            int bytesRead = _reader.Read(buffer, offset, toRead);
            return bytesRead;
        }

        public void Dispose()
        {
            if (_reader != null)
            {
                _reader.Close();
                _reader = null;
            }
            if (_fileStream != null)
            {
                _fileStream.Close();
                _fileStream = null;
            }
        }
    }
}
