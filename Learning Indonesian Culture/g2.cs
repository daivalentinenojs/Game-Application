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
    public partial class game2 : Form
    {
        Player _p1, _p2;
        int stage = 0;
        orang[] dat ={
                new orang(Image.FromFile(Application.StartupPath+"\\G2WrongPormBajuAdat\\0.png"),"x"),
                new orang(Image.FromFile(Application.StartupPath+"\\G2WrongPormBajuAdat\\1.png"),"Sumatera Utara"),
                new orang(Image.FromFile(Application.StartupPath+"\\G2WrongPormBajuAdat\\2.png"),"Sumatera Barat"),
                new orang(Image.FromFile(Application.StartupPath+"\\G2WrongPormBajuAdat\\3.png"),"Riau"),
                new orang(Image.FromFile(Application.StartupPath+"\\G2WrongPormBajuAdat\\4.png"),"Sumatera Selatan"),
                new orang(Image.FromFile(Application.StartupPath+"\\G2WrongPormBajuAdat\\5.png"),"Lampung"),
                new orang(Image.FromFile(Application.StartupPath+"\\G2WrongPormBajuAdat\\6.png"),"Banten"),
                new orang(Image.FromFile(Application.StartupPath+"\\G2WrongPormBajuAdat\\7.png"),"Jakarta"),
                new orang(Image.FromFile(Application.StartupPath+"\\G2WrongPormBajuAdat\\8.png"),"Jawa Timur"),
                new orang(Image.FromFile(Application.StartupPath+"\\G2WrongPormBajuAdat\\9.png"),"Bali"),
                new orang(Image.FromFile(Application.StartupPath+"\\G2WrongPormBajuAdat\\10.png"),"Nusa Tenggara Barat"),
                new orang(Image.FromFile(Application.StartupPath+"\\G2WrongPormBajuAdat\\11.png"),"Papua Barat"),
                new orang(Image.FromFile(Application.StartupPath+"\\G2WrongPormBajuAdat\\12.png"),"Maluku"),
                new orang(Image.FromFile(Application.StartupPath+"\\G2WrongPormBajuAdat\\13.png"),"Sulawesi Utara"),
                new orang(Image.FromFile(Application.StartupPath+"\\G2WrongPormBajuAdat\\14.png"),"Kalimantan Barat"),
                new orang(Image.FromFile(Application.StartupPath+"\\G2WrongPormBajuAdat\\15.png"),"Gorontalo"),
                new orang(Image.FromFile(Application.StartupPath+"\\G2WrongPormBajuAdat\\16.png"),"x")
        };
        public game2(Player p1, Player p2, int stage)
        {
            InitializeComponent();
            this._p1 = p1;
            this._p2 = p2;
            this.stage = stage;
        }

        private void picExit_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        Random gen = new Random();
        int jwb = 0;
        private void generate()
        {
            int x1 = gen.Next(0, 17);
            int x2 = gen.Next(0, 17);
            int x3 = gen.Next(0, 17);
            while (x1 == x2 || x2 == x3 || x1 == x3)
            {
                 x1 = gen.Next(0, 17);
                 x2 = gen.Next(0, 17);
                 x3 = gen.Next(0, 17);
            }
            int ra = gen.Next(0, 3);
            orang pake=new orang();
            if (ra == 0)
            {
                if (dat[x1].soal == "x")
                {
                    if (x1 - 1 < 0) x1+=gen.Next(0,5);
                    if (x1 + 1 > 16) x1-=gen.Next(0,5);
                }
                pake = dat[x1];
                p1.Image = pake.img;
                p2.Image = dat[x2].img;
                p3.Image = dat[x3].img;
                jwb = 1;
            } 
            if (ra == 1)
            {
                if (dat[x2].soal == "x")
                {
                    if (x2 - 1 < 0) x2 += gen.Next(0, 5);
                    if (x2 + 1 > 16) x2 -= gen.Next(0, 5);
                }
                pake = dat[x2];
                p2.Image = pake.img;
                p1.Image = dat[x1].img;
                p3.Image = dat[x3].img;
                jwb = 2;
            } 
            if (ra == 2)
            {
                if (dat[x3].soal == "x")
                {
                    if (x3 - 1 < 0) x3 += gen.Next(0, 5);
                    if (x3 + 1 > 16) x3 -= gen.Next(0, 5);
                }
                pake = dat[x3];
                p3.Image = pake.img;
                p2.Image = dat[x2].img;
                p1.Image = dat[x1].img;
                jwb = 3;
            }
            lblSoal.Text=pake.soal;
            p1go = true;
            p2go = true;
           label2.Text=(ra.ToString());
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            int kiInc = tiraiKi.X / (tmrWait.Interval / timer2.Interval);
            int kaInc = tiraiKa.X / (tmrWait.Interval / timer2.Interval);
            picTiraiKiri.Visible = true;
            picTiraiKanan.Visible = true;
            picTiraiKiri.Location = new Point(picTiraiKiri.Location.X - 20, picTiraiKiri.Location.Y);
            picTiraiKanan.Location = new Point(picTiraiKanan.Location.X + 20, picTiraiKanan.Location.Y);
            if (picTiraiKiri.Location.X + picTiraiKiri.Width <= 0)
            {
                timer2.Enabled = false;
                _soal = DateTime.UtcNow.AddSeconds(4);
                generate();
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

        private void game2_Load(object sender, EventArgs e)
        {
            picP1BS.Image = null;
            picP2BS.Image = null;
            picP3BS.Image = null;
            picP1BS.Visible = true;
            picP2BS.Visible = true;
            picP3BS.Visible = true;
            tiraiKi = picTiraiKiri.Location;
            tiraiKa = picTiraiKanan.Location;
        }
        int phase = 0;
        DateTime _start;
        private void timer3_Tick(object sender, EventArgs e)
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
                    timer3.Interval = 350;
                    textBox1.Enabled = true;
                    textBox1.Focus();
                    tmrG2.Enabled = true;
                    tmrSoal.Enabled = true;
                    _start = DateTime.UtcNow.AddSeconds(60);
                    _soal = DateTime.UtcNow.AddSeconds(4);
                    generate();
                    break;
                case 4:

                    label17.Dispose();
                    break;
            }
        }
        int p1score = 0;
        int p2score = 0;
        public Form theParent;
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
                ae.counter++; ae.p1.Score += p1score; ae.p2.Score += p2score;
            }
            this.Dispose();
        }

        private void end()
        {
            textBox1.Enabled = false;
            lblHasil.Visible = true;
            lblHasil.BringToFront();

            if (p1score > p2score)
            {
                lblHasil.Text = "Pemain 1 menang!";
            }
            else if (p1score < p2score)
            {
                lblHasil.Text = "Pemain 2 menang!";
            }
            else
                lblHasil.Text = "Permainan seri!";
            timer1.Enabled = true;
        }

        private void tmrG2_Tick(object sender, EventArgs e)
        {
            lblDetik.Text = (_start - DateTime.UtcNow).Seconds.ToString() + ":" + ((_start - DateTime.UtcNow).Milliseconds / 10).ToString();
            if ((_start - DateTime.UtcNow).Ticks < 0)
            {
                end();
                tmrG2.Enabled = false;
                tmrSoal.Enabled = false;
            }
        }

        bool p1go = false;
        bool p2go = false;
        int[] note = { 0, 0, 0 };
        Point tiraiKi, tiraiKa;
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A || e.KeyCode == Keys.S || e.KeyCode == Keys.D )
            {
                if (p1go)
                {
                    p1go = false;
                        if (e.KeyCode == Keys.A && jwb == 1)
                        {
                            p1score+=100;
                            picP1BS.Image = Image.FromFile(Application.StartupPath + "\\G2WrongPormBajuAdat\\o.png");
                            p2go = false;
                            //tmrWait.Enabled = true;
                             
                            note[0] = 1;
                        }
                        else
                        {
                            if (jwb != 1 && e.KeyCode == Keys.A)
                            {
                                if (note[0] == 0)
                                if (p1score > 0)
                                p1score-=50;
                                picP1BS.Image = Image.FromFile(Application.StartupPath + "\\G2WrongPormBajuAdat\\x.png");

                                if (note[0] == 1) p1go = true;
                                note[0] = 1;
                            }
                        }

                        if (e.KeyCode == Keys.S && jwb == 2)
                        {
                            p1score+=100;
                            picP2BS.Image = Image.FromFile(Application.StartupPath + "\\G2WrongPormBajuAdat\\o.png");
                            p2go = false;
                            //tmrWait.Enabled = true;
                             

                        }
                        else
                        {
                            if (jwb != 2 && e.KeyCode == Keys.S)
                            {
                                if (note[1] == 0)
                                if (p1score > 0)
                                p1score-=50;
                                picP2BS.Image = Image.FromFile(Application.StartupPath + "\\G2WrongPormBajuAdat\\x.png");

                                if (note[1] == 1) p1go = true;
                                note[1] = 1;
                            }
                        }

                        if (e.KeyCode == Keys.D && jwb == 3)
                        {
                            p1score+=100;
                            picP3BS.Image = Image.FromFile(Application.StartupPath + "\\G2WrongPormBajuAdat\\o.png");
                            p2go = false;
                            //tmrWait.Enabled = true;
                             
                        }
                        else
                        {
                            if (jwb != 3 && e.KeyCode == Keys.D)
                            {
                                if (note[2] == 0)
                                if (p1score > 0)
                                p1score-=50;
                                picP3BS.Image = Image.FromFile(Application.StartupPath + "\\G2WrongPormBajuAdat\\x.png");
                                if (note[2] == 1) p1go = true;
                                note[2] = 1;
                            }
                        }
                    
                    if (!p2go && !p1go)
                    {
                        tmrWait.Enabled = true;
                        _soal = DateTime.UtcNow.AddSeconds(4);
                         
                    }
                }
            }
            if (e.KeyCode == Keys.K || e.KeyCode == Keys.J || e.KeyCode == Keys.L)
            {
                
                if (p2go)
                {
                    p2go = false;
                    if (e.KeyCode == Keys.J && jwb == 1)
                    {
                        p2score+=100;
                        picP1BS.Image = Image.FromFile(Application.StartupPath + "\\G2WrongPormBajuAdat\\o.png");
                        p1go = false;
                       // tmrWait.Enabled = true;
                         
                        note[0] = 1;
                    }
                    else
                    {
                        if (e.KeyCode == Keys.J && jwb != 1)
                        {
                            if (note[0] == 0)
                            if (p2score > 0)
                            p2score-=50;
                            picP1BS.Image = Image.FromFile(Application.StartupPath + "\\G2WrongPormBajuAdat\\x.png");
                            if (note[0] == 1) p2go = true;
                            note[0] = 1;
                        }
                    }

                    if (e.KeyCode == Keys.K && jwb == 2)
                    {
                        p2score+=100;
                        picP2BS.Image = Image.FromFile(Application.StartupPath + "\\G2WrongPormBajuAdat\\o.png");
                        p1go = false;
                        //tmrWait.Enabled = true;
                         
                        
                    }
                    else
                    {
                        if (e.KeyCode == Keys.K && jwb != 2)
                        {
                            if (note[1] == 0)
                            if (p2score > 0)
                            p2score-=50;
                            picP2BS.Image = Image.FromFile(Application.StartupPath + "\\G2WrongPormBajuAdat\\x.png");
                            if (note[1] == 1) p2go = true;
                            note[1] = 1;
                        }
                    }

                    if (e.KeyCode == Keys.L && jwb == 3)
                    {
                        p2score+=100;
                        picP3BS.Image = Image.FromFile(Application.StartupPath + "\\G2WrongPormBajuAdat\\o.png");
                        p1go = false;
                        //tmrWait.Enabled = true;
                         
                    }
                    else
                    {
                        if (e.KeyCode == Keys.L && jwb != 3)
                        {
                            if (note[2] == 0)
                            if(p2score>0)
                            p2score-=50;
                            picP3BS.Image = Image.FromFile(Application.StartupPath + "\\G2WrongPormBajuAdat\\x.png");
                            if (note[2] == 1) p2go = true;
                            note[2] = 1;
                        }
                    }
                    if (!p1go && !p2go)
                    {
                        tmrWait.Enabled = true;
                        _soal = DateTime.UtcNow.AddSeconds(4);
                    }
                }
            }
            pp1.Text = p1score.ToString();
            pp2.Text = p2score.ToString();
        }

        private void tmrWait_Tick(object sender, EventArgs e)
        {
            picTiraiKiri.Location = tiraiKi;
            picTiraiKanan.Location=tiraiKa;
            timer2.Enabled = true;
            _soal = DateTime.UtcNow.AddSeconds(4);
            for (int a = 0; a < 3; a++)
                note[a] = 0;
            p1go = false;
            p2go = false;
            picP1BS.Image = null;
            picP2BS.Image = null;
            picP3BS.Image = null;
            tmrWait.Enabled = false;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        DateTime _soal;
        private void tmrSoal_Tick(object sender, EventArgs e)
        {
            //label1.Text = (_soal - DateTime.UtcNow).Seconds.ToString() + ":" + ((_soal - DateTime.UtcNow).Milliseconds/10).ToString();
            if ((_soal - DateTime.UtcNow).Ticks <= 0)
            {
                picTiraiKiri.Location = tiraiKi;
                picTiraiKanan.Location = tiraiKa;
                timer2.Enabled = true;
                for (int a = 0; a < 3; a++)
                    note[a] = 0;
                p1go = false;
                p2go = false;
                picP1BS.Image = null;
                picP2BS.Image = null;
                picP3BS.Image = null;
                tmrWait.Enabled = false;
                _soal = DateTime.UtcNow.AddSeconds(4);
            }
        }
    }

    public class orang
    {
        public Image img;
        public String soal;
        public orang(Image img, String soal)
        {
            this.img = img;
            this.soal = soal;
        }
        public orang()
        {
            soal = "kosong";
        }
    }

}
