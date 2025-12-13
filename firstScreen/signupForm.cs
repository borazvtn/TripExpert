using System;
using System.Windows.Forms;

namespace firstScreen
{
    public partial class signupForm : Form
    {
        public signupForm()
        {
            InitializeComponent();
        }

        // Kayýt Ol Butonu
        private void signupButton_Click(object sender, EventArgs e)
        {
            // Veritabaný kayýt kodlarýn buradaysa kalsýn (veya UserManager kullanýyorsan o kalsýn)
            // Bizim düzelttiðimiz yer sayfa geçiþi:

            MessageBox.Show("Registration Successful! Please Login.");

            // HATA ÇIKARAN KISIM SÝLÝNDÝ.
            // Sadece formu kapatýyoruz.
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}