﻿namespace Penjadwalan_CPU
{
    partial class Story_Line_4
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
            this.picBack = new System.Windows.Forms.PictureBox();
            this.picNext = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picBack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picNext)).BeginInit();
            this.SuspendLayout();
            // 
            // picBack
            // 
            this.picBack.BackColor = System.Drawing.Color.Transparent;
            this.picBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picBack.Location = new System.Drawing.Point(10, 280);
            this.picBack.Name = "picBack";
            this.picBack.Size = new System.Drawing.Size(135, 43);
            this.picBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBack.TabIndex = 3;
            this.picBack.TabStop = false;
            this.picBack.Click += new System.EventHandler(this.picBack_Click);
            this.picBack.MouseLeave += new System.EventHandler(this.picBack_MouseLeave);
            this.picBack.MouseHover += new System.EventHandler(this.picBack_MouseHover);
            // 
            // picNext
            // 
            this.picNext.BackColor = System.Drawing.Color.Transparent;
            this.picNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picNext.Location = new System.Drawing.Point(516, 282);
            this.picNext.Name = "picNext";
            this.picNext.Size = new System.Drawing.Size(135, 43);
            this.picNext.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picNext.TabIndex = 2;
            this.picNext.TabStop = false;
            this.picNext.Click += new System.EventHandler(this.picNext_Click);
            this.picNext.MouseLeave += new System.EventHandler(this.picNext_MouseLeave);
            this.picNext.MouseHover += new System.EventHandler(this.picNext_MouseHover);
            // 
            // Story_Line_4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 332);
            this.Controls.Add(this.picBack);
            this.Controls.Add(this.picNext);
            this.Name = "Story_Line_4";
            this.Text = "Story_Line_4";
            this.Load += new System.EventHandler(this.Story_Line_4_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picNext)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picBack;
        private System.Windows.Forms.PictureBox picNext;
    }
}