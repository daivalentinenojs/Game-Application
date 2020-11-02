using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Penjadwalan_CPU
{
    public partial class CPU_FCFS : Form
    {
        public CPU_FCFS()
        {
            InitializeComponent();
        }

        double number = 1;
        double hasil = 0;
        double tunggu = 0;
        double ulang = 1;
        double totalaverage = 0;
        int[] timer = new int[1000];
        double[] average = new double[1000];
        int avg = 0;
        int kotak = 0;
        int kosong;
        int tambah2 = 0;

        System.Media.SoundPlayer SoundChange = new System.Media.SoundPlayer(Application.StartupPath + "\\Music\\LowBell.wav");
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtTime.Text != "" && double.Parse(txtTime.Text) >= 0)
            {

                #region Baru
                if (txtProses.Text == "1")
                {
                    PB1.Visible = true;
                    P1.Visible = true;
                    PB1.Maximum = int.Parse(txtTime.Text);
                }
                else if (txtProses.Text == "2")
                {
                    PB2.Visible = true;
                    P2.Visible = true;
                    PB2.Maximum = int.Parse(txtTime.Text);
                }
                else if (txtProses.Text == "3")
                {
                    PB3.Visible = true;
                    P3.Visible = true;
                    PB3.Maximum = int.Parse(txtTime.Text);
                }
                else if (txtProses.Text == "4")
                {
                    PB4.Visible = true;
                    P4.Visible = true;
                    PB4.Maximum = int.Parse(txtTime.Text);
                }
                else if (txtProses.Text == "5")
                {
                    PB5.Visible = true;
                    P5.Visible = true;
                    PB5.Maximum = int.Parse(txtTime.Text);
                }
                else if (txtProses.Text == "6")
                {
                    PB6.Visible = true;
                    P6.Visible = true;
                    PB6.Maximum = int.Parse(txtTime.Text);
                }
                else if (txtProses.Text == "7")
                {
                    PB7.Visible = true;
                    P7.Visible = true;
                    PB7.Maximum = int.Parse(txtTime.Text);
                }
                else if (txtProses.Text == "8")
                {
                    PB8.Visible = true;
                    P8.Visible = true;
                    PB8.Maximum = int.Parse(txtTime.Text);
                }
                else if (txtProses.Text == "9")
                {
                    PB9.Visible = true;
                    P9.Visible = true;
                    PB9.Maximum = int.Parse(txtTime.Text);
                }
                else if (txtProses.Text == "10")
                {
                    PB10.Visible = true;
                    P10.Visible = true;
                    PB10.Maximum = int.Parse(txtTime.Text);
                }
                else if (txtProses.Text == "11")
                {
                    PB11.Visible = true;
                    P11.Visible = true;
                    PB11.Maximum = int.Parse(txtTime.Text);
                }
                else if (txtProses.Text == "12")
                {
                    PB12.Visible = true;
                    P12.Visible = true;
                    PB12.Maximum = int.Parse(txtTime.Text);
                }
                else if (txtProses.Text == "13")
                {
                    PB13.Visible = true;
                    P13.Visible = true;
                    PB13.Maximum = int.Parse(txtTime.Text);
                }
                else if (txtProses.Text == "14")
                {
                    PB14.Visible = true;
                    P14.Visible = true;
                    PB14.Maximum = int.Parse(txtTime.Text);
                }
                else if (txtProses.Text == "15")
                {
                    PB15.Visible = true;
                    P15.Visible = true;
                    PB15.Maximum = int.Parse(txtTime.Text);
                }
                else if (txtProses.Text == "16")
                {
                    PB16.Visible = true;
                    P16.Visible = true;
                    PB16.Maximum = int.Parse(txtTime.Text);
                }
                else if (txtProses.Text == "17")
                {
                    PB17.Visible = true;
                    P17.Visible = true;
                    PB17.Maximum = int.Parse(txtTime.Text);
                }
                else if (txtProses.Text == "18")
                {
                    PB18.Visible = true;
                    P18.Visible = true;
                    PB18.Maximum = int.Parse(txtTime.Text);
                }
                else if (txtProses.Text == "19")
                {
                    PB19.Visible = true;
                    P19.Visible = true;
                    PB19.Maximum = int.Parse(txtTime.Text);
                }
                else if (txtProses.Text == "20")
                {
                    PB20.Visible = true;
                    P20.Visible = true;
                    PB20.Maximum = int.Parse(txtTime.Text);
                }
                else if (txtProses.Text == "21")
                {
                    PB21.Visible = true;
                    P21.Visible = true;
                    PB21.Maximum = int.Parse(txtTime.Text);
                }
                else if (txtProses.Text == "22")
                {
                    PB22.Visible = true;
                    P22.Visible = true;
                    PB22.Maximum = int.Parse(txtTime.Text);
                }
                else if (txtProses.Text == "23")
                {
                    PB23.Visible = true;
                    P23.Visible = true;
                    PB23.Maximum = int.Parse(txtTime.Text);
                }
                else if (txtProses.Text == "24")
                {
                    PB24.Visible = true;
                    P24.Visible = true;
                    PB24.Maximum = int.Parse(txtTime.Text);
                }
                else if (txtProses.Text == "25")
                {
                    PB25.Visible = true;
                    P25.Visible = true;
                    PB25.Maximum = int.Parse(txtTime.Text);
                }
                #endregion

                #region Lama
                kosong = 0;
                txtProses.Text = (number + 1).ToString();
                lstNumber.Items.Add(number);
                lstProses.Items.Add("P" + number);
                btnPlay.Enabled = true;
                if (number < 10)
                {
                    if (tunggu < 10)
                    {
                        lstWTime.Items.Add("   P0" + number + "                     0" + tunggu);
                    }
                    else
                    {
                        lstWTime.Items.Add("   P0" + number + "                     " + tunggu);
                    }
                }
                else
                {
                    lstWTime.Items.Add("   P" + number + "                     " + tunggu);
                }

                average[avg] = double.Parse(txtTime.Text);
                lstTime.Items.Add(double.Parse(txtTime.Text));
                timer[kotak] = int.Parse(txtTime.Text);
                kotak++;
                avg++;
                hasil += double.Parse(txtTime.Text);
                txtRata.Text = Math.Round((totalaverage / (lstTime.Items.Count - 1)), 2).ToString();
                tunggu = hasil;

                txtTime.Text = "";
                txtTime.Focus();
                number++;

                for (int i = 0; i < 1000; i++)
                {
                    if (timer[i] != 0)
                    { kosong++; }
                    if (average[i]!=0)
                    {
                        totalaverage += average[i];
                    }
                }
            #endregion
            }
            else if (txtTime.Text == "")
            {
                MessageBox.Show("Silahkan Masukkan Nilai Burst Time !!", "Peringatan !");
            }
            else if (double.Parse(txtTime.Text) < 0)
            {
                MessageBox.Show("Nilai Burst Time Tidak Dapat Negatif !!", "Peringatan !");
            }
            
        }

        private void CPU_FCFS_Load(object sender, EventArgs e)
        {
            btnReset.Enabled = false;
            btnPlay.Enabled = false;
            lblGambar1.Text = "";
            txtProses.Text = "1";
            label5.Visible = false;
            lblTimer.Visible = false;
            lblCheck.Visible = false;
            //tbProcess.Visible = false;
            this.BackgroundImage = Image.FromFile(Application.StartupPath + "\\CPU_FCFS\\LBA_SweetSensation_PP10.jpg");
            picBack.Image = Image.FromFile(Application.StartupPath + "\\StoryLine\\Kembali.png");
            picNext.Image = Image.FromFile(Application.StartupPath + "\\StoryLine\\Lanjut.png");

            pictureBox1.Image = Image.FromFile(Application.StartupPath + "\\CPU_FCFS\\0.png");
            pictureBox2.Image = Image.FromFile(Application.StartupPath + "\\CPU_FCFS\\0.png");
            pictureBox3.Image = Image.FromFile(Application.StartupPath + "\\CPU_FCFS\\0.png");
            pictureBox4.Image = Image.FromFile(Application.StartupPath + "\\CPU_FCFS\\0.png");
            pictureBox5.Image = Image.FromFile(Application.StartupPath + "\\CPU_FCFS\\0.png");
            pictureBox6.Image = Image.FromFile(Application.StartupPath + "\\CPU_FCFS\\0.png");
            pictureBox7.Image = Image.FromFile(Application.StartupPath + "\\CPU_FCFS\\0.png");
            pictureBox8.Image = Image.FromFile(Application.StartupPath + "\\CPU_FCFS\\0.png");
            pictureBox9.Image = Image.FromFile(Application.StartupPath + "\\CPU_FCFS\\0.png");
            pictureBox10.Image = Image.FromFile(Application.StartupPath + "\\CPU_FCFS\\0.png");
            pictureBox11.Image = Image.FromFile(Application.StartupPath + "\\CPU_FCFS\\1.png");
            pictureBox12.Image = Image.FromFile(Application.StartupPath + "\\CPU_FCFS\\0.png");
            pictureBox13.Image = Image.FromFile(Application.StartupPath + "\\CPU_FCFS\\0.png");
            pictureBox14.Image = Image.FromFile(Application.StartupPath + "\\CPU_FCFS\\0.png");
            pictureBox15.Image = Image.FromFile(Application.StartupPath + "\\CPU_FCFS\\0.png");
            pictureBox16.Image = Image.FromFile(Application.StartupPath + "\\CPU_FCFS\\0.png");
        }

        int isi = 0;

        private void btnPlay_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            btnAdd.Enabled = false;
            btnPlay.Enabled = false;
            btnReset.Enabled = true;
            for (int i = 0; i < kosong; i++)
            {
                for (int j = 0; j < i + 1; j++)
                {
                    waiting[isi] += timer[j];
                }
                /*
                lblCheck.Text += (waiting[isi]).ToString();
                lblTimer.Text += (timer[isi]).ToString();
                label5.Text = kosong.ToString();
                */
                isi++;
            }
        }

        int finish = 0;
        int tampung = 1;
        int tambah = 0;
        int[] waiting = new int[1000];
        int check = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            tbProcess.Text = tampung.ToString();

            tampung++;
            lblJalan.Location = new Point(lblJalan.Location.X + 5, lblJalan.Location.Y);
            finish = 0;
            while (finish == 0)
            {
                if (tampung == 10)
                {
                    if (check == 0)
                    {
                        if (PB1.Value < PB1.Maximum)
                        { PB1.Value++; }
                    }
                    else if (check == 1)
                    {
                        if (PB2.Value < PB2.Maximum)
                        { PB2.Value++; }
                    }
                    else if (check == 2)
                    {
                        if (PB3.Value < PB3.Maximum)
                        { PB3.Value++; }
                    }
                    else if (check == 3)
                    {
                        if (PB4.Value < PB4.Maximum)
                        { PB4.Value++; }
                    }
                    else if (check == 4)
                    {
                        if (PB5.Value < PB5.Maximum)
                        { PB5.Value++; }
                    }
                    else if (check == 5)
                    {
                        if (PB6.Value < PB6.Maximum)
                        { PB6.Value++; }
                    }
                    else if (check == 6)
                    {
                        if (PB7.Value < PB7.Maximum)
                        { PB7.Value++; }
                    }
                    else if (check == 7)
                    {
                        if (PB8.Value < PB8.Maximum)
                        { PB8.Value++; }
                    }
                    else if (check == 8)
                    {
                        if (PB9.Value < PB9.Maximum)
                        { PB9.Value++; }
                    }
                    else if (check == 9)
                    {
                        if (PB10.Value < PB10.Maximum)
                        { PB10.Value++; }
                    }
                    else if (check == 10)
                    {
                        if (PB11.Value < PB11.Maximum)
                        { PB11.Value++; }
                    }
                    else if (check == 11)
                    {
                        if (PB12.Value < PB12.Maximum)
                        { PB12.Value++; }
                    }
                    else if (check == 12)
                    {
                        if (PB13.Value < PB13.Maximum)
                        { PB13.Value++; }
                    }
                    else if (check == 13)
                    {
                        if (PB14.Value < PB14.Maximum)
                        { PB14.Value++; }
                    }
                    else if (check == 14)
                    {
                        if (PB15.Value < PB15.Maximum)
                        { PB15.Value++; }
                    }
                    else if (check == 15)
                    {
                        if (PB16.Value < PB16.Maximum)
                        { PB16.Value++; }
                    }
                    else if (check == 16)
                    {
                        if (PB17.Value < PB17.Maximum)
                        { PB17.Value++; }
                    }
                    else if (check == 17)
                    {
                        if (PB18.Value < PB18.Maximum)
                        { PB18.Value++; }
                    }
                    else if (check == 18)
                    {
                        if (PB19.Value < PB19.Maximum)
                        { PB19.Value++; }
                    }
                    else if (check == 19)
                    {
                        if (PB20.Value < PB20.Maximum)
                        { PB20.Value++; }
                    }
                    else if (check == 20)
                    {
                        if (PB21.Value < PB21.Maximum)
                        { PB21.Value++; }
                    }
                    else if (check == 21)
                    {
                        if (PB22.Value < PB22.Maximum)
                        { PB22.Value++; }
                    }
                    else if (check == 22)
                    {
                        if (PB23.Value < PB23.Maximum)
                        { PB23.Value++; }
                    }
                    else if (check == 23)
                    {
                        if (PB24.Value < PB24.Maximum)
                        { PB24.Value++; }
                    }
                    else if (check == 24)
                    {
                        if (PB25.Value < PB25.Maximum)
                        { PB25.Value++; }
                    }

                    tambah++;
                    tambah2++;
                    tampung = 0;
                    
                }

                textBox1.Text = (0 + (15 * (ulang - 1))).ToString();
                tb1.Text = (1 + (15*(ulang-1))).ToString();
                tb2.Text = (2 + (15*(ulang-1))).ToString();
                tb3.Text = (3 + (15*(ulang-1))).ToString();
                tb4.Text = (4 + (15*(ulang-1))).ToString();
                tb5.Text = (5 + (15*(ulang-1))).ToString();
                tb6.Text = (6 + (15*(ulang-1))).ToString();
                tb7.Text = (7 + (15*(ulang-1))).ToString();
                tb8.Text = (8 + (15*(ulang-1))).ToString();
                tb9.Text = (9 + (15*(ulang-1))).ToString();
                tb10.Text = (10 + (15*(ulang-1))).ToString();
                tb11.Text = (11 + (15*(ulang-1))).ToString();
                tb12.Text = (12 + (15*(ulang-1))).ToString();
                tb13.Text = (13 + (15*(ulang-1))).ToString();
                tb14.Text = (14 + (15*(ulang-1))).ToString();
                tb15.Text = (15 + (15 * (ulang - 1))).ToString();

                if (tambah2 == waiting[check])
                {
                    lblJalan.Text = "P" + (check + 2).ToString();
                    check++;
                    if (check == kosong)
                    {
                        lblJalan.Text = "P" + (check).ToString();
                        // ubah warna yang diubah lblJalan
                    }
                    SoundChange.Play();
                }
      
                if (tambah == 15)
                {
                    lblJalan.Location = new Point(3, 567);
                    tambah = 0;
                    ulang++;

                    textBox1.Text = (0 + (15 * (ulang - 1))).ToString();
                    tb1.Text = (1 + (15 * (ulang - 1))).ToString();
                    tb2.Text = (2 + (15 * (ulang - 1))).ToString();
                    tb3.Text = (3 + (15 * (ulang - 1))).ToString();
                    tb4.Text = (4 + (15 * (ulang - 1))).ToString();
                    tb5.Text = (5 + (15 * (ulang - 1))).ToString();
                    tb6.Text = (6 + (15 * (ulang - 1))).ToString();
                    tb7.Text = (7 + (15 * (ulang - 1))).ToString();
                    tb8.Text = (8 + (15 * (ulang - 1))).ToString();
                    tb9.Text = (9 + (15 * (ulang - 1))).ToString();
                    tb10.Text = (10 + (15 * (ulang - 1))).ToString();
                    tb11.Text = (11 + (15 * (ulang - 1))).ToString();
                    tb12.Text = (12 + (15 * (ulang - 1))).ToString();
                    tb13.Text = (13 + (15 * (ulang - 1))).ToString();
                    tb14.Text = (14 + (15 * (ulang - 1))).ToString();
                    tb15.Text = (15 + (15 * (ulang - 1))).ToString();
                }

                if (check == kosong)
                {
                    timer1.Enabled = false;
                }
                finish = 1;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            PB1.Visible = false;
            P1.Visible = false;
            PB2.Visible = false;
            P2.Visible = false;
            PB3.Visible = false;
            P3.Visible = false;
            PB4.Visible = false;
            P4.Visible = false;
            PB5.Visible = false;
            P5.Visible = false;
            PB6.Visible = false;
            P6.Visible = false;
            PB7.Visible = false;
            P7.Visible = false;
            PB8.Visible = false;
            P8.Visible = false;
            PB9.Visible = false;
            P9.Visible = false;
            PB10.Visible = false;
            P10.Visible = false;
            PB11.Visible = false;
            P11.Visible = false;
            PB12.Visible = false;
            P12.Visible = false;
            PB13.Visible = false;
            P13.Visible = false;
            PB14.Visible = false;
            P14.Visible = false;
            PB15.Visible = false;
            P15.Visible = false;
            PB16.Visible = false;
            P16.Visible = false;
            PB17.Visible = false;
            P17.Visible = false;
            PB18.Visible = false;
            P18.Visible = false;
            PB19.Visible = false;
            P19.Visible = false;
            PB20.Visible = false;
            P20.Visible = false;
            PB21.Visible = false;
            P21.Visible = false;
            PB22.Visible = false;
            P22.Visible = false;
            PB23.Visible = false;
            P23.Visible = false;
            PB24.Visible = false;
            P24.Visible = false;
            PB25.Visible = false;
            P25.Visible = false;

            PB1.Maximum = 0;
            PB2.Maximum = 0;
            PB3.Maximum = 0;
            PB4.Maximum = 0;
            PB5.Maximum = 0;
            PB6.Maximum = 0;
            PB7.Maximum = 0;
            PB8.Maximum = 0;
            PB9.Maximum = 0;
            PB10.Maximum = 0;
            PB11.Maximum = 0;
            PB12.Maximum = 0;
            PB13.Maximum = 0;
            PB14.Maximum = 0;
            PB15.Maximum = 0;
            PB16.Maximum = 0;
            PB17.Maximum = 0;
            PB18.Maximum = 0;
            PB19.Maximum = 0;
            PB20.Maximum = 0;
            PB21.Maximum = 0;
            PB22.Maximum = 0;
            PB23.Maximum = 0;
            PB24.Maximum = 0;
            PB25.Maximum = 0;

            totalaverage = 0;
            btnAdd.Enabled = true;
            btnReset.Enabled = false;
            btnPlay.Enabled = false;
            lstNumber.Items.Clear();
            lstProses.Items.Clear();
            lstTime.Items.Clear();
            lstWTime.Items.Clear();
            tambah = 0;
            tambah2 = 0;
            ulang = 1;
            number = 1;
            hasil = 0;
            tunggu = 0;
            kotak = 0;
            kosong = 0;
            isi = 0;
            finish = 0;
            tampung = 1;
            check = 0;
            lblJalan.Location = new Point(3, 567);
            lblGambar1.Text = "";
            txtProses.Text = "1";
            label5.Visible = false;
            lblTimer.Visible = false;
            lblCheck.Visible = false;
            tbProcess.Visible = false;
            txtRata.Text = "";
            textBox1.Text = "";
            tb1.Text = "";
            tb2.Text = "";
            tb3.Text = "";
            tb4.Text = "";
            tb5.Text = "";
            tb6.Text = "";
            tb7.Text = "";
            tb8.Text = "";
            tb9.Text = "";
            tb10.Text = "";
            tb11.Text = "";
            tb12.Text = "";
            tb13.Text = "";
            tb14.Text = "";
            tb15.Text = "";
            for (int i=0;i<1000;i++)
            {
                waiting[i]=0;
                timer[i]=0;
                average[i] = 0;
            }
            avg = 0;
            lstWTime.Items.Add("Proses          Waiting Time");
            lstNumber.Items.Add("Number");
            lstProses.Items.Add("Proses");
            lstTime.Items.Add("Burst Time");
            lblJalan.Text = "P1";
            timer1.Enabled = false;
        }

        private void picBack_Click(object sender, EventArgs e)
        {
            Map form = new Map();
            this.Hide();
            form.ShowDialog();
            this.Close();
        }

        private void picNext_Click(object sender, EventArgs e)
        {
            Story_Line_3 form = new Story_Line_3();
            this.Hide();
            form.ShowDialog();
            this.Close();
        }

        System.Media.SoundPlayer SoundButton = new System.Media.SoundPlayer(Application.StartupPath + "\\Music\\HomeEnter.wav");
        private void picBack_MouseHover(object sender, EventArgs e)
        {
            SoundButton.Play();
            picBack.Image = Image.FromFile(Application.StartupPath + "\\StoryLine\\KembaliHover.png");
        }

        private void picNext_MouseHover(object sender, EventArgs e)
        {
            SoundButton.Play();
            picNext.Image = Image.FromFile(Application.StartupPath + "\\StoryLine\\LanjutHover.png");
        }

        private void picNext_MouseLeave(object sender, EventArgs e)
        {
            picNext.Image = Image.FromFile(Application.StartupPath + "\\StoryLine\\Lanjut.png");
        }

        private void picBack_MouseLeave(object sender, EventArgs e)
        {
            picBack.Image = Image.FromFile(Application.StartupPath + "\\StoryLine\\Kembali.png");
        }
    }
}
