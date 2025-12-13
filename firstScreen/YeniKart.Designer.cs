namespace firstScreen
{
    partial class YeniKart
    {
        /// <summary> 
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Bileşen Tasarımcısı üretimi kod

        /// <summary> 
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            lblAd = new Label();
            lblPuan = new Label();
            pbResim = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pbResim).BeginInit();
            SuspendLayout();
            // 
            // lblAd
            // 
            lblAd.AutoSize = true;
            lblAd.Location = new Point(264, 67);
            lblAd.Name = "lblAd";
            lblAd.Size = new Size(38, 15);
            lblAd.TabIndex = 0;
            lblAd.Text = "label1";
            // 
            // lblPuan
            // 
            lblPuan.AutoSize = true;
            lblPuan.Location = new Point(264, 82);
            lblPuan.Name = "lblPuan";
            lblPuan.Size = new Size(38, 15);
            lblPuan.TabIndex = 1;
            lblPuan.Text = "label2";
            // 
            // pbResim
            // 
            pbResim.Location = new Point(55, 67);
            pbResim.Name = "pbResim";
            pbResim.Size = new Size(100, 50);
            pbResim.TabIndex = 2;
            pbResim.TabStop = false;
            // 
            // YeniKart
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pbResim);
            Controls.Add(lblPuan);
            Controls.Add(lblAd);
            Name = "YeniKart";
            Size = new Size(531, 331);
            ((System.ComponentModel.ISupportInitialize)pbResim).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblAd;
        private Label lblPuan;
        private PictureBox pbResim;
    }
}
