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

    public List<double> load(String fname)
    {
        FileStream ifs = new FileStream(fname, FileMode.Open, FileAccess.Read);
        BinaryReader br = new BinaryReader(ifs);

        RIFFheader hed;
        try {
            hed.groupID = br.ReadBytes(4);
            hed.chunkSize = br.ReadUInt32();
            hed.riffType = br.ReadBytes(4);
        }
        catch (Exception ex){
            br.Close();
            return null;
        }
        Encoding enc = Encoding.GetEncoding("Shift_JIS");
        if (!(hed.groupID.Equals(enc.GetBytes("RIFF")) && hed.riffType.Equals(enc.GetBytes("WAVE")))) {
            br.Close();
            return null;
        }

        FormatChunk fmt;
        try {
            fmt.chunkID = br.ReadBytes(4);
            fmt.chunkSize = br.ReadUInt32();
            fmt.wFormatTag = br.ReadInt16();
            fmt.wChannels = br.ReadUInt16();
            fmt.dwSamplesPerSec = br.ReadUInt32();
            fmt.dwAvgBytesPerSec = br.ReadUInt32();
            fmt.wBlockAlign = br.ReadUInt16();
            fmt.wBitsPerSample = br.ReadUInt16();
        }
        catch (Exception ex) {
            br.Close();
            return null;
        }
        if (!fmt.chunkID.Equals(enc.GetBytes("fmt "))) {
            br.Close();
            return null;
        }

        DataChunk dat;
        try {
            dat.chunkID = br.ReadBytes(4);
            dat.chunkSize = br.ReadUInt32();
        }
        catch (Exception ex) {
            br.Close();
            return null;
        }
        if (!dat.chunkID.Equals(enc.GetBytes("data"))) {
            br.Close();
            return null;
        }

        bytesPerSample = fmt.wBlockAlign;
        samplePerSec = fmt.dwSamplesPerSec;

        List<double> data;
        if (bytesPerSample == 1) {
            uint count = dat.chunkSize / bytesPerSample;

            data = new List<double>();
            data.Clear();
            try {
                for (int i = 0; i < count; i++) {
                    byte n = br.ReadByte();
                    data.Add(((double)n * 2 / byte.MaxValue) - 1);
                }
            }
            catch (Exception ex) {
                br.Close();
                return null;
            }
        }
        else if (bytesPerSample == 2) {
            uint count = dat.chunkSize / bytesPerSample;

            data = new List<double>();
            data.Clear();
            try {
                for (int i = 0; i < count; i++) {
                    short n = br.ReadInt16();
                    data.Add((double)n / short.MaxValue);
                }
            }
            catch (Exception ex) {
                br.Close();
                return null;
            }

        }
        else {
            br.Close();
            return null;
        }
        br.Close();
        return data;
    }

    public void save(String fname, List<double> data)
    {
	    FileStream ofs = new FileStream(fname, FileMode.Create, FileAccess.Write);
        BinaryWriter bw = new BinaryWriter(ofs);

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

        if (bytesPerSample == 1) {
            foreach (double x in data) bw.Write((byte)(byte.MaxValue * (x + 1) / 2));
        }
        else if (bytesPerSample == 2) {
            foreach (double x in data) bw.Write((short)(short.MaxValue * x));
        }
        ofs.Close();
    }
}
