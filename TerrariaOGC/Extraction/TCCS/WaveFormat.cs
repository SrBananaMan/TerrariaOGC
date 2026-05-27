using TCCS.Handlers;
using TCCS.Handlers;

namespace TCCS
{
    public class WaveFormat
    {
        protected XWBHandler.EncodingType EncodingTag;
        protected short ChannelCount;
        protected int SamplesPerSec;
        protected int AvgBytesPerSec;
        protected short Alignment;
        protected short BitsPerSample;
        protected byte[] ExtraHeader;

        public WaveFormat() : this(44100, 16, 2) { }

        public WaveFormat(int sampleRate, int bitDepth, int channels)
        {
            if (channels < 1) throw new System.ArgumentOutOfRangeException("channels");
            EncodingTag = bitDepth < 32 ? XWBHandler.EncodingType.PCM : XWBHandler.EncodingType.IEEE;
            ChannelCount = (short)channels;
            SamplesPerSec = sampleRate;
            Alignment = (short)(channels * (bitDepth / 8));
            AvgBytesPerSec = SamplesPerSec * Alignment;
            BitsPerSample = (short)bitDepth;
            ExtraHeader = new byte[0];
        }

        public static WaveFormat SetupNonPCM(XWBHandler.EncodingType encoding, int sampleRate, int channels,
            int byteRate, int blockAlignment, int bitDepth, byte[] extraHeader)
        {
            return new WaveFormat
            {
                EncodingTag = encoding,
                ChannelCount = (short)channels,
                SamplesPerSec = sampleRate,
                Alignment = (short)blockAlignment,
                AvgBytesPerSec = byteRate,
                BitsPerSample = (short)bitDepth,
                ExtraHeader = extraHeader
            };
        }

        public XWBHandler.EncodingType Encoding => EncodingTag;
        public int Channels => ChannelCount;
        public int SampleRate => SamplesPerSec;
        public int BlockAlignment => Alignment;
        public int AvgBytesPerSecond => AvgBytesPerSec;
        public int BitDepth => BitsPerSample;
        public byte[] ExtraSize => ExtraHeader;
    }
}