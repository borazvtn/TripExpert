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

        private void ProfileForm_Load(object sender, EventArgs e)
        {
        }

        private void ProfileForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}