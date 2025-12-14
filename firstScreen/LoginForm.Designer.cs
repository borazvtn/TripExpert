
namespace firstScreen
{
    partial class LoginForm
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
            headerLabel = new Label();
            logmessageLabel = new Label();
            loginPanel = new Panel();
            LogtoSignLabel = new Label();
            logSignLabel = new Label();
            loginButton = new Button();
            logpassTextbox = new TextBox();
            logpassLabel = new Label();
            logUsernameLabel = new Label();
            logUsernameTextbox = new TextBox();
            loginPanel.SuspendLayout();
            SuspendLayout();
            // 
            // headerLabel
            // 
            headerLabel.AutoSize = true;
            headerLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            headerLabel.Location = new Point(262, 4);
            headerLabel.Name = "headerLabel";
            headerLabel.Size = new Size(129, 32);
            headerLabel.TabIndex = 0;
            headerLabel.Text = "GoTürkiye";
            // 
            // logmessageLabel
            // 
            logmessageLabel.AutoSize = true;
            logmessageLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            logmessageLabel.Location = new Point(10, 68);
            logmessageLabel.Name = "logmessageLabel";
            logmessageLabel.Size = new Size(159, 32);
            logmessageLabel.TabIndex = 1;
            logmessageLabel.Text = "Please log in";
            // 
            // loginPanel
            // 
            loginPanel.BorderStyle = BorderStyle.Fixed3D;
            loginPanel.Controls.Add(LogtoSignLabel);
            loginPanel.Controls.Add(logSignLabel);
            loginPanel.Controls.Add(loginButton);
            loginPanel.Controls.Add(logpassTextbox);
            loginPanel.Controls.Add(logpassLabel);
            loginPanel.Controls.Add(logUsernameLabel);
            loginPanel.Controls.Add(logUsernameTextbox);
            loginPanel.Location = new Point(177, 110);
            loginPanel.Margin = new Padding(3, 2, 3, 2);
            loginPanel.Name = "loginPanel";
            loginPanel.Size = new Size(338, 289);
            loginPanel.TabIndex = 2;
            // 
            // LogtoSignLabel
            // 
            LogtoSignLabel.AutoSize = true;
            LogtoSignLabel.Font = new Font("Microsoft YaHei UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LogtoSignLabel.ForeColor = Color.Crimson;
            LogtoSignLabel.Location = new Point(169, 235);
            LogtoSignLabel.Name = "LogtoSignLabel";
            LogtoSignLabel.Size = new Size(134, 19);
            LogtoSignLabel.TabIndex = 8;
            LogtoSignLabel.Text = "Create an account";
            LogtoSignLabel.Click += LogtoSignLabel_Click;
            // 
            // logSignLabel
            // 
            logSignLabel.AutoSize = true;
            logSignLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            logSignLabel.Location = new Point(3, 232);
            logSignLabel.Name = "logSignLabel";
            logSignLabel.Size = new Size(153, 21);
            logSignLabel.TabIndex = 7;
            logSignLabel.Text = "New to TripExpert?";
            // 
            // loginButton
            // 
            loginButton.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            loginButton.Location = new Point(84, 199);
            loginButton.Margin = new Padding(3, 2, 3, 2);
            loginButton.Name = "loginButton";
            loginButton.RightToLeft = RightToLeft.No;
            loginButton.Size = new Size(107, 28);
            loginButton.TabIndex = 5;
            loginButton.Text = "Log in";
            loginButton.UseVisualStyleBackColor = true;
            loginButton.Click += loginButton_Click;
            // 
            // logpassTextbox
            // 
            logpassTextbox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            logpassTextbox.Location = new Point(84, 152);
            logpassTextbox.Margin = new Padding(3, 2, 3, 2);
            logpassTextbox.Multiline = true;
            logpassTextbox.Name = "logpassTextbox";
            logpassTextbox.PasswordChar = '*';
            logpassTextbox.Size = new Size(198, 26);
            logpassTextbox.TabIndex = 4;
            // 
            // logpassLabel
            // 
            logpassLabel.AutoSize = true;
            logpassLabel.Font = new Font("Segoe UI Semibold", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            logpassLabel.Location = new Point(84, 122);
            logpassLabel.Name = "logpassLabel";
            logpassLabel.Size = new Size(105, 30);
            logpassLabel.TabIndex = 3;
            logpassLabel.Text = "Password";
            // 
            // logUsernameLabel
            // 
            logUsernameLabel.AutoSize = true;
            logUsernameLabel.Font = new Font("Segoe UI Semibold", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            logUsernameLabel.Location = new Point(84, 41);
            logUsernameLabel.Name = "logUsernameLabel";
            logUsernameLabel.Size = new Size(112, 30);
            logUsernameLabel.TabIndex = 2;
            logUsernameLabel.Text = "Username";
            // 
            // logUsernameTextbox
            // 
            logUsernameTextbox.Location = new Point(84, 72);
            logUsernameTextbox.Margin = new Padding(3, 2, 3, 2);
            logUsernameTextbox.Multiline = true;
            logUsernameTextbox.Name = "logUsernameTextbox";
            logUsernameTextbox.Size = new Size(198, 26);
            logUsernameTextbox.TabIndex = 0;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.PaleTurquoise;
            ClientSize = new Size(684, 415);
            Controls.Add(loginPanel);
            Controls.Add(logmessageLabel);
            Controls.Add(headerLabel);
            Margin = new Padding(3, 2, 3, 2);
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "GoTürkiye";
            
            loginPanel.ResumeLayout(false);
            loginPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label headerLabel;
        private Label logmessageLabel;
        private Panel loginPanel;
        private Button loginButton;
        private TextBox logpassTextbox;
        private Label logpassLabel;
        private Label logUsernameLabel;
        private TextBox logUsernameTextbox;
        private Label logSignLabel;
        private Label LogtoSignLabel;

        public EventHandler LoginForm_Load { get; private set; }
    }
}
