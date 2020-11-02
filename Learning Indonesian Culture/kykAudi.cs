using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;
using System.Windows.Media;


namespace MIB_2015
{
    public partial class kykAudi : Form
    {
        /// <summary>
        /// improve: beda gbr pas dipitek bener
        /// improve: highscore module
        /// </summary>
        Player p1, p2;
        public kykAudi(Player p1, Player p2, int stage)
        {
            InitializeComponent();
            this.p1 = p1;
            this.p2 = p2;
            this.Text = "Stage " + stage.ToString();
            
        }

        string p1ans = "";
        string p2ans = "";
        int p1correct = 0, p2correct = 0, p1score = 0, p2score = 0;
        int p1key = 0;
        int p2key = 0;
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar.ToString().ToLower() == "a" || e.KeyChar.ToString().ToLower() == "w" ||
               e.KeyChar.ToString().ToLower() == "s" || e.KeyChar.ToString().ToLower() == "d"))
            {
                p1ans += e.KeyChar.ToString().ToLower();
                if (p1ans.Length != 0)
                {
                    if (p1ans.Length == cLength[p1now] || (p1ans[p1ans.Length - 1] != p1set[p1now][p1ans.Length - 1]))
                    {
                        if (p1ans == p1set[p1now])
                        {
                            p1key = 0;
                            p1bnr.Visible = true;
                            p1slh.Visible = false;
                            timer1.Enabled = false;
                            timer1.Enabled = true;
                            p1correct++;
                            p1score += 100;
                            p1move(false);
                            p1now++;
                            groupBox3.Controls.Clear();
                            p1draw();
                            new System.Threading.Thread(() =>
                            {
                                var c = new System.Windows.Media.MediaPlayer();
                                c.Open(new System.Uri(@Application.StartupPath + "\\s3\\sounds\\bnr.wav"));
                                c.Play();
                            }).Start();
                        }
                        else if (p1ans != p1set[p1now] && (p1ans[p1ans.Length - 1] != p1set[p1now][p1ans.Length - 1]))
                        {
                            p1key = 0;
                            p1slh.Visible = true;
                            p1bnr.Visible = false;
                            timer1.Enabled = true;
                            if (p1score > 0)
                                p1score -= 100;
                            groupBox3.Controls.Clear(); ;
                            p1regen();
                            p1draw();
                            p1move(true);
                            new System.Threading.Thread(() =>
                            {
                                var c = new System.Windows.Media.MediaPlayer();
                                c.Open(new System.Uri(@Application.StartupPath + "\\s3\\sounds\\slh.wav"));
                                c.Play();
                            }).Start();
                        }
                        if ((DateTime.UtcNow - _start).Seconds >= 30)
                        {
                            timer1.Enabled = true;
                            //p1go = false;
                            end();
                        }

                        p1ans = "";

                        label7.Text = "Skor: " + p1score.ToString();
                        label15.Text = "Jumlah benar: " + p1correct.ToString();
                    }
                    else if ((p1ans[p1ans.Length - 1] == p1set[p1now][p1ans.Length - 1]))
                    {
                        p1key++;
                        p1draw();
                    }
                }
            }
            if ((e.KeyChar.ToString().ToLower() == "i" || e.KeyChar.ToString().ToLower() == "k" ||
               e.KeyChar.ToString().ToLower() == "j" || e.KeyChar.ToString().ToLower() == "l"))
            {
                p2ans += e.KeyChar.ToString().ToLower();
                if (p2ans.Length != 0)
                {
                    if (p2ans.Length == cLength[p2now] || (p2ans[p2ans.Length - 1] != p2set[p2now][p2ans.Length - 1]))
                    {
                        if (p2ans == p2set[p2now])
                        {
                            p2key = 0;
                            new System.Threading.Thread(() =>
                            {
                                var c = new System.Windows.Media.MediaPlayer();
                                c.Open(new System.Uri(@Application.StartupPath + "\\s3\\sounds\\bnr.wav"));
                                c.Play();
                            }).Start();
                            p2slh.Visible = false;
                            p2bnr.Visible = true;
                            timer3.Enabled = false;
                            timer3.Enabled = true;
                            p2correct++;
                            p2score += 100;
                            p2move(false);
                            p2now++;
                            groupBox4.Controls.Clear();
                            p2draw();
                        }
                        else if (p2ans != p2set[p1now] && (p2ans[p2ans.Length - 1] != p2set[p2now][p2ans.Length - 1]))
                        {
                            p2key = 0;
                            new System.Threading.Thread(() =>
                            {
                                var c = new System.Windows.Media.MediaPlayer();
                                c.Open(new System.Uri(@Application.StartupPath + "\\s3\\sounds\\slh.wav"));
                                c.Play();
                            }).Start();
                            p2bnr.Visible = false;
                            p2slh.Visible = true;
                            timer1.Enabled = true;
                            if (p2score > 0)
                                p2score -= 100;
                            groupBox4.Controls.Clear();
                            p2regen();
                            p2draw();
                            p2move(true);

                        }

                        if ((DateTime.UtcNow - _start).Seconds >= 30)
                        {
                            timer3.Enabled = true;
                            //  p2go = false;
                            end();
                        }
                        p2ans = "";
                        label8.Text = "Skor: " + p2score.ToString();
                        label16.Text = "Jumlah benar: " + p2correct.ToString();
                    }
                    else if ((p2ans[p2ans.Length - 1] == p2set[p2now][p2ans.Length - 1]))
                    {
                        p2key++;
                        p2draw();
                    }

                }

            }
        }

        Queue<Image> p2q = new Queue<Image>();
        Queue<Image> p1q = new Queue<Image>();

        private void p2move(bool kalah)
        {
            Image p2i = Image.FromFile(Application.StartupPath + "\\s3\\imgs\\im.png");//i move
            Image p2j = Image.FromFile(Application.StartupPath + "\\s3\\imgs\\jm.png");//j move
            Image p2k = Image.FromFile(Application.StartupPath + "\\s3\\imgs\\km.png");//k move
            Image p2l = Image.FromFile(Application.StartupPath + "\\s3\\imgs\\lm.png");//l move
            Image p2f = Image.FromFile(Application.StartupPath + "\\s3\\imgs\\p2f.png");//p2 failed
            Image p2d = Image.FromFile(Application.StartupPath + "\\s3\\imgs\\p2d.png");//p2 diam
            if (kalah)
            {
              //  if (p1q.Count <= 1)
                p2q.Clear();
                    p2q.Enqueue(p2f);
            }
            else
            {
                for (int a = 0; a < p2set[p2now].Length; a++)
                {
                    if (p2set[p2now][a] == 'i') p2q.Enqueue(p2i);
                    if (p2set[p2now][a] == 'j') p2q.Enqueue(p2j);
                    if (p2set[p2now][a] == 'k') p2q.Enqueue(p2k);
                    if (p2set[p2now][a] == 'l') p2q.Enqueue(p2l);
                }

            }
            p2q.Enqueue(p2d);//diam
            tmrP2Gerak.Enabled = true;//jalankan
        }


        private void p1move(bool kalah)
        {

            Image p1a = Image.FromFile(Application.StartupPath + "\\s3\\imgs\\am.png");//i move
            Image p1w = Image.FromFile(Application.StartupPath + "\\s3\\imgs\\wm.png");//j move
            Image p1s = Image.FromFile(Application.StartupPath + "\\s3\\imgs\\sm.png");//k move
            Image p1d = Image.FromFile(Application.StartupPath + "\\s3\\imgs\\dm.png");//l move
            Image p1f = Image.FromFile(Application.StartupPath + "\\s3\\imgs\\p1f.png");//p1 failed
            Image p1di = Image.FromFile(Application.StartupPath + "\\s3\\imgs\\p1d.png");//p1 diam
            if (kalah)
            {
               // if (p1q.Count <= 1)
                p1q.Clear();
                    p1q.Enqueue(p1f);
            }
            else
            {
                for (int a = 0; a < p1set[p1now].Length; a++)
                {
                    if (p1set[p1now][a] == 'a') p1q.Enqueue(p1a);
                    if (p1set[p1now][a] == 'w') p1q.Enqueue(p1w);
                    if (p1set[p1now][a] == 's') p1q.Enqueue(p1s);
                    if (p1set[p1now][a] == 'd') p1q.Enqueue(p1d);

                }

            }
            p1q.Enqueue(p1di);//diam
            tmrp1Gerak.Enabled = true;//jalankan
        }

        private void end()
        {
            textBox1.Enabled = false;
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
            timer5.Enabled = true;
            System.Threading.Thread.Sleep(400);
            Player.RecordScore(3, p1.Name, p2.Name, p1score, p2score);
            hs t = new hs(3);
            t.ShowDialog();
            t.BringToFront();
            t.center();
        }

        private void p1regen()
        {
            string p1m = "awsd";
            string rep = "";
            for (int a = 0; a < cLength[p1now]; a++)
            {
                rep += p1m[gen.Next(0, 4)];
            }
            p1set[p1now] = rep;
        }

        private void p2regen()
        {
            string p2m = "ijkl";//ijkl
            string rep = "";
            for (int a = 0; a < cLength[p2now]; a++)
            {
                rep += p2m[gen.Next(0, 4)];
            }
            p2set[p2now] = rep;
        }

        private void p1draw()
        {
            int pk = p1key;
            Image pa = Image.FromFile(Application.StartupPath + "\\s3\\imgs\\a.png");
            Image pw = Image.FromFile(Application.StartupPath + "\\s3\\imgs\\w.png");
            Image ps = Image.FromFile(Application.StartupPath + "\\s3\\imgs\\s.png");
            Image pd = Image.FromFile(Application.StartupPath + "\\s3\\imgs\\d.png");

            Image pab = Image.FromFile(Application.StartupPath + "\\s3\\imgs\\ab.png");
            Image pwb = Image.FromFile(Application.StartupPath + "\\s3\\imgs\\wb.png");
            Image psb = Image.FromFile(Application.StartupPath + "\\s3\\imgs\\sb.png");
            Image pdb = Image.FromFile(Application.StartupPath + "\\s3\\imgs\\db.png");
            groupBox3.Controls.Clear();
            for (int a = 0; a < p1set[p1now].Length; a++)
            {
                PictureBox d = new PictureBox();
                if (pk > 0)
                {
                    if (p1set[p1now][a] == 'a')
                        d.BackgroundImage = pab;
                    if (p1set[p1now][a] == 'w')
                        d.BackgroundImage = pwb;
                    if (p1set[p1now][a] == 's')
                        d.BackgroundImage = psb;
                    if (p1set[p1now][a] == 'd')
                        d.BackgroundImage = pdb;
                    pk--;
                }
                else
                {
                    if (p1set[p1now][a] == 'a')
                        d.BackgroundImage = pa;
                    if (p1set[p1now][a] == 'w')
                        d.BackgroundImage = pw;
                    if (p1set[p1now][a] == 's')
                        d.BackgroundImage = ps;
                    if (p1set[p1now][a] == 'd')
                        d.BackgroundImage = pd;
                }
                d.Width = 40;
                d.Height = 40;
                d.Visible = true;
                d.Left = (a * 40);
                d.Top = 10;
                d.BackgroundImageLayout = ImageLayout.Stretch;
                groupBox3.Controls.Add(d);
            }

        }


        private void p2draw()
        {
            int pk = p2key;
            Image pa = Image.FromFile(Application.StartupPath + "\\s3\\imgs\\i.png");
            Image pw = Image.FromFile(Application.StartupPath + "\\s3\\imgs\\j.png");
            Image ps = Image.FromFile(Application.StartupPath + "\\s3\\imgs\\k.png");
            Image pd = Image.FromFile(Application.StartupPath + "\\s3\\imgs\\l.png");

            Image pab = Image.FromFile(Application.StartupPath + "\\s3\\imgs\\ib.png");
            Image pwb = Image.FromFile(Application.StartupPath + "\\s3\\imgs\\jb.png");
            Image psb = Image.FromFile(Application.StartupPath + "\\s3\\imgs\\kb.png");
            Image pdb = Image.FromFile(Application.StartupPath + "\\s3\\imgs\\lb.png");
            groupBox4.Controls.Clear();
            for (int a = 0; a < p2set[p2now].Length; a++)
            {
                PictureBox d = new PictureBox();
                if (pk > 0)
                {

                    if (p2set[p2now][a] == 'i')
                        d.BackgroundImage = pab;
                    if (p2set[p2now][a] == 'j')
                        d.BackgroundImage = pwb;
                    if (p2set[p2now][a] == 'k')
                        d.BackgroundImage = psb;
                    if (p2set[p2now][a] == 'l')
                        d.BackgroundImage = pdb;
                    pk--;
                }
                else
                {
                    if (p2set[p2now][a] == 'i')
                        d.BackgroundImage = pa;
                    if (p2set[p2now][a] == 'j')
                        d.BackgroundImage = pw;
                    if (p2set[p2now][a] == 'k')
                        d.BackgroundImage = ps;
                    if (p2set[p2now][a] == 'l')
                        d.BackgroundImage = pd;
                }
                d.Width = 40;
                d.Height = 40;
                d.Visible = true;
                d.Left = (a * 40);
                d.Top = 10;
                d.BackgroundImageLayout = ImageLayout.Stretch;
                groupBox4.Controls.Add(d);
            }

        }

        List<string> p1set = new List<string>();
        List<string> p2set = new List<string>();
        int p1now = 0, p2now = 0;
        DateTime _start = DateTime.UtcNow;
        Random gen = new Random();
        const int _maxLv = 40;
        int[] cLength = new int[_maxLv];
        public Form theParent;
        SoundPlayer w = new SoundPlayer(Application.StartupPath + "\\Music\\G33.wav");
        private void kykAudi_Load(object sender, EventArgs e)
        {
            CenterToScreen();
            this.BackgroundImage = Image.FromFile(Application.StartupPath + "\\s3\\imgs\\Backs.png");
            textBox1.Enabled = false;
            pictureBox2.BackgroundImage = Image.FromFile(Application.StartupPath + "\\s3\\imgs\\p1d.png");
            pictureBox3.BackgroundImage = Image.FromFile(Application.StartupPath + "\\s3\\imgs\\p2d.png");
            w.PlayLooping();
            int t = 0, i = 0;
            for (int a = 0; a < _maxLv; a++)
            {
                if (a < 4)
                {
                    cLength[a] = (a + 1);
                    if (a == 3) t++;
                }
                else if (a <= 3 + (t * 3))
                {
                    cLength[a] = 4 + t;
                    i++;
                }
                if (i == 3)
                {
                    i = 0;
                    t++;
                }

            }
            string p1m = "awsd";
            string p2m = "ijkl";
            for (int a = 0; a < cLength.Length; a++)
            {
                string tmp = "";
                string tmp2 = "";
                for (int b = 0; b < cLength[a]; b++)
                {
                    tmp += p1m[gen.Next(0, 4)];
                    tmp2 += p2m[gen.Next(0, 4)];
                }
                p1set.Add(tmp);
                p2set.Add(tmp2);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            p1bnr.Visible = false;
            p1slh.Visible = false;


        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            label2.Text = (_start.AddSeconds(30) - DateTime.UtcNow).Seconds.ToString() + ":" + ((_start.AddSeconds(30) - DateTime.UtcNow).Milliseconds / 10).ToString();
            if ((_start.AddSeconds(30) - DateTime.UtcNow).TotalSeconds <= 0)
            {
                timer2.Enabled = false;
                label2.Text = "0";
                end();
                //MessageBox.Show("uda 30s");
            }
        }

        private void kykAudi_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            p2bnr.Visible = false;
            p2slh.Visible = false;
        }

        private void tmrP2Gerak_Tick(object sender, EventArgs e)
        {
            if (p2q.Count != 0)
                pictureBox3.BackgroundImage = (Image)p2q.Dequeue();
            else
                tmrP2Gerak.Enabled = false;

        }

        private void tmrp1Gerak_Tick(object sender, EventArgs e)
        {
            if (p1q.Count != 0)
                pictureBox2.BackgroundImage = (Image)p1q.Dequeue();
            else
                tmrp1Gerak.Enabled = false;
        }

        int phase = 0;

        private void timer4_Tick(object sender, EventArgs e)
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
                    label17.Left -= 100;
                    label17.Text = "Mulai!";
                    timer4.Interval = 350;
                    textBox1.Enabled = true;
                    textBox1.Focus();
                    timer2.Enabled = true;
                    _start = DateTime.UtcNow;
                    p1draw();
                    p2draw();
                    /*
                    new System.Threading.Thread(() =>
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

        private void label4_Click(object sender, EventArgs e)
        {
            tmrp1Gerak.Enabled = true;
        }

        private void p2seri_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void timer5_Tick(object sender, EventArgs e)
        {
            
            w.Stop();
            this.Hide();
            this.theParent.Show();
            this.theParent.Focus();

            G0RandomGame ae = (G0RandomGame)this.theParent;
            if (ae.counter < 5)
            {
                ae.tmrRandom.Enabled = true;
                ae._start = DateTime.UtcNow;
                ae.counter++; ae.p1.Score += p1score; ae.p2.Score += p2score;
            }
            this.Dispose();
        }

        private void picExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            //{
            //    if (e.KeyCode == Keys.A || e.KeyCode == Keys.W || e.KeyCode == Keys.S || e.KeyCode == Keys.D)
            //        p1up = true;
            //    if (e.KeyCode == Keys.I || e.KeyCode == Keys.J || e.KeyCode == Keys.K || e.KeyCode == Keys.L)
            //        p2up = true;
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
