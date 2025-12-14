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

        // DİKKAT: Artık parantez içinde (User user) istiyoruz!
        public FavoritesForm(User user)
        {
            InitializeComponent();
            currentUser = user; // Kullanıcıyı teslim al
            this.Text = "Favorilerim";

            FavorileriListele();
        }

        private void FavorileriListele()
        {
            // Panel adını senin söylediğin gibi 'panelMekanlar' yaptım
            panelMekanlar.Controls.Clear();

            // 1. Veritabanından en güncel favorileri çek
            if (currentUser != null)
            {
                DataManagement.FavorileriGetir(currentUser);
            }

            // 2. Eğer favori yoksa uyarı ver
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

            // 3. Kartları Oluştur ve Ekle
            foreach (Mekan mekan in currentUser.Favorites)
            {
                YeniKart kart = new YeniKart();
                kart.BilgileriYukle(mekan);
                kart.Margin = new Padding(15);

                // Panele ekle
                panelMekanlar.Controls.Add(kart);
            }
        }

        private void FavoritesForm_Load(object sender, EventArgs e)
        {

        }

        private void FavoriteToMain_Click(object sender, EventArgs e)
        {
            mainPage main = new mainPage(currentUser);
            this.Hide();
            DialogResult sonuc = main.ShowDialog();
            if (sonuc == DialogResult.OK)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                Application.Exit();
            }
        }
    }
    
}