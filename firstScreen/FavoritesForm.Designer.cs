namespace firstScreen
{
    partial class FavoritesForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            FavoritePictureBox1 = new PictureBox();
            FavoritePictureBox2 = new PictureBox();
            FavoritePictureBox3 = new PictureBox();
            FavoriteNameLabel1 = new Label();
            FavoriteNameLabel2 = new Label();
            FavoriteNameLabel3 = new Label();
            isFavoritecheckBox1 = new CheckBox();
            isFavoritecheckBox2 = new CheckBox();
            isFavoritecheckBox3 = new CheckBox();
            FavoriteToMain = new Button();
            FavoriteNextButton = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)FavoritePictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)FavoritePictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)FavoritePictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(300, 5);
            label1.Name = "label1";
            label1.Size = new Size(161, 41);
            label1.TabIndex = 0;
            label1.Text = "GoTürkiye";
            // 
            // FavoritePictureBox1
            // 
            FavoritePictureBox1.Location = new Point(12, 98);
            FavoritePictureBox1.Name = "FavoritePictureBox1";
            FavoritePictureBox1.Size = new Size(200, 100);
            FavoritePictureBox1.TabIndex = 1;
            FavoritePictureBox1.TabStop = false;
            // 
            // FavoritePictureBox2
            // 
            FavoritePictureBox2.Location = new Point(12, 225);
            FavoritePictureBox2.Name = "FavoritePictureBox2";
            FavoritePictureBox2.Size = new Size(200, 100);
            FavoritePictureBox2.TabIndex = 2;
            FavoritePictureBox2.TabStop = false;
            // 
            // FavoritePictureBox3
            // 
            FavoritePictureBox3.Location = new Point(12, 354);
            FavoritePictureBox3.Name = "FavoritePictureBox3";
            FavoritePictureBox3.Size = new Size(200, 100);
            FavoritePictureBox3.TabIndex = 3;
            FavoritePictureBox3.TabStop = false;
            // 
            // FavoriteNameLabel1
            // 
            FavoriteNameLabel1.AutoSize = true;
            FavoriteNameLabel1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FavoriteNameLabel1.Location = new Point(261, 98);
            FavoriteNameLabel1.Name = "FavoriteNameLabel1";
            FavoriteNameLabel1.Size = new Size(122, 28);
            FavoriteNameLabel1.TabIndex = 4;
            FavoriteNameLabel1.Text = "mekan1 adi";
            // 
            // FavoriteNameLabel2
            // 
            FavoriteNameLabel2.AutoSize = true;
            FavoriteNameLabel2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FavoriteNameLabel2.Location = new Point(261, 225);
            FavoriteNameLabel2.Name = "FavoriteNameLabel2";
            FavoriteNameLabel2.Size = new Size(122, 28);
            FavoriteNameLabel2.TabIndex = 5;
            FavoriteNameLabel2.Text = "mekan2 adi";
            // 
            // FavoriteNameLabel3
            // 
            FavoriteNameLabel3.AutoSize = true;
            FavoriteNameLabel3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FavoriteNameLabel3.Location = new Point(261, 354);
            FavoriteNameLabel3.Name = "FavoriteNameLabel3";
            FavoriteNameLabel3.Size = new Size(122, 28);
            FavoriteNameLabel3.TabIndex = 6;
            FavoriteNameLabel3.Text = "mekan3 adi";
            // 
            // isFavoritecheckBox1
            // 
            isFavoritecheckBox1.AutoSize = true;
            isFavoritecheckBox1.Location = new Point(470, 98);
            isFavoritecheckBox1.Name = "isFavoritecheckBox1";
            isFavoritecheckBox1.Size = new Size(83, 24);
            isFavoritecheckBox1.TabIndex = 7;
            isFavoritecheckBox1.Text = "Favorite";
            isFavoritecheckBox1.UseVisualStyleBackColor = true;
            // 
            // isFavoritecheckBox2
            // 
            isFavoritecheckBox2.AutoSize = true;
            isFavoritecheckBox2.Location = new Point(470, 225);
            isFavoritecheckBox2.Name = "isFavoritecheckBox2";
            isFavoritecheckBox2.Size = new Size(83, 24);
            isFavoritecheckBox2.TabIndex = 8;
            isFavoritecheckBox2.Text = "Favorite";
            isFavoritecheckBox2.UseVisualStyleBackColor = true;
            // 
            // isFavoritecheckBox3
            // 
            isFavoritecheckBox3.AutoSize = true;
            isFavoritecheckBox3.Location = new Point(470, 354);
            isFavoritecheckBox3.Name = "isFavoritecheckBox3";
            isFavoritecheckBox3.Size = new Size(83, 24);
            isFavoritecheckBox3.TabIndex = 9;
            isFavoritecheckBox3.Text = "Favorite";
            isFavoritecheckBox3.UseVisualStyleBackColor = true;
            // 
            // FavoriteToMain
            // 
            FavoriteToMain.Location = new Point(12, 12);
            FavoriteToMain.Name = "FavoriteToMain";
            FavoriteToMain.Size = new Size(108, 41);
            FavoriteToMain.TabIndex = 10;
            FavoriteToMain.Text = "Main Page";
            FavoriteToMain.UseVisualStyleBackColor = true;
            FavoriteToMain.Click += FavoriteToMain_Click;
            // 
            // FavoriteNextButton
            // 
            FavoriteNextButton.Location = new Point(672, 510);
            FavoriteNextButton.Name = "FavoriteNextButton";
            FavoriteNextButton.Size = new Size(108, 41);
            FavoriteNextButton.TabIndex = 11;
            FavoriteNextButton.Text = "Next Page";
            FavoriteNextButton.UseVisualStyleBackColor = true;
            FavoriteNextButton.Click += FavoriteNextButton_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(12, 478);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(200, 100);
            pictureBox1.TabIndex = 12;
            pictureBox1.TabStop = false;
            // 
            // FavoritesForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.PowderBlue;
            ClientSize = new Size(782, 553);
            Controls.Add(pictureBox1);
            Controls.Add(FavoriteNextButton);
            Controls.Add(FavoriteToMain);
            Controls.Add(isFavoritecheckBox3);
            Controls.Add(isFavoritecheckBox2);
            Controls.Add(isFavoritecheckBox1);
            Controls.Add(FavoriteNameLabel3);
            Controls.Add(FavoriteNameLabel2);
            Controls.Add(FavoriteNameLabel1);
            Controls.Add(FavoritePictureBox3);
            Controls.Add(FavoritePictureBox2);
            Controls.Add(FavoritePictureBox1);
            Controls.Add(label1);
            Name = "FavoritesForm";
            Text = "GoTürkiye";
            ((System.ComponentModel.ISupportInitialize)FavoritePictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)FavoritePictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)FavoritePictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private PictureBox FavoritePictureBox1;
        private PictureBox FavoritePictureBox2;
        private PictureBox FavoritePictureBox3;
        private Label FavoriteNameLabel1;
        private Label FavoriteNameLabel2;
        private Label FavoriteNameLabel3;
        private CheckBox isFavoritecheckBox1;
        private CheckBox isFavoritecheckBox2;
        private CheckBox isFavoritecheckBox3;
        private Button FavoriteToMain;
        private Button FavoriteNextButton;
        private PictureBox pictureBox1;
    }
}