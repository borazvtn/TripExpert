using firstScreen.Properties;
namespace firstScreen
{
    public partial class mainPage : Form
    {
        public mainPage()
        {
            InitializeComponent();
        }

        private void CityComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // --- BURADAN BAÞLAYIP YAPIÞTIRIN ---

            // 1. GÜVENLÝK KÝLÝDÝ: Eðer kutu boþsa veya seçim yoksa DUR.
            // (Programýn çökmesini engelleyen satýr budur)
            ComboBox kutu = (ComboBox)sender;
            if (kutu.SelectedItem == null) return;

            string secilenSehirAdi = kutu.SelectedItem.ToString();

            // 2. Gereksiz yazýlarý filtrele
            if (secilenSehirAdi == "Please select a city" || secilenSehirAdi == "") return;

            // 3. Þehir Ekranýný Aç
            // (Seçilen þehrin adýný gönderiyoruz, o da gidip veritabanýndan buluyor)
            SehirDetayForm detayFormu = new SehirDetayForm(secilenSehirAdi);
            detayFormu.ShowDialog();

            // --- BURADA BÝTÝYOR ---
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void mainPage_FormClosed(object sender, FormClosedEventArgs e)
        {
            foreach (Form runningForm in Application.OpenForms)
            {
                if (runningForm is firstScreen)
                {
                    runningForm.Show();
                    break;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProfileForm profileForm = new ProfileForm();
            this.Hide();
            DialogResult result = profileForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.Show();
            }
            else
            {
                Application.Exit();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FavoritesForm favoritesForm = new FavoritesForm();
            this.Hide();
            DialogResult result = favoritesForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.Show();
            }
            else
            {
                Application.Exit();
            }
        }
    }
}
