using System;
using System.Windows.Forms;

namespace firstScreen
{
    public partial class ProfileForm : Form
    {
        public ProfileForm()
        {
            InitializeComponent();
        }

        // Geri Dön Butonu (Veya iþlem butonu)
        // Tasarýmcýda bu butona çift týkladýysan bu metodun içi boþ gelir, bunu yapýþtýr.
        private void ProfileToMain_Click(object sender, EventArgs e)
        {
            // ESKÝ HATA: mainpage m = new mainpage(); (Yanlýþ yazým ve gereksiz)
            // ÇÖZÜM: Formu kapat, arkadaki ana sayfa zaten açýk.
            this.Close();
        }

        private void ProfileSignOutButton_Click(object sender, EventArgs e)
        {
            // Çýkýþ yapýnca tamamen kapatýp login'e dönmek istersen:
            Application.Restart();
        }

        private void ProfileForm_Load(object sender, EventArgs e)
        {
        }
    }
}