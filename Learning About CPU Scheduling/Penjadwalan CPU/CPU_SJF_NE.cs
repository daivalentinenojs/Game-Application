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
    public partial class CPU_SJF_NE : Form
    {
        public CPU_SJF_NE()
        {
            InitializeComponent();
        }

        #region Introduction
        System.Media.SoundPlayer SoundButton = new System.Media.SoundPlayer(Application.StartupPath + "\\Music\\HomeEnter.wav");
        System.Media.SoundPlayer SoundChange = new System.Media.SoundPlayer(Application.StartupPath + "\\Music\\LowBell.wav");
        System.Media.SoundPlayer SoundIdle = new System.Media.SoundPlayer(Application.StartupPath + "\\Music\\True.wav");

        private void picBack_Click(object sender, EventArgs e)
        {
            Map_3 form = new Map_3();
            this.Hide();
            form.ShowDialog();
            this.Close();
        }

        private void picNext_Click(object sender, EventArgs e)
        {
            Story_Line_7 form = new Story_Line_7();
            this.Hide();
            form.ShowDialog();
            this.Close();
        }

        private void CPU_SJF_NE_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = Image.FromFile(Application.StartupPath + "\\CPU_SJF_NE\\MCO_BeautifulJourney010.jpg");
            picBack.Image = Image.FromFile(Application.StartupPath + "\\StoryLine\\Kembali.png");
            picNext.Image = Image.FromFile(Application.StartupPath + "\\StoryLine\\Lanjut.png");

            pp1.Image = Image.FromFile(Application.StartupPath + "\\CPU_FCFS\\0.png");
            pp2.Image = Image.FromFile(Application.StartupPath + "\\CPU_FCFS\\0.png");
            pp3.Image = Image.FromFile(Application.StartupPath + "\\CPU_FCFS\\0.png");
            pp4.Image = Image.FromFile(Application.StartupPath + "\\CPU_FCFS\\0.png");
            pp5.Image = Image.FromFile(Application.StartupPath + "\\CPU_FCFS\\0.png");
            pp6.Image = Image.FromFile(Application.StartupPath + "\\CPU_FCFS\\0.png");
            pp7.Image = Image.FromFile(Application.StartupPath + "\\CPU_FCFS\\0.png");
            pp8.Image = Image.FromFile(Application.StartupPath + "\\CPU_FCFS\\0.png");
            pp9.Image = Image.FromFile(Application.StartupPath + "\\CPU_FCFS\\0.png");
            pp10.Image = Image.FromFile(Application.StartupPath + "\\CPU_FCFS\\0.png");
            pp11.Image = Image.FromFile(Application.StartupPath + "\\CPU_FCFS\\0.png");
            pp12.Image = Image.FromFile(Application.StartupPath + "\\CPU_FCFS\\0.png");
            pp13.Image = Image.FromFile(Application.StartupPath + "\\CPU_FCFS\\0.png");
            pp14.Image = Image.FromFile(Application.StartupPath + "\\CPU_FCFS\\0.png");
            pp15.Image = Image.FromFile(Application.StartupPath + "\\CPU_FCFS\\0.png");
            pp16.Image = Image.FromFile(Application.StartupPath + "\\CPU_FCFS\\1.png");

            btnReset.Enabled = false;
            btnPlay.Enabled = false;
            txtProses.Text = "1";
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
        #endregion

        double number = 1;
        int[,] SJF = new int[3, 1000];
        int kotakSJF = 0;

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtTime.Text != "" && double.Parse(txtTime.Text) >= 0 && txtArrival.Text != "" && double.Parse(txtArrival.Text) >= 0)
            {
                #region CodingBaru
                SJF[0, kotakSJF] = int.Parse(txtProses.Text);
                SJF[1, kotakSJF] = int.Parse(txtArrival.Text);
                SJF[2, kotakSJF] = int.Parse(txtTime.Text);
                kotakSJF++;
                #endregion

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
                txtProses.Text = (number + 1).ToString();
                lstNumber.Items.Add(number);
                lstProses.Items.Add("P" + number);
                lstArrival.Items.Add(txtArrival.Text);
                lstTime.Items.Add(double.Parse(txtTime.Text));

                btnPlay.Enabled = true;
                
                txtTime.Text = "";
                txtArrival.Text = "";
                txtArrival.Focus();
                number++;
                #endregion
            }


            else if (txtTime.Text == "" || txtArrival.Text == "")
            {
                MessageBox.Show("Silahkan Masukkan Nilai Burst Time Atau Nilai Arrival !!", "Peringatan !");
            }
            else if (double.Parse(txtTime.Text) < 0 || double.Parse(txtArrival.Text) < 0)
            {
                MessageBox.Show("Nilai Burst Time Tidak Dapat Negatif Atau Nilai Arrival Tidak Dapat Negatif !!", "Peringatan !");
            }
        }

        int tidakKosong = 0, Rendah, i,j,k,h=0;
        private void btnPlay_Click(object sender, EventArgs e)
        {
            int tunggu;
            btnAdd.Enabled = false;
            btnReset.Enabled = true;
            for (int i = 0;i<1000 ; i++)
            {
                if (SJF[0, i] != 0)
                {
                    tidakKosong++;
                }
            }

            for (j = 1; j < tidakKosong; j++)
            {
                Rendah = SJF[1, 0];
                if (Rendah == SJF[1, j])
                {
                    if (SJF[2,0] > SJF[2, j])
                    {
                        int temp = SJF[1, 0];
                        SJF[1, 0] = SJF[1, j];
                        SJF[1, j] = temp;

                        temp = SJF[0, 0];
                        SJF[0, 0] = SJF[0, j];
                        SJF[0, j] = temp;

                        temp = SJF[2, 0];
                        SJF[2, 0] = SJF[2, j];
                        SJF[2, j] = temp;
                    }
                }
                else if (Rendah > SJF[1, j])
                {
                    int temp = SJF[1, 0];
                    SJF[1, 0] = SJF[1, j];
                    SJF[1, j] = temp;

                    temp = SJF[0, 0];
                    SJF[0, 0] = SJF[0, j];
                    SJF[0, j] = temp;

                    temp = SJF[2, 0];
                    SJF[2, 0] = SJF[2, j];
                    SJF[2, j] = temp;
                }
            }
            int totalbt = SJF[2,0];
            for (j = 2; j < tidakKosong; j++)
            {
                Rendah = SJF[2, j - 1];
                k = j;
                
                for (i = 0; i < tidakKosong - j; i++)
                {

                    if (SJF[2, j - 1] == SJF[2, k])
                    {
                        if (SJF[1, j - 1] > SJF[1, k])
                        {
                            int temp = SJF[0, j - 1];
                            SJF[0, j - 1] = SJF[0, k];
                            SJF[0, k] = temp;

                            temp = SJF[1, j - 1];
                            SJF[1, j - 1] = SJF[1, k];
                            SJF[1, k] = temp;

                            temp = SJF[2, j - 1];
                            SJF[2, j - 1] = SJF[2, k];
                            SJF[2, k] = temp;
                            Rendah = SJF[2, j - 1];
                        }
                    }
                    else if (Rendah > SJF[2, k] && totalbt > SJF[1, k])
                    {
                        int temp = SJF[0, j - 1];
                        SJF[0, j - 1] = SJF[0, k];
                        SJF[0, k] = temp;

                        temp = SJF[1, j - 1];
                        SJF[1, j - 1] = SJF[1, k];
                        SJF[1, k] = temp;

                        temp = SJF[2, j - 1];
                        SJF[2, j - 1] = SJF[2, k];
                        SJF[2, k] = temp;
                        Rendah = SJF[2, j - 1];

                    }
                    
                    k++;
                }
                totalbt += SJF[2, j];
            }
    
            // Tampil Array
            
            for (i = 0; i < 3; i++)
            {
                for (j = 0; j < tidakKosong; j++)
                {
                    array.Text += SJF[i, j];
                }
                array.Text += "\n";
            }

            double total = 0;
            //Isi Waiting Time ListBox
            for (int i = 0; i <= (lstNumber.Items.Count - 2); i++)
            {
                tunggu = 0;
                if (h == 0)
                {
                    tunggu = 0;
                    if (tunggu < 10)
                    {
                        lstWTime.Items.Add("   P" + SJF[0, h] + "                    0" + tunggu);
                    }
                    else
                    {
                        lstWTime.Items.Add("   P" + SJF[0, h] + "                     " + tunggu);
                    }
                    h++;
                }
                else
                {
                    int wa = 0, ta=0;
                    for (int p = 0; p < i; p++)
                    {
                        tunggu += SJF[2, p];
                        ta = SJF[1, p + 1];         
                    }
                    //tunggu -= SJF[1, i];
                    wa = tunggu + SJF[1, 0] - ta;
                    if (wa < 0)
                    {
                        wa = 0;
                    }

                    total += wa;
                    if (wa < 10)
                    {
                        lstWTime.Items.Add("   P" + SJF[0, h] + "                    0" + wa);
                    }
                    else
                    {
                        lstWTime.Items.Add("   P" + SJF[0, h] + "                     " + wa);
                    }
                    h++;
                }
            }

            txtRata.Text = (total / (lstNumber.Items.Count - 1)).ToString();
            lblJalan.Text = "P" + SJF[0,0];
            btnPlay.Enabled = false;
            timer1.Enabled = true;
        }
        int totalidle=0;
        
        int tambah2 = 0, tambah = 0, proses = 0, ulang = 1, check = 0, check15=0, idle = 0;
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            tambah2++;
            tbProcess.Text = idle.ToString();

            lblJalan.Location = new Point(lblJalan.Location.X + 5, lblJalan.Location.Y);

            #region ProgressBar
            if (tambah2 == 10)
            {
                if (SJF[0, proses] == 1)
                {
                    if (PB1.Value < PB1.Maximum)
                    { PB1.Value++; }
                }
                else if (SJF[0, proses] == 2)
                {
                    if (PB2.Value < PB2.Maximum)
                    { PB2.Value++; }
                }
                else if (SJF[0, proses] == 3)
                {
                    if (PB3.Value < PB3.Maximum)
                    { PB3.Value++; }
                }
                else if (SJF[0, proses] == 4)
                {
                    if (PB4.Value < PB4.Maximum)
                    { PB4.Value++; }
                }
                else if (SJF[0, proses] == 5)
                {
                    if (PB5.Value < PB5.Maximum)
                    { PB5.Value++; }
                }
                else if (SJF[0, proses] == 6)
                {
                    if (PB6.Value < PB6.Maximum)
                    { PB6.Value++; }
                }
                else if (SJF[0, proses] == 7)
                {
                    if (PB7.Value < PB7.Maximum)
                    { PB7.Value++; }
                }
                else if (SJF[0, proses] == 8)
                {
                    if (PB8.Value < PB8.Maximum)
                    { PB8.Value++; }
                }
                else if (SJF[0, proses] == 9)
                {
                    if (PB9.Value < PB9.Maximum)
                    { PB9.Value++; }
                }
                else if (SJF[0, proses] == 10)
                {
                    if (PB10.Value < PB10.Maximum)
                    { PB10.Value++; }
                }
                else if (SJF[0, proses] == 11)
                {
                    if (PB11.Value < PB11.Maximum)
                    { PB11.Value++; }
                }
                else if (SJF[0, proses] == 12)
                {
                    if (PB12.Value < PB12.Maximum)
                    { PB12.Value++; }
                }
                else if (SJF[0, proses] == 13)
                {
                    if (PB13.Value < PB13.Maximum)
                    { PB13.Value++; }
                }
                else if (SJF[0, proses] == 14)
                {
                    if (PB14.Value < PB14.Maximum)
                    { PB14.Value++; }
                }
                else if (SJF[0, proses] == 15)
                {
                    if (PB15.Value < PB15.Maximum)
                    { PB15.Value++; }
                }
                else if (SJF[0, proses] == 16)
                {
                    if (PB16.Value < PB16.Maximum)
                    { PB16.Value++; }
                }
                else if (SJF[0, proses] == 17)
                {
                    if (PB17.Value < PB17.Maximum)
                    { PB17.Value++; }
                }
                else if (SJF[0, proses] == 18)
                {
                    if (PB18.Value < PB18.Maximum)
                    { PB18.Value++; }
                }
                else if (SJF[0, proses] == 19)
                {
                    if (PB19.Value < PB19.Maximum)
                    { PB19.Value++; }
                }
                else if (SJF[0, proses] == 20)
                {
                    if (PB20.Value < PB20.Maximum)
                    { PB20.Value++; }
                }
                else if (SJF[0, proses] == 21)
                {
                    if (PB21.Value < PB21.Maximum)
                    { PB21.Value++; }
                }
                else if (SJF[0, proses] == 22)
                {
                    if (PB22.Value < PB22.Maximum)
                    { PB22.Value++; }
                }
                else if (SJF[0, proses] == 23)
                {
                    if (PB23.Value < PB23.Maximum)
                    { PB23.Value++; }
                }
                else if (SJF[0, proses] == 24)
                {
                    if (PB24.Value < PB24.Maximum)
                    { PB24.Value++; }
                }
                else if (SJF[0, proses] == 25)
                {
                    if (PB25.Value < PB25.Maximum)
                    { PB25.Value++; }
                }
            }
            #endregion

            if (tambah2 == 10)
            {
                tambah2 = 0;
                tambah++;
                check15++;
                idle++;
            }

            if (tambah == SJF[2, proses])
            {
                tambah = 0;
                proses++;
                lblJalan.Text = "P" + SJF[0, proses];
                check++;
                SoundChange.Play();
                // Arival Time Tinggi

                int t = 0;
                for (int i = 0; i < proses; i++)
                {
                    if (t < SJF[1, i])
                    {
                        t = SJF[1, i];
                    }
                }

                // Nilai tertinggi
                int tinggi = 0;
                for (int i = 0; i < proses; i++)
                {
                    tinggi += SJF[2, i];
                }

                lbltidak.Text = tinggi.ToString();
                // Check Ide
                //if (tinggi < SJF[1, proses] && (t < SJF[1, proses]))
                if ((SJF[1,0]+tinggi)< SJF[1,proses])
                {
                    lblIdle.Text += "Idle : Terjadi Idle Antara Proses Ke " + SJF[0, proses - 1].ToString() + " Dengan Proses Ke " + SJF[0, proses].ToString() + " Selama " + ((SJF[1, proses] - tinggi) - SJF[1, 0]).ToString() + " Burst Time\n";
                    totalidle = SJF[1, proses] - tinggi - SJF[1, 0];
                    SoundIdle.Play();
                }

            }
           
        

            #region Kasih Nilai 0-15
            textBox1.Text = (totalidle + SJF[1, 0] + 0 + (15 * (ulang - 1))).ToString();
            tb1.Text = (totalidle + SJF[1, 0] + 1 + (15 * (ulang - 1))).ToString();
            tb2.Text = (totalidle + SJF[1, 0] + 2 + (15 * (ulang - 1))).ToString();
            tb3.Text = (totalidle + SJF[1, 0] + 3 + (15 * (ulang - 1))).ToString();
            tb4.Text = (totalidle + SJF[1, 0] + 4 + (15 * (ulang - 1))).ToString();
            tb5.Text = (totalidle + SJF[1, 0] + 5 + (15 * (ulang - 1))).ToString();
            tb6.Text = (totalidle + SJF[1, 0] + 6 + (15 * (ulang - 1))).ToString();
            tb7.Text = (totalidle + SJF[1, 0] + 7 + (15 * (ulang - 1))).ToString();
            tb8.Text = (totalidle + SJF[1, 0] + 8 + (15 * (ulang - 1))).ToString();
            tb9.Text = (totalidle + SJF[1, 0] + 9 + (15 * (ulang - 1))).ToString();
            tb10.Text = (totalidle + SJF[1, 0] + 10 + (15 * (ulang - 1))).ToString();
            tb11.Text = (totalidle + SJF[1, 0] + 11 + (15 * (ulang - 1))).ToString();
            tb12.Text = (totalidle + SJF[1, 0] + 12 + (15 * (ulang - 1))).ToString();
            tb13.Text = (totalidle + SJF[1, 0] + 13 + (15 * (ulang - 1))).ToString();
            tb14.Text = (totalidle + SJF[1, 0] + 14 + (15 * (ulang - 1))).ToString();
            tb15.Text = (totalidle + SJF[1, 0] + 15 + (15 * (ulang - 1))).ToString();
            #endregion

            if (check15 == 15)
            {
                lblJalan.Location = new Point(9, 560);
                ulang++;
                check15 = 0;

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

            if (check == tidakKosong)
            {
                lblJalan.Text = "P" + SJF[0, proses - 1];
                timer1.Enabled = false;
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

            btnAdd.Enabled = true;
            btnReset.Enabled = false;
            btnPlay.Enabled = false;
            lstNumber.Items.Clear();
            lstProses.Items.Clear();
            lstTime.Items.Clear();
            lstWTime.Items.Clear();
            lstArrival.Items.Clear();
            tambah = 0;
            tambah2 = 0;
            ulang = 1;
            number = 1;
            lblIdle.Text = "";
            check = 0;
            lblJalan.Location = new Point(9, 560);
            lblGambar1.Text = "";
            txtProses.Text = "1";
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
            
            for (int j = 0; j < 3; j++)
            {
                for (int i = 0; i < 1000; i++)
                {
                    SJF[j, i] = 0;
                }
            }

            lstWTime.Items.Add("Proses          Waiting Time");
            lstNumber.Items.Add("Number");
            lstProses.Items.Add("Proses");
            lstTime.Items.Add("Burst Time");
            lstArrival.Items.Add("Arrival");
            lblJalan.Text = "P1";
            timer1.Enabled = false;
        }
    }
}
