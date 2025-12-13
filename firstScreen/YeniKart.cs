using System;
using System.Windows.Forms;
using System.ComponentModel;

namespace firstScreen
{
    public partial class YeniKart : UserControl
    {
        public YeniKart()
        {
            InitializeComponent();
        }

        // --- KARTIN ÖZELLİKLERİ ---

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Baslik
        {
            get { return lblAd.Text; }
            set { lblAd.Text = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Puan
        {
            get { return lblPuan.Text; }
            set { lblPuan.Text = value; }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ResimYolu
        {
            set
            {
                try
                {
                    if (!string.IsNullOrEmpty(value))
                        pbResim.Load(value);
                }
                catch { }
            }
        }
    }
}
