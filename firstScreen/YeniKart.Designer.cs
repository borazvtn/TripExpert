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

        // BAK BURASI TEK VE BİRLEŞTİRİLMİŞ KOD BLOĞU
        private void InitializeComponent()
        {
            this.lblAd = new System.Windows.Forms.Label();
            this.lblPuan = new System.Windows.Forms.Label();
            this.pbResim = new System.Windows.Forms.PictureBox();
            this.btnFav = new System.Windows.Forms.Button();
            this.btnPuanVer = new System.Windows.Forms.Button(); // Yeni buton da burada
            ((System.ComponentModel.ISupportInitialize)(this.pbResim)).BeginInit();
            this.SuspendLayout();

            // --- 1. PARÇA: YAZILAR ---
            // lblAd
            this.lblAd.AutoSize = true;
            this.lblAd.Location = new System.Drawing.Point(264, 67);
            this.lblAd.Name = "lblAd";
            this.lblAd.Size = new System.Drawing.Size(38, 15);
            this.lblAd.TabIndex = 0;
            this.lblAd.Text = "label1";

            // lblPuan
            this.lblPuan.AutoSize = true;
            this.lblPuan.Location = new System.Drawing.Point(264, 127);
            this.lblPuan.Name = "lblPuan";
            this.lblPuan.Size = new System.Drawing.Size(38, 15);
            this.lblPuan.TabIndex = 1;
            this.lblPuan.Text = "label2";

            // --- 2. PARÇA: RESİM ---
            // pbResim
            this.pbResim.Location = new System.Drawing.Point(22, 67);
            this.pbResim.Name = "pbResim";
            this.pbResim.Size = new System.Drawing.Size(182, 140);
            this.pbResim.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbResim.TabIndex = 2;
            this.pbResim.TabStop = false;
            this.pbResim.Click += new System.EventHandler(this.pbResim_Click);

            // --- 3. PARÇA: BUTONLAR ---
            // btnFav
            this.btnFav.Location = new System.Drawing.Point(418, 75);
            this.btnFav.Name = "btnFav";
            this.btnFav.Size = new System.Drawing.Size(75, 23);
            this.btnFav.TabIndex = 3;
            this.btnFav.Text = "fav";
            this.btnFav.UseVisualStyleBackColor = true;
            this.btnFav.Click += new System.EventHandler(this.btnFav_Click);

            // btnPuanVer (Bunu da ekledik, hepsi bir arada)
            this.btnPuanVer.Location = new System.Drawing.Point(418, 115);
            this.btnPuanVer.Name = "btnPuanVer";
            this.btnPuanVer.Size = new System.Drawing.Size(75, 23);
            this.btnPuanVer.TabIndex = 4;
            this.btnPuanVer.Text = "Puan Ver";
            this.btnPuanVer.UseVisualStyleBackColor = true;
            this.btnPuanVer.Click += new System.EventHandler(this.btnPuanVer_Click);

            // --- GENEL AYARLAR ---
            // YeniKart
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnPuanVer); // Puan butonu karta eklendi
            this.Controls.Add(this.btnFav);     // Fav butonu karta eklendi
            this.Controls.Add(this.pbResim);    // Resim karta eklendi
            this.Controls.Add(this.lblPuan);    // Yazılar karta eklendi
            this.Controls.Add(this.lblAd);
            this.Name = "YeniKart";
            this.Size = new System.Drawing.Size(531, 331);
            this.Load += new System.EventHandler(this.YeniKart_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbResim)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private Label lblAd;
        private Label lblPuan;
        private PictureBox pbResim;
        private Button btnFav;
        private Button btnPuanVer;

    }
}
