using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace firstScreen
{
    public partial class FavoritesForm : Form
    {
        public FavoritesForm()
        {
            InitializeComponent();
        }

        private void FavoritesForm_Load(object sender, EventArgs e)
        {
            FavorileriListele();
        }

        private void FavorileriListele()
        {
            // 1. Tepsiyi temizle
            panelMekanlar.Controls.Clear();

            // 2. Giriş kontrolü
            if (UserManager.CurrentUser == null)
            {
                MessageBox.Show("Favorileri görmek için giriş yapmalısınız.");
                this.Close();
                return;
            }

            // 3. Favorileri al
            List<Mekan> favoriListesi = UserManager.CurrentUser.Favorites;

            // 4. Favori yoksa uyar
            if (favoriListesi == null || favoriListesi.Count == 0)
            {
                Label lblUyari = new Label();
                lblUyari.Text = "Henüz favori mekanınız yok.";
                lblUyari.AutoSize = true;
                lblUyari.Font = new Font("Arial", 12, FontStyle.Bold);
                lblUyari.Margin = new Padding(50);
                panelMekanlar.Controls.Add(lblUyari);
                return;
            }

            // 5. Kartları Bas (YeniKart kullanıyoruz)
            foreach (Mekan mekan in favoriListesi)
            {
                // DİKKAT: Artık ismimiz YeniKart
                YeniKart kart = new YeniKart();

                kart.Baslik = mekan.Name;
                kart.Puan = "Puan: " + mekan.AverageScore.ToString("0.0");
                kart.ResimYolu = mekan.ImageUrl;
                kart.Margin = new Padding(10);

                panelMekanlar.Controls.Add(kart);
            }
        }

        private void FavoriteToMain_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
