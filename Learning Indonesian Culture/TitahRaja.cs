using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Media;

namespace MIB_2015
{
    public partial class TitahRaja : Form
    {
        Player p1, p2;
        public TitahRaja(Player p1, Player p2, int stage)
        {
            InitializeComponent();
            this.Text = "Stage " + stage.ToString();
            this.p1 = p1;
            this.p2 = p2;
        }

        Image kenong = Image.FromFile(Application.StartupPath + "\\s2\\imgs\\kenong.png");
        Image kendhang = Image.FromFile(Application.StartupPath + "\\s2\\imgs\\kendhang.png");
        Image bp = Image.FromFile(Application.StartupPath + "\\s2\\imgs\\bonangPenerus.gif");
        Image bb = Image.FromFile(Application.StartupPath + "\\s2\\imgs\\bonangBarung.gif");

        SoundPlayer p = new SoundPlayer(Application.StartupPath + "\\Music\\G7.wav");

        private void Form1_Load(object sender, EventArgs e)
        {
            //this.BackgroundImage = Image.FromFile(Application.StartupPath + "\\s2\\imgs\\bg.jpg");
            // this.BackgroundImageLayout = ImageLayout.Stretch;
            p.PlayLooping();
            //p1a.Image = Image.FromFile(Application.StartupPath + "\\s2\\imgs\\kenong.png");
            //p1w.Image = Image.FromFile(Application.StartupPath + "\\s2\\imgs\\kendhang.png");
            //p1s.Image = Image.FromFile(Application.StartupPath + "\\s2\\imgs\\bonangPenerus.gif");
            //p1d.Image = Image.FromFile(Application.StartupPath + "\\s2\\imgs\\bonangBarung.gif");
            for (int a = 0; a < this.Controls.Count; a++)
                try
                {
                    if (this.Controls[a].BackColor == Color.FromKnownColor(KnownColor.Control))
                        this.Controls[a].BackColor = Color.FromArgb(67, 200, 50, 50);
                }
                catch (Exception ex)
                {
                    this.Controls[a].BackColor = Color.White;
                }

            //Bitmap BackBmp;
            //Bitmap BackImg;
            //Graphics memoryGraphics;
            //BackImg = (Bitmap)Bitmap.FromFile(Application.StartupPath + "\\s2\\imgs\\bg.jpg");
            //BackBmp = new Bitmap(BackImg.Width, BackImg.Height);
            //memoryGraphics = Graphics.FromImage(BackBmp);
            //memoryGraphics.DrawImage(BackImg, 0, 0, BackImg.Width, BackImg.Height);
            //// Slow
            ////BackgroundImage = Resources.Background;

            //// Fast
            //BackgroundImage = BackBmp;
            CenterToScreen();
            SuspendLayout();

            //panel3.BringToFront();
            //panel3.Left = 10;
            //panel3.Top = 10;
            //textBox3.Left = -100;
            //panel3.Width = this.Width;
            //panel3.Height = this.Height;
            textBox1.Focus();
            this.SuspendLayout();
            string p1moves = "awsd";
            string p2moves = "jikl";
            for (int a = 0; a < 5; a++)
            {
                string tmp = "";
                string tmp2 = "";
                for (int b = 0; b < cLength[a]; b++)
                {
                    int equalize = gen.Next(0, 4);
                    tmp += p1moves[equalize];
                    tmp2 += p2moves[equalize];
                }
                p1set.Add(tmp);
                p2set.Add(tmp2);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }
        List<string> p1set = new List<string>();
        List<string> p2set = new List<string>();
        int[] cLength = { 4, 5, 7, 8, 10 };
        int p1now = 0;
        int p1nowat = 0;

        //int p2now = 0;
        //int p2nowat = 0;
        Color[] cSet = { Color.Red, Color.ForestGreen, Color.Blue, Color.Yellow, Color.SteelBlue,Color.SeaGreen,Color.SkyBlue,Color.Navy,
                       Color.MediumVioletRed,Color.Maroon,Color.Lime,Color.LightPink,Color.Pink,Color.HotPink,Color.Gold,Color.Orange,Color.PeachPuff};
        Random gen = new Random();
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (p1nowat != cLength[p1now])
            {
                if (p1a.ForeColor != Color.Transparent)
                {
                    
                    p1a.ForeColor = Color.Transparent;
                }
                //else
                //{
                //    p1aa.Image = Image.FromFile(Application.StartupPath + "\\s2\\imgs\\bonang_off.jpg");
                //}
                if (p1w.ForeColor != Color.Transparent)
                {
                    p1w.ForeColor = Color.Transparent;
                }
                //else
                //{
                //    p1ww.Image = Image.FromFile(Application.StartupPath + "\\s2\\imgs\\kendhang_off.jpg");
                //}
                if (p1s.ForeColor != Color.Transparent)
                {
                    p1s.ForeColor = Color.Transparent;
                }
                //else
                //{
                //    p1ss.Image = Image.FromFile(Application.StartupPath + "\\s2\\imgs\\kenong_off.jpg");
                //}
                if (p1d.ForeColor != Color.Transparent)
                {
                    p1d.ForeColor = Color.Transparent;
                    //p1dd.Image = Image.FromFile(Application.StartupPath + "\\s2\\imgs\\penerus_off.jpg");
                }
                //else
                //{
                //    p1dd.Image = Image.FromFile(Application.StartupPath + "\\s2\\imgs\\penerus_off.jpg");
                //}
                //Thread.Sleep(1);
                if (p1set[p1now][p1nowat] == 'a')
                {
                    p1a.ForeColor = cSet[p1nowat];
                    p1aa.Image = Image.FromFile(Application.StartupPath + "\\s2\\imgs\\bonang_off.jpg");
                    p1ww.Image = Image.FromFile(Application.StartupPath + "\\s2\\imgs\\kendhang_off.jpg");
                    p1ss.Image = Image.FromFile(Application.StartupPath + "\\s2\\imgs\\kenong_off.jpg");
                    p1dd.Image = Image.FromFile(Application.StartupPath + "\\s2\\imgs\\penerus_off.jpg");
                  //  System.Threading.Thread.Sleep(100);
                    if(p1nowat%2==0)
                        p1aa.Image = Image.FromFile(Application.StartupPath + "\\s2\\imgs\\bonang.jpg");
                    else
                        p1aa.Image = Image.FromFile(Application.StartupPath + "\\s2\\imgs\\bonang2.jpg");
                    new System.Threading.Thread(() =>
                    {
                        var c = new System.Windows.Media.MediaPlayer();
                        c.Open(new System.Uri(@Application.StartupPath + "\\Music\\1.wav"));
                        c.Play();
                    }).Start();
                }
                if (p1set[p1now][p1nowat] == 'w')
                {
                    p1w.ForeColor = cSet[p1nowat];

                    p1ww.Image = Image.FromFile(Application.StartupPath + "\\s2\\imgs\\kendhang_off.jpg");
                    p1aa.Image = Image.FromFile(Application.StartupPath + "\\s2\\imgs\\bonang_off.jpg");
                    //p1ww.Image = Image.FromFile(Application.StartupPath + "\\s2\\imgs\\kendhang_off.jpg");
                    p1ss.Image = Image.FromFile(Application.StartupPath + "\\s2\\imgs\\kenong_off.jpg");
                    p1dd.Image = Image.FromFile(Application.StartupPath + "\\s2\\imgs\\penerus_off.jpg");
                  //  System.Threading.Thread.Sleep(100);
                    if (p1nowat % 2 == 0)
                        p1ww.Image = Image.FromFile(Application.StartupPath + "\\s2\\imgs\\kendhang_act.jpg");
                    else
                        p1ww.Image = Image.FromFile(Application.StartupPath + "\\s2\\imgs\\kendhang_act2.jpg");
                    new System.Threading.Thread(() =>
                    {
                        var c = new System.Windows.Media.MediaPlayer();
                        c.Open(new System.Uri(@Application.StartupPath + "\\Music\\2.wav"));
                        c.Play();
                    }).Start();
                }
                if (p1set[p1now][p1nowat] == 's')
                {
                    p1s.ForeColor = cSet[p1nowat];

                    p1ss.Image = Image.FromFile(Application.StartupPath + "\\s2\\imgs\\kenong_off.jpg");
                    p1aa.Image = Image.FromFile(Application.StartupPath + "\\s2\\imgs\\bonang_off.jpg");
                    p1ww.Image = Image.FromFile(Application.StartupPath + "\\s2\\imgs\\kendhang_off.jpg");
                    //p1ss.Image = Image.FromFile(Application.StartupPath + "\\s2\\imgs\\kenong_off.jpg");
                    p1dd.Image = Image.FromFile(Application.StartupPath + "\\s2\\imgs\\penerus_off.jpg");
                   // System.Threading.Thread.Sleep(100);

                    if (p1nowat % 2 == 0)
                        p1ss.Image = Image.FromFile(Application.StartupPath + "\\s2\\imgs\\kenong.jpg");
                    else
                        p1ss.Image = Image.FromFile(Application.StartupPath + "\\s2\\imgs\\kenong2.jpg");
                    new System.Threading.Thread(() =>
                    {
                        var c = new System.Windows.Media.MediaPlayer();
                        c.Open(new System.Uri(@Application.StartupPath + "\\Music\\3.wav"));
                        c.Play();
                    }).Start();
                }
                if (p1set[p1now][p1nowat] == 'd')
                {
                    p1d.ForeColor = cSet[p1nowat];

                    p1dd.Image = Image.FromFile(Application.StartupPath + "\\s2\\imgs\\penerus_off.jpg");
                    p1aa.Image = Image.FromFile(Application.StartupPath + "\\s2\\imgs\\bonang_off.jpg");
                    p1ww.Image = Image.FromFile(Application.StartupPath + "\\s2\\imgs\\kendhang_off.jpg");
                    p1ss.Image = Image.FromFile(Application.StartupPath + "\\s2\\imgs\\kenong_off.jpg");
                   // System.Threading.Thread.Sleep(100);

                    if (p1nowat % 2 == 0)
                        p1dd.Image = Image.FromFile(Application.StartupPath + "\\s2\\imgs\\penerus.jpg");
                    else
                        p1dd.Image = Image.FromFile(Application.StartupPath + "\\s2\\imgs\\penerus2.jpg");
                    new System.Threading.Thread(() =>
                    {
                        var c = new System.Windows.Media.MediaPlayer();
                        c.Open(new System.Uri(@Application.StartupPath + "\\Music\\4.wav"));
                        c.Play();
                    }).Start();
                }

                p1nowat++;
            }
            else
            {
                timer1.Enabled = false;
                // label1.Text = p1set[p1now];
                p1go = true;
                p2go = true;
                p1ans = "";
                p2ans = "";
                if (p1aa.ForeColor != Color.Transparent)
                    p1aa.ForeColor = Color.Transparent;
                if (p1ww.ForeColor != Color.Transparent)
                    p1ww.ForeColor = Color.Transparent;
                if (p1ss.ForeColor != Color.Transparent)
                    p1ss.ForeColor = Color.Transparent;
                if (p1dd.ForeColor != Color.Transparent)
                    p1dd.ForeColor = Color.Transparent;
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        string p1ans = "";
        int p1correct = 0;
        bool p1go = false;
        int p1score = 0;

        string p2ans = "";
        int p2correct = 0;
        bool p2go = false;
        int p2score = 0;
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (p1go)
            {
                if ((e.KeyChar.ToString().ToLower() == "a" || e.KeyChar.ToString().ToLower() == "w" ||
                    e.KeyChar.ToString().ToLower() == "s" || e.KeyChar.ToString().ToLower() == "d"))
                    p1ans += e.KeyChar.ToString().ToLower();
                #region kalo di pencet bunyi(p1)
                if (e.KeyChar.ToString().ToLower() == "a")
                {
                    pictureBox1.BackgroundImage = kenong;
                    new System.Threading.Thread(() =>
                    {
                        var c = new System.Windows.Media.MediaPlayer();
                        c.Open(new System.Uri(@Application.StartupPath + "\\Music\\1.wav"));
                        c.Play();
                    }).Start();
                }
                if (e.KeyChar.ToString().ToLower() == "w")
                {
                    pictureBox1.BackgroundImage = kendhang;
                    new System.Threading.Thread(() =>
                    {
                        var c = new System.Windows.Media.MediaPlayer();
                        c.Open(new System.Uri(@Application.StartupPath + "\\Music\\2.wav"));
                        c.Play();
                    }).Start();
                }
                if (e.KeyChar.ToString().ToLower() == "s")
                {

                    pictureBox1.BackgroundImage = bp;
                    new System.Threading.Thread(() =>
                    {
                        var c = new System.Windows.Media.MediaPlayer();
                        c.Open(new System.Uri(@Application.StartupPath + "\\Music\\3.wav"));
                        c.Play();
                    }).Start();
                }
                if (e.KeyChar.ToString().ToLower() == "d")
                {

                    pictureBox1.BackgroundImage = bb;
                    new System.Threading.Thread(() =>
                    {
                        var c = new System.Windows.Media.MediaPlayer();
                        c.Open(new System.Uri(@Application.StartupPath + "\\Music\\4.wav"));
                        c.Play();
                    }).Start();
                }

                #endregion

                if (p1ans.Length != 0)
                {
                    if (p1ans.Length == cLength[p1now] || (p1ans[p1ans.Length - 1] != p1set[p1now][p1ans.Length - 1]))
                    {
                        if (p1ans == p1set[p1now])
                        {

                            progressBar1.Value++;
                            progressBar2.Value++;
                            label11.Text = progressBar1.Value.ToString() + " dari 5 (" + Math.Round((progressBar1.Value / 5.0) * 100.0, 1) + "%)";
                            label5.Text = progressBar2.Value.ToString() + " dari 5 (" + Math.Round((progressBar2.Value / 5.0) * 100.0, 1) + "%)";
                            p1go = false;
                            p2go = false;
                            p1bnr.Visible = true;
                            timer3.Enabled = true;
                            p1correct++;
                            p1score += 100;
                            p1now++;
                            timer1.Enabled = true;
                        }
                        else// if (p1ans.Length != cLength[p1now] && (p1ans[p1ans.Length - 1] != p1set[p1now][p1ans.Length - 1]))
                        {

                            if (!p2go)
                            {
                                p1now++;
                                timer1.Enabled = true;
                                progressBar1.Value++;
                                progressBar2.Value++;
                                label11.Text = progressBar1.Value.ToString() + " dari 5 (" + Math.Round((progressBar1.Value / 5.0) * 100.0, 1) + "%)";
                                label5.Text = progressBar2.Value.ToString() + " dari 5 (" + Math.Round((progressBar2.Value / 5.0) * 100.0, 1) + "%)";
                            }
                            p1go = false;
                            p1slh.Visible = true;
                            timer3.Enabled = true;
                            if (p1score > 0)
                                p1score -= 50;
                        }
                        p1nowat = 0;
                        if (p1now <= 4)
                        {
                            //   p1go = false;
                        }
                        else
                            end();
                        
                        p1ans = "";

                        label7.Text = "Skor: " + p1score.ToString();
                        label15.Text = "Jumlah benar: " + p1correct.ToString();
                    }
                }
            }

            if (p2go)
            {
                if ((e.KeyChar.ToString().ToLower() == "i" || e.KeyChar.ToString().ToLower() == "k" ||
                   e.KeyChar.ToString().ToLower() == "j" || e.KeyChar.ToString().ToLower() == "l"))
                    p2ans += e.KeyChar.ToString().ToLower();
                #region kalo dipencet bunyi(p2)
                if (e.KeyChar.ToString().ToLower() == "j")
                {
                    pictureBox2.BackgroundImage = kenong;
                    new System.Threading.Thread(() =>
                    {
                        var c = new System.Windows.Media.MediaPlayer();
                        c.Open(new System.Uri(@Application.StartupPath + "\\Music\\1.wav"));
                        c.Play();
                    }).Start();
                }
                if (e.KeyChar.ToString().ToLower() == "i")
                {
                    pictureBox2.BackgroundImage = kendhang;
                    new System.Threading.Thread(() =>
                    {
                        var c = new System.Windows.Media.MediaPlayer();
                        c.Open(new System.Uri(@Application.StartupPath + "\\Music\\2.wav"));
                        c.Play();
                    }).Start();
                }
                if (e.KeyChar.ToString().ToLower() == "k")
                {
                    pictureBox2.BackgroundImage = bp;
                    new System.Threading.Thread(() =>
                    {
                        var c = new System.Windows.Media.MediaPlayer();
                        c.Open(new System.Uri(@Application.StartupPath + "\\Music\\3.wav"));
                        c.Play();
                    }).Start();
                }
                if (e.KeyChar.ToString().ToLower() == "l")
                {

                    pictureBox2.BackgroundImage = bb;
                    new System.Threading.Thread(() =>
                    {
                        var c = new System.Windows.Media.MediaPlayer();
                        c.Open(new System.Uri(@Application.StartupPath + "\\Music\\4.wav"));
                        c.Play();
                    }).Start();
                }
                #endregion

                if (p2ans.Length != 0)
                {
                    if (p2ans.Length == cLength[p1now] || (p2ans[p2ans.Length - 1] != p2set[p1now][p2ans.Length - 1]))
                    {
                        if (p2ans == p2set[p1now])
                        {
                            progressBar1.Value++;
                            progressBar2.Value++;
                            label5.Text = progressBar2.Value.ToString() + " dari 5 (" + Math.Round((progressBar2.Value / 5.0) * 100.0, 1) + "%)";
                            label11.Text = progressBar1.Value.ToString() + " dari 5 (" + Math.Round((progressBar1.Value / 5.0) * 100.0, 1) + "%)";
                            p2go = false;
                            p1go = false;
                            p2bnr.Visible = true;
                            timer4.Enabled = true;
                            p2correct++;
                            p2score += 100;
                            p1now++;
                            timer1.Enabled = true;
                        }
                        else //if (p2ans.Length != cLength[p2now] && (p2ans[p2ans.Length - 1] != p2set[p2now][p2ans.Length - 1]))
                        {
                            if (!p1go)
                            {
                                p1now++;
                                timer1.Enabled = true;
                                progressBar2.Value++;
                                progressBar1.Value++; 
                                label5.Text = progressBar2.Value.ToString() + " dari 5 (" + Math.Round((progressBar2.Value / 5.0) * 100.0, 1) + "%)";
                                label11.Text = progressBar1.Value.ToString() + " dari 5 (" + Math.Round((progressBar1.Value / 5.0) * 100.0, 1) + "%)";
                            }
                            p2go = false;
                            p2slh.Visible = true;
                            timer4.Enabled = true;
                            if (p2score > 0)
                                p2score -= 50;

                        }

                        if (p1now <= 4)
                        {
                            //  p2go = false;
                        }
                        else
                            end();
                        
                        
                        p2ans = "";
                        label8.Text = "Skor: " + p2score.ToString();
                        label16.Text = "Jumlah benar: " + p2correct.ToString();
                    }
                }
            }
            // groupBox1.Text = p1ans;
            // groupBox2.Text = p2ans;
        }

        private void end()
        {
            textBox1.Enabled = false;
            timer1.Enabled = false;
            if (p1score < p2score)
            {
                p1kalah.Visible = true;
                p2menang.Visible = true;
                p1score += 200;

            }
            else if (p1score > p2score)
            {
                p1menang.Visible = true;
                p2kalah.Visible = true;
                p2score += 100;
            }
            else
            {
                p2seri.Visible = true;
                p1seri.Visible = true;
                p1score += 50;
                p2score += 50;
            }

            label7.Text = "Skor: " + p1score.ToString();
            label8.Text = "Skor: " + p2score.ToString();

            System.Threading.Thread.Sleep(400);
            Player.RecordScore(4, p1.Name, p2.Name, p1score, p2score);
            hs t = new hs(4);
            t.ShowDialog();
            t.BringToFront();
            t.center();
            timer2.Enabled = true;
        }

        private void p1s_Click(object sender, EventArgs e)
        {

        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (p1bnr.Visible)
                p1bnr.Visible = !p1bnr.Visible;

            if (p1slh.Visible)
                p1slh.Visible = !p1slh.Visible;
            timer3.Enabled = false;
        }

        private void timer4_Tick_1(object sender, EventArgs e)
        {

            if (p2bnr.Visible)
                p2bnr.Visible = !p2bnr.Visible;

            if (p2slh.Visible)
                p2slh.Visible = !p2slh.Visible;
            timer4.Enabled = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {

            //if (e.KeyCode == Keys.A)
            //    p1r++;

            //if (e.KeyCode == Keys.J)
            //    p2r++;
            //if (p1r >= 2)
            //    label13.Visible = true;
            //if (p2r >= 2)
            //    label14.Visible = true;
            //if (p1r >= 2 && p2r >= 2)
            //{
            //    timer5.Enabled = true;
            //    //panel3.Dispose();
            //}
        }
        int phase = 0;
        private void timer5_Tick(object sender, EventArgs e)
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
                    textBox1.Enabled = true;
                    textBox1.Focus();
                    timer1.Enabled = true;
                    timer5.Interval = 400;
                    break;
                case 4:

                    label17.Dispose();
                    timer5.Dispose();
                    break;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void p1d_Click(object sender, EventArgs e)
        {

        }

        private void p2k_Click(object sender, EventArgs e)
        {

        }

        private void p1w_Click(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {

            this.Hide();
            this.theParent.Show();
            this.theParent.Focus();

            G0RandomGame ae = (G0RandomGame)this.theParent;
            if (ae.counter < 5)
            {
                ae.tmrRandom.Enabled = true;
                ae._start = DateTime.UtcNow;
                ae.counter++; ae.p1.Score+=p1score; ae.p2.Score+=p2score;
            }
            this.Dispose();
        }
        public Form theParent;

        private void picExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void TitahRaja_FormClosed(object sender, FormClosedEventArgs e)
        {
            p.Stop();
        }

        private void picExit_MouseHover(object sender, EventArgs e)
        {
            picExit.Image = Image.FromFile(Application.StartupPath + "\\Button\\quithover.png");
        }

        private void picExit_MouseLeave(object sender, EventArgs e)
        {
            picExit.Image = Image.FromFile(Application.StartupPath + "\\Button\\quit.png");
        }

        private void label24_Click(object sender, EventArgs e)
        {

        }
    }
}
