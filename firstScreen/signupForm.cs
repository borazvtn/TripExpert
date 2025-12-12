namespace firstScreen
{
    public partial class signupForm : Form
    {
        public signupForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            DialogResult result = loginForm.ShowDialog();
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

        private void signupButton_Click(object sender, EventArgs e)
        {
            User newuser = new User()
            {
                Name = signnametextBox.Text,
                Password = signpasstextBox.Text,
                Nickname = signUsernametextBox.Text,
                UserStatus = "Standart"
            };

            mainPage mainpage = new mainPage();
            string result=UserManager.Register(newuser);
            if(result== "Registered succesfully")
            {
                MessageBox.Show("Registered succesfully","Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
                
                DialogResult sonuc = mainpage.ShowDialog();
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
                MessageBox.Show(result, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }
    }
}
