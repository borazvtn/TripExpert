using firstScreen.Properties;
namespace firstScreen
{
    public partial class CityForm : Form
    {
        public CityForm()
        {
            InitializeComponent();
        }

        private void CityToMainButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
