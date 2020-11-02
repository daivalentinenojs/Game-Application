namespace Project_PBO_Monopoly
{
    partial class Form_High_Scores
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
            this.lblHighScore1 = new System.Windows.Forms.Label();
            this.lblHighScore2 = new System.Windows.Forms.Label();
            this.lblHighScore3 = new System.Windows.Forms.Label();
            this.picBack = new System.Windows.Forms.PictureBox();
            this.lblHighScore5 = new System.Windows.Forms.Label();
            this.lblHighScore4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picBack)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHighScore1
            // 
            this.lblHighScore1.AutoSize = true;
            this.lblHighScore1.BackColor = System.Drawing.Color.Transparent;
            this.lblHighScore1.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHighScore1.Location = new System.Drawing.Point(682, 148);
            this.lblHighScore1.Name = "lblHighScore1";
            this.lblHighScore1.Size = new System.Drawing.Size(68, 29);
            this.lblHighScore1.TabIndex = 6;
            this.lblHighScore1.Text = "label1";
            // 
            // lblHighScore2
            // 
            this.lblHighScore2.AutoSize = true;
            this.lblHighScore2.BackColor = System.Drawing.Color.Transparent;
            this.lblHighScore2.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHighScore2.Location = new System.Drawing.Point(678, 262);
            this.lblHighScore2.Name = "lblHighScore2";
            this.lblHighScore2.Size = new System.Drawing.Size(72, 29);
            this.lblHighScore2.TabIndex = 7;
            this.lblHighScore2.Text = "label2";
            // 
            // lblHighScore3
            // 
            this.lblHighScore3.AutoSize = true;
            this.lblHighScore3.BackColor = System.Drawing.Color.Transparent;
            this.lblHighScore3.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHighScore3.Location = new System.Drawing.Point(682, 377);
            this.lblHighScore3.Name = "lblHighScore3";
            this.lblHighScore3.Size = new System.Drawing.Size(72, 29);
            this.lblHighScore3.TabIndex = 8;
            this.lblHighScore3.Text = "label3";
            // 
            // picBack
            // 
            this.picBack.BackColor = System.Drawing.Color.Transparent;
            this.picBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picBack.Location = new System.Drawing.Point(1109, 637);
            this.picBack.Name = "picBack";
            this.picBack.Size = new System.Drawing.Size(233, 91);
            this.picBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBack.TabIndex = 9;
            this.picBack.TabStop = false;
            this.picBack.Click += new System.EventHandler(this.picBack_Click);
            this.picBack.MouseLeave += new System.EventHandler(this.picBack_MouseLeave);
            this.picBack.MouseHover += new System.EventHandler(this.picBack_MouseHover);
            // 
            // lblHighScore5
            // 
            this.lblHighScore5.AutoSize = true;
            this.lblHighScore5.BackColor = System.Drawing.Color.Transparent;
            this.lblHighScore5.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHighScore5.Location = new System.Drawing.Point(686, 596);
            this.lblHighScore5.Name = "lblHighScore5";
            this.lblHighScore5.Size = new System.Drawing.Size(72, 29);
            this.lblHighScore5.TabIndex = 13;
            this.lblHighScore5.Text = "label3";
            // 
            // lblHighScore4
            // 
            this.lblHighScore4.AutoSize = true;
            this.lblHighScore4.BackColor = System.Drawing.Color.Transparent;
            this.lblHighScore4.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHighScore4.Location = new System.Drawing.Point(682, 481);
            this.lblHighScore4.Name = "lblHighScore4";
            this.lblHighScore4.Size = new System.Drawing.Size(72, 29);
            this.lblHighScore4.TabIndex = 12;
            this.lblHighScore4.Text = "label2";
            // 
            // Form_High_Scores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1354, 744);
            this.Controls.Add(this.lblHighScore5);
            this.Controls.Add(this.lblHighScore4);
            this.Controls.Add(this.picBack);
            this.Controls.Add(this.lblHighScore3);
            this.Controls.Add(this.lblHighScore2);
            this.Controls.Add(this.lblHighScore1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_High_Scores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_High_Scores";
            this.Load += new System.EventHandler(this.Form_High_Scores_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBack)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHighScore1;
        private System.Windows.Forms.Label lblHighScore2;
        private System.Windows.Forms.Label lblHighScore3;
        private System.Windows.Forms.PictureBox picBack;
        private System.Windows.Forms.Label lblHighScore5;
        private System.Windows.Forms.Label lblHighScore4;
    }
}