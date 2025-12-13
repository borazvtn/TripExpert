using firstScreen.Properties;

namespace firstScreen
    
{
    partial class mainPage
    {
        
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            mainPanel = new Panel();
            MainSignOutButton = new Button();
            button2 = new Button();
            label1 = new Label();
            button1 = new Button();
            label2 = new Label();
            CityComboBox = new ComboBox();
            AnkarapictureBox = new PictureBox();
            İstanbulpictureBox = new PictureBox();
            İzmirpictureBox = new PictureBox();
            mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)AnkarapictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)İstanbulpictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)İzmirpictureBox).BeginInit();
            SuspendLayout();
            // 
            // mainPanel
            // 
            mainPanel.BackColor = Color.AliceBlue;
            mainPanel.Controls.Add(MainSignOutButton);
            mainPanel.Controls.Add(button2);
            mainPanel.Controls.Add(label1);
            mainPanel.Controls.Add(button1);
            mainPanel.Dock = DockStyle.Left;
            mainPanel.Location = new Point(0, 0);
            mainPanel.Margin = new Padding(3, 2, 3, 2);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(146, 415);
            mainPanel.TabIndex = 0;
            // 
            // MainSignOutButton
            // 
            MainSignOutButton.BackColor = Color.AliceBlue;
            MainSignOutButton.BackgroundImageLayout = ImageLayout.Center;
            MainSignOutButton.Dock = DockStyle.Bottom;
            MainSignOutButton.FlatStyle = FlatStyle.Popup;
            MainSignOutButton.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            MainSignOutButton.Location = new Point(0, 391);
            MainSignOutButton.Margin = new Padding(3, 2, 3, 2);
            MainSignOutButton.Name = "MainSignOutButton";
            MainSignOutButton.Size = new Size(146, 24);
            MainSignOutButton.TabIndex = 4;
            MainSignOutButton.Text = "Sign out";
            MainSignOutButton.UseVisualStyleBackColor = false;
            MainSignOutButton.Click += button3_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.AliceBlue;
            button2.BackgroundImageLayout = ImageLayout.Center;
            button2.FlatStyle = FlatStyle.Popup;
            button2.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.Location = new Point(-63, 59);
            button2.Margin = new Padding(3, 2, 3, 2);
            button2.Name = "button2";
            button2.Size = new Size(208, 22);
            button2.TabIndex = 3;
            button2.Text = "Favorites";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(32, 9);
            label1.Name = "label1";
            label1.Size = new Size(45, 19);
            label1.TabIndex = 2;
            label1.Text = "Menu";
            // 
            // button1
            // 
            button1.BackColor = Color.AliceBlue;
            button1.BackgroundImageLayout = ImageLayout.Center;
            button1.FlatStyle = FlatStyle.Popup;
            button1.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(-79, 38);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(224, 24);
            button1.TabIndex = 0;
            button1.Text = "Profile";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(262, 4);
            label2.Name = "label2";
            label2.Size = new Size(129, 32);
            label2.TabIndex = 1;
            label2.Text = "GoTürkiye";
            // 
            // CityComboBox
            // 
            CityComboBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            CityComboBox.FormattingEnabled = true;
            CityComboBox.Items.AddRange(new object[] { "Adana", "Adıyaman", "Afyonkarahisar", "Ağrı", "Aksaray", "Amasya", "Ankara", "Antalya", "Ardahan", "Artvin", "Aydın", "Balıkesir", "Bartın", "Batman", "Bayburt", "Bilecik", "Bingöl", "Bitlis", "Bolu", "Burdur", "Bursa", "Çanakkale", "Çankırı", "Çorum", "Denizli", "Diyarbakır", "Düzce", "Edirne", "Elazığ", "Erzincan", "Erzurum", "Eskişehir", "Gaziantep", "Giresun", "Gümüşhane", "Hakkâri", "Hatay", "Iğdır", "Isparta", "İstanbul", "İzmir", "Kahramanmaraş", "Karabük", "Karaman", "Kars", "Kastamonu", "Kayseri", "Kırıkkale", "Kırklareli", "Kırşehir", "Kilis", "Kocaeli", "Konya", "Kütahya", "Malatya", "Manisa", "Mardin", "Mersin", "Muğla", "Muş", "Nevşehir", "Niğde", "Ordu", "Osmaniye", "Rize", "Sakarya", "Samsun", "Siirt", "Sinop", "Sivas", "Şanlıurfa", "Şırnak", "Tekirdağ", "Tokat", "Trabzon", "Tunceli", "Uşak", "Van", "Yalova", "Yozgat", "Zonguldak" });
            CityComboBox.Location = new Point(552, 10);
            CityComboBox.Margin = new Padding(3, 2, 3, 2);
            CityComboBox.Name = "CityComboBox";
            CityComboBox.Size = new Size(133, 23);
            CityComboBox.TabIndex = 2;
            CityComboBox.Text = "Please select a city";
            CityComboBox.SelectedIndexChanged += CityComboBox_SelectedIndexChanged;
            // 
            // AnkarapictureBox
            // 
            AnkarapictureBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            AnkarapictureBox.Image = Resources.ankara;
            AnkarapictureBox.Location = new Point(423, 40);
            AnkarapictureBox.Margin = new Padding(3, 2, 3, 2);
            AnkarapictureBox.Name = "AnkarapictureBox";
            AnkarapictureBox.Size = new Size(299, 168);
            AnkarapictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
            AnkarapictureBox.TabIndex = 3;
            AnkarapictureBox.TabStop = false;
            // 
            // İstanbulpictureBox
            // 
            İstanbulpictureBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            İstanbulpictureBox.Image = Resources.istanbul;
            İstanbulpictureBox.Location = new Point(148, 166);
            İstanbulpictureBox.Margin = new Padding(3, 2, 3, 2);
            İstanbulpictureBox.Name = "İstanbulpictureBox";
            İstanbulpictureBox.Size = new Size(269, 121);
            İstanbulpictureBox.TabIndex = 4;
            İstanbulpictureBox.TabStop = false;
            // 
            // İzmirpictureBox
            // 
            İzmirpictureBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            İzmirpictureBox.Image = Resources.izmir;
            İzmirpictureBox.Location = new Point(413, 293);
            İzmirpictureBox.Margin = new Padding(3, 2, 3, 2);
            İzmirpictureBox.Name = "İzmirpictureBox";
            İzmirpictureBox.Size = new Size(310, 162);
            İzmirpictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
            İzmirpictureBox.TabIndex = 5;
            İzmirpictureBox.TabStop = false;
            // 
            // mainPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.PowderBlue;
            ClientSize = new Size(684, 415);
            Controls.Add(İzmirpictureBox);
            Controls.Add(İstanbulpictureBox);
            Controls.Add(AnkarapictureBox);
            Controls.Add(CityComboBox);
            Controls.Add(label2);
            Controls.Add(mainPanel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 2, 3, 2);
            Name = "mainPage";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "GoTürkiye";
            FormClosed += mainPage_FormClosed;
            Load += mainPage_Load;
            mainPanel.ResumeLayout(false);
            mainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)AnkarapictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)İstanbulpictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)İzmirpictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel mainPanel;
        private Button MainSignOutButton;
        private Button button2;
        private Label label1;
        private Button button1;
        private Label label2;
        private ComboBox CityComboBox;
        private PictureBox AnkarapictureBox;
        private PictureBox İstanbulpictureBox;
        private PictureBox İzmirpictureBox;
    }
}
