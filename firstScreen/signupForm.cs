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

       
        private void signupButton_Click(object sender, EventArgs e)
        {

            User newuser = new User()
            {
                Name = signnametextBox.Text,
                Password = signpasstextBox.Text,
                Nickname = signUsernametextBox.Text,
                UserStatus = "Standart"
            };

            LoginForm loginform = new LoginForm();
            string result = UserManager.Register(newuser);
            if (result == "Registered succesfully")
            {
                MessageBox.Show("Registration Successful! Please Login.");


                this.DialogResult = DialogResult.OK;
                this.Close();


                DialogResult sonuc = loginform.ShowDialog();
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
    

   

        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}