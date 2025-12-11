namespace firstScreen
{
    public partial class ProfileForm : Form
    {
        public ProfileForm()
        {
            InitializeComponent();
        }

        private void ProfileToMain_Click(object sender, EventArgs e)
        {
            mainPage mainpage = new mainPage();
            this.Hide();
            DialogResult result = mainpage.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.Show();
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
    }
}
