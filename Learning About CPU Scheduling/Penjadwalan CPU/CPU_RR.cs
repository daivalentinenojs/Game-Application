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
    public partial class CPU_RR : Form
    {
        public CPU_RR()
        {
            InitializeComponent();
        }

        double number = 1;
        double ulang = 1;
        int kotak;
        int kosong;
        int tambah2 = 1;
        int tampung = 1;
        int tambah = 1;
        int[] waiting = new int[1000];


        // Kevin
        int[] timer = new int[1000];
        int rrTime = 0;
        int[,] arrWaitingTime = new int[3, 1000];
        int[,] arrHitung = new int[2, 1000];
        int tampung1 = -1;
        int count = 1;
        int checkPlus = 0;
        int checktime = 0;
        int finish = 0;
        int hit1 = 0;
        double rata2WaitingTime = 0;
        double count2 = 0;
       
        System.Media.SoundPlayer SoundButton = new System.Media.SoundPlayer(Application.StartupPath + "\\Music\\HomeEnter.wav");
        System.Media.SoundPlayer SoundChange = new System.Media.SoundPlayer(Application.StartupPath + "\\Music\\LowBell.wav");

        private void picBack_Click(object sender, EventArgs e)
        {
            Map_4 form = new Map_4();
            this.Hide();
            form.ShowDialog();
            this.Close();
        }

        private void picNext_Click(object sender, EventArgs e)
        {
            Story_Line_9 form = new Story_Line_9();
            this.Hide();
            form.ShowDialog();
            this.Close();
        }

        private void picBack_MouseHover(object sender, EventArgs e)
        {
            SoundButton.Play();
            picBack.Image = Image.FromFile(Application.StartupPath + "\\StoryLine\\KembaliHover.png");
        }

        private void picBack_MouseLeave(object sender, EventArgs e)
        {
            picBack.Image = Image.FromFile(Application.StartupPath + "\\StoryLine\\Kembali.png");
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

        private void CPU_RR_Load(object sender, EventArgs e)
        {
            picBack.Image = Image.FromFile(Application.StartupPath + "\\StoryLine\\Kembali.png");
            picNext.Image = Image.FromFile(Application.StartupPath + "\\StoryLine\\Lanjut.png");
            this.BackgroundImage = Image.FromFile(Application.StartupPath + "\\CPU_RR\\MCO_BeautifulJourney04.jpg");

            lblTampilrrTime.Text = "";
            txtProses.Enabled = false;
            txtTime.Enabled = false;
            btnPlay.Enabled = false;
            btnAdd.Enabled = false;
            btnDone.Enabled = false;
            lblGambar1.Text = "";
            txtProses.Text = "1";
            label5.Visible = false;
            lblTimer.Visible = false;
            lblCheck.Visible = false;

            pictureBox1.Image = Image.FromFile(Application.StartupPath + "\\CPU_RR\\0.png");
            pictureBox2.Image = Image.FromFile(Application.StartupPath + "\\CPU_RR\\0.png");
            pictureBox3.Image = Image.FromFile(Application.StartupPath + "\\CPU_RR\\0.png");
            pictureBox4.Image = Image.FromFile(Application.StartupPath + "\\CPU_RR\\0.png");
            pictureBox5.Image = Image.FromFile(Application.StartupPath + "\\CPU_RR\\0.png");
            pictureBox6.Image = Image.FromFile(Application.StartupPath + "\\CPU_RR\\0.png");
            pictureBox7.Image = Image.FromFile(Application.StartupPath + "\\CPU_RR\\0.png");
            pictureBox8.Image = Image.FromFile(Application.StartupPath + "\\CPU_RR\\0.png");
            pictureBox9.Image = Image.FromFile(Application.StartupPath + "\\CPU_RR\\0.png");
            pictureBox10.Image = Image.FromFile(Application.StartupPath + "\\CPU_RR\\0.png");
            pictureBox11.Image = Image.FromFile(Application.StartupPath + "\\CPU_RR\\0.png");
            pictureBox12.Image = Image.FromFile(Application.StartupPath + "\\CPU_RR\\0.png");
            pictureBox13.Image = Image.FromFile(Application.StartupPath + "\\CPU_RR\\0.png");
            pictureBox14.Image = Image.FromFile(Application.StartupPath + "\\CPU_RR\\0.png");
            pictureBox15.Image = Image.FromFile(Application.StartupPath + "\\CPU_RR\\0.png");
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            for (int j = 0; j < (timer.Length / checktime) - 1; j++)
            {
                tampung1++;
                for (int k = 0; k < checktime; k++)
                {

                    if (timer[k] >= rrTime)
                    {
                        arrHitung[0, k + (checktime * tampung1)] = k + 1;
                        arrHitung[1, k + (checktime * tampung1)] = rrTime;
                        timer[k] = timer[k] - rrTime;
                    }

                    else if (timer[k] < rrTime && timer[k] < rrTime)
                    {
                        arrHitung[0, k + (checktime * tampung1)] = k + 1;
                        arrHitung[1, k + (checktime * tampung1)] = timer[k];
                        timer[k] = 0;
                    }
                }

            }

            tampung1 = 0;

            for (int i = 0; i < checktime * 100; i++)
            {
                tampung1 = 0;
                for (int j = 0; j < (timer.Length / checktime) - 2; j++)
                {
                    tampung1++;
                    for (int k = 0; k < checktime; k++)
                    {
                        if ((arrHitung[1, k + (checktime * tampung1)] == 0) && (arrHitung[1, ((k + (checktime * tampung1)) + 1)] != 0))
                        {
                            arrHitung[0, k + (checktime * tampung1)] = arrHitung[0, ((k + (checktime * tampung1)) + 1)];
                            arrHitung[1, k + (checktime * tampung1)] = arrHitung[1, ((k + (checktime * tampung1)) + 1)];
                            arrHitung[1, ((k + (checktime * tampung1)) + 1)] = 0;
                        }
                    }
                }
            }

            for (int i = 0; i < checktime * 100; i++)
            {
                tampung1 = 0;
                for (int j = 0; j < (timer.Length / checktime) - 2; j++)
                {
                    tampung1++;
                    for (int k = 0; k < checktime; k++)
                    {
                        if (arrHitung[1, k + (checktime * tampung1)] == 0)
                        {
                            arrHitung[0, k + (checktime * tampung1)] = 0;
                        }
                    }
                }
            }


            // buat check hasil arrHitung
            /* for (int x = 0; x < 1000; x++)
             {
                 MessageBox.Show(arrHitung[0, x].ToString() + " = " + arrHitung[1, x].ToString());
             }
            */


            for (int g = 0; g < 1000; g++)
            {
                arrWaitingTime[0, g] = g + 1;
            }


            for (int a = 0; a < 1000; a++)
            {
                for (int b = 0; b < 1000; b++)
                {
                    if (arrHitung[1, b] != 0)
                    {
                        if (arrHitung[0, b] == arrWaitingTime[0, a])
                        {
                            arrWaitingTime[1, a] += 1;
                        }
                    }
                }
            }

            for (int u = 0; u < 1000; u++)
            {
                hit1 = 0;
                for (int v = 0; v < 1000; v++)
                {
                    if (arrHitung[0, v] != 0 && hit1 < arrWaitingTime[1, u])
                    {
                        if (arrHitung[0, v] != arrWaitingTime[0, u])
                        {
                            arrWaitingTime[2, u] += arrHitung[1, v];
                        }

                        else if (arrHitung[0, v] == arrWaitingTime[0, u])
                        {
                            hit1++;
                        }
                    }
                }
            }

            /*  for (int x = 0; x < 1000; x++)
              {
                  MessageBox.Show(arrWaitingTime[0, x].ToString() + " = " + arrWaitingTime[2, x].ToString());
              } */

            for (int j = 0; j < 1000; j++)
            {
                if (arrWaitingTime[2, j] != 0)
                {
                    lstWTime.Items.Add("P" + arrWaitingTime[0, j].ToString() + "                   " + arrWaitingTime[2, j].ToString());
                    rata2WaitingTime += arrWaitingTime[2, j];
                    count2++;
                }
            }

            lblRata.Text = (rata2WaitingTime / count2).ToString();



            btnAdd.Enabled = false;
            btnDone.Enabled = false;
            btnPlay.Enabled = true;

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtTime.Text != "" && double.Parse(txtTime.Text) > 0)
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

                kosong = 0;
                if (txtTime.Text != "" && double.Parse(txtTime.Text) > 0)
                {
                    txtProses.Text = (number + 1).ToString();
                    lstNumber.Items.Add(number);
                    lstProses.Items.Add("P" + number);

                    lstTime.Items.Add(double.Parse(txtTime.Text));
                    timer[kotak] = int.Parse(txtTime.Text);
                    kotak++;

                    txtTime.Text = "";
                    txtTime.Focus();
                    number++;

                    for (int i = 0; i < 1000; i++)
                    {
                        if (timer[i] != 0)
                        { kosong++; }
                    }
                    checktime++;

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
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            PB1.Value = 1;
            timer1.Enabled = true;
            btnPlay.Visible = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            tampung++;
            finish = 0;
            label9.Text = count.ToString();
            label10.Text = checkPlus.ToString();

            lblJalan.Location = new Point(lblJalan.Location.X + 5, lblJalan.Location.Y);

            if (tampung % 10 == 0)
            {

                tambah++;
                count += 1;

                if (arrHitung[0, checkPlus] == 1)
                {
                    if (PB1.Value <= PB1.Maximum)
                    { PB1.Value++; }
                }
                if (arrHitung[0, checkPlus] == 2)
                {
                    if (PB2.Value <= PB2.Maximum)
                    { PB2.Value++; }
                }
                if (arrHitung[0, checkPlus] == 3)
                {
                    if (PB3.Value <= PB3.Maximum)
                    { PB3.Value++; }
                }
                if (arrHitung[0, checkPlus] == 4)
                {
                    if (PB4.Value <= PB4.Maximum)
                    { PB4.Value++; }
                }
                if (arrHitung[0, checkPlus] == 5)
                {
                    if (PB5.Value <= PB5.Maximum)
                    { PB5.Value++; }
                }
                if (arrHitung[0, checkPlus] == 6)
                {
                    if (PB6.Value <= PB6.Maximum)
                    { PB6.Value++; }
                }
                if (arrHitung[0, checkPlus] == 7)
                {
                    if (PB7.Value <= PB7.Maximum)
                    { PB7.Value++; }
                }
                if (arrHitung[0, checkPlus] == 8)
                {
                    if (PB8.Value <= PB8.Maximum)
                    { PB8.Value++; }
                }
                if (arrHitung[0, checkPlus] == 9)
                {
                    if (PB9.Value <= PB9.Maximum)
                    { PB9.Value++; }
                }
                if (arrHitung[0, checkPlus] == 10)
                {
                    if (PB10.Value <= PB10.Maximum)
                    { PB10.Value++; }
                }
                if (arrHitung[0, checkPlus] == 11)
                {
                    if (PB11.Value <= PB11.Maximum)
                    { PB11.Value++; }
                }
                if (arrHitung[0, checkPlus] == 12)
                {
                    if (PB12.Value <= PB12.Maximum)
                    { PB12.Value++; }
                }
                if (arrHitung[0, checkPlus] == 13)
                {
                    if (PB13.Value <= PB13.Maximum)
                    { PB13.Value++; }
                }
                if (arrHitung[0, checkPlus] == 14)
                {
                    if (PB14.Value <= PB14.Maximum)
                    { PB14.Value++; }
                }
                if (arrHitung[0, checkPlus] == 15)
                {
                    if (PB15.Value <= PB15.Maximum)
                    { PB15.Value++; }
                }
                if (arrHitung[0, checkPlus] == 16)
                {
                    if (PB16.Value <= PB16.Maximum)
                    { PB16.Value++; }
                }
                if (arrHitung[0, checkPlus] == 17)
                {
                    if (PB17.Value <= PB17.Maximum)
                    { PB17.Value++; }
                }
                if (arrHitung[0, checkPlus] == 18)
                {
                    if (PB18.Value <= PB18.Maximum)
                    { PB18.Value++; }
                }
                if (arrHitung[0, checkPlus] == 19)
                {
                    if (PB19.Value <= PB19.Maximum)
                    { PB19.Value++; }
                }
                if (arrHitung[0, checkPlus] == 20)
                {
                    if (PB20.Value <= PB20.Maximum)
                    { PB20.Value++; }
                }
                if (arrHitung[0, checkPlus] == 21)
                {
                    if (PB21.Value <= PB21.Maximum)
                    { PB21.Value++; }
                }
                if (arrHitung[0, checkPlus] == 22)
                {
                    if (PB22.Value <= PB22.Maximum)
                    { PB22.Value++; }
                }
                if (arrHitung[0, checkPlus] == 23)
                {
                    if (PB23.Value <= PB23.Maximum)
                    { PB23.Value++; }
                }
                if (arrHitung[0, checkPlus] == 24)
                {
                    if (PB24.Value <= PB24.Maximum)
                    { PB24.Value++; }
                }
                if (arrHitung[0, checkPlus] == 25)
                {
                    if (PB25.Value <= PB25.Maximum)
                    { PB25.Value++; }
                }


            }

            while (finish == 0)
            {
                if (count == arrHitung[1, checkPlus])
                {
                    SoundChange.Play();
                    count = 0;
                    checkPlus += 1;
                }

                if (ulang == 1)
                {
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
                else if (ulang > 1)
                {
                    tb1.Text = (0 + (15 * (ulang - 1))).ToString();
                    tb2.Text = (1 + (15 * (ulang - 1))).ToString();
                    tb3.Text = (2 + (15 * (ulang - 1))).ToString();
                    tb4.Text = (3 + (15 * (ulang - 1))).ToString();
                    tb5.Text = (4 + (15 * (ulang - 1))).ToString();
                    tb6.Text = (5 + (15 * (ulang - 1))).ToString();
                    tb7.Text = (6 + (15 * (ulang - 1))).ToString();
                    tb8.Text = (7 + (15 * (ulang - 1))).ToString();
                    tb9.Text = (8 + (15 * (ulang - 1))).ToString();
                    tb10.Text = (9 + (15 * (ulang - 1))).ToString();
                    tb11.Text = (10 + (15 * (ulang - 1))).ToString();
                    tb12.Text = (11 + (15 * (ulang - 1))).ToString();
                    tb13.Text = (12 + (15 * (ulang - 1))).ToString();
                    tb14.Text = (13 + (15 * (ulang - 1))).ToString();
                    tb15.Text = (14 + (15 * (ulang - 1))).ToString();
                }

                if (tambah == 15)
                {
                    lblJalan.Location = new Point(0, 607);
                    tambah = 0;
                    ulang++;
                    tambah2 += 1;
                }

                lblJalan.Text = "P" + arrHitung[0, checkPlus];

                if (arrHitung[1, checkPlus] == 0)
                {
                 
                    lblJalan.Text = "P" + arrHitung[0, checkPlus - 1];
                }

                if (arrHitung[1, checkPlus] == 0)
                {

                    timer1.Enabled = false;

                }



                finish = 1;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (txtrrTime.Text == "")
            {
                MessageBox.Show(" RR Time harus diisi ");
            }
            else if (int.Parse(txtrrTime.Text) <= 0)
            {
                MessageBox.Show(" tidak boleh 0 atau negatif");
            }
            else
            {
                rrTime = int.Parse(txtrrTime.Text);
                txtrrTime.Enabled = false;
                btnOk.Enabled = false;
                btnAdd.Enabled = true;
                btnDone.Enabled = true;
                lblTampilrrTime.Text = "RR Time :" + "\n" + txtrrTime.Text;
                txtProses.Enabled = true;
                txtTime.Enabled = true;
            }
        }
    }
}
