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
            mainPage anaekran =new mainPage();
            string girilenNick = logUsernameTextbox.Text.Trim();
            string girilenSifre = logpassTextbox.Text.Trim();

            
            if (string.IsNullOrEmpty(girilenNick) || string.IsNullOrEmpty(girilenSifre))
            {
                MessageBox.Show("Please enter valid username and password.", "Missing information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            
            User girisYapanKullanici = UserManager.Login(girilenNick, girilenSifre);

           
            if (girisYapanKullanici != null)
            {
                

                MessageBox.Show($"Welcome, {girisYapanKullanici.Name}!", "Logged in succesfully.", MessageBoxButtons.OK, MessageBoxIcon.Information);

                
                mainPage anaForm = new mainPage();
                anaForm.Show();
                
                this.Hide();
                DialogResult sonuc = anaekran.ShowDialog();
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
            DialogResult result = sign.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.DialogResult=DialogResult.OK;
                this.Close();
            }
            else
            {
                Application.Exit();
            }
        }

        private void LogtoSignLabel_Click(object sender, EventArgs e)
        {
            signupForm sign = new signupForm();
            DialogResult result=sign.ShowDialog();
            if(result == DialogResult.OK)
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
