namespace firstScreen
{
    partial class firstScreen
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
            firstmessageLabel = new Label();
            firstsignButton = new Button();
            firstlogButton = new Button();
            SuspendLayout();
            // 
            // headerLabel
            // 
            headerLabel.AutoSize = true;
            headerLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            headerLabel.Location = new Point(300, 5);
            headerLabel.Name = "headerLabel";
            headerLabel.Size = new Size(161, 41);
            headerLabel.TabIndex = 0;
            headerLabel.Text = "GoTürkiye";
            // 
            // firstmessageLabel
            // 
            firstmessageLabel.AutoSize = true;
            firstmessageLabel.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            firstmessageLabel.Location = new Point(22, 73);
            firstmessageLabel.Name = "firstmessageLabel";
            firstmessageLabel.Size = new Size(740, 38);
            firstmessageLabel.TabIndex = 1;
            firstmessageLabel.Text = "If you have an account please log in else please sign up";
            // 
            // firstsignButton
            // 
            firstsignButton.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            firstsignButton.Location = new Point(300, 349);
            firstsignButton.Name = "firstsignButton";
            firstsignButton.Size = new Size(131, 54);
            firstsignButton.TabIndex = 2;
            firstsignButton.Text = "Sign up";
            firstsignButton.UseVisualStyleBackColor = true;
            firstsignButton.Click += firstsignButton_Click;
            // 
            // firstlogButton
            // 
            firstlogButton.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            firstlogButton.Location = new Point(300, 222);
            firstlogButton.Name = "firstlogButton";
            firstlogButton.Size = new Size(131, 54);
            firstlogButton.TabIndex = 3;
            firstlogButton.Text = "Log in";
            firstlogButton.UseVisualStyleBackColor = true;
            firstlogButton.Click += firstlogButton_Click;
            // 
            // firstScreen
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.PaleTurquoise;
            ClientSize = new Size(782, 553);
            Controls.Add(firstlogButton);
            Controls.Add(firstsignButton);
            Controls.Add(firstmessageLabel);
            Controls.Add(headerLabel);
            Name = "firstScreen";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "GoTürkiye";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label headerLabel;
        private Label firstmessageLabel;
        private Button firstsignButton;
        private Button firstlogButton;
    }
}
