namespace firstScreen
{
    partial class ProfileForm
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
            ProfileToMain = new Button();
            ProfileLabel = new Label();
            ProfilePanel = new Panel();
            label2 = new Label();
            label1 = new Label();
            ProfileNameLabel = new Label();
            ProfileSignOutButton = new Button();
            ProfileUserNameLabel = new Label();
            ProfilePanel.SuspendLayout();
            SuspendLayout();
            // 
            // ProfileToMain
            // 
            ProfileToMain.Location = new Point(-3, 5);
            ProfileToMain.Name = "ProfileToMain";
            ProfileToMain.Size = new Size(108, 41);
            ProfileToMain.TabIndex = 0;
            ProfileToMain.Text = "Main Page";
            ProfileToMain.UseVisualStyleBackColor = true;
            ProfileToMain.Click += ProfileToMain_Click;
            // 
            // ProfileLabel
            // 
            ProfileLabel.AutoSize = true;
            ProfileLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ProfileLabel.Location = new Point(300, 5);
            ProfileLabel.Name = "ProfileLabel";
            ProfileLabel.Size = new Size(112, 41);
            ProfileLabel.TabIndex = 1;
            ProfileLabel.Text = "Profile";
            // 
            // ProfilePanel
            // 
            ProfilePanel.BackColor = Color.MediumTurquoise;
            ProfilePanel.Controls.Add(label2);
            ProfilePanel.Controls.Add(label1);
            ProfilePanel.Controls.Add(ProfileNameLabel);
            ProfilePanel.Controls.Add(ProfileSignOutButton);
            ProfilePanel.Controls.Add(ProfileUserNameLabel);
            ProfilePanel.Location = new Point(-3, 72);
            ProfilePanel.Name = "ProfilePanel";
            ProfilePanel.Size = new Size(784, 469);
            ProfilePanel.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(15, 176);
            label2.Name = "label2";
            label2.Size = new Size(50, 20);
            label2.TabIndex = 6;
            label2.Text = "label2";
            // 
            // label1
            // 
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(100, 23);
            label1.TabIndex = 0;
            // 
            // ProfileNameLabel
            // 
            ProfileNameLabel.AutoSize = true;
            ProfileNameLabel.Location = new Point(15, 87);
            ProfileNameLabel.Name = "ProfileNameLabel";
            ProfileNameLabel.Size = new Size(40, 20);
            ProfileNameLabel.TabIndex = 5;
            ProfileNameLabel.Text = "bora";
            // 
            // ProfileSignOutButton
            // 
            ProfileSignOutButton.BackColor = Color.LightSteelBlue;
            ProfileSignOutButton.FlatStyle = FlatStyle.Popup;
            ProfileSignOutButton.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            ProfileSignOutButton.Location = new Point(650, 421);
            ProfileSignOutButton.Name = "ProfileSignOutButton";
            ProfileSignOutButton.Size = new Size(134, 48);
            ProfileSignOutButton.TabIndex = 4;
            ProfileSignOutButton.Text = "Sign out";
            ProfileSignOutButton.UseVisualStyleBackColor = false;
            ProfileSignOutButton.Click += ProfileSignOutButton_Click;
            // 
            // ProfileUserNameLabel
            // 
            ProfileUserNameLabel.AutoSize = true;
            ProfileUserNameLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ProfileUserNameLabel.Location = new Point(15, 23);
            ProfileUserNameLabel.Name = "ProfileUserNameLabel";
            ProfileUserNameLabel.Size = new Size(108, 28);
            ProfileUserNameLabel.TabIndex = 3;
            ProfileUserNameLabel.Text = "asdasdasd";
            // 
            // ProfileForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.PowderBlue;
            ClientSize = new Size(782, 553);
            Controls.Add(ProfilePanel);
            Controls.Add(ProfileLabel);
            Controls.Add(ProfileToMain);
            Name = "ProfileForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TripExpert";
            ProfilePanel.ResumeLayout(false);
            ProfilePanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button ProfileToMain;
        private Label ProfileLabel;
        private Panel ProfilePanel;
        private Button ProfileSignOutButton;
        private Label ProfileUserNameLabel;
        private Label label1;
        private Label ProfileNameLabel;
        private Label label2;
    }
}
