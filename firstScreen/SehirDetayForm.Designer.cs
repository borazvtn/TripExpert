namespace firstScreen
{
    partial class SehirDetayForm
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
            panelMekanlar = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // panelMekanlar
            // 
            panelMekanlar.AutoScroll = true;
            panelMekanlar.Location = new Point(3, 3);
            panelMekanlar.Name = "panelMekanlar";
            panelMekanlar.Size = new Size(541, 337);
            panelMekanlar.TabIndex = 0;
            // 
            // SehirDetayForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panelMekanlar);
            Name = "SehirDetayForm";
            Size = new Size(547, 343);
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel panelMekanlar;
    }
}
