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
            // --- BU SATIRI EKLE, İSMİ RATE OLSUN ---
            btnPuanVer.Text = "Rate";
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

        private void btnPuanVer_Click(object sender, EventArgs e)
        {
            // Giriş yapmamışsa uyarı (Please log in to rate)
            if (UserManager.CurrentUser == null) { MessageBox.Show("Please log in to rate."); return; }

            // Pencere Başlığı: Rate Place (Mekanı Puanla)
            Form prompt = new Form() { Width = 300, Height = 150, Text = "Rate Place", StartPosition = FormStartPosition.CenterScreen };

            // Etiket: Score (1-5)
            Label textLabel = new Label() { Left = 20, Top = 20, Text = "Score (1-5):" };

            TextBox inputBox = new TextBox() { Left = 20, Top = 50, Width = 240 };

            // Buton: OK
            Button confirmation = new Button() { Text = "OK", Left = 180, Top = 80, DialogResult = DialogResult.OK };

            prompt.Controls.Add(textLabel); prompt.Controls.Add(inputBox); prompt.Controls.Add(confirmation);
            prompt.AcceptButton = confirmation;

            if (prompt.ShowDialog() == DialogResult.OK)
            {
                if (int.TryParse(inputBox.Text, out int verilenPuan) && verilenPuan >= 1 && verilenPuan <= 5)
                {
                    // 1. Puanı RAM'e işle
                    MevcutMekan.AddPoint(verilenPuan);

                    // 2. Veritabanına kaydet
                    DataManagement.InsertUserRating(UserManager.CurrentUser.Nickname, MevcutMekan.Id, verilenPuan);

                    // Başarılı Mesajı: Thanks! You rated X stars.
                    MessageBox.Show("Thanks! You rated " + verilenPuan + " stars.");

                    // Ekranı güncelle
                    BilgileriYukle(MevcutMekan);
                }
                else
                {
                    // Hata Mesajı: Lütfen 1-5 arası girin
                    MessageBox.Show("Please enter a number between 1 and 5.");
                }
            }
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