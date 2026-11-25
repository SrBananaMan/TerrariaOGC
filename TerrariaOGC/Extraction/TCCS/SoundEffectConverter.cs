using System;
using System.Diagnostics;
using System.IO;

namespace TCCS
{
    internal static class SoundEffectConverter
    {
        public static void ConvertDirectory(string soundsDir, string toolsDir)
        {
            foreach (string path in Directory.GetFiles(soundsDir, "*.xnb", SearchOption.AllDirectories))
                ConvertFile(path, toolsDir);
        }

        private static void ConvertFile(string path, string toolsDir)
        {
            byte[] source = File.ReadAllBytes(path);
            using (var reader = new BinaryReader(new MemoryStream(source)))
            {
                if (reader.ReadUInt32() != 0x78424E58)
                    return;

                byte version = reader.ReadByte();
                byte flags = reader.ReadByte();
                if (version != 5 || (flags & 0xC0) != 0)
                    throw new InvalidDataException("Expected an uncompressed Xbox 360 sound effect: " + path);

                reader.ReadInt32(); // XNB length
                if (reader.ReadByte() != 1 ||
                    reader.ReadString() != "Microsoft.Xna.Framework.Content.SoundEffectReader")
                    throw new InvalidDataException("Unexpected sound effect reader table: " + path);

                reader.ReadInt32(); // Reader version
                if (reader.ReadByte() != 0 || reader.ReadByte() != 1)
                    throw new InvalidDataException("Unexpected sound effect object table: " + path);

                int formatOffset = (int)reader.BaseStream.Position;
                if (reader.ReadInt32() != 52 || ReadBigEndianUInt16(reader) != 0x166)
                    throw new InvalidDataException("Expected an Xbox 360 XMA2 sound effect: " + path);

                ushort channels = ReadBigEndianUInt16(reader);
                uint sampleRate = ReadBigEndianUInt32(reader);
                reader.BaseStream.Position = formatOffset + 4;
                byte[] format = reader.ReadBytes(52);
                // XMA2's WAVEFORMATEX and extension contain these big-endian fields.
                int offset = 0;
                foreach (int size in new[] { 2, 2, 4, 4, 2, 2, 2, 2, 4, 4, 4, 4, 4, 4, 4, 1, 1, 2 })
                {
                    Array.Reverse(format, offset, size);
                    offset += size;
                }

                int dataLength = reader.ReadInt32();
                if (dataLength <= 0 || dataLength != reader.BaseStream.Length - reader.BaseStream.Position - 12)
                    throw new InvalidDataException("Invalid sound effect data length: " + path);

                byte[] data = reader.ReadBytes(dataLength);
                uint loopStart = reader.ReadUInt32();
                uint loopLength = reader.ReadUInt32();
                uint duration = reader.ReadUInt32();
                byte[] pcm = Decode(path, toolsDir, format, data);
                WritePcm(path, source, formatOffset, channels, sampleRate, pcm, loopStart, loopLength, duration);
            }
        }

        private static byte[] Decode(string path, string toolsDir, byte[] format, byte[] data)
        {
            string ffmpeg = Path.Combine(toolsDir, "ffmpeg.exe");
            if (!File.Exists(ffmpeg))
                throw new FileNotFoundException("FFmpeg is required to convert Xbox 360 sound effects. Add ffmpeg.exe to " + toolsDir, ffmpeg);

            string temporary = path + "." + Guid.NewGuid().ToString("N");
            string wave = temporary + ".wav";
            string pcm = temporary + ".pcm";
            try
            {
                using (var writer = new BinaryWriter(File.Create(wave)))
                {
                    writer.Write(0x46464952); // RIFF
                    writer.Write(20 + format.Length + data.Length);
                    writer.Write(0x45564157); // WAVE
                    writer.Write(0x20746D66); // fmt
                    writer.Write(format.Length);
                    writer.Write(format);
                    writer.Write(0x61746164); // data
                    writer.Write(data.Length);
                    writer.Write(data);
                }

                var start = new ProcessStartInfo
                {
                    FileName = ffmpeg,
                    Arguments = $"-nostdin -v error -xerror -i \"{wave}\" -f s16le -c:a pcm_s16le \"{pcm}\"",
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    RedirectStandardError = true
                };
                using (var process = Process.Start(start))
                {
                    string error = process.StandardError.ReadToEnd();
                    process.WaitForExit();
                    if (process.ExitCode != 0)
                        throw new InvalidDataException("FFmpeg failed to decode " + path + Environment.NewLine + error);
                }

                return File.ReadAllBytes(pcm);
            }
            finally
            {
                File.Delete(wave);
                File.Delete(pcm);
            }
        }

        private static void WritePcm(string path, byte[] source, int formatOffset, ushort channels,
            uint sampleRate, byte[] pcm, uint loopStart, uint loopLength, uint duration)
        {
            ushort blockAlignment = checked((ushort)(channels * 2));
            if (blockAlignment == 0 || pcm.Length == 0 || pcm.Length % blockAlignment != 0)
                throw new InvalidDataException("Invalid decoded PCM data: " + path);

            // A full-length XMA2 loop can start after encoder padding that FFmpeg trims.
            uint sampleCount = (uint)(pcm.Length / blockAlignment);
            loopStart = loopLength >= sampleCount ? 0 : Math.Min(loopStart, sampleCount - 1);
            loopLength = Math.Min(loopLength, sampleCount - loopStart);

            source[3] = (byte)'w';
            string output = path + "." + Guid.NewGuid().ToString("N") + ".tmp";
            try
            {
                using (var writer = new BinaryWriter(File.Create(output)))
                {
                    writer.Write(source, 0, 6);
                    writer.Write(checked(formatOffset + 24 + pcm.Length + 12));
                    writer.Write(source, 10, formatOffset - 10);
                    writer.Write(16); // PCM format length
                    writer.Write((ushort)1);
                    writer.Write(channels);
                    writer.Write(sampleRate);
                    writer.Write(sampleRate * blockAlignment);
                    writer.Write(blockAlignment);
                    writer.Write((ushort)16);
                    writer.Write(pcm.Length);
                    writer.Write(pcm);
                    writer.Write(loopStart);
                    writer.Write(loopLength);
                    writer.Write(duration);
                }

                File.Replace(output, path, null);
            }
            finally
            {
                File.Delete(output);
            }
        }

        private static ushort ReadBigEndianUInt16(BinaryReader reader)
        {
            return (ushort)((reader.ReadByte() << 8) | reader.ReadByte());
        }

        private static uint ReadBigEndianUInt32(BinaryReader reader)
        {
            return ((uint)ReadBigEndianUInt16(reader) << 16) | ReadBigEndianUInt16(reader);
        }
    }
}
