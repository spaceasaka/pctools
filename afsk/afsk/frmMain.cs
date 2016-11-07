using System;
using System.Collections.Generic;
using System.IO;
using System.Media;
using System.Text;
using System.Windows.Forms;

namespace afsk
{
    public partial class frmMain : Form
    {
        private int nPreFlags = 32;
        private int nPostFlags = 5;
        private string destination = "CQ";
        private string source = "ABC123";

        public frmMain()
        {
            InitializeComponent();
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            frmSettings dlg = new frmSettings();

            dlg.preFlags = nPreFlags;
            dlg.postFlags = nPostFlags;
            dlg.destination = destination;
            dlg.source = source;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                nPreFlags = dlg.preFlags;
                nPostFlags = dlg.postFlags;
                destination = dlg.destination;
                source = dlg.source;
            }
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            ax25wave ax25 = make_wave(txtMessage.Text);
            if (ax25 != null)
            {
                waveFile wc = new waveFile(1, ax25wave.SAMPLE);
                MemoryStream stm = new MemoryStream();
                wc.save(stm, ax25.wave_data);
                stm.Position = 0;
                SoundPlayer player = new SoundPlayer(stm);
                player.Play();
                stm.Close();
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            ax25wave ax25 = make_wave(txtMessage.Text);
            if (ax25 != null)
            {
                SaveFileDialog fd = new SaveFileDialog();

                fd.FileName = "新しいファイル.wav";
                fd.InitialDirectory = Directory.GetCurrentDirectory();
                fd.Filter = "WAVファイル(*.wav)|*.wav|すべてのファイル(*.*)|*.*";
                fd.FilterIndex = 1;
                fd.Title = "保存先のファイルを選択してください";

                if (fd.ShowDialog() == DialogResult.OK)
                {
                    waveFile wc = new waveFile(1, ax25wave.SAMPLE);
                    FileStream ofs = new FileStream(fd.FileName, FileMode.Create, FileAccess.Write);
                    wc.save(ofs, ax25.wave_data);
                    ofs.Close();
                }        
            }
        }

        private ax25wave make_wave(string text)
        {
            if (text.Length <= 0) return null;

            ax25wave ax25 = new ax25wave();     /* Waveデータの生成 */
            
            ax25.begin_sending();
            for (int i = 0; i < nPreFlags; i++) ax25.send_flag_nrzi();

            ax25.send_bytes_nrzi(make_address(destination, (byte)0x60));
            ax25.send_bytes_nrzi(make_address(source, (byte)0x61));
            ax25.send_byte_nrzi((byte)0x03);
            ax25.send_byte_nrzi((byte)0xf0);    // PID is no layer 3 protocol
            ax25.send_bytes_nrzi(Encoding.UTF8.GetBytes(text));
            ax25.send_crc();

            for (int i = 0; i < nPostFlags; i++) ax25.send_flag_nrzi();
            ax25.end_sending();

            return ax25;
        }

        private byte[] make_address(string csign, byte ssid)
        {
            byte[] obj = new byte[7];
            byte[] data = Encoding.UTF8.GetBytes(csign);

            int i = 0;
            foreach (byte c in data)
            {
                obj[i] = (byte)((uint)c << 1);
                i += 1;
                if (i >= 6) break;
            }
            while (i < 6)
            {
                obj[i] = (byte)(0x20 << 1);    // space
                i += 1;
            }
            obj[6] = ssid;
            return obj;
        }
    }
}
