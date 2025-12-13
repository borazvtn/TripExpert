using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace firstScreen
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            // ESKÝ HATALI SATIR SÝLÝNDÝ
            // Kullanýcý giriþi kontrol ediliyor...

            string girilenNick = logUsernameTextbox.Text.Trim();
            string girilenSifre = logpassTextbox.Text.Trim();

            if (string.IsNullOrEmpty(girilenNick) || string.IsNullOrEmpty(girilenSifre))
            {
                MessageBox.Show("Please enter valid username and password.", "Missing information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Giriþ iþlemini dene
            User girisYapanKullanici = UserManager.Login(girilenNick, girilenSifre);

            if (girisYapanKullanici != null)
            {
                MessageBox.Show($"Welcome, {girisYapanKullanici.Name}!", "Logged in succesfully.", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // --- ÝÞTE SÝHÝRLÝ DOKUNUÞ ---
                // Kullanýcýyý (girisYapanKullanici) ana sayfaya paketleyip gönderiyoruz.
                mainPage anaForm = new mainPage(girisYapanKullanici);

                this.Hide();

                // Ana ekraný açýyoruz
                DialogResult sonuc = anaForm.ShowDialog();

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
            else
            {
                MessageBox.Show("Wrong username or password!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void logSignButton_Click(object sender, EventArgs e)
        {
            signupForm sign = new signupForm();
            this.Hide(); // Kayýt olurken giriþi gizle
            DialogResult result = sign.ShowDialog();

            if (result == DialogResult.OK)
            {
                this.Show(); // Kayýt bittiyse tekrar göster
            }
            else
            {
                // Eðer çarpýdan kapattýysa uygulamayý kapatma, sadece formu göster
                this.Show();
            }
        }

        private void LogtoSignLabel_Click(object sender, EventArgs e)
        {
            signupForm sign = new signupForm();
            this.Hide();
            DialogResult result = sign.ShowDialog();

            if (result == DialogResult.OK)
            {
                this.Show();
            }
            else
            {
                this.Show();
            }
        }

        // SORUNLU LoginForm_Load METODU BURADAN SÝLÝNDÝ!
        // Artýk "Zaten bir taným içeriyor" hatasý vermeyecek.
    }
}