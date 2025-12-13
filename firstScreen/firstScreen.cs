namespace firstScreen
{
    public partial class firstScreen : Form
    {
        public firstScreen()
        {
            InitializeComponent();
        }

        private void firstlogButton_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            this.Hide();
            DialogResult result = loginForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.Show();
            }
            else
            {
                Application.Exit();
            }
        }

        private void firstsignButton_Click(object sender, EventArgs e)
        {
            signupForm signForm = new signupForm();
            this.Hide();
            DialogResult result = signForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.Show();
            }
        }

        private void firstScreen_Load(object sender, EventArgs e)
        {

        }
    }
}
