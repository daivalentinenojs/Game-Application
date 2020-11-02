namespace Core_DB_Competition
{
    partial class Form_About
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
            this.picSound = new System.Windows.Forms.PictureBox();
            this.picExit = new System.Windows.Forms.PictureBox();
            this.picBack = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picSound)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBack)).BeginInit();
            this.SuspendLayout();
            // 
            // picSound
            // 
            this.picSound.BackColor = System.Drawing.Color.Transparent;
            this.picSound.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picSound.Location = new System.Drawing.Point(828, 20);
            this.picSound.Name = "picSound";
            this.picSound.Size = new System.Drawing.Size(78, 76);
            this.picSound.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picSound.TabIndex = 8;
            this.picSound.TabStop = false;
            this.picSound.Click += new System.EventHandler(this.picSound_Click);
            // 
            // picExit
            // 
            this.picExit.BackColor = System.Drawing.Color.Transparent;
            this.picExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picExit.Location = new System.Drawing.Point(924, 20);
            this.picExit.Name = "picExit";
            this.picExit.Size = new System.Drawing.Size(78, 76);
            this.picExit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picExit.TabIndex = 7;
            this.picExit.TabStop = false;
            this.picExit.Click += new System.EventHandler(this.picExit_Click);
            this.picExit.MouseLeave += new System.EventHandler(this.picExit_MouseLeave);
            this.picExit.MouseHover += new System.EventHandler(this.picExit_MouseHover);
            // 
            // picBack
            // 
            this.picBack.BackColor = System.Drawing.Color.Transparent;
            this.picBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picBack.Location = new System.Drawing.Point(12, 677);
            this.picBack.Name = "picBack";
            this.picBack.Size = new System.Drawing.Size(183, 79);
            this.picBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBack.TabIndex = 9;
            this.picBack.TabStop = false;
            this.picBack.Click += new System.EventHandler(this.picBack_Click);
            this.picBack.MouseLeave += new System.EventHandler(this.picBack_MouseLeave);
            this.picBack.MouseHover += new System.EventHandler(this.picBack_MouseHover);
            // 
            // Form_About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.picBack);
            this.Controls.Add(this.picSound);
            this.Controls.Add(this.picExit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_About";
            this.Text = "Form_About";
            this.Load += new System.EventHandler(this.Form_About_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picSound)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBack)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picSound;
        private System.Windows.Forms.PictureBox picExit;
        private System.Windows.Forms.PictureBox picBack;
    }
}