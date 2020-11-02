namespace Core_DB_Competition
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
            this.picExit = new System.Windows.Forms.PictureBox();
            this.picNewGame = new System.Windows.Forms.PictureBox();
            this.picSound = new System.Windows.Forms.PictureBox();
            this.picAbout = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picNewGame)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSound)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAbout)).BeginInit();
            this.SuspendLayout();
            // 
            // picExit
            // 
            this.picExit.BackColor = System.Drawing.Color.Transparent;
            this.picExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picExit.Location = new System.Drawing.Point(934, 12);
            this.picExit.Name = "picExit";
            this.picExit.Size = new System.Drawing.Size(78, 76);
            this.picExit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picExit.TabIndex = 5;
            this.picExit.TabStop = false;
            this.picExit.Click += new System.EventHandler(this.picExit_Click);
            this.picExit.MouseLeave += new System.EventHandler(this.picExit_MouseLeave);
            this.picExit.MouseHover += new System.EventHandler(this.picExit_MouseHover);
            // 
            // picNewGame
            // 
            this.picNewGame.BackColor = System.Drawing.Color.Transparent;
            this.picNewGame.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picNewGame.Location = new System.Drawing.Point(332, 536);
            this.picNewGame.Name = "picNewGame";
            this.picNewGame.Size = new System.Drawing.Size(351, 111);
            this.picNewGame.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picNewGame.TabIndex = 4;
            this.picNewGame.TabStop = false;
            this.picNewGame.Click += new System.EventHandler(this.picNewGame_Click);
            this.picNewGame.MouseLeave += new System.EventHandler(this.picNewGame_MouseLeave);
            this.picNewGame.MouseHover += new System.EventHandler(this.picNewGame_MouseHover);
            // 
            // picSound
            // 
            this.picSound.BackColor = System.Drawing.Color.Transparent;
            this.picSound.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picSound.Location = new System.Drawing.Point(838, 12);
            this.picSound.Name = "picSound";
            this.picSound.Size = new System.Drawing.Size(78, 76);
            this.picSound.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picSound.TabIndex = 6;
            this.picSound.TabStop = false;
            this.picSound.Click += new System.EventHandler(this.picSound_Click);
            // 
            // picAbout
            // 
            this.picAbout.BackColor = System.Drawing.Color.Transparent;
            this.picAbout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picAbout.Location = new System.Drawing.Point(736, 12);
            this.picAbout.Name = "picAbout";
            this.picAbout.Size = new System.Drawing.Size(78, 76);
            this.picAbout.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picAbout.TabIndex = 7;
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
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.picAbout);
            this.Controls.Add(this.picSound);
            this.Controls.Add(this.picExit);
            this.Controls.Add(this.picNewGame);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_Main_Menu";
            this.Text = "Form_Main_Menu";
            this.Load += new System.EventHandler(this.Form_Main_Menu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picNewGame)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSound)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAbout)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picExit;
        private System.Windows.Forms.PictureBox picNewGame;
        private System.Windows.Forms.PictureBox picSound;
        private System.Windows.Forms.PictureBox picAbout;
    }
}

