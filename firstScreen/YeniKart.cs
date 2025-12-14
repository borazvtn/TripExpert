using System;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel; // Bu kütüphane o sihirli kod için şart

namespace firstScreen
{
    public partial class YeniKart : UserControl
    {
        // --- HATA ÇÖZÜCÜ KOD BURAYA EKLENDİ ---
        // Bu satır Visual Studio'ya der ki: "Tasarım yaparken bu özelliği kaydetmeye çalışma!"
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Mekan MevcutMekan { get; set; }

        public YeniKart()
        {
            InitializeComponent();
        }

        // --- AKILLI YÜKLEME METODU ---
        public void BilgileriYukle(Mekan mekan)
        {
            MevcutMekan = mekan;

            // Yazılar ve Resim
            lblAd.Text = mekan.Name;
            lblPuan.Text = mekan.AverageScore > 0 ? "Puan: " + mekan.AverageScore.ToString("0.0") : "Yeni";

            try
            {
                if (!string.IsNullOrEmpty(mekan.ImageUrl)) pbResim.Load(mekan.ImageUrl);
            }
            catch { }

            // Favori Durumuna Göre Renk Ayarla
            FavoriRenginiGuncelle();
        }

        private void FavoriRenginiGuncelle()
        {
            if (UserManager.CurrentUser != null && MevcutMekan != null)
            {
                if (UserManager.CurrentUser.IsFavorite(MevcutMekan))
                {
                    btnFav.Text = "❤️";
                    btnFav.ForeColor = Color.Red;
                }
                else
                {
                    btnFav.Text = "🤍";
                    btnFav.ForeColor = Color.Black;
                }
            }
        }

        private void btnFav_Click(object sender, EventArgs e)
        {
            if (UserManager.CurrentUser == null)
            {
                MessageBox.Show("Lütfen önce giriş yapın.");
                return;
            }

            UserManager.CurrentUser.ToggleFavorite(MevcutMekan);
            FavoriRenginiGuncelle();
        }

        private void pbResim_Click(object sender, EventArgs e)
        {
            if (MevcutMekan != null && !string.IsNullOrEmpty(MevcutMekan.Description))
            {
                MessageBox.Show(MevcutMekan.Description, MevcutMekan.Name + " Hakkında Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Bu mekan için açıklama girilmemiş.");
            }
        }

        private void YeniKart_Load(object sender, EventArgs e)
        {

        }
    }
}