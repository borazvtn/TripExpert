using System;
using System.Windows.Forms;

namespace firstScreen
{
    public partial class mainPage : Form
    {
        // Ýçerideki kullanýcýyý tutan deðiþken
        User activeUser;

        // KAPICI: Kimlik (User) göstermeden içeri almaz!
        public mainPage(User user)
        {
            InitializeComponent();
            activeUser = user;
        }

        private void CityComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox kutu = (ComboBox)sender;
            if (kutu.SelectedItem == null) return;
            string sehir = kutu.SelectedItem.ToString();
            if (sehir == "" || sehir == "Please select a city") return;

            // Þehir detayýný aç
            SehirDetayForm detay = new SehirDetayForm(sehir);
            detay.ShowDialog();
        }

        // FAVORÝLER BUTONU
        private void button2_Click(object sender, EventArgs e)
        {
            // Zinciri kuruyoruz: Kullanýcýyý favoriler formuna atýyoruz.
            FavoritesForm fav = new FavoritesForm(activeUser);
            this.Hide();
            fav.ShowDialog();
            this.Show(); // Geri dönünce ana sayfayý tekrar göster
        }

        // PROFÝL BUTONU
        private void button1_Click(object sender, EventArgs e)
        {
            ProfileForm profil = new ProfileForm();
            this.Hide();
            profil.ShowDialog();
            this.Show();
        }

        // ÇIKIÞ BUTONU
        private void button3_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void mainPage_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void mainPage_Load(object sender, EventArgs e) { }
    }
}