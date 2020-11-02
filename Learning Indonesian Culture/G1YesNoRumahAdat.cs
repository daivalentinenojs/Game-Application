using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Media;
using System.Collections;
using System.Media;

namespace MIB_2015
{
    public partial class G1YesNoRumahAdat : Form
    {
        Player p1, p2;
        public G1YesNoRumahAdat(Player p1, Player p2, int stage)
        {
            InitializeComponent();
            this.p1 = p1;
            this.p2 = p2;
            this.Text = "Stage: " + stage.ToString();
            //this.label9.Text = p1.Name;
            //this.label5.Text = p2.Name;
        }

        soal[] task = new soal[20];
        DateTime _start;
        SoundPlayer p = new SoundPlayer(Application.StartupPath + "\\s5\\G1.wav");
        private void G1YesNoRumahAdat_Load(object sender, EventArgs e)
        {
            Lock = true;
            this.CenterToScreen();
            p.PlayLooping();
            task[0] = new soal(Image.FromFile(Application.StartupPath + "\\s5\\1.jpg"), "Sumatra Barat, Rumah Gadang");
            task[1] = new soal(Image.FromFile(Application.StartupPath + "\\s5\\2.jpg"), "Riau, Rumah Melayu Selaso");
            task[2] = new soal(Image.FromFile(Application.StartupPath + "\\s5\\3.jpg"), "Jambi, Rumah Panjang");
            task[3] = new soal(Image.FromFile(Application.StartupPath + "\\s5\\4.jpg"), "Sumatra Selatan, Rumah Limas");
            task[4] = new soal(Image.FromFile(Application.StartupPath + "\\s5\\5.jpg"), "Bangka Belitung, Rumah Limas");
            task[5] = new soal(Image.FromFile(Application.StartupPath + "\\s5\\6.jpg"), "Bengkulu, Rumah Rakyat");
            task[6] = new soal(Image.FromFile(Application.StartupPath + "\\s5\\7.jpg"), "Lampung, Nowou Sesat");
            task[7] = new soal(Image.FromFile(Application.StartupPath + "\\s5\\8.jpg"), "Jakarta, Rumah Kebaya");
            task[8] = new soal(Image.FromFile(Application.StartupPath + "\\s5\\9.jpg"), "Jawa Barat, Rumah Kasepuhan Cirebon");
            task[9] = new soal(Image.FromFile(Application.StartupPath + "\\s5\\10.jpg"), "Banten, Rumah Badui");
            task[10] = new soal(Image.FromFile(Application.StartupPath + "\\s5\\11.jpg"), "Jawa Tengah, Rumah Joglo");
            task[11] = new soal(Image.FromFile(Application.StartupPath + "\\s5\\12.jpg"), "Yogyakarta, Bangsal Kencono");
            task[12] = new soal(Image.FromFile(Application.StartupPath + "\\s5\\13.jpg"), "Jawa Timur, Rumah Joglo Situbondo");
            task[13] = new soal(Image.FromFile(Application.StartupPath + "\\s5\\14.jpg"), "Bali, Rumah Gapura Candi Bentar");
            task[14] = new soal(Image.FromFile(Application.StartupPath + "\\s5\\15.jpg"), "Nusa Tenggara Barat, Isata Sumbawa");
            task[15] = new soal(Image.FromFile(Application.StartupPath + "\\s5\\16.jpg"), "Nusa Tenggara Timur, Rumah Musalaki");
            task[16] = new soal(Image.FromFile(Application.StartupPath + "\\s5\\17.jpg"), "Kalimantan Barat, Istana Pontianak");
            task[17] = new soal(Image.FromFile(Application.StartupPath + "\\s5\\18.jpg"), "Kalimantan Tengah, Rumah Betang");
            task[18] = new soal(Image.FromFile(Application.StartupPath + "\\s5\\19.jpg"), "Kalimantan Selatan, Bubungan Tinggi");
            //task[19] = new soal(Image.FromFile(Application.StartupPath + "\\s5\\20.jpg"), "");

            pbp1.Image = Image.FromFile(Application.StartupPath + "\\s5\\P1Netral.png");
            pbp2.Image = Image.FromFile(Application.StartupPath + "\\s5\\P2Netral.png");
            picExit.Image = Image.FromFile(Application.StartupPath + "\\Button\\quit.png");
            this.BackgroundImage = Image.FromFile(Application.StartupPath + "\\s5\\Backs.png");
              
        }

        Stack p1m = new Stack();
        Stack p2m = new Stack();
        bool Lock = false;
        private void G1YesNoRumahAdat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Lock)
            {
                if ((e.KeyChar == 'a' || e.KeyChar == 'w' || e.KeyChar == 's' || e.KeyChar == 'd') && !p1lock)
                {
                    p1m.Push(e.KeyChar);
                    if (e.KeyChar == 'a')
                    {
                        pbp1.Image = Image.FromFile(Application.StartupPath + "\\s5\\P1Kiri.png");
                    }

                    if (e.KeyChar == 'w')
                    {
                        pbp1.Image = Image.FromFile(Application.StartupPath + "\\s5\\P1Atas.png");
                    }

                    if (e.KeyChar == 's')
                    {
                        pbp1.Image = Image.FromFile(Application.StartupPath + "\\s5\\P1Bawah.png");
                    }

                    if (e.KeyChar == 'd')
                    {
                        pbp1.Image = Image.FromFile(Application.StartupPath + "\\s5\\P1Kanan.png");
                    }
                }
                if (e.KeyChar == 'i' || e.KeyChar == 'j' || e.KeyChar == 'k' || e.KeyChar == 'l')
                {
                    p2m.Push(e.KeyChar);
                    if (e.KeyChar == 'j')
                    {
                        pbp2.Image = Image.FromFile(Application.StartupPath + "\\s5\\P2Kiri.png");
                    }

                    if (e.KeyChar == 'i')
                    {
                        pbp2.Image = Image.FromFile(Application.StartupPath + "\\s5\\P2Atas.png");
                    }

                    if (e.KeyChar == 'k')
                    {
                        pbp2.Image = Image.FromFile(Application.StartupPath + "\\s5\\P2Bawah.png");
                    }

                    if (e.KeyChar == 'l')
                    {
                        pbp2.Image = Image.FromFile(Application.StartupPath + "\\s5\\P2Kanan.png");
                    }
                }
                cek();
            }
        }

        Random gen = new Random();
        soal now;
        string question;
        private void generate()
        {
            p1lock = false;
            p2lock = false;
            p1angguk = 0;
            p2angguk = 0;
            p1geleng = 0;
            p2geleng = 0;
            int num = gen.Next(0, 1000);
            if (num % 2 == 0)
            {
                now = task[gen.Next(0, 19)];
                question = task[gen.Next(0, 19)].ans;
            }
            else
            {
                now = task[gen.Next(0, 19)];
                question = now.ans;
            }
            lblSoal.Text = question;
            picSoal.Image = now.img;

            lblSoal.Left = (this.Width / 2 - lblSoal.Width / 2);
        }


        int p1geleng = 0;
        int p1angguk = 0;
        int p1score = 0;
        bool p1lock = false;

        int p2geleng = 0;
        int p2angguk = 0;
        int p2score = 0;
        bool p2lock = false;

        private void cek()
        {

            if (p1lock && p2lock)
            {
                generate();
            }
            if (!p1lock)
            {
                char p1a = '\0', p1b = '\0';
                if (p1m.Count != 0) p1a = (char)p1m.Pop();
                if (p1m.Count != 0) p1b = (char)p1m.Pop();
                if (p1b == '\0')
                    p1m.Push(p1a);
                else
                {
                    if (p1a == 'a' && p1b == 'd')
                    {
                        p1geleng++;
                        p1angguk = 0;
                        p1m.Clear();
                    }
                    else if (p1a == 'w' && p1b == 's')
                    {
                        p1geleng = 0;
                        p1angguk++;
                        p1m.Clear();
                    }
                    else
                    {
                        p1geleng = 0;
                        p1angguk = 0;
                        p1m.Push(p1b);
                        p1m.Push(p1a);
                    }
                }
                if (p1angguk == 3)
                {
                    if (now.ans == question)
                    {
                        new System.Threading.Thread(() =>
                        {
                            var c = new System.Windows.Media.MediaPlayer();
                            c.Open(new System.Uri(@Application.StartupPath + "\\s5\\G1Benar.wav"));
                            c.Play();
                        }).Start();
                        _soal = DateTime.UtcNow.AddSeconds(4);
                        picP1BS.Image = Image.FromFile(Application.StartupPath + "\\s5\\1.png");
                        picP1BS.Visible = true;
                        tmrBS1.Enabled = true;
                        p1score += 100;
                        pp1.Text = p1score.ToString();
                        p1lock = true;
                        p2lock = true;
                        cek();
                    }
                    else
                    {
                        new System.Threading.Thread(() =>
                        {
                            var c = new System.Windows.Media.MediaPlayer();
                            c.Open(new System.Uri(@Application.StartupPath + "\\s5\\G1Salah.wav"));
                            c.Play();
                        }).Start();
                        picP1BS.Image = Image.FromFile(Application.StartupPath + "\\s5\\0.png");
                        picP1BS.Visible = true;
                        tmrBS1.Enabled = true;
                    }
                }
                if (p1geleng == 3)
                {
                    if (now.ans != question && p1geleng == 3)
                    {
                        new System.Threading.Thread(() =>
                        {
                            var c = new System.Windows.Media.MediaPlayer();
                            c.Open(new System.Uri(@Application.StartupPath + "\\s5\\G1Benar.wav"));
                            c.Play();
                        }).Start();
                        _soal = DateTime.UtcNow.AddSeconds(4);
                        picP1BS.Image = Image.FromFile(Application.StartupPath + "\\s5\\1.png");
                        picP1BS.Visible = true;
                        tmrBS1.Enabled = true;
                        p1score += 100;
                        pp1.Text = p1score.ToString();
                        p1lock = true;
                        p2lock = true;
                        cek();
                    }
                    else
                    {
                        new System.Threading.Thread(() =>
                        {
                            var c = new System.Windows.Media.MediaPlayer();
                            c.Open(new System.Uri(@Application.StartupPath + "\\s5\\G1Salah.wav"));
                            c.Play();
                        }).Start();
                        picP1BS.Image = Image.FromFile(Application.StartupPath + "\\s5\\0.png");
                        picP1BS.Visible = true;
                        tmrBS1.Enabled = true;
                    }
                }
            }
            if (!p2lock)
            {
                char p2a = '\0', p2b = '\0';
                if (p2m.Count != 0) p2a = (char)p2m.Pop();
                if (p2m.Count != 0) p2b = (char)p2m.Pop();
                if (p2b == '\0')
                    p2m.Push(p2a);
                else
                {
                    if (p2a == 'j' && p2b == 'l')
                    {
                        p2geleng++;
                        p2angguk = 0;
                        p2m.Clear();
                    }
                    else if (p2a == 'i' && p2b == 'k')
                    {
                        p2geleng = 0;
                        p2angguk++;
                        p2m.Clear();
                    }
                    else
                    {
                        p2geleng = 0;
                        p2angguk = 0;
                        p2m.Push(p2b);
                        p2m.Push(p2a);
                    }
                }
                if (p2angguk == 3)
                {
                    if (now.ans == question)
                    {
                        new System.Threading.Thread(() =>
                        {
                            var c = new System.Windows.Media.MediaPlayer();
                            c.Open(new System.Uri(@Application.StartupPath + "\\s5\\G1Benar.wav"));
                            c.Play();
                        }).Start();
                        _soal = DateTime.UtcNow.AddSeconds(4);
                        picP2BS.Image = Image.FromFile(Application.StartupPath + "\\s5\\1.png");
                        picP2BS.Visible = true;
                        tmrBS2.Enabled = true;
                        p2score += 100;
                        pp2.Text = p2score.ToString();
                        p2lock = true;
                        p1lock = true;
                        cek();
                    }
                    else
                    {
                        new System.Threading.Thread(() =>
                        {
                            var c = new System.Windows.Media.MediaPlayer();
                            c.Open(new System.Uri(@Application.StartupPath + "\\s5\\G1Salah.wav"));
                            c.Play();
                        }).Start();
                        picP2BS.Image = Image.FromFile(Application.StartupPath + "\\s5\\0.png");
                        picP2BS.Visible = true;
                        tmrBS2.Enabled = true;
                    }
                }
                if (p2geleng == 3)
                {
                    if (now.ans != question && p2geleng == 3)
                    {
                        new System.Threading.Thread(() =>
                        {
                            var c = new System.Windows.Media.MediaPlayer();
                            c.Open(new System.Uri(@Application.StartupPath + "\\s5\\G1Benar.wav"));
                            c.Play();
                        }).Start();
                        _soal = DateTime.UtcNow.AddSeconds(4);
                        picP2BS.Image = Image.FromFile(Application.StartupPath + "\\s5\\1.png");
                        picP2BS.Visible = true;
                        tmrBS2.Enabled = true;
                        p2score += 100;
                        pp2.Text = p2score.ToString();
                        p2lock = true;
                        p1lock = true;
                        cek();
                    }
                    else
                    {
                        new System.Threading.Thread(() =>
                        {
                            var c = new System.Windows.Media.MediaPlayer();
                            c.Open(new System.Uri(@Application.StartupPath + "\\s5\\G1Salah.wav"));
                            c.Play();
                        }).Start();
                        picP2BS.Image = Image.FromFile(Application.StartupPath + "\\s5\\0.png");
                        picP2BS.Visible = true;
                        tmrBS2.Enabled = true;
                    }
                }
            }

        }

        private void picExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tmrBS_Tick(object sender, EventArgs e)
        {

            picP1BS.Visible = false;
        }

        private void tmrBS2_Tick(object sender, EventArgs e)
        {
            picP2BS.Visible = false;
        }

        DateTime _soal;
        private void tmrG1_Tick(object sender, EventArgs e)
        {
            lblDetik.Text = (_start - DateTime.UtcNow).Seconds.ToString() + " : " + ((_start - DateTime.UtcNow).Milliseconds / 10).ToString();
            label8.Text = (_soal - DateTime.UtcNow).Seconds.ToString() + " : " + ((_soal - DateTime.UtcNow).Milliseconds / 10).ToString();
            if ((_soal - DateTime.UtcNow).Ticks <= 0)
            {
                _soal = DateTime.UtcNow.AddSeconds(4);
                generate();
            }
            if ((_start - DateTime.UtcNow).Ticks<=0)
            {
                tmrG1.Enabled = false;
                lblDetik.Text = "00:00";
                end();
            }
        }

        private void end()
        {
            Lock = true;
            if (p1score > p2score)
            {
                p1menang.Visible = true;
                p1kalah.Visible = false;
                p2menang.Visible = false;
                p2kalah.Visible = true;
            }
            else if (p1score < p2score)
            {
                p1menang.Visible = false;
                p1kalah.Visible = true;
                p2menang.Visible = true;
                p2kalah.Visible = false;
            }
            else
            {
                p1seri.Visible = true;
                p2seri.Visible = true;
            }
            timer1.Enabled = true;

            System.Threading.Thread.Sleep(400);
            Player.RecordScore(1, p1.Name, p2.Name, p1score, p2score);
            hs t = new hs(1);
            t.ShowDialog();
            t.BringToFront();
            t.center();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            p.Stop();
            this.Hide();
            this.theParent.Show();
            this.theParent.Focus();

            G0RandomGame ae = (G0RandomGame)this.theParent;
            if (ae.counter < 5)
            {
                ae.tmrRandom.Enabled = true;
                ae._start = DateTime.UtcNow;
                ae.counter++; ae.p1.Score+=p1score; ae.p2.Score+=p2score;
                ae.p1.Score += p1score;
                ae.p2.Score += p2score;
            }
            this.Dispose();
        }
        public Form theParent;

        private void picExit_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        int phase = 0;

        private void timer2_Tick(object sender, EventArgs e)
        {
            phase++;
            switch (phase)
            {
                case 0:
                    label17.Text = "3";
                    break;
                case 1:
                    label17.Text = "2";
                    break;
                case 2:
                    label17.Text = "1";
                    break;
                case 3:
                    Lock = false;
                    _start = DateTime.UtcNow.AddSeconds(60);
                    _soal = DateTime.UtcNow.AddSeconds(4);
                    label17.Left -= 100;
                    label17.Text = "Mulai!";
                    timer2.Interval = 350;
                    tmrG1.Enabled = true;
                    generate();
                    /*new System.Threading.Thread(() =>
                    {
                        var c = new System.Windows.Media.MediaPlayer();
                        c.Open(new System.Uri(@Application.StartupPath + "\\s3\\sounds\\start.wav"));
                        c.Play();
                    }).Start();*/
                    break;
                case 4:

                    label17.Dispose();
                    break;
            }
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

    public class soal
    {
        public Image img;
        public string ans;
        public soal(Image img, string ans)
        {
            this.img = img;
            this.ans = ans;
        }

    }
}