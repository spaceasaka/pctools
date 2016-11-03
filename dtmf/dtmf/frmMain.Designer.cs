namespace dtmf
{
    partial class frmMain
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.txtNumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCteate = new System.Windows.Forms.Button();
            this.btnPlay = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtNumber
            // 
            this.txtNumber.Location = new System.Drawing.Point(50, 24);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(154, 19);
            this.txtNumber.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tel:";
            // 
            // btnCteate
            // 
            this.btnCteate.Location = new System.Drawing.Point(50, 93);
            this.btnCteate.Name = "btnCteate";
            this.btnCteate.Size = new System.Drawing.Size(154, 24);
            this.btnCteate.TabIndex = 2;
            this.btnCteate.Text = "WAVファイルの作成...";
            this.btnCteate.UseVisualStyleBackColor = true;
            this.btnCteate.Click += new System.EventHandler(this.btnCteate_Click);
            // 
            // btnPlay
            // 
            this.btnPlay.Location = new System.Drawing.Point(51, 57);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(66, 22);
            this.btnPlay.TabIndex = 3;
            this.btnPlay.Text = "聞く";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(243, 129);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.btnCteate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNumber);
            this.Name = "frmMain";
            this.Text = "DTMF";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCteate;
        private System.Windows.Forms.Button btnPlay;
    }
}

