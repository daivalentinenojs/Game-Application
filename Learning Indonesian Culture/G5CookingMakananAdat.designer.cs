namespace MIB_2015
{
    partial class picMakananP1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(picMakananP1));
            this.lblHasil = new System.Windows.Forms.Label();
            this.lblDetik = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tmrG5 = new System.Windows.Forms.Timer(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.picBahanP1 = new System.Windows.Forms.PictureBox();
            this.picHiddenP1 = new System.Windows.Forms.PictureBox();
            this.picMakanP1 = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tmrHidden1 = new System.Windows.Forms.Timer(this.components);
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.picBahanP2 = new System.Windows.Forms.PictureBox();
            this.picHiddenP2 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.picMakanP2 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.tmrHidden2 = new System.Windows.Forms.Timer(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.picExit = new System.Windows.Forms.PictureBox();
            this.pp2 = new System.Windows.Forms.Label();
            this.pp1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.label17 = new System.Windows.Forms.Label();
            this.p1Kanan = new System.Windows.Forms.PictureBox();
            this.p1Kiri = new System.Windows.Forms.PictureBox();
            this.p2Kiri = new System.Windows.Forms.PictureBox();
            this.p2Kanan = new System.Windows.Forms.PictureBox();
            this.p1BS = new System.Windows.Forms.PictureBox();
            this.p2BS = new System.Windows.Forms.PictureBox();
            this.tmrSalahP1 = new System.Windows.Forms.Timer(this.components);
            this.tmrSalahP2 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picBahanP1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHiddenP1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMakanP1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBahanP2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHiddenP2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMakanP2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.p1Kanan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.p1Kiri)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.p2Kiri)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.p2Kanan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.p1BS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.p2BS)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHasil
            // 
            this.lblHasil.AutoSize = true;
            this.lblHasil.BackColor = System.Drawing.Color.Transparent;
            this.lblHasil.Font = new System.Drawing.Font("Berlin Sans FB", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHasil.ForeColor = System.Drawing.Color.Black;
            this.lblHasil.Location = new System.Drawing.Point(559, 85);
            this.lblHasil.Name = "lblHasil";
            this.lblHasil.Size = new System.Drawing.Size(290, 37);
            this.lblHasil.TabIndex = 107;
            this.lblHasil.Text = "Pemain 1 Menang !";
            this.lblHasil.Visible = false;
            // 
            // lblDetik
            // 
            this.lblDetik.AutoSize = true;
            this.lblDetik.BackColor = System.Drawing.Color.Transparent;
            this.lblDetik.Font = new System.Drawing.Font("Berlin Sans FB", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetik.ForeColor = System.Drawing.Color.Black;
            this.lblDetik.Location = new System.Drawing.Point(607, 48);
            this.lblDetik.Name = "lblDetik";
            this.lblDetik.Size = new System.Drawing.Size(122, 37);
            this.lblDetik.TabIndex = 106;
            this.lblDetik.Text = "00 : 00";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Berlin Sans FB", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(596, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 37);
            this.label2.TabIndex = 105;
            this.label2.Text = "Time Left";
            // 
            // tmrG5
            // 
            this.tmrG5.Interval = 1000;
            this.tmrG5.Tick += new System.EventHandler(this.tmrG5_Tick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Tempus Sans ITC", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(616, 223);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 37);
            this.label6.TabIndex = 117;
            this.label6.Text = "00 : 00";
            this.label6.Visible = false;
            // 
            // picBahanP1
            // 
            this.picBahanP1.BackColor = System.Drawing.Color.Transparent;
            this.picBahanP1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picBahanP1.Location = new System.Drawing.Point(324, 348);
            this.picBahanP1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picBahanP1.Name = "picBahanP1";
            this.picBahanP1.Size = new System.Drawing.Size(69, 65);
            this.picBahanP1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBahanP1.TabIndex = 119;
            this.picBahanP1.TabStop = false;
            // 
            // picHiddenP1
            // 
            this.picHiddenP1.BackColor = System.Drawing.Color.Transparent;
            this.picHiddenP1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picHiddenP1.Location = new System.Drawing.Point(324, 348);
            this.picHiddenP1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picHiddenP1.Name = "picHiddenP1";
            this.picHiddenP1.Size = new System.Drawing.Size(69, 65);
            this.picHiddenP1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picHiddenP1.TabIndex = 121;
            this.picHiddenP1.TabStop = false;
            this.picHiddenP1.Visible = false;
            // 
            // picMakanP1
            // 
            this.picMakanP1.BackColor = System.Drawing.Color.Transparent;
            this.picMakanP1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picMakanP1.Location = new System.Drawing.Point(228, 92);
            this.picMakanP1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picMakanP1.Name = "picMakanP1";
            this.picMakanP1.Size = new System.Drawing.Size(259, 156);
            this.picMakanP1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picMakanP1.TabIndex = 122;
            this.picMakanP1.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Tempus Sans ITC", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(616, 260);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(114, 37);
            this.label8.TabIndex = 123;
            this.label8.Text = "00 : 00";
            this.label8.Visible = false;
            // 
            // tmrHidden1
            // 
            this.tmrHidden1.Tick += new System.EventHandler(this.tmrHidden1_Tick);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Tempus Sans ITC", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(616, 394);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(114, 37);
            this.label12.TabIndex = 125;
            this.label12.Text = "00 : 00";
            this.label12.Visible = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Tempus Sans ITC", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(616, 431);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(114, 37);
            this.label13.TabIndex = 124;
            this.label13.Text = "00 : 00";
            this.label13.Visible = false;
            // 
            // picBahanP2
            // 
            this.picBahanP2.BackColor = System.Drawing.Color.Transparent;
            this.picBahanP2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picBahanP2.Location = new System.Drawing.Point(960, 348);
            this.picBahanP2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picBahanP2.Name = "picBahanP2";
            this.picBahanP2.Size = new System.Drawing.Size(69, 65);
            this.picBahanP2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBahanP2.TabIndex = 127;
            this.picBahanP2.TabStop = false;
            // 
            // picHiddenP2
            // 
            this.picHiddenP2.BackColor = System.Drawing.Color.Transparent;
            this.picHiddenP2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picHiddenP2.Location = new System.Drawing.Point(960, 348);
            this.picHiddenP2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picHiddenP2.Name = "picHiddenP2";
            this.picHiddenP2.Size = new System.Drawing.Size(69, 65);
            this.picHiddenP2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picHiddenP2.TabIndex = 128;
            this.picHiddenP2.TabStop = false;
            this.picHiddenP2.Visible = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(215, 79);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(283, 185);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 130;
            this.pictureBox2.TabStop = false;
            // 
            // picMakanP2
            // 
            this.picMakanP2.BackColor = System.Drawing.Color.Transparent;
            this.picMakanP2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picMakanP2.Location = new System.Drawing.Point(867, 78);
            this.picMakanP2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picMakanP2.Name = "picMakanP2";
            this.picMakanP2.Size = new System.Drawing.Size(259, 156);
            this.picMakanP2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picMakanP2.TabIndex = 131;
            this.picMakanP2.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox5.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox5.BackgroundImage")));
            this.pictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox5.Location = new System.Drawing.Point(855, 64);
            this.pictureBox5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(283, 185);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 132;
            this.pictureBox5.TabStop = false;
            // 
            // tmrHidden2
            // 
            this.tmrHidden2.Tick += new System.EventHandler(this.tmrHidden2_Tick);
            // 
            // timer1
            // 
            this.timer1.Interval = 3000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // picExit
            // 
            this.picExit.BackColor = System.Drawing.Color.Transparent;
            this.picExit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picExit.BackgroundImage")));
            this.picExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picExit.Location = new System.Drawing.Point(1309, 2);
            this.picExit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.picExit.Name = "picExit";
            this.picExit.Size = new System.Drawing.Size(53, 49);
            this.picExit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picExit.TabIndex = 133;
            this.picExit.TabStop = false;
            this.picExit.Click += new System.EventHandler(this.picExit_Click);
            this.picExit.MouseLeave += new System.EventHandler(this.picExit_MouseLeave);
            this.picExit.MouseHover += new System.EventHandler(this.picExit_MouseHover);
            // 
            // pp2
            // 
            this.pp2.AutoSize = true;
            this.pp2.BackColor = System.Drawing.Color.Transparent;
            this.pp2.Font = new System.Drawing.Font("Berlin Sans FB", 29.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pp2.ForeColor = System.Drawing.Color.White;
            this.pp2.Location = new System.Drawing.Point(1119, 832);
            this.pp2.Name = "pp2";
            this.pp2.Size = new System.Drawing.Size(57, 60);
            this.pp2.TabIndex = 137;
            this.pp2.Text = "0";
            // 
            // pp1
            // 
            this.pp1.AutoSize = true;
            this.pp1.BackColor = System.Drawing.Color.Transparent;
            this.pp1.Font = new System.Drawing.Font("Berlin Sans FB", 29.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pp1.ForeColor = System.Drawing.Color.White;
            this.pp1.Location = new System.Drawing.Point(437, 832);
            this.pp1.Name = "pp1";
            this.pp1.Size = new System.Drawing.Size(57, 60);
            this.pp1.TabIndex = 136;
            this.pp1.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Berlin Sans FB", 29.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(947, 832);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(154, 60);
            this.label4.TabIndex = 135;
            this.label4.Text = "Skor :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Berlin Sans FB", 29.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(265, 832);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(154, 60);
            this.label5.TabIndex = 134;
            this.label5.Text = "Skor :";
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Blue;
            this.label17.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.Yellow;
            this.label17.Location = new System.Drawing.Point(613, 278);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(127, 137);
            this.label17.TabIndex = 138;
            this.label17.Text = "3";
            // 
            // p1Kanan
            // 
            this.p1Kanan.BackColor = System.Drawing.Color.Transparent;
            this.p1Kanan.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("p1Kanan.BackgroundImage")));
            this.p1Kanan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.p1Kanan.Location = new System.Drawing.Point(399, 364);
            this.p1Kanan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.p1Kanan.Name = "p1Kanan";
            this.p1Kanan.Size = new System.Drawing.Size(35, 35);
            this.p1Kanan.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.p1Kanan.TabIndex = 139;
            this.p1Kanan.TabStop = false;
            // 
            // p1Kiri
            // 
            this.p1Kiri.BackColor = System.Drawing.Color.Transparent;
            this.p1Kiri.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("p1Kiri.BackgroundImage")));
            this.p1Kiri.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.p1Kiri.Location = new System.Drawing.Point(283, 364);
            this.p1Kiri.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.p1Kiri.Name = "p1Kiri";
            this.p1Kiri.Size = new System.Drawing.Size(35, 35);
            this.p1Kiri.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.p1Kiri.TabIndex = 140;
            this.p1Kiri.TabStop = false;
            // 
            // p2Kiri
            // 
            this.p2Kiri.BackColor = System.Drawing.Color.Transparent;
            this.p2Kiri.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("p2Kiri.BackgroundImage")));
            this.p2Kiri.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.p2Kiri.Location = new System.Drawing.Point(919, 364);
            this.p2Kiri.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.p2Kiri.Name = "p2Kiri";
            this.p2Kiri.Size = new System.Drawing.Size(35, 35);
            this.p2Kiri.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.p2Kiri.TabIndex = 142;
            this.p2Kiri.TabStop = false;
            // 
            // p2Kanan
            // 
            this.p2Kanan.BackColor = System.Drawing.Color.Transparent;
            this.p2Kanan.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("p2Kanan.BackgroundImage")));
            this.p2Kanan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.p2Kanan.Location = new System.Drawing.Point(1035, 364);
            this.p2Kanan.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.p2Kanan.Name = "p2Kanan";
            this.p2Kanan.Size = new System.Drawing.Size(35, 35);
            this.p2Kanan.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.p2Kanan.TabIndex = 141;
            this.p2Kanan.TabStop = false;
            // 
            // p1BS
            // 
            this.p1BS.BackColor = System.Drawing.Color.Transparent;
            this.p1BS.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.p1BS.Location = new System.Drawing.Point(342, 309);
            this.p1BS.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.p1BS.Name = "p1BS";
            this.p1BS.Size = new System.Drawing.Size(35, 35);
            this.p1BS.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.p1BS.TabIndex = 143;
            this.p1BS.TabStop = false;
            this.p1BS.Visible = false;
            // 
            // p2BS
            // 
            this.p2BS.BackColor = System.Drawing.Color.Transparent;
            this.p2BS.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.p2BS.Location = new System.Drawing.Point(974, 309);
            this.p2BS.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.p2BS.Name = "p2BS";
            this.p2BS.Size = new System.Drawing.Size(35, 35);
            this.p2BS.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.p2BS.TabIndex = 144;
            this.p2BS.TabStop = false;
            this.p2BS.Visible = false;
            // 
            // tmrSalahP1
            // 
            this.tmrSalahP1.Tick += new System.EventHandler(this.tmrSalahP1_Tick);
            // 
            // tmrSalahP2
            // 
            this.tmrSalahP2.Tick += new System.EventHandler(this.tmrSalahP2_Tick);
            // 
            // picMakananP1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1365, 945);
            this.Controls.Add(this.p2BS);
            this.Controls.Add(this.p1BS);
            this.Controls.Add(this.p2Kiri);
            this.Controls.Add(this.p2Kanan);
            this.Controls.Add(this.p1Kiri);
            this.Controls.Add(this.p1Kanan);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.pp2);
            this.Controls.Add(this.pp1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.picExit);
            this.Controls.Add(this.picMakanP2);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.picBahanP2);
            this.Controls.Add(this.picHiddenP2);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.picMakanP1);
            this.Controls.Add(this.picBahanP1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblHasil);
            this.Controls.Add(this.lblDetik);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.picHiddenP1);
            this.Controls.Add(this.pictureBox2);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "picMakananP1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.picMakananP1_FormClosed);
            this.Load += new System.EventHandler(this.G5CookingMakananAdat_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.picMakananP1_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.picMakananP1_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.picMakananP1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.picBahanP1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHiddenP1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMakanP1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBahanP2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHiddenP2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMakanP2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.p1Kanan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.p1Kiri)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.p2Kiri)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.p2Kanan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.p1BS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.p2BS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHasil;
        private System.Windows.Forms.Label lblDetik;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer tmrG5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox picBahanP1;
        private System.Windows.Forms.PictureBox picHiddenP1;
        private System.Windows.Forms.PictureBox picMakanP1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Timer tmrHidden1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.PictureBox picBahanP2;
        private System.Windows.Forms.PictureBox picHiddenP2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox picMakanP2;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Timer tmrHidden2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox picExit;
        private System.Windows.Forms.Label pp2;
        private System.Windows.Forms.Label pp1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.PictureBox p1Kanan;
        private System.Windows.Forms.PictureBox p1Kiri;
        private System.Windows.Forms.PictureBox p2Kiri;
        private System.Windows.Forms.PictureBox p2Kanan;
        private System.Windows.Forms.PictureBox p1BS;
        private System.Windows.Forms.PictureBox p2BS;
        private System.Windows.Forms.Timer tmrSalahP1;
        private System.Windows.Forms.Timer tmrSalahP2;
    }
}