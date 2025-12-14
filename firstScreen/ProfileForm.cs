using System;
using System.Windows.Forms;

namespace firstScreen
{
    public partial class ProfileForm : Form
    {
        User currentUser;

        public ProfileForm(User user)
        {
            InitializeComponent();
            currentUser = user;

            if (currentUser != null)
            {
                ProfileNameLabel.Text = currentUser.Name;
                ProfileUserNameLabel.Text = currentUser.Nickname;
            }
        }

        private void ProfileForm_Load(object sender, EventArgs e)
        {
            // 1. Veritabanından kullanıcının favorilerini çekiyoruz
            DataManagement.FavorileriGetir(currentUser);

            // 2. Listeyi temizle (Çift yazmasın diye)
            if (lbFavorites != null)
            {
                lbFavorites.Items.Clear();

                foreach (var mekan in currentUser.Favorites)
                {
                    // 3. Bu mekana kaç puan vermişiz? Veritabanına soruyoruz.
                    int puan = DataManagement.GetUserScore(currentUser.Nickname, mekan.Id);

                    // 4. Puanı yıldıza çeviriyoruz (Örn: 3 -> "★★★")
                    string yildizlar = "";
                    if (puan > 0)
                    {
                        yildizlar = new string('★', puan);
                    }
                    else
                    {
                        yildizlar = "(Puanın Yok)";
                    }

                    // 5. Listeye ekle: "Köfteci Yusuf   ★★★★★"
                    lbFavorites.Items.Add($"{mekan.Name}   {yildizlar}");
                }
            }
        }

        private void ProfileToMain_Click(object sender, EventArgs e)
        {
            mainPage main = new mainPage(currentUser);
            this.Hide();

            DialogResult result = main.ShowDialog();

            if (result == DialogResult.OK)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                Application.Exit();
            }
        }

        private void ProfileSignOutButton_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void ProfileForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}