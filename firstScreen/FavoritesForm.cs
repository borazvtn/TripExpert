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
            // (Eğer User.cs dosyanızda listenin adı MyFavorites ise burayı .MyFavorites yapın)
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

            // 5. Kartları Bas (GÜNCELLENEN KISIM - YeniKart Sistemi)
            foreach (Mekan mekan in favoriListesi)
            {
                YeniKart kart = new YeniKart();

                // --- ESKİ KODLAR SİLİNDİ (Baslik, Puan vs. yok artık) ---

                // --- YENİ SİSTEM: Tek satırda her şeyi yükle ---
                kart.BilgileriYukle(mekan);

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