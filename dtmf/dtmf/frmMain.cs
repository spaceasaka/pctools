using System;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;

namespace dtmf
{
    public partial class frmMain : Form
    {
        uint fsample = 11025;         // WAVファイルのサンプリング周波数
        
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnCteate_Click(object sender, EventArgs e)
        {
            if (!check_dtmf_string(txtNumber.Text))
            {
                MessageBox.Show("Tel番号が正しくありません", "DTMF", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SaveFileDialog fd = new SaveFileDialog();

            fd.FileName = "新しいファイル.wav";
            fd.InitialDirectory = Directory.GetCurrentDirectory();
            fd.Filter = "WAVファイル(*.wav)|*.wav|すべてのファイル(*.*)|*.*";
            fd.FilterIndex = 1;
            fd.Title = "保存先のファイルを選択してください";

            if (fd.ShowDialog() == DialogResult.OK)
            {
                waveFile wf = new waveFile(1, fsample);
                List<double> data = dtmf_run(txtNumber.Text, 0.15);
                wf.save(fd.FileName, data);
                data = null;
            }
        }

        private bool check_dtmf_string(string dtmf)
        {
            foreach (char ch in dtmf)
            {
                if ((ch < '0' || ch > '9') && (ch < 'A' || ch > 'D') && ch != '#' && ch != '*' && ch != '-') return false;
            }
            return true;
        }

        private List<double> dtmf_run(string dtmf, double sec)
        {
            List<double> data = new List<double>();

            Dictionary<char, uint> dtmf_LF = new Dictionary<char, uint>();
            dtmf_LF.Add('0', 941);
            dtmf_LF.Add('1', 697);
            dtmf_LF.Add('2', 697);
            dtmf_LF.Add('3', 697);
            dtmf_LF.Add('4', 770);
            dtmf_LF.Add('5', 770);
            dtmf_LF.Add('6', 770);
            dtmf_LF.Add('7', 852);
            dtmf_LF.Add('8', 852);
            dtmf_LF.Add('9', 852);
            dtmf_LF.Add('A', 697);
            dtmf_LF.Add('B', 770);
            dtmf_LF.Add('C', 852);
            dtmf_LF.Add('D', 941);
            dtmf_LF.Add('*', 941);
            dtmf_LF.Add('#', 941);

            Dictionary<char, uint> dtmf_HF = new Dictionary<char, uint>();
            dtmf_HF.Add('0', 1336);
            dtmf_HF.Add('1', 1209);
            dtmf_HF.Add('2', 1336);
            dtmf_HF.Add('3', 1477);
            dtmf_HF.Add('4', 1209);
            dtmf_HF.Add('5', 1336);
            dtmf_HF.Add('6', 1477);
            dtmf_HF.Add('7', 1209);
            dtmf_HF.Add('8', 1336);
            dtmf_HF.Add('9', 1477);
            dtmf_HF.Add('A', 1633);
            dtmf_HF.Add('B', 1633);
            dtmf_HF.Add('C', 1633);
            dtmf_HF.Add('D', 1633);
            dtmf_HF.Add('*', 1209);
            dtmf_HF.Add('#', 1477);

            uint t_max = (uint)(fsample * sec);
            foreach (char key in dtmf)
            {
                uint a_phase = 0;
                uint b_phase = 0;
                if (key != '-')
                {
                    uint a_delta = (uint)(((ulong)dtmf_LF[key] << 32) / fsample);
                    uint b_delta = (uint)(((ulong)dtmf_HF[key] << 32) / fsample);
                    uint t = 0;
                    while (t < t_max / 2)
                    {
                        double a = Math.Sin(2 * Math.PI * (double)a_phase / (1L << 32));
                        double b = Math.Sin(2 * Math.PI * (double)b_phase / (1L << 32));
                        data.Add((a + b) / 2);
                        a_phase += a_delta;
                        b_phase += b_delta;
                        t++;
                    }
                    while (t < t_max)
                    {
                        data.Add(0.0);
                        t++;
                    }
                }
            }
            return data;
        }
    }
}
