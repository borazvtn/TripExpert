namespace firstScreen
{
    partial class signupForm
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
            signupHeader = new Label();
            signmessageLabel = new Label();
            signPanel = new Panel();
            label1 = new Label();
            signLoglabel = new Label();
            signupButton = new Button();
            signpasstextBox = new TextBox();
            signUsernametextBox = new TextBox();
            signnametextBox = new TextBox();
            signUsernameLabel = new Label();
            signpassLabel = new Label();
            signnameLabel = new Label();
            signPanel.SuspendLayout();
            SuspendLayout();
            // 
            // signupHeader
            // 
            signupHeader.AutoSize = true;
            signupHeader.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            signupHeader.Location = new Point(300, 5);
            signupHeader.Name = "signupHeader";
            signupHeader.Size = new Size(161, 41);
            signupHeader.TabIndex = 0;
            signupHeader.Text = "GoTürkiye";
            // 
            // signmessageLabel
            // 
            signmessageLabel.AutoSize = true;
            signmessageLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            signmessageLabel.Location = new Point(12, 62);
            signmessageLabel.Name = "signmessageLabel";
            signmessageLabel.Size = new Size(218, 41);
            signmessageLabel.TabIndex = 1;
            signmessageLabel.Text = "Please sign up";
            // 
            // signPanel
            // 
            signPanel.BorderStyle = BorderStyle.Fixed3D;
            signPanel.Controls.Add(label1);
            signPanel.Controls.Add(signLoglabel);
            signPanel.Controls.Add(signupButton);
            signPanel.Controls.Add(signpasstextBox);
            signPanel.Controls.Add(signUsernametextBox);
            signPanel.Controls.Add(signnametextBox);
            signPanel.Controls.Add(signUsernameLabel);
            signPanel.Controls.Add(signpassLabel);
            signPanel.Controls.Add(signnameLabel);
            signPanel.Location = new Point(144, 106);
            signPanel.Name = "signPanel";
            signPanel.Size = new Size(508, 435);
            signPanel.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft YaHei UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Crimson;
            label1.Location = new Point(274, 316);
            label1.Name = "label1";
            label1.Size = new Size(62, 24);
            label1.TabIndex = 10;
            label1.Text = "Log in";
            label1.Click += label1_Click;
            // 
            // signLoglabel
            // 
            signLoglabel.AutoSize = true;
            signLoglabel.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            signLoglabel.Location = new Point(61, 317);
            signLoglabel.Name = "signLoglabel";
            signLoglabel.Size = new Size(207, 23);
            signLoglabel.TabIndex = 9;
            signLoglabel.Text = "Already have an account?";
            // 
            // signupButton
            // 
            signupButton.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            signupButton.Location = new Point(154, 277);
            signupButton.Name = "signupButton";
            signupButton.Size = new Size(120, 36);
            signupButton.TabIndex = 8;
            signupButton.Text = "Sign up";
            signupButton.UseVisualStyleBackColor = true;
            signupButton.Click += signupButton_Click;
            // 
            // signpasstextBox
            // 
            signpasstextBox.Location = new Point(154, 228);
            signpasstextBox.Name = "signpasstextBox";
            signpasstextBox.Size = new Size(167, 27);
            signpasstextBox.TabIndex = 7;
            // 
            // signUsernametextBox
            // 
            signUsernametextBox.Location = new Point(154, 138);
            signUsernametextBox.Name = "signUsernametextBox";
            signUsernametextBox.Size = new Size(167, 27);
            signUsernametextBox.TabIndex = 6;
            // 
            // signnametextBox
            // 
            signnametextBox.Location = new Point(154, 50);
            signnametextBox.Name = "signnametextBox";
            signnametextBox.Size = new Size(167, 27);
            signnametextBox.TabIndex = 4;
            // 
            // signUsernameLabel
            // 
            signUsernameLabel.AutoSize = true;
            signUsernameLabel.Font = new Font("Segoe UI Semibold", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            signUsernameLabel.Location = new Point(154, 97);
            signUsernameLabel.Name = "signUsernameLabel";
            signUsernameLabel.Size = new Size(145, 38);
            signUsernameLabel.TabIndex = 3;
            signUsernameLabel.Text = "Username";
            // 
            // signpassLabel
            // 
            signpassLabel.AutoSize = true;
            signpassLabel.Font = new Font("Segoe UI Semibold", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            signpassLabel.Location = new Point(154, 187);
            signpassLabel.Name = "signpassLabel";
            signpassLabel.Size = new Size(136, 38);
            signpassLabel.TabIndex = 2;
            signpassLabel.Text = "Password";
            // 
            // signnameLabel
            // 
            signnameLabel.AutoSize = true;
            signnameLabel.Font = new Font("Segoe UI Semibold", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            signnameLabel.Location = new Point(154, 9);
            signnameLabel.Name = "signnameLabel";
            signnameLabel.Size = new Size(93, 38);
            signnameLabel.TabIndex = 0;
            signnameLabel.Text = "Name";
            // 
            // signupForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.PaleTurquoise;
            ClientSize = new Size(782, 553);
            Controls.Add(signPanel);
            Controls.Add(signmessageLabel);
            Controls.Add(signupHeader);
            Name = "signupForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "GoTürkiye";
            signPanel.ResumeLayout(false);
            signPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label signupHeader;
        private Label signmessageLabel;
        private Panel signPanel;
        private TextBox signUsernametextBox;
        private TextBox signnametextBox;
        private Label signUsernameLabel;
        private Label signpassLabel;
        private Label signnameLabel;
        private Button signupButton;
        private TextBox signpasstextBox;
        private Label label1;
        private Label signLoglabel;
    }
}
