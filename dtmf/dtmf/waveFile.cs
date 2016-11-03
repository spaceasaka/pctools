using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

public class waveFile
{
    struct RIFFheader {
        public byte[] groupID;
        public uint chunkSize;
        public byte[] riffType;
    }

    struct FormatChunk {
        public byte[] chunkID;
        public uint chunkSize;
        public short wFormatTag;
        public ushort wChannels;
        public uint dwSamplesPerSec;
        public uint dwAvgBytesPerSec;
        public ushort wBlockAlign;
        public ushort wBitsPerSample;
    }

    struct DataChunk {
        public byte[] chunkID;
        public uint chunkSize;
    }

    private uint bytesPerSample;
    private uint samplePerSec;

    public waveFile(uint bytes, uint sample)
    {
        bytesPerSample = bytes;
        samplePerSec = sample;
    }

    public void save(System.IO.Stream s, List<double> data)
    {
        BinaryWriter bw = new BinaryWriter(s);

        Encoding enc = Encoding.GetEncoding("Shift_JIS");

        bw.Write(enc.GetBytes("RIFF"));
        bw.Write((uint)(36 + data.Count * bytesPerSample));
        bw.Write(enc.GetBytes("WAVE"));

        bw.Write(enc.GetBytes("fmt "));
        bw.Write((uint)16);
        bw.Write((short)1);
        bw.Write((ushort)1);
        bw.Write((uint)samplePerSec);
        bw.Write((uint)(samplePerSec * bytesPerSample));
        bw.Write((ushort)bytesPerSample);
        bw.Write((ushort)(bytesPerSample * 8));

        bw.Write(enc.GetBytes("data"));
        bw.Write((uint)(data.Count * bytesPerSample));

        if (bytesPerSample == 1)
        {
            foreach (double x in data) bw.Write((byte)(byte.MaxValue * (x + 1) / 2));
        }
        else if (bytesPerSample == 2)
        {
            foreach (double x in data) bw.Write((short)(short.MaxValue * x));
        }
    }
}
