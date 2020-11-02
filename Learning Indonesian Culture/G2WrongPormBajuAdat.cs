using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MIB_2015
{
    public partial class G2WrongPormBajuAdat : Form
    {
        Player _p1, _p2;
        int stage = 0;
        public G2WrongPormBajuAdat(Player p1,Player p2,int stage)
        {
            InitializeComponent();
            this._p1 = p1;
            this._p2 = p2;
            this.stage = stage;
        }

        int waktuMain = 0, check = 0, soal = -1, gambar = -1, benarSalah = -1;
        bool jawabP1 = true, jawabP2 = true;
        int pointP1 = 0, pointP2 = 0;
        System.Media.SoundPlayer SoundMain = new System.Media.SoundPlayer(Application.StartupPath + "\\Music\\G2.wav");

        String[] Jawaban = { "xxx",
                           "Sumatera Utara",
                           "Sumatera Barat",
                           "Riau",
                           "Sumatera Selatan",
                           "Lampung",
                           "Banten",
                           "Jakarta",
                           "Jawa Timur",
                           "Bali",
                           "NTB",
                           "Papua Barat",
                           "Maluku",
                           "Sulawesi Utara",
                           "Kalimantan Barat",
                           "Gorontalo",
                           "xxx"};

        private void gambarVisible()
        {
            picP1BS.Visible = false;
            picP2BS.Visible = false;
            picP3BS.Visible = false;
        }

        private void picExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //bool awalcek = true;
        private void G2WrongPormBajuAdat_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            tmrG2.Enabled = true;
            SoundMain.PlayLooping();
            tmrWait.Enabled = true;
            //label1.BackColor = Color.FromArgb(80, 100, 84, 66);
            //label9.BackColor = Color.FromArgb(80, 100, 84, 66);

            picTiraiKiri.Visible = true;
            picTiraiKanan.Visible = true;
            tiraiKi = picTiraiKiri.Location;
            tiraiKa = picTiraiKanan.Location;
            timer2.Enabled = true;
        }
        Point tiraiKi,tiraiKa;
        private void tmrG2_Tick(object sender, EventArgs e)
        {
            waktuMain++;
            lblSoal.Left = (this.Width / 2 - lblSoal.Width / 2);
            pp1.Text = pointP1.ToString();
            pp2.Text = pointP2.ToString();

            picTiraiKiri.Visible = false;
            picTiraiKanan.Visible = false;

            if ((60 - waktuMain) >= 10)
                lblDetik.Text = "00 : " + (60 - waktuMain).ToString();
            else
                lblDetik.Text = "00 : 0" + (60 - waktuMain).ToString();
            
            if (waktuMain >= 60)
            {
                tmrG2.Enabled = false;
                lblDetik.Text = "00 : 00";
                lblSoal.Visible = false;
                lblHasil.Visible = true;

                gambarVisible();

                if (pointP1 > pointP2)
                    lblHasil.Text = "Pemain 1 Menang !";
                else if (pointP2 > pointP1)
                    lblHasil.Text = "Pemain 2 Menang !";
                else
                    lblHasil.Text = "Permainan Seri !";

                System.Threading.Thread.Sleep(400);
                Player.RecordScore(2, _p1.Name, _p2.Name, pointP1, pointP2);
                hs t = new hs(2);
                t.ShowDialog();
                t.BringToFront();
                t.center();
                timer1.Enabled = true;
            }

            if (check == 0 || (jawabP1 == false && jawabP2 == false))
            {
                //System.Threading.Thread.Sleep(1000);
                    tmrWait.Enabled = true;
            }
        }

        private void G2WrongPormBajuAdat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'a' || e.KeyChar == 'A')
            {
                if (jawabP1)
                {
                    if (gambar == 0)
                    {
                        pointP1+= 100;
                        new System.Threading.Thread(() =>
                        {
                            var c = new System.Windows.Media.MediaPlayer();
                            c.Open(new System.Uri(@Application.StartupPath + "\\Music\\G1Benar.wav"));
                            c.Play();
                        }).Start();
                        jawabP2 = false;
                        //gambarVisible();
                        check = 0;
                        tmrG2.Enabled = false;
                        tmrPause.Enabled = true;
                        benarSalah = 11;
                    }
                    else
                    {
                        picP1BS.Visible = true;
                        picP1BS.Image = Image.FromFile(Application.StartupPath + "\\G1YesNoRumahAdat\\0.png");

                        new System.Threading.Thread(() =>
                        {
                            var c = new System.Windows.Media.MediaPlayer();
                            c.Open(new System.Uri(@Application.StartupPath + "\\Music\\G1Salah.wav"));
                            c.Play();
                        }).Start();
                        //tmrG2.Enabled = false;
                        //tmrPause.Enabled = true;
                        //benarSalah = 10;
                        jawabP1 = false;
                        if (pointP1 > 0)
                            pointP1 -= 50;

                    }
                }
            }
            else if (e.KeyChar == 's' || e.KeyChar == 'S')
            {
                if (jawabP1)
                {
                    if (gambar == 1)
                    {
                        pointP1 += 100;
                        new System.Threading.Thread(() =>
                        {
                            var c = new System.Windows.Media.MediaPlayer();
                            c.Open(new System.Uri(@Application.StartupPath + "\\Music\\G1Benar.wav"));
                            c.Play();
                        }).Start();
                        //gambarVisible();
                        check = 0;
                        jawabP2 = false;
                        tmrG2.Enabled = false;
                        tmrPause.Enabled = true;
                        benarSalah = 21;
                    }
                    else
                    {
                        picP2BS.Visible = true;
                        picP2BS.Image = Image.FromFile(Application.StartupPath + "\\G1YesNoRumahAdat\\0.png");
                        new System.Threading.Thread(() =>
                        {
                            var c = new System.Windows.Media.MediaPlayer();
                            c.Open(new System.Uri(@Application.StartupPath + "\\Music\\G1Salah.wav"));
                            c.Play();
                        }).Start();
                        //tmrG2.Enabled = false;
                        //tmrPause.Enabled = true;
                        //benarSalah = 20;
                        jawabP1 = false;
                        if (pointP1 > 0)
                            pointP1 -= 50;
                    }
                }
            }
            else if (e.KeyChar == 'd' || e.KeyChar == 'D')
            {
                if (jawabP1)
                {
                    if (gambar == 2)
                    {
                        pointP1 += 100;
                        jawabP2 = false;
                        new System.Threading.Thread(() =>
                        {
                            var c = new System.Windows.Media.MediaPlayer();
                            c.Open(new System.Uri(@Application.StartupPath + "\\Music\\G1Benar.wav"));
                            c.Play();
                        }).Start();
                        //gambarVisible();
                        check = 0;
                        tmrG2.Enabled = false;
                        tmrPause.Enabled = true;
                        benarSalah = 31;
                    }
                    else
                    {
                        picP3BS.Visible = true;
                        picP3BS.Image = Image.FromFile(Application.StartupPath + "\\G1YesNoRumahAdat\\0.png");
                        new System.Threading.Thread(() =>
                        {
                            var c = new System.Windows.Media.MediaPlayer();
                            c.Open(new System.Uri(@Application.StartupPath + "\\Music\\G1Salah.wav"));
                            c.Play();
                        }).Start();
                        //tmrG2.Enabled = false;
                        //tmrPause.Enabled = true;
                        //benarSalah = 30;
                        jawabP1 = false;
                        if (pointP1 > 0)
                            pointP1 -= 50;
                    }
                }
            }

            if (e.KeyChar == 'j' || e.KeyChar == 'J')
            {
                if (jawabP2)
                {
                    if (gambar == 0)
                    {
                        pointP2 += 100;
                        jawabP1 = false;
                        new System.Threading.Thread(() =>
                        {
                            var c = new System.Windows.Media.MediaPlayer();
                            c.Open(new System.Uri(@Application.StartupPath + "\\Music\\G1Benar.wav"));
                            c.Play();
                        }).Start();
                        //gambarVisible();
                        check = 0;
                        benarSalah = 11;
                        tmrG2.Enabled = false;
                        tmrPause.Enabled = true;
                    }
                    else
                    {
                        picP1BS.Visible = true;
                        picP1BS.Image = Image.FromFile(Application.StartupPath + "\\G1YesNoRumahAdat\\0.png");
                        new System.Threading.Thread(() =>
                        {
                            var c = new System.Windows.Media.MediaPlayer();
                            c.Open(new System.Uri(@Application.StartupPath + "\\Music\\G1Salah.wav"));
                            c.Play();
                        }).Start();
                        //tmrG2.Enabled = false;
                        //tmrPause.Enabled = true;
                        //benarSalah = 10;
                        jawabP2 = false;
                        if (pointP2 > 0)
                            pointP2 -= 50;
                    }
                }
            }
            else if (e.KeyChar == 'k' || e.KeyChar == 'K')
            {
                if (jawabP2)
                {
                    if (gambar == 1)
                    {
                        pointP2 += 100;
                        jawabP1 = false;
                        new System.Threading.Thread(() =>
                        {
                            var c = new System.Windows.Media.MediaPlayer();
                            c.Open(new System.Uri(@Application.StartupPath + "\\Music\\G1Benar.wav"));
                            c.Play();
                        }).Start();
                        //gambarVisible();
                        check = 0;
                        benarSalah = 21;
                        tmrG2.Enabled = false;
                        tmrPause.Enabled = true;
                    }
                    else
                    {
                        picP2BS.Visible = true;
                        picP2BS.Image = Image.FromFile(Application.StartupPath + "\\G1YesNoRumahAdat\\0.png");
                        new System.Threading.Thread(() =>
                        {
                            var c = new System.Windows.Media.MediaPlayer();
                            c.Open(new System.Uri(@Application.StartupPath + "\\Music\\G1Salah.wav"));
                            c.Play();
                        }).Start();
                        //tmrG2.Enabled = false;
                        //tmrPause.Enabled = true;
                        //benarSalah = 20;
                        jawabP2 = false;
                        if (pointP2 > 0)
                            pointP2 -= 50;
                    }
                }
            }
            else if (e.KeyChar == 'l' || e.KeyChar == 'L')
            {
                if (jawabP2)
                {
                    if (gambar == 2)
                    {
                        pointP2 += 100;
                        jawabP1 = false;
                        new System.Threading.Thread(() =>
                        {
                            var c = new System.Windows.Media.MediaPlayer();
                            c.Open(new System.Uri(@Application.StartupPath + "\\Music\\G1Benar.wav"));
                            c.Play();
                        }).Start();
                        //gambarVisible();
                        check = 0;
                        tmrG2.Enabled = false;
                        tmrPause.Enabled = true;
                        benarSalah = 31;
                    }
                    else
                    {
                        picP3BS.Visible = true;
                        picP3BS.Image = Image.FromFile(Application.StartupPath + "\\G1YesNoRumahAdat\\0.png");
                        new System.Threading.Thread(() =>
                        {
                            var c = new System.Windows.Media.MediaPlayer();
                            c.Open(new System.Uri(@Application.StartupPath + "\\Music\\G1Salah.wav"));
                            c.Play();
                        }).Start();
                        //tmrG2.Enabled = false;
                        //tmrPause.Enabled = true;
                        //benarSalah = 30;
                        jawabP2 = false;
                        if (pointP2 > 0)
                            pointP2 -= 50;
                    }
                }
            }
        }

        int waktuPause = 0;
        private void tmrPause_Tick(object sender, EventArgs e)
        {
            waktuPause++;
            picTiraiKiri.Visible = true;
            picTiraiKanan.Visible = true;
            //picTiraiKiri.Location = new Point(picTiraiKiri.Location.X - 50, picTiraiKiri.Location.Y);
            //picTiraiKanan.Location = new Point(picTiraiKanan.Location.X + 50, picTiraiKanan.Location.Y);

            if (benarSalah == 11)
            {
                picP1BS.Visible = true;
                picP1BS.Image = Image.FromFile(Application.StartupPath + "\\G1YesNoRumahAdat\\1.png");
            }

            if (benarSalah == 21)
            {
                picP2BS.Visible = true;
                picP2BS.Image = Image.FromFile(Application.StartupPath + "\\G1YesNoRumahAdat\\1.png");
            }

            if (benarSalah == 31)
            {
                picP3BS.Visible = true;
                picP3BS.Image = Image.FromFile(Application.StartupPath + "\\G1YesNoRumahAdat\\1.png");
            }

            if (waktuPause == 5)
            {
                tmrG2.Enabled = true;
                tmrPause.Enabled = false;
                gambarVisible();
                waktuPause = 0;
                benarSalah = -1;
            }
        }

        int waktuSoal = 0;
        private void tmrSoal_Tick(object sender, EventArgs e)
        {
            waktuSoal++;
            if (waktuSoal == 4)
            {
                check = 0;
                soal = -1;
                gambar = -1;
                benarSalah = -1;
                jawabP1 = true;
                jawabP2 = true;
                waktuSoal = 0;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            this.Hide();
            this.theParent.Show();
            this.theParent.Focus();

            G0RandomGame ae = (G0RandomGame)this.theParent;
            if (ae.counter < 5)
            {
                ae.tmrRandom.Enabled = true;
                ae._start = DateTime.UtcNow;
                ae.counter++; ae.p1.Score+=pointP1; ae.p2.Score+=pointP2;
            }
            this.Dispose();
            
        }
        public Form theParent;

        //int waktuTunggu = 0;
        private void tmrWait_Tick(object sender, EventArgs e)
        {
            //waktuTunggu++;

            //if (waktuTunggu == 1)
            //{
                picTiraiKiri.Visible = true;
                picTiraiKanan.Visible = true;
                picTiraiKiri.Location = tiraiKi;
                picTiraiKanan.Location = tiraiKa;

                Random rnd = new Random();
                tmrSoal.Enabled = true;
                waktuSoal = 0;
                soal = rnd.Next(1, 15);
                gambar = rnd.Next(0, 3);
                lblSoal.Text = Jawaban[soal];
                check = 1;
                jawabP1 = true;
                jawabP2 = true;
                gambarVisible();

                if (gambar == 0)
                {
                    p1.Image = Image.FromFile(Application.StartupPath + "\\G2WrongPormBajuAdat\\" + soal + ".png");
                    p2.Image = Image.FromFile(Application.StartupPath + "\\G2WrongPormBajuAdat\\" + (soal - 1) + ".png");
                    p3.Image = Image.FromFile(Application.StartupPath + "\\G2WrongPormBajuAdat\\" + (soal + 1) + ".png");
                }
                else if (gambar == 1)
                {
                    p2.Image = Image.FromFile(Application.StartupPath + "\\G2WrongPormBajuAdat\\" + soal + ".png");
                    p3.Image = Image.FromFile(Application.StartupPath + "\\G2WrongPormBajuAdat\\" + (soal - 1) + ".png");
                    p1.Image = Image.FromFile(Application.StartupPath + "\\G2WrongPormBajuAdat\\" + (soal + 1) + ".png");
                }
                else if (gambar == 2)
                {
                    p3.Image = Image.FromFile(Application.StartupPath + "\\G2WrongPormBajuAdat\\" + soal + ".png");
                    p1.Image = Image.FromFile(Application.StartupPath + "\\G2WrongPormBajuAdat\\" + (soal - 1) + ".png");
                    p2.Image = Image.FromFile(Application.StartupPath + "\\G2WrongPormBajuAdat\\" + (soal + 1) + ".png");
                }
            //}

            //if (waktuTunggu == 2)
                tmrWait.Enabled = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void picExit_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            picTiraiKiri.Visible = true;
            picTiraiKanan.Visible = true;
            picTiraiKiri.Location = new Point(picTiraiKiri.Location.X - 35, picTiraiKiri.Location.Y);
            picTiraiKanan.Location = new Point(picTiraiKanan.Location.X + 35, picTiraiKanan.Location.Y);
        }

        private void picTiraiKanan_Click(object sender, EventArgs e)
        {

        }

        private void picExit_MouseHover(object sender, EventArgs e)
        {
            picExit.Image = Image.FromFile(Application.StartupPath + "\\Button\\quithover.png");
        }

        private void picExit_MouseLeave(object sender, EventArgs e)
        {
            picExit.Image = Image.FromFile(Application.StartupPath + "\\Button\\quit.png");
        }
    }
}
