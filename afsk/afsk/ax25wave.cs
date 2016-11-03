using System;
using System.Collections.Generic;

class ax25wave
{
    public const uint SAMPLE = 11025;

    private const uint BOUND = 1200;
    private const uint FM = 1200;       // Tone for mark (typically a binary 1).
    private const uint FS = 2200;       // Tone for space (typically a binary 0).

    public List<double> wave_data;
    private uint bound_phase;
    private uint bound_delta;
    private uint wave_phase;
    private uint wave_delta;
    private uint fm_delta;
    private uint fs_delta;
    private uint cnt_marks;
    private ushort crc;
    private ushort[] crc16_table =
            {
                0x0000, 0x1081, 0x2102, 0x3183, 0x4204, 0x5285, 0x6306, 0x7387, 
                0x8408, 0x9489, 0xa50a, 0xb58b, 0xc60c, 0xd68d, 0xe70e, 0xf78f
            };

    public ax25wave()
    {
        wave_data = new List<double>();
        wave_data.Clear();
        crc = 0xffff;
    }

    public void begin_sending()
    {
        wave_phase = 0;
        bound_phase = 0;
        bound_delta = (uint)(((ulong)BOUND << 32) / SAMPLE);
        fm_delta = (uint)(((ulong)FM << 32) / SAMPLE);
        fs_delta = (uint)(((ulong)FS << 32) / SAMPLE);
        cnt_marks = 0;
        wave_delta = fs_delta;
    }

    public void end_sending()
    {
        output();
	    uint next = wave_phase +  wave_delta;
	    while (next < wave_phase)
        {
		    wave_phase = next;
            output();
		    next = wave_phase +  wave_delta;
	    }
    }

    public void send_flag_nrzi()
    {
        for (byte nbit = 1; nbit != 0; nbit *= 2)		/* 最下のビットから送信する。 */
        {
            if ((0x7e & nbit) == 0)						/* 0送信のときトーンを変える(NRZI)。 */
                wave_delta = (wave_delta == fs_delta) ? fm_delta : fs_delta;
            send_bit();
        }
    }

    public void send_bytes_nrzi(byte[] text)
    {
        foreach (byte data in text)
        {
            send_byte_nrzi(data);       /* バイト送信 */
        }
    }

    public void send_byte_nrzi(byte data)
    {
        for (byte nbit = 1; nbit != 0; nbit *= 2)		/* 最下のビットから送信する。 */
        {
            if ((data & nbit) != 0) 		    /* ビットは1か。*/
            {
                cnt_marks++;
                if (cnt_marks == 5)			/* 1が5回続いたら0を送信する。 */
                {
                    send_bit();					/* マークを送る */
                    wave_delta = (wave_delta == fs_delta) ? fm_delta : fs_delta;	/* 0送信のためトーンを変える(NRZI)。 */
                    cnt_marks = 0;
                }
            }
            else
            {
                wave_delta = (wave_delta == fs_delta) ? fm_delta : fs_delta;	/* 0送信のためトーンを変える(NRZI)。 */
                cnt_marks = 0;
            }
            send_bit();
        }
        ax25crc16(data);        /* CRC計算 */
    }

    public void send_crc()
    {
        ushort data = (ushort)~crc;
        send_byte_nrzi((byte)(data & 0xff));     /* 下位8ビット送信 */
        send_byte_nrzi((byte)(data >> 8));       /* 上位8ビット送信 */
    }

    private void send_bit()      /* ビットのWaveデータ生成 */
    {
        output();
        wave_phase += wave_delta;

        uint next = bound_phase + bound_delta;
        while (next > bound_phase) {
            bound_phase = next;
            output();
            wave_phase += wave_delta;
            next = bound_phase + bound_delta;
        }
	    bound_phase = next;
    }

    private void output()
    {
        double x = (double)wave_phase / (1L << 32);
        wave_data.Add(Math.Sin(2 * Math.PI * x));
    }

    private void ax25crc16(byte data)
    {
        crc = (ushort)((crc >> 4) ^ crc16_table[(crc & 0xf) ^ (data & 0xf)]);
        crc = (ushort)((crc >> 4) ^ crc16_table[(crc & 0xf) ^ (data >> 4)]);
    }
}