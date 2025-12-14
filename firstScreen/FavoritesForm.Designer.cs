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
            FavoriteToMain = new Button();
            panelMekanlar = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(299, 5);
            label1.Name = "label1";
            label1.Size = new Size(161, 41);
            label1.TabIndex = 0;
            label1.Text = "GoTürkiye";
            // 
            // FavoriteToMain
            // 
            FavoriteToMain.Location = new Point(11, 12);
            FavoriteToMain.Name = "FavoriteToMain";
            FavoriteToMain.Size = new Size(107, 41);
            FavoriteToMain.TabIndex = 10;
            FavoriteToMain.Text = "Main Page";
            FavoriteToMain.UseVisualStyleBackColor = true;
            FavoriteToMain.Click += FavoriteToMain_Click;
            // 
            // panelMekanlar
            // 
            panelMekanlar.AutoScroll = true;
            panelMekanlar.Location = new Point(14, 76);
            panelMekanlar.Margin = new Padding(3, 4, 3, 4);
            panelMekanlar.Name = "panelMekanlar";
            panelMekanlar.Size = new Size(754, 461);
            panelMekanlar.TabIndex = 12;
            // 
            // FavoritesForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.PowderBlue;
            ClientSize = new Size(782, 553);
            Controls.Add(panelMekanlar);
            Controls.Add(FavoriteToMain);
            Controls.Add(label1);
            Name = "FavoritesForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "GoTürkiye";
            Load += FavoritesForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button FavoriteToMain;
        private FlowLayoutPanel panelMekanlar;
    }
}