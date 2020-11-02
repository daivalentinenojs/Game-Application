namespace MIB_2015
{
    partial class kykAudi
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(kykAudi));
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label15 = new System.Windows.Forms.Label();
            this.p1slh = new System.Windows.Forms.Label();
            this.p1bnr = new System.Windows.Forms.Label();
            this.p1seri = new System.Windows.Forms.Label();
            this.p1kalah = new System.Windows.Forms.Label();
            this.p1menang = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label16 = new System.Windows.Forms.Label();
            this.p2slh = new System.Windows.Forms.Label();
            this.p2bnr = new System.Windows.Forms.Label();
            this.p2seri = new System.Windows.Forms.Label();
            this.p2kalah = new System.Windows.Forms.Label();
            this.p2menang = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.tmrP2Gerak = new System.Windows.Forms.Timer(this.components);
            this.tmrp1Gerak = new System.Windows.Forms.Timer(this.components);
            this.label17 = new System.Windows.Forms.Label();
            this.timer4 = new System.Windows.Forms.Timer(this.components);
            this.timer5 = new System.Windows.Forms.Timer(this.components);
            this.picExit = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picExit)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(157, 128);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(160, 338);
            this.pictureBox2.TabIndex = 50;
            this.pictureBox2.TabStop = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Berlin Sans FB", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(190, 107);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(114, 18);
            this.label15.TabIndex = 43;
            this.label15.Text = "Jumlah benar: 0";
            // 
            // p1slh
            // 
            this.p1slh.AutoSize = true;
            this.p1slh.BackColor = System.Drawing.Color.DarkRed;
            this.p1slh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.p1slh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.p1slh.Font = new System.Drawing.Font("Berlin Sans FB", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.p1slh.ForeColor = System.Drawing.Color.White;
            this.p1slh.Location = new System.Drawing.Point(193, 515);
            this.p1slh.Name = "p1slh";
            this.p1slh.Size = new System.Drawing.Size(97, 36);
            this.p1slh.TabIndex = 42;
            this.p1slh.Text = "Salah!";
            this.p1slh.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.p1slh.Visible = false;
            // 
            // p1bnr
            // 
            this.p1bnr.AutoSize = true;
            this.p1bnr.BackColor = System.Drawing.Color.RoyalBlue;
            this.p1bnr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.p1bnr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.p1bnr.Font = new System.Drawing.Font("Berlin Sans FB", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.p1bnr.Location = new System.Drawing.Point(185, 515);
            this.p1bnr.Name = "p1bnr";
            this.p1bnr.Size = new System.Drawing.Size(103, 36);
            this.p1bnr.TabIndex = 41;
            this.p1bnr.Text = "Benar!";
            this.p1bnr.Visible = false;
            // 
            // p1seri
            // 
            this.p1seri.AutoSize = true;
            this.p1seri.BackColor = System.Drawing.Color.Lime;
            this.p1seri.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.p1seri.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.p1seri.Font = new System.Drawing.Font("Berlin Sans FB", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.p1seri.Location = new System.Drawing.Point(207, 476);
            this.p1seri.Name = "p1seri";
            this.p1seri.Size = new System.Drawing.Size(73, 36);
            this.p1seri.TabIndex = 40;
            this.p1seri.Text = "SERI";
            this.p1seri.Visible = false;
            // 
            // p1kalah
            // 
            this.p1kalah.AutoSize = true;
            this.p1kalah.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.p1kalah.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.p1kalah.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.p1kalah.Font = new System.Drawing.Font("Berlin Sans FB", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.p1kalah.Location = new System.Drawing.Point(182, 476);
            this.p1kalah.Name = "p1kalah";
            this.p1kalah.Size = new System.Drawing.Size(122, 36);
            this.p1kalah.TabIndex = 39;
            this.p1kalah.Text = "KALAH!\r\n";
            this.p1kalah.Visible = false;
            // 
            // p1menang
            // 
            this.p1menang.AutoSize = true;
            this.p1menang.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.p1menang.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.p1menang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.p1menang.Font = new System.Drawing.Font("Berlin Sans FB", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.p1menang.Location = new System.Drawing.Point(167, 476);
            this.p1menang.Name = "p1menang";
            this.p1menang.Size = new System.Drawing.Size(147, 36);
            this.p1menang.TabIndex = 38;
            this.p1menang.Text = "MENANG!";
            this.p1menang.Visible = false;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Location = new System.Drawing.Point(21, 554);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(469, 60);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Berlin Sans FB", 29.25F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(170, 687);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(151, 49);
            this.label7.TabIndex = 44;
            this.label7.Text = "Skor: 0";
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox3.Location = new System.Drawing.Point(705, 130);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(150, 338);
            this.pictureBox3.TabIndex = 51;
            this.pictureBox3.TabStop = false;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("Berlin Sans FB", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(724, 107);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(114, 18);
            this.label16.TabIndex = 45;
            this.label16.Text = "Jumlah benar: 0";
            // 
            // p2slh
            // 
            this.p2slh.AutoSize = true;
            this.p2slh.BackColor = System.Drawing.Color.DarkRed;
            this.p2slh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.p2slh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.p2slh.Font = new System.Drawing.Font("Berlin Sans FB", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.p2slh.ForeColor = System.Drawing.Color.White;
            this.p2slh.Location = new System.Drawing.Point(733, 515);
            this.p2slh.Name = "p2slh";
            this.p2slh.Size = new System.Drawing.Size(97, 36);
            this.p2slh.TabIndex = 43;
            this.p2slh.Text = "Salah!";
            this.p2slh.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.p2slh.Visible = false;
            // 
            // p2bnr
            // 
            this.p2bnr.AutoSize = true;
            this.p2bnr.BackColor = System.Drawing.Color.RoyalBlue;
            this.p2bnr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.p2bnr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.p2bnr.Font = new System.Drawing.Font("Berlin Sans FB", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.p2bnr.Location = new System.Drawing.Point(727, 515);
            this.p2bnr.Name = "p2bnr";
            this.p2bnr.Size = new System.Drawing.Size(103, 36);
            this.p2bnr.TabIndex = 42;
            this.p2bnr.Text = "Benar!";
            this.p2bnr.Visible = false;
            // 
            // p2seri
            // 
            this.p2seri.AutoSize = true;
            this.p2seri.BackColor = System.Drawing.Color.Lime;
            this.p2seri.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.p2seri.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.p2seri.Font = new System.Drawing.Font("Berlin Sans FB", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.p2seri.Location = new System.Drawing.Point(745, 476);
            this.p2seri.Name = "p2seri";
            this.p2seri.Size = new System.Drawing.Size(73, 36);
            this.p2seri.TabIndex = 41;
            this.p2seri.Text = "SERI";
            this.p2seri.Visible = false;
            this.p2seri.Click += new System.EventHandler(this.p2seri_Click);
            // 
            // p2kalah
            // 
            this.p2kalah.AutoSize = true;
            this.p2kalah.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.p2kalah.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.p2kalah.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.p2kalah.Font = new System.Drawing.Font("Berlin Sans FB", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.p2kalah.Location = new System.Drawing.Point(722, 476);
            this.p2kalah.Name = "p2kalah";
            this.p2kalah.Size = new System.Drawing.Size(122, 36);
            this.p2kalah.TabIndex = 40;
            this.p2kalah.Text = "KALAH!";
            this.p2kalah.Visible = false;
            // 
            // p2menang
            // 
            this.p2menang.AutoSize = true;
            this.p2menang.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.p2menang.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.p2menang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.p2menang.Font = new System.Drawing.Font("Berlin Sans FB", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.p2menang.Location = new System.Drawing.Point(705, 476);
            this.p2menang.Name = "p2menang";
            this.p2menang.Size = new System.Drawing.Size(147, 36);
            this.p2menang.TabIndex = 39;
            this.p2menang.Text = "MENANG!";
            this.p2menang.Visible = false;
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Transparent;
            this.groupBox4.Location = new System.Drawing.Point(537, 554);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(468, 60);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Berlin Sans FB", 29.25F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(704, 687);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(151, 49);
            this.label8.TabIndex = 44;
            this.label8.Text = "Skor: 0";
            // 
            // timer1
            // 
            this.timer1.Interval = 1500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 1;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Berlin Sans FB", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(460, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 32);
            this.label2.TabIndex = 47;
            this.label2.Text = "30:00";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // timer3
            // 
            this.timer3.Interval = 1500;
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Berlin Sans FB", 19.8F);
            this.label3.Location = new System.Drawing.Point(436, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(155, 30);
            this.label3.TabIndex = 49;
            this.label3.Text = "Sisa waktu:  ";
            // 
            // tmrP2Gerak
            // 
            this.tmrP2Gerak.Interval = 200;
            this.tmrP2Gerak.Tick += new System.EventHandler(this.tmrP2Gerak_Tick);
            // 
            // tmrp1Gerak
            // 
            this.tmrp1Gerak.Interval = 200;
            this.tmrp1Gerak.Tick += new System.EventHandler(this.tmrp1Gerak_Tick);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Blue;
            this.label17.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.Yellow;
            this.label17.Location = new System.Drawing.Point(466, 200);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(101, 110);
            this.label17.TabIndex = 50;
            this.label17.Text = "3";
            // 
            // timer4
            // 
            this.timer4.Enabled = true;
            this.timer4.Interval = 1000;
            this.timer4.Tick += new System.EventHandler(this.timer4_Tick);
            // 
            // timer5
            // 
            this.timer5.Interval = 3000;
            this.timer5.Tick += new System.EventHandler(this.timer5_Tick);
            // 
            // picExit
            // 
            this.picExit.BackColor = System.Drawing.Color.Transparent;
            this.picExit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picExit.BackgroundImage")));
            this.picExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picExit.Location = new System.Drawing.Point(982, 2);
            this.picExit.Name = "picExit";
            this.picExit.Size = new System.Drawing.Size(40, 40);
            this.picExit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picExit.TabIndex = 51;
            this.picExit.TabStop = false;
            this.picExit.Click += new System.EventHandler(this.picExit_Click);
            this.picExit.MouseLeave += new System.EventHandler(this.picExit_MouseLeave);
            this.picExit.MouseHover += new System.EventHandler(this.picExit_MouseHover);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(1027, 387);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 52;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            this.textBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyUp);
            // 
            // kykAudi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.p1slh);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.p1bnr);
            this.Controls.Add(this.picExit);
            this.Controls.Add(this.p1seri);
            this.Controls.Add(this.p1kalah);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.p1menang);
            this.Controls.Add(this.p2slh);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.p2bnr);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.p2seri);
            this.Controls.Add(this.p2kalah);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.p2menang);
            this.Controls.Add(this.label3);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "kykAudi";
            this.Text = "kykAudi";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.kykAudi_FormClosed);
            this.Load += new System.EventHandler(this.kykAudi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picExit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label p1slh;
        private System.Windows.Forms.Label p1bnr;
        private System.Windows.Forms.Label p1seri;
        private System.Windows.Forms.Label p1kalah;
        private System.Windows.Forms.Label p1menang;
        private System.Windows.Forms.Label p2slh;
        private System.Windows.Forms.Label p2bnr;
        private System.Windows.Forms.Label p2seri;
        private System.Windows.Forms.Label p2kalah;
        private System.Windows.Forms.Label p2menang;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Timer tmrP2Gerak;
        private System.Windows.Forms.Timer tmrp1Gerak;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Timer timer4;
        private System.Windows.Forms.Timer timer5;
        private System.Windows.Forms.PictureBox picExit;
        private System.Windows.Forms.TextBox textBox1;
    }
}