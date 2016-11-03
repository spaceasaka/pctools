namespace afsk
{
    partial class frmSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnOK = new System.Windows.Forms.Button();
            this.フラグ = new System.Windows.Forms.GroupBox();
            this.txtPostFlags = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPreFlags = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.grpAddress = new System.Windows.Forms.GroupBox();
            this.txtDestination = new System.Windows.Forms.TextBox();
            this.txtSource = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.フラグ.SuspendLayout();
            this.grpAddress.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(9, 184);
            this.btnOK.Margin = new System.Windows.Forms.Padding(2);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(78, 25);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // フラグ
            // 
            this.フラグ.Controls.Add(this.txtPostFlags);
            this.フラグ.Controls.Add(this.label4);
            this.フラグ.Controls.Add(this.txtPreFlags);
            this.フラグ.Controls.Add(this.label3);
            this.フラグ.Controls.Add(this.label2);
            this.フラグ.Controls.Add(this.label1);
            this.フラグ.Location = new System.Drawing.Point(11, 10);
            this.フラグ.Margin = new System.Windows.Forms.Padding(2);
            this.フラグ.Name = "フラグ";
            this.フラグ.Padding = new System.Windows.Forms.Padding(2);
            this.フラグ.Size = new System.Drawing.Size(209, 74);
            this.フラグ.TabIndex = 1;
            this.フラグ.TabStop = false;
            this.フラグ.Text = "フラグ";
            // 
            // txtPostFlags
            // 
            this.txtPostFlags.Location = new System.Drawing.Point(40, 44);
            this.txtPostFlags.Margin = new System.Windows.Forms.Padding(2);
            this.txtPostFlags.Name = "txtPostFlags";
            this.txtPostFlags.Size = new System.Drawing.Size(37, 19);
            this.txtPostFlags.TabIndex = 1;
            this.txtPostFlags.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(81, 47);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "バイト";
            // 
            // txtPreFlags
            // 
            this.txtPreFlags.Location = new System.Drawing.Point(40, 21);
            this.txtPreFlags.Margin = new System.Windows.Forms.Padding(2);
            this.txtPreFlags.Name = "txtPreFlags";
            this.txtPreFlags.Size = new System.Drawing.Size(37, 19);
            this.txtPreFlags.TabIndex = 1;
            this.txtPreFlags.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 47);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "末尾：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(81, 25);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "バイト";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "先頭：";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(145, 184);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(78, 25);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "キャンセル";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // grpAddress
            // 
            this.grpAddress.Controls.Add(this.txtDestination);
            this.grpAddress.Controls.Add(this.txtSource);
            this.grpAddress.Controls.Add(this.label6);
            this.grpAddress.Controls.Add(this.label8);
            this.grpAddress.Location = new System.Drawing.Point(9, 95);
            this.grpAddress.Margin = new System.Windows.Forms.Padding(2);
            this.grpAddress.Name = "grpAddress";
            this.grpAddress.Padding = new System.Windows.Forms.Padding(2);
            this.grpAddress.Size = new System.Drawing.Size(211, 76);
            this.grpAddress.TabIndex = 3;
            this.grpAddress.TabStop = false;
            this.grpAddress.Text = "コールサイン";
            // 
            // txtDestination
            // 
            this.txtDestination.Location = new System.Drawing.Point(50, 21);
            this.txtDestination.Margin = new System.Windows.Forms.Padding(2);
            this.txtDestination.Name = "txtDestination";
            this.txtDestination.Size = new System.Drawing.Size(112, 19);
            this.txtDestination.TabIndex = 6;
            // 
            // txtSource
            // 
            this.txtSource.Location = new System.Drawing.Point(50, 43);
            this.txtSource.Margin = new System.Windows.Forms.Padding(2);
            this.txtSource.Name = "txtSource";
            this.txtSource.Size = new System.Drawing.Size(112, 19);
            this.txtSource.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 23);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 12);
            this.label6.TabIndex = 3;
            this.label6.Text = "あて先：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 46);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 12);
            this.label8.TabIndex = 5;
            this.label8.Text = "送信元：";
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(230, 215);
            this.Controls.Add(this.grpAddress);
            this.Controls.Add(this.フラグ);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSettings";
            this.Text = "詳細設定";
            this.Load += new System.EventHandler(this.frmSettings_Load);
            this.フラグ.ResumeLayout(false);
            this.フラグ.PerformLayout();
            this.grpAddress.ResumeLayout(false);
            this.grpAddress.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.GroupBox フラグ;
        private System.Windows.Forms.TextBox txtPostFlags;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPreFlags;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox grpAddress;
        private System.Windows.Forms.TextBox txtDestination;
        private System.Windows.Forms.TextBox txtSource;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
    }
}