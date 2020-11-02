namespace Project_PBO_Monopoly
{
    partial class Form_Loading
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>


        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblJudul = new System.Windows.Forms.Label();
            this.lblLoading = new System.Windows.Forms.Label();
            this.picMoon1 = new System.Windows.Forms.PictureBox();
            this.picMoon2 = new System.Windows.Forms.PictureBox();
            this.picMoon3 = new System.Windows.Forms.PictureBox();
            this.picMoon4 = new System.Windows.Forms.PictureBox();
            this.picMoon5 = new System.Windows.Forms.PictureBox();
            this.picRocket = new System.Windows.Forms.PictureBox();
            this.tmrTextLoading = new System.Windows.Forms.Timer(this.components);
            this.tmrRocket = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picMoon1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMoon2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMoon3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMoon4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMoon5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRocket)).BeginInit();
            this.SuspendLayout();
            // 
            // lblJudul
            // 
            this.lblJudul.AutoSize = true;
            this.lblJudul.BackColor = System.Drawing.SystemColors.Control;
            this.lblJudul.Font = new System.Drawing.Font("Jokerman", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJudul.ForeColor = System.Drawing.Color.White;
            this.lblJudul.Location = new System.Drawing.Point(324, 20);
            this.lblJudul.Name = "lblJudul";
            this.lblJudul.Size = new System.Drawing.Size(696, 140);
            this.lblJudul.TabIndex = 0;
            this.lblJudul.Text = "Now Loading";
            // 
            // lblLoading
            // 
            this.lblLoading.AutoSize = true;
            this.lblLoading.BackColor = System.Drawing.SystemColors.Control;
            this.lblLoading.Font = new System.Drawing.Font("Matura MT Script Capitals", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoading.ForeColor = System.Drawing.Color.White;
            this.lblLoading.Location = new System.Drawing.Point(195, 500);
            this.lblLoading.Name = "lblLoading";
            this.lblLoading.Size = new System.Drawing.Size(375, 25);
            this.lblLoading.TabIndex = 1;
            this.lblLoading.Text = "Starting Monopoly ... Please Wait ...";
            // 
            // picMoon1
            // 
            this.picMoon1.BackColor = System.Drawing.Color.Black;
            this.picMoon1.Location = new System.Drawing.Point(200, 340);
            this.picMoon1.Name = "picMoon1";
            this.picMoon1.Size = new System.Drawing.Size(100, 100);
            this.picMoon1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picMoon1.TabIndex = 2;
            this.picMoon1.TabStop = false;
            // 
            // picMoon2
            // 
            this.picMoon2.BackColor = System.Drawing.Color.Black;
            this.picMoon2.Location = new System.Drawing.Point(400, 340);
            this.picMoon2.Name = "picMoon2";
            this.picMoon2.Size = new System.Drawing.Size(100, 100);
            this.picMoon2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picMoon2.TabIndex = 3;
            this.picMoon2.TabStop = false;
            // 
            // picMoon3
            // 
            this.picMoon3.BackColor = System.Drawing.Color.Black;
            this.picMoon3.Location = new System.Drawing.Point(600, 340);
            this.picMoon3.Name = "picMoon3";
            this.picMoon3.Size = new System.Drawing.Size(100, 100);
            this.picMoon3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picMoon3.TabIndex = 4;
            this.picMoon3.TabStop = false;
            // 
            // picMoon4
            // 
            this.picMoon4.BackColor = System.Drawing.Color.Black;
            this.picMoon4.Location = new System.Drawing.Point(800, 340);
            this.picMoon4.Name = "picMoon4";
            this.picMoon4.Size = new System.Drawing.Size(100, 100);
            this.picMoon4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picMoon4.TabIndex = 5;
            this.picMoon4.TabStop = false;
            // 
            // picMoon5
            // 
            this.picMoon5.BackColor = System.Drawing.Color.Black;
            this.picMoon5.Location = new System.Drawing.Point(1000, 330);
            this.picMoon5.Name = "picMoon5";
            this.picMoon5.Size = new System.Drawing.Size(125, 125);
            this.picMoon5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picMoon5.TabIndex = 6;
            this.picMoon5.TabStop = false;
            // 
            // picRocket
            // 
            this.picRocket.Location = new System.Drawing.Point(40, 325);
            this.picRocket.Name = "picRocket";
            this.picRocket.Size = new System.Drawing.Size(125, 125);
            this.picRocket.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picRocket.TabIndex = 7;
            this.picRocket.TabStop = false;
            // 
            // tmrTextLoading
            // 
            this.tmrTextLoading.Enabled = true;
            this.tmrTextLoading.Interval = 10;
            this.tmrTextLoading.Tick += new System.EventHandler(this.tmrTextLoading_Tick);
            // 
            // tmrRocket
            // 
            this.tmrRocket.Enabled = true;
            this.tmrRocket.Interval = 10;
            this.tmrRocket.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // Form_Loading
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1344, 726);
            this.Controls.Add(this.picMoon5);
            this.Controls.Add(this.picMoon4);
            this.Controls.Add(this.picMoon3);
            this.Controls.Add(this.picMoon2);
            this.Controls.Add(this.picMoon1);
            this.Controls.Add(this.picRocket);
            this.Controls.Add(this.lblLoading);
            this.Controls.Add(this.lblJudul);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_Loading";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Loading";
            this.Load += new System.EventHandler(this.frmLoading_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picMoon1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMoon2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMoon3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMoon4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMoon5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRocket)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblJudul;
        private System.Windows.Forms.Label lblLoading;
        private System.Windows.Forms.PictureBox picMoon1;
        private System.Windows.Forms.PictureBox picMoon2;
        private System.Windows.Forms.PictureBox picMoon3;
        private System.Windows.Forms.PictureBox picMoon4;
        private System.Windows.Forms.PictureBox picMoon5;
        private System.Windows.Forms.PictureBox picRocket;
        private System.Windows.Forms.Timer tmrTextLoading;
        private System.Windows.Forms.Timer tmrRocket;
    }
}

