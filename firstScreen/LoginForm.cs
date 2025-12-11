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
            mainPage mainpage = new mainPage();
            if (logUsernameTextbox.Text == "admin" && logpassTextbox.Text == "123")
            {
                MessageBox.Show("giris basarili");
                this.Hide();
                DialogResult result = mainpage.ShowDialog();
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
            else
                MessageBox.Show("kullanici adi veya sifre hatali");
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
