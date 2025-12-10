using firstScreen.Properties;
namespace firstScreen
{
    public partial class mainPage : Form
    {
        public mainPage()
        {
            InitializeComponent();
        }

        private void CityComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedCity = CityComboBox.SelectedItem.ToString();
            CityForm selected = new CityForm();
            this.Hide();
            DialogResult result = selected.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.Show();
            }
            else
            {
                Application.Exit();
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void mainPage_FormClosed(object sender, FormClosedEventArgs e)
        {
            foreach (Form runningForm in Application.OpenForms)
            {
                if (runningForm is firstScreen)
                {
                    runningForm.Show();
                    break;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProfileForm profileForm = new ProfileForm();
            this.Hide();
            DialogResult result = profileForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.Show();
            }
            else
            {
                Application.Exit();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FavoritesForm favoritesForm = new FavoritesForm();
            this.Hide();
            DialogResult result = favoritesForm.ShowDialog();
            if (result == DialogResult.OK)
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
