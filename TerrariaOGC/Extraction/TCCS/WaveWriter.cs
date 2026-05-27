using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using TCCS.EndianUtils;
using TCCS.Handlers;
using static TCCS.Handlers.XWBHandler;

namespace TCCS
{
    public class WaveWriter
    {
        private const uint SampleRate = 44100;
        private const ushort ChannelCount = 2;

        private readonly ushort _blockAlignment;
        private readonly string _toolsDir;

        public int HeaderSize = 16;
        public int XMA2Size = 34;
        public int ExtSize = 22;
        public int? DpdsSize = null;
        public int? SeekSize = null;

        public uint ExtChannelMask;
        public uint[] Seek = new uint[0];
        public ushort ExtValidBitRate;
        public ushort? HSize = null;

        public XMAData Parameters = new XMAData();
        public Guid ExtSubfmt;
        private SimpleWaveReader WaveData;
        private WaveFormat Format;

        public byte[] Header, Data, Dpds = new byte[0];
        public byte[] ExtSubfmtBytes, Remainder, ExtRemainder;
        private byte[] SampleBufferA;
        private short[] SampleBufferP;
        private readonly byte[] TempBuffer;
        public byte[] RIFF = Encoding.ASCII.GetBytes("WAVE");

        private readonly int[] AdaptionTable =
        {
            230, 230, 230, 230,
            307, 409, 512, 614,
            768, 614, 512, 409,
            307, 230, 230, 230,
        };

        public WaveWriter(WaveFormat waveFormat, string waveName, byte[] waveHeader,
            MetaData waveMeta, byte[] waveData, byte[] waveDpds, uint[] waveSeek,
            string toolsDir, EndianReader.Endianness endian)
        {
            _blockAlignment = TccsConverter.BlockSetting;
            _toolsDir = toolsDir;

            SampleBufferA = new byte[_blockAlignment];
            SampleBufferP = new short[(_blockAlignment * 2) - 24];
            TempBuffer = new byte[SampleBufferP.Length * 2];

            Format = waveFormat;
            Header = waveHeader;
            Data = waveData;
            Dpds = waveDpds ?? new byte[0];
            Seek = waveSeek ?? new uint[0];

            var entryDetails = new MemoryStream(Header);
            var entryReader = new EndianReader(entryDetails, endian);

            if (Header.Length >= HeaderSize + 2)
            {
                entryReader.BaseStream.Position = 0x10;
                HSize = entryReader.ReadUInt16();
                HeaderSize += 2;

                if (Format.Encoding == EncodingType.XMA2)
                {
                    if (HSize != XMA2Size) throw new Exception("Unknown Size");

                    Parameters.XMANumStreams = entryReader.ReadUInt16();
                    Parameters.XMAChannelMask = entryReader.ReadUInt32();
                    Parameters.XMASamplesEncoded = entryReader.ReadUInt32();
                    Parameters.XMABytesPBlock = entryReader.ReadUInt32();
                    Parameters.XMAPlayStart = entryReader.ReadUInt32();
                    Parameters.XMAPlayLength = entryReader.ReadUInt32();
                    Parameters.XMALoopStart = entryReader.ReadUInt32();
                    Parameters.XMALoopLength = entryReader.ReadUInt32();
                    Parameters.XMALoopCount = entryReader.ReadByte();
                    Parameters.XMAEncoderVer = entryReader.ReadByte();
                    Parameters.XMABlockCount = entryReader.ReadUInt16();

                    HeaderSize += XMA2Size;
                }
                else if (Format.Encoding == EncodingType.Extensible)
                {
                    if (HSize < ExtSize) throw new Exception("Invalid Size");

                    ExtValidBitRate = entryReader.ReadUInt16();
                    ExtChannelMask = entryReader.ReadUInt32();
                    ExtSubfmtBytes = entryReader.ReadBytes(16);
                    ExtSubfmt = new Guid(ExtSubfmtBytes);
                    HeaderSize += ExtSize;

                    if (HSize > ExtSize)
                    {
                        ExtRemainder = entryReader.ReadBytes(HSize.Value - ExtSize);
                        HeaderSize += HSize.Value - ExtSize;
                        throw new Exception("Too many bytes");
                    }
                }

                long remaining = entryReader.BaseStream.Length - entryReader.BaseStream.Position;
                Remainder = entryReader.ReadBytes((int)remaining);
                if (Remainder.Length > 0) HeaderSize += Remainder.Length;
            }

            if (HeaderSize != Header.Length)
                throw new Exception("Size Mismatch");
        }

        public void Write(string songName, string directory)
        {
            var entryStream = new MemoryStream();
            var entryWriter = new EndianWriter(entryStream, EndianWriter.Endianness.Little);

            entryWriter.Write((ushort)Format.Encoding);
            entryWriter.Write((ushort)Format.Channels);
            entryWriter.Write(Format.SampleRate);
            entryWriter.Write(Format.AvgBytesPerSecond);
            entryWriter.Write((ushort)Format.BlockAlignment);
            entryWriter.Write((ushort)Format.BitDepth);

            if (HSize != null)
            {
                entryWriter.Write(HSize.Value);

                if (Format.Encoding == EncodingType.XMA2)
                {
                    if (Format.Channels == 1 && Parameters.XMAChannelMask == 1)
                        Parameters.XMAChannelMask = 0;

                    entryWriter.Write(Parameters.XMANumStreams);
                    entryWriter.Write(Parameters.XMAChannelMask);
                    entryWriter.Write(Parameters.XMASamplesEncoded);
                    entryWriter.Write(Parameters.XMABytesPBlock);
                    entryWriter.Write(Parameters.XMAPlayStart);
                    entryWriter.Write(Parameters.XMAPlayLength);
                    entryWriter.Write(Parameters.XMALoopStart);
                    entryWriter.Write(Parameters.XMALoopLength);
                    entryWriter.Write(Parameters.XMALoopCount);
                    entryWriter.Write(Parameters.XMAEncoderVer);
                    entryWriter.Write(Parameters.XMABlockCount);
                }
                else if (Format.Encoding == EncodingType.Extensible)
                {
                    entryWriter.Write(ExtValidBitRate);
                    entryWriter.Write(ExtChannelMask);
                    entryWriter.Write(ExtSubfmt.ToByteArray());
                    if (ExtRemainder != null && ExtRemainder.Length > 0)
                        entryWriter.Write(ExtRemainder);
                }

                if (Remainder != null && Remainder.Length > 0)
                    entryWriter.Write(Remainder);
            }
            Header = entryStream.ToArray();

            if (Dpds != null && Dpds.Length > 0) DpdsSize = Dpds.Length;
            if (Seek != null && Seek.Length > 0) SeekSize = Seek.Length;

            var waveStream = new MemoryStream();
            var streamWriter = new EndianWriter(waveStream, EndianWriter.Endianness.Little);

            if (Format.Encoding == EncodingType.WMAudio2 || Format.Encoding == EncodingType.WMAudio3)
                RIFF = Encoding.ASCII.GetBytes("XWMA");

            int fullSize = 20 + Header.Length + Data.Length;
            if (DpdsSize != null) fullSize += 8 + DpdsSize.Value;

            streamWriter.Write(Encoding.ASCII.GetBytes("RIFF"));
            streamWriter.Write((uint)fullSize);
            streamWriter.Write(RIFF);
            WriteChunk(streamWriter, Encoding.ASCII.GetBytes("fmt "), Header);

            if (Dpds != null && Dpds.Length > 0)
                WriteChunk(streamWriter, Encoding.ASCII.GetBytes("dpds"), Dpds);

            WriteChunk(streamWriter, Encoding.ASCII.GetBytes("data"), Data);

            // Sanitize the song name to remove illegal characters
            string safeSongName = SanitizeFileName(songName);
            string baseName = Path.Combine(directory, safeSongName);
            string extension = "O.wav";

            if (Format.Encoding == EncodingType.XMA2)
                extension = "O.xma";
            else if (Format.Encoding == EncodingType.WMAudio2 || Format.Encoding == EncodingType.WMAudio3)
                extension = "O.xwma";

            string target = baseName + extension;

            using (var waveFile = new FileStream(target, FileMode.Create, FileAccess.Write))
                waveStream.WriteTo(waveFile);

            if (Format.Encoding == EncodingType.XMA2)
            {
                RunTool("xma2encode.exe",
                    string.Format("{0} /DecodeToPCM {1}",
                        "\"" + target + "\"",
                        "\"" + target.Substring(0, target.Length - 4) + ".wav\""));
                File.Delete(target);
            }
            else if (Format.Encoding == EncodingType.WMAudio2 || Format.Encoding == EncodingType.WMAudio3)
            {
                RunTool("xWMAEncode.exe",
                    string.Format("{0} {1}",
                        "\"" + target + "\"",
                        "\"" + target.Substring(0, target.Length - 5) + ".wav\""));
                File.Delete(target);
            }

            string intermediateWav = baseName + "O.wav";
            WaveData = new SimpleWaveReader(intermediateWav);
            using (var writer = new BinaryWriter(File.OpenWrite(baseName + ".wav")))
            {
                ConvertAndWrite(WaveData, writer);
                WaveData.Dispose();
            }
            File.Delete(intermediateWav);
        }

        private static string SanitizeFileName(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                return "untitled";

            // First check if the filename is already valid - if so, return it as-is
            // This preserves original names like "Music_1", "Music_Title", etc.
            if (IsValidFileName(fileName))
                return fileName;

            // Get invalid characters for filenames
            char[] invalidChars = Path.GetInvalidFileNameChars();

            // Replace invalid characters with underscore
            string sanitized = fileName;
            foreach (char c in invalidChars)
            {
                sanitized = sanitized.Replace(c, '_');
            }

            // Also remove/replace some other problematic characters
            sanitized = sanitized.Replace(':', '_');
            sanitized = sanitized.Replace('/', '_');
            sanitized = sanitized.Replace('\\', '_');

            // Trim whitespace and dots from start/end (Windows doesn't like files ending with dots)
            sanitized = sanitized.Trim(' ', '.');

            // Limit length to avoid MAX_PATH issues (leave room for directory path and extension)
            if (sanitized.Length > 100)
                sanitized = sanitized.Substring(0, 100);

            // If empty after sanitization, use default name
            if (string.IsNullOrEmpty(sanitized))
                sanitized = "untitled";

            return sanitized;
        }

        private static bool IsValidFileName(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                return false;

            // Check for invalid characters
            char[] invalidChars = Path.GetInvalidFileNameChars();
            if (fileName.IndexOfAny(invalidChars) >= 0)
                return false;

            // Check for other problematic characters
            if (fileName.Contains(":") || fileName.Contains("/") || fileName.Contains("\\"))
                return false;

            // Check if it starts/ends with whitespace or dots
            if (fileName != fileName.Trim(' ', '.'))
                return false;

            // Check length (reasonable limit)
            if (fileName.Length > 100)
                return false;

            return true;
        }

        private void RunTool(string exe, string args)
        {
            var info = new ProcessStartInfo
            {
                FileName = Path.Combine(_toolsDir, exe),
                Arguments = args,
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true
            };
            using (var p = Process.Start(info))
                p.WaitForExit();
        }

        private void ConvertAndWrite(SimpleWaveReader waveData, BinaryWriter writer)
        {
            long start = writer.BaseStream.Position;
            int factData = 0;
            int tempIdx, bytesRead;
            ushort samplesPerBlock = (ushort)(((_blockAlignment - 7 * ChannelCount) * 8 / (4 * ChannelCount)) + 2);
            uint dataRate = SampleRate * _blockAlignment / samplesPerBlock;

            writer.BaseStream.Position += 0x5A;
            while ((bytesRead = waveData.Read(TempBuffer, 0, TempBuffer.Length)) > 0)
            {
                factData += bytesRead;
                tempIdx = 0;
                for (int i = 0; i < SampleBufferP.Length; i++)
                {
                    SampleBufferP[i] = TempBuffer[tempIdx++];
                    SampleBufferP[i] += (short)(TempBuffer[tempIdx++] << 8);
                }
                EncodeBlock(SampleBufferP, ref SampleBufferA);
                for (int i = 0; i < _blockAlignment; i++)
                    writer.Write(SampleBufferA[i]);
            }

            long end = writer.BaseStream.Position;
            factData /= 4;

            writer.BaseStream.Position = start;

            int blocks = factData / samplesPerBlock;
            int sampsInLastBlock = factData % samplesPerBlock;
            if (sampsInLastBlock != 0) blocks++;

            uint dataSize = (uint)(blocks * _blockAlignment);
            uint fileSize = 82 + dataSize;

            writer.Write(Encoding.ASCII.GetBytes("RIFF"));
            writer.Write(fileSize);
            writer.Write(Encoding.ASCII.GetBytes("WAVE"));
            writer.Write(Encoding.ASCII.GetBytes("fmt "));
            writer.Write(50);
            writer.Write((ushort)2);
            writer.Write(ChannelCount);
            writer.Write(SampleRate);
            writer.Write(dataRate);
            writer.Write(_blockAlignment);
            writer.Write((ushort)4);
            writer.Write((ushort)32);
            writer.Write(samplesPerBlock);
            writer.Write((ushort)ADPCMCoEfficients.Length);

            for (int i = 0; i < ADPCMCoEfficients.Length; i++)
            {
                writer.Write((short)ADPCMCoEfficients[i].X);
                writer.Write((short)ADPCMCoEfficients[i].Y);
            }

            writer.Write(Encoding.ASCII.GetBytes("fact"));
            writer.Write((uint)4);
            writer.Write((uint)factData);
            writer.Write(Encoding.ASCII.GetBytes("data"));
            writer.Write(dataSize);

            writer.BaseStream.Position = end;
        }

        public static void WriteChunk(EndianWriter writer, byte[] name, byte[] data)
        {
            writer.Write(name);
            writer.Write((uint)data.Length);
            writer.Write(data);
        }

        public void EncodeBlock(short[] decoded, ref byte[] encoded)
        {
            int enc = 0, dec = 0;
            int half = decoded.Length / 2;
            var pred1 = new short[half - 4];
            var pred2 = new short[half - 4];

            var states = new State[] { new State(), new State() };

            for (int i = 0; i < half - 4; i++)
            {
                pred1[i] = decoded[2 * i];
                pred2[i] = decoded[2 * i + 1];
            }

            int bestIdx1 = GetBestPredictorIndex(pred1, ref states[0]);
            int bestIdx2 = GetBestPredictorIndex(pred2, ref states[1]);

            states[0].CoEff1 = ADPCMCoEfficients[bestIdx1].X;
            states[0].CoEff2 = ADPCMCoEfficients[bestIdx1].Y;
            states[1].CoEff1 = ADPCMCoEfficients[bestIdx2].X;
            states[1].CoEff2 = ADPCMCoEfficients[bestIdx2].Y;

            encoded[enc++] = (byte)bestIdx1;
            encoded[enc++] = (byte)bestIdx2;
            encoded[enc++] = (byte)(states[0].Delta & 0xff);
            encoded[enc++] = (byte)(states[0].Delta >> 8);
            encoded[enc++] = (byte)(states[1].Delta & 0xff);
            encoded[enc++] = (byte)(states[1].Delta >> 8);

            states[0].Sample2 = decoded[dec++];
            states[1].Sample2 = decoded[dec++];
            states[0].Sample1 = decoded[dec++];
            states[1].Sample1 = decoded[dec++];

            encoded[enc++] = (byte)(states[0].Sample1 & 0xff);
            encoded[enc++] = (byte)(states[0].Sample1 >> 8);
            encoded[enc++] = (byte)(states[1].Sample1 & 0xff);
            encoded[enc++] = (byte)(states[1].Sample1 >> 8);
            encoded[enc++] = (byte)(states[0].Sample2 & 0xff);
            encoded[enc++] = (byte)(states[0].Sample2 >> 8);
            encoded[enc++] = (byte)(states[1].Sample2 & 0xff);
            encoded[enc++] = (byte)(states[1].Sample2 >> 8);

            while (enc < encoded.Length)
            {
                byte r1 = EncodeSample(decoded[dec++], ref states[0]);
                byte r2 = EncodeSample(decoded[dec++], ref states[1]);
                encoded[enc++] = (byte)((r1 << 4) | r2);
            }
        }

        private byte EncodeSample(short sample, ref State adpcm)
        {
            int predictor = (adpcm.Sample1 * adpcm.CoEff1 + adpcm.Sample2 * adpcm.CoEff2) >> 8;
            int remainder = sample - predictor;
            int bias = adpcm.Delta / 2;
            if (remainder < 0) bias = -bias;

            remainder = (remainder + bias) / adpcm.Delta;
            remainder = Math.Max(-8, Math.Min(7, remainder)) & 0xf;

            predictor += ((remainder & 0x8) != 0 ? remainder - 0x10 : remainder) * adpcm.Delta;
            adpcm.Sample2 = adpcm.Sample1;
            adpcm.Sample1 = (short)Math.Max(short.MinValue, Math.Min(short.MaxValue, predictor));
            adpcm.Delta = (AdaptionTable[remainder] * adpcm.Delta) >> 8;
            if (adpcm.Delta < 16) adpcm.Delta = 16;

            return (byte)remainder;
        }

        private static int GetBestPredictorIndex(short[] samples, ref State adpcm)
        {
            int bestIdx = 0, bestErr = int.MaxValue;

            for (int p = 0; p < ADPCMCoEfficients.Length; p++)
            {
                int c1 = ADPCMCoEfficients[p].X;
                int c2 = ADPCMCoEfficients[p].Y;
                int err = 0;

                for (int i = 2; i < samples.Length; i++)
                    err += Math.Abs(samples[i] - ((c1 * samples[i - 1] + c2 * samples[i - 2]) >> 8));

                err /= 4 * samples.Length;

                if (err < bestErr) { bestErr = err; bestIdx = p; }
                if (err == 0) break;
            }

            if (bestErr < 16) bestErr = 16;
            adpcm.Delta = bestErr;
            return bestIdx;
        }
    }

    internal struct State
    {
        internal int Delta, CoEff1, CoEff2;
        internal short Sample1, Sample2;
    }
}