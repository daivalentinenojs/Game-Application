namespace Project_PBO_Monopoly
{
    partial class Form_Exit
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
            this.picYes = new System.Windows.Forms.PictureBox();
            this.picNo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picYes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picNo)).BeginInit();
            this.SuspendLayout();
            // 
            // picYes
            // 
            this.picYes.BackColor = System.Drawing.Color.Transparent;
            this.picYes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picYes.Location = new System.Drawing.Point(375, 248);
            this.picYes.Name = "picYes";
            this.picYes.Size = new System.Drawing.Size(187, 124);
            this.picYes.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picYes.TabIndex = 0;
            this.picYes.TabStop = false;
            this.picYes.Click += new System.EventHandler(this.picYes_Click);
            this.picYes.MouseLeave += new System.EventHandler(this.picYes_MouseLeave);
            this.picYes.MouseHover += new System.EventHandler(this.picYes_MouseHover);
            // 
            // picNo
            // 
            this.picNo.BackColor = System.Drawing.Color.Transparent;
            this.picNo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picNo.Location = new System.Drawing.Point(829, 243);
            this.picNo.Name = "picNo";
            this.picNo.Size = new System.Drawing.Size(184, 129);
            this.picNo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picNo.TabIndex = 1;
            this.picNo.TabStop = false;
            this.picNo.Click += new System.EventHandler(this.picNo_Click);
            this.picNo.MouseLeave += new System.EventHandler(this.picNo_MouseLeave);
            this.picNo.MouseHover += new System.EventHandler(this.picNo_MouseHover);
            // 
            // Form_Exit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1354, 744);
            this.Controls.Add(this.picNo);
            this.Controls.Add(this.picYes);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_Exit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_Exit";
            this.Load += new System.EventHandler(this.Form_Exit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picYes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picNo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picYes;
        private System.Windows.Forms.PictureBox picNo;
    }
}