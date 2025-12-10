using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace firstScreen
{
    public partial class FavoritesForm : Form
    {
        public FavoritesForm()
        {
            InitializeComponent();
        }

        private void FavoriteToMain_Click(object sender, EventArgs e)
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

        private void FavoriteNextButton_Click(object sender, EventArgs e)
        {
            FavoritesForm favoritesForm2 = new FavoritesForm();
            this.Hide();
            DialogResult result = favoritesForm2.ShowDialog();
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
