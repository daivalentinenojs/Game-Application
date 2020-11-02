namespace Project_PBO_Monopoly
{
    partial class Form_Main_Menu
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
            this.picNewGame = new System.Windows.Forms.PictureBox();
            this.picHighScores = new System.Windows.Forms.PictureBox();
            this.picExit = new System.Windows.Forms.PictureBox();
            this.picAbout = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picNewGame)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHighScores)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAbout)).BeginInit();
            this.SuspendLayout();
            // 
            // picNewGame
            // 
            this.picNewGame.BackColor = System.Drawing.Color.Transparent;
            this.picNewGame.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picNewGame.Location = new System.Drawing.Point(516, 302);
            this.picNewGame.Name = "picNewGame";
            this.picNewGame.Size = new System.Drawing.Size(311, 95);
            this.picNewGame.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picNewGame.TabIndex = 0;
            this.picNewGame.TabStop = false;
            this.picNewGame.Click += new System.EventHandler(this.picNewGame_Click);
            this.picNewGame.MouseLeave += new System.EventHandler(this.picNewGame_MouseLeave);
            this.picNewGame.MouseHover += new System.EventHandler(this.picNewGame_MouseHover);
            // 
            // picHighScores
            // 
            this.picHighScores.BackColor = System.Drawing.Color.Transparent;
            this.picHighScores.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picHighScores.Location = new System.Drawing.Point(516, 413);
            this.picHighScores.Name = "picHighScores";
            this.picHighScores.Size = new System.Drawing.Size(311, 95);
            this.picHighScores.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picHighScores.TabIndex = 2;
            this.picHighScores.TabStop = false;
            this.picHighScores.Click += new System.EventHandler(this.picHighScores_Click);
            this.picHighScores.MouseLeave += new System.EventHandler(this.picHighScores_MouseLeave);
            this.picHighScores.MouseHover += new System.EventHandler(this.picHighScores_MouseHover);
            // 
            // picExit
            // 
            this.picExit.BackColor = System.Drawing.Color.Transparent;
            this.picExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picExit.Location = new System.Drawing.Point(516, 637);
            this.picExit.Name = "picExit";
            this.picExit.Size = new System.Drawing.Size(311, 95);
            this.picExit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picExit.TabIndex = 3;
            this.picExit.TabStop = false;
            this.picExit.Click += new System.EventHandler(this.picExit_Click);
            this.picExit.MouseLeave += new System.EventHandler(this.picExit_MouseLeave);
            this.picExit.MouseHover += new System.EventHandler(this.picExit_MouseHover);
            // 
            // picAbout
            // 
            this.picAbout.BackColor = System.Drawing.Color.Transparent;
            this.picAbout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picAbout.Location = new System.Drawing.Point(516, 524);
            this.picAbout.Name = "picAbout";
            this.picAbout.Size = new System.Drawing.Size(311, 95);
            this.picAbout.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picAbout.TabIndex = 4;
            this.picAbout.TabStop = false;
            this.picAbout.Click += new System.EventHandler(this.picAbout_Click);
            this.picAbout.MouseLeave += new System.EventHandler(this.picAbout_MouseLeave);
            this.picAbout.MouseHover += new System.EventHandler(this.picAbout_MouseHover);
            // 
            // Form_Main_Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1354, 744);
            this.Controls.Add(this.picAbout);
            this.Controls.Add(this.picExit);
            this.Controls.Add(this.picHighScores);
            this.Controls.Add(this.picNewGame);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_Main_Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_Main_Menu";
            this.Load += new System.EventHandler(this.Form_Main_Menu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picNewGame)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHighScores)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAbout)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picNewGame;
        private System.Windows.Forms.PictureBox picHighScores;
        private System.Windows.Forms.PictureBox picExit;
        private System.Windows.Forms.PictureBox picAbout;


    }
}

