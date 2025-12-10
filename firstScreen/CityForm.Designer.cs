namespace firstScreen
{
    partial class CityForm
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
            CityNameLabel = new Label();
            pictureBox1 = new PictureBox();
            mekan1Label = new Label();
            mekan2Label = new Label();
            mekan3Label = new Label();
            panel1 = new Panel();
            CityMessageLabel = new Label();
            CityToMainButton = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // CityNameLabel
            // 
            CityNameLabel.AutoSize = true;
            CityNameLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CityNameLabel.Location = new Point(322, 5);
            CityNameLabel.Name = "CityNameLabel";
            CityNameLabel.Size = new Size(0, 41);
            CityNameLabel.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(82, 49);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(600, 220);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // mekan1Label
            // 
            mekan1Label.AutoSize = true;
            mekan1Label.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            mekan1Label.Location = new Point(20, 86);
            mekan1Label.Name = "mekan1Label";
            mekan1Label.Size = new Size(0, 28);
            mekan1Label.TabIndex = 2;
            // 
            // mekan2Label
            // 
            mekan2Label.AutoSize = true;
            mekan2Label.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            mekan2Label.Location = new Point(17, 141);
            mekan2Label.Name = "mekan2Label";
            mekan2Label.Size = new Size(0, 28);
            mekan2Label.TabIndex = 3;
            // 
            // mekan3Label
            // 
            mekan3Label.AutoSize = true;
            mekan3Label.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            mekan3Label.Location = new Point(17, 198);
            mekan3Label.Name = "mekan3Label";
            mekan3Label.Size = new Size(0, 28);
            mekan3Label.TabIndex = 4;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(CityMessageLabel);
            panel1.Controls.Add(mekan3Label);
            panel1.Controls.Add(mekan1Label);
            panel1.Controls.Add(mekan2Label);
            panel1.Location = new Point(82, 293);
            panel1.Name = "panel1";
            panel1.Size = new Size(600, 248);
            panel1.TabIndex = 5;
            // 
            // CityMessageLabel
            // 
            CityMessageLabel.AutoSize = true;
            CityMessageLabel.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CityMessageLabel.Location = new Point(20, 11);
            CityMessageLabel.Name = "CityMessageLabel";
            CityMessageLabel.Size = new Size(242, 31);
            CityMessageLabel.TabIndex = 5;
            CityMessageLabel.Text = "Three popular places:";
            // 
            // CityToMainButton
            // 
            CityToMainButton.Location = new Point(5, 5);
            CityToMainButton.Name = "CityToMainButton";
            CityToMainButton.Size = new Size(86, 41);
            CityToMainButton.TabIndex = 6;
            CityToMainButton.Text = "Main Page";
            CityToMainButton.UseVisualStyleBackColor = true;
            CityToMainButton.Click += CityToMainButton_Click;
            // 
            // CityForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.PowderBlue;
            ClientSize = new Size(782, 553);
            Controls.Add(CityToMainButton);
            Controls.Add(panel1);
            Controls.Add(pictureBox1);
            Controls.Add(CityNameLabel);
            Name = "CityForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TripExpert";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label CityNameLabel;
        private PictureBox pictureBox1;
        private Label mekan1Label;
        private Label mekan2Label;
        private Label mekan3Label;
        private Panel panel1;
        private Label CityMessageLabel;
        private Button CityToMainButton;
    }
}
