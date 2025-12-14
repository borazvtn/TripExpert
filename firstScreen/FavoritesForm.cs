using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;

namespace firstScreen
{
    public partial class FavoritesForm : Form
    {
        // Favorilerine bakacağımız kullanıcı
        private User currentUser;

        public FavoritesForm(User user)
        {
            InitializeComponent();
            currentUser = user;
            this.Text = "Favorilerim";

            // Listeyi doldur
            FavorileriListele();
        }

        private void FavorileriListele()
        {
            panelMekanlar.Controls.Clear();

            // Mekanlar yüklenmemişse yükle (Resimler gözüksün diye)
            if (DataManagement.AllCities.Count == 0)
            {
                DataManagement.LoadPlacesFromDatabase();
            }

            // Veritabanından çek
            if (currentUser != null)
            {
                DataManagement.FavorileriGetir(currentUser);
            }

            // Boş mu dolu mu kontrol et
            if (currentUser == null || currentUser.Favorites.Count == 0)
            {
                Label bosMesaj = new Label();
                bosMesaj.Text = "Henüz favorilere eklediğiniz bir mekan yok.\nKalp ikonuna tıklayarak ekleyebilirsiniz.";
                bosMesaj.AutoSize = true;
                bosMesaj.Font = new Font("Segoe UI", 12, FontStyle.Italic);
                bosMesaj.ForeColor = Color.Gray;
                bosMesaj.Location = new Point(20, 20);

                panelMekanlar.Controls.Add(bosMesaj);
                return;
            }

            // Kartları oluştur
            foreach (Mekan mekan in currentUser.Favorites)
            {
                YeniKart kart = new YeniKart();
                kart.BilgileriYukle(mekan);
                kart.Margin = new Padding(15);
                panelMekanlar.Controls.Add(kart);
            }
        }

        // --- İŞTE HATA VEREN YER BURASIYDI ---
        // Tasarımcı bu metodu arıyordu, boş olarak ekledik. Hata gidecek.
        private void FavoritesForm_Load(object sender, EventArgs e)
        {
        }

        // Geri butonu varsa diye bunu da ekledim, zararı olmaz.
        private void FavoriteToMain_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}