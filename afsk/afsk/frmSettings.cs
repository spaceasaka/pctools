using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace afsk
{
    public partial class frmSettings : Form
    {
        public int preFlags;
        public int postFlags;
        public string destination;
        public string source;

        public frmSettings()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            int n = check_number(txtPreFlags.Text);
            if (n > 0)
            {
                preFlags = n;
            }
            else
            {
                MessageBox.Show("フラグの数に誤りがあります。", "詳細設定", MessageBoxButtons.OK);
                return;
            }

            n = check_number(txtPostFlags.Text);
            if (n > 0)
            {
                postFlags = n;
            }
            else
            {
                MessageBox.Show("フラグの数に誤りがあります。", "詳細設定", MessageBoxButtons.OK);
                return;
            }
 

            if (check_address(txtDestination.Text))
            {
                destination = txtDestination.Text;
            }
            else
            {
                MessageBox.Show("あて元のコールサインに誤りがあります。", "詳細設定", MessageBoxButtons.OK);
                return;
            }

            if (check_address(txtSource.Text))
            {
                source = txtSource.Text;
            }
            else
            {
                MessageBox.Show("送信元のコールサインに誤りがあります。", "詳細設定", MessageBoxButtons.OK);
                return;
            }
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {
            txtPreFlags.Text = preFlags.ToString();
            txtPostFlags.Text = postFlags.ToString();
            txtDestination.Text = destination;
            txtSource.Text = source;
        }

        private int check_number(string num)
        {
            int n = 0;
            foreach (char ch in num)
            {
                if (char.IsDigit(ch))
                {
                    n = n * 10 + (int)ch - '0';
                }
                else
                    return 0;
            }
            return n;
        }

        private bool check_address(string addr)
        {
            int i = 0;
            foreach (char ch in addr)
            {
                if (!((ch >= '0') && (ch <= '9') || (ch >= 'A') && (ch <= 'Z'))) return false;
                i += 1;
                if (i > 6) return false;
            }
            return true;
        }
    }
}
