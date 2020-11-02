using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;

namespace MIB_2015
{
    public partial class Senjata2 : Form
    {
        Player p1, p2;
        public Senjata2(Player p1,Player p2,int stage)
        {
            InitializeComponent();
            //groupBox1.Text = p1.Name;
            //groupBox2.Text = p2.Name;
            this.p1 = p1;
            this.p2 = p2;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        senjata[] keris = {new senjata(Image.FromFile(Application.StartupPath + "\\s4\\imgs\\keris0.jpeg"),'a'),
                         new senjata(Image.FromFile(Application.StartupPath + "\\s4\\imgs\\keris1.jpeg"),'s'),
                         new senjata(Image.FromFile(Application.StartupPath + "\\s4\\imgs\\keris2.jpeg"),'d'),
                         new senjata(Image.FromFile(Application.StartupPath + "\\s4\\imgs\\keris3.jpeg"),'w') };

        senjata[] kujang = {new senjata(Image.FromFile(Application.StartupPath + "\\s4\\imgs\\kujang0.jpeg"),'a'),
                         new senjata(Image.FromFile(Application.StartupPath + "\\s4\\imgs\\kujang1.jpeg"),'s'),
                         new senjata(Image.FromFile(Application.StartupPath + "\\s4\\imgs\\kujang2.jpeg"),'d'),
                         new senjata(Image.FromFile(Application.StartupPath + "\\s4\\imgs\\kujang3.jpeg"),'w') };

        senjata[] mandau = {new senjata(Image.FromFile(Application.StartupPath + "\\s4\\imgs\\mandau0.jpeg"),'a'),
                         new senjata(Image.FromFile(Application.StartupPath + "\\s4\\imgs\\mandau1.jpeg"),'s'),
                         new senjata(Image.FromFile(Application.StartupPath + "\\s4\\imgs\\mandau2.jpeg"),'d'),
                         new senjata(Image.FromFile(Application.StartupPath + "\\s4\\imgs\\mandau3.jpeg"),'w') };
        string p1ans = "";
        bool[] p1pick = { false, false, false,false };
        senjata[] p1hand = new senjata[4];
        Random gen = new Random();
        int p1correct = 0;

        string p2ans = "";
        bool[] p2pick = { false, false, false, false };
        senjata[] p2hand = new senjata[4];
        
        int p2correct = 0;

       

        public void p1generate()
        {
            for (int a = 0; a < 4; a++)
                p1pick[a] = false;
            p1do.Clear();
            panel1.Invalidate();
            p1ans = "";
            int p1picks = gen.Next(0, 3);

            switch (p1picks)
            {
                case 0:
                    p1hand = keris;
                    break;
                case 1:
                    p1hand = kujang;
                    break;
                case 2:
                    p1hand = mandau;
                    break;
            }

            for (int a = 0; a < 100; a++)
            {
                int src = gen.Next(0, 3);
                int dest = gen.Next(0, 3);
                senjata tmp = p1hand[src];
                p1hand[src] = p1hand[dest];
                p1hand[dest] = tmp;

            }
            p1part1.Image = p1hand[0].img;
            p1part1.Height = p1hand[0].img.Height;
            p1part1.Width = p1hand[0].img.Width;

            p1part2.Image = p1hand[1].img;
            p1part2.Height = p1hand[1].img.Height;
            p1part2.Width = p1hand[1].img.Width;

            p1part3.Image = p1hand[2].img;
            p1part3.Height = p1hand[2].img.Height;
            p1part3.Width = p1hand[2].img.Width;

            p1part4.Image = p1hand[3].img;
            p1part4.Height = p1hand[3].img.Height;
            p1part4.Width = p1hand[3].img.Width;
        }


        public void p2generate()
        {
            for (int a = 0; a < 4; a++)
                p2pick[a] = false;
            p2do.Clear();
            panel2.Invalidate();
            p2ans = "";
            int p2picks = gen.Next(0, 3);

            switch (p2picks)
            {
                case 0:
                    p2hand = keris;
                    break;
                case 1:
                    p2hand = kujang;
                    break;
                case 2:
                    p2hand = mandau;
                    break;
            }

            for (int a = 0; a < 100; a++)
            {
                int src = gen.Next(0, 3);
                int dest = gen.Next(0, 3);
                senjata tmp = p2hand[src];
                p2hand[src] = p2hand[dest];
                p2hand[dest] = tmp;

            }
            p2part1.Image = p2hand[0].img;
            p2part1.Height = p2hand[0].img.Height;
            p2part1.Width = p2hand[0].img.Width;

            p2part2.Image = p2hand[1].img;
            p2part2.Height = p2hand[1].img.Height;
            p2part2.Width = p2hand[1].img.Width;

            p2part3.Image = p2hand[2].img;
            p2part3.Height = p2hand[2].img.Height;
            p2part3.Width = p2hand[2].img.Width;

            p2part4.Image = p2hand[3].img;
            p2part4.Height = p2hand[3].img.Height;
            p2part4.Width = p2hand[3].img.Width;
        }

        private void Senjata2_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            textBox1.Enabled = false;
            p1count.Text = p1correct.ToString();
            p2count.Text = p2correct.ToString();
        }

        List<senjata> p1do = new List<senjata>();
        List<senjata> p2do = new List<senjata>();

        private void p1draw()
        {
            panel1.Refresh();
            
        }


        private void p2draw()
        {
            panel2.Refresh();

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'a' || e.KeyChar == 'w' || e.KeyChar == 's' || e.KeyChar == 'd')
            {
                if (e.KeyChar == 'a' && !p1pick[0])
                {
                    p1do.Add(p1hand[0]);
                    p1pick[0] = true;
                    p1ans += p1hand[0].urutan.ToString();
                }
                if (e.KeyChar == 's' && !p1pick[1])
                {
                    p1do.Add(p1hand[1]);
                    p1pick[1] = true;
                    p1ans += p1hand[1].urutan.ToString();
                }
                if (e.KeyChar == 'd' && !p1pick[2])
                {
                    p1do.Add(p1hand[2]);
                    p1pick[2] = true;
                    p1ans += p1hand[2].urutan.ToString();
                }
                if (e.KeyChar == 'w' && !p1pick[3])
                {
                    p1do.Add(p1hand[3]);
                    p1pick[3] = true;
                    p1ans += p1hand[3].urutan.ToString();
                }
                p1draw();
                if (p1ans.Length == 4)
                {
                    if (p1ans == "asdw")
                    {
                        p1bnr.Visible = true;
                        timer4.Enabled = true;
                        p1correct++;
                        p1count.Text = p1correct.ToString();
                        label3.Text = "Score: " + (p1correct * 50).ToString();
                    }
                    else
                    {
                        p1slh.Visible = true;
                        timer4.Enabled = true;
                    }
                }
            }

            if (e.KeyChar == 'i' || e.KeyChar == 'j' || e.KeyChar == 'k' || e.KeyChar == 'l')
            {
                if (e.KeyChar == 'j' && !p2pick[0])
                {
                    p2do.Add(p2hand[0]);
                    p2pick[0] = true;
                    p2ans += p2hand[0].urutan.ToString();
                }
                if (e.KeyChar == 'k' && !p2pick[1])
                {
                    p2do.Add(p2hand[1]);
                    p2pick[1] = true;
                    p2ans += p2hand[1].urutan.ToString();
                }
                if (e.KeyChar == 'l' && !p2pick[2])
                {
                    p2do.Add(p2hand[2]);
                    p2pick[2] = true;
                    p2ans += p2hand[2].urutan.ToString();
                }
                if (e.KeyChar == 'i' && !p2pick[3])
                {
                    p2do.Add(p2hand[3]);
                    p2pick[3] = true;
                    p2ans += p2hand[3].urutan.ToString();
                }
                p2draw();
                if (p2ans.Length == 4)
                {
                    if (p2ans == "asdw")
                    {
                        p2bnr.Visible = true;
                        timer5.Enabled = true;
                        p2correct++;
                        p2count.Text = p2correct.ToString();
                        label9.Text = "Score: " + (p2correct * 50).ToString();
                    }
                    else
                    {
                        p2slh.Visible = true;
                        timer5.Enabled = true;
                    }
                    //p2generate();
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            if (p1do.Count > 0)
            {
                int hh = 0;
                for (int a = 0; a < p1do.Count; a++)
                {
                    e.Graphics.DrawImageUnscaled(p1do[a].img, 0, hh);
                    //hh += p1do[a].img.Height;
                    hh += img_h;
                }
            }
        }
        DateTime _start;
        private void label3_Click(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label4.Text = (_start - DateTime.UtcNow).Seconds.ToString() + ":" + ((_start - DateTime.UtcNow).Milliseconds / 10).ToString();
            if ((_start - DateTime.UtcNow).Ticks <= 0)
            {
                timer1.Enabled = false;
                end();
            }
        }

        private void end()
        {
            textBox1.Enabled = false;
            if (p1correct > p2correct)
            {
                p1menang.Visible = true;
                p2kalah.Visible = true;
            }
            else if (p1correct < p2correct)
            {
                p1kalah.Visible = true; 
                p2menang.Visible = true;
            }
            else
            {
                p1seri.Visible = true;
                p2seri.Visible = true;
            }

            System.Threading.Thread.Sleep(400);
            Player.RecordScore(7, p1.Name, p2.Name, p1correct*50, p2correct*50);
            hs t = new hs(7);
            t.ShowDialog();
            t.BringToFront();
            t.center();
            timer2.Enabled = true;
        }

        const int img_h = 73;

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

            if (p2do.Count > 0)
            {
                int hh = 0;
                for (int a = 0; a < p2do.Count; a++)
                {
                    e.Graphics.DrawImageUnscaled(p2do[a].img, 0, hh);
                    //hh += p2do[a].img.Height;
                    hh += img_h;
                }
            }
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
                ae.counter++; 
                ae.p1.Score+=p1correct*50; 
                ae.p2.Score+=p2correct*50;
            }
            this.Dispose();
        }
        public Form theParent;

        private void picExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        int phase = 0;

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
                    p1generate();
                    p2generate();
                    textBox1.Enabled = true;
                    timer1.Enabled = true;
                    _start = DateTime.UtcNow.AddSeconds(30);
                    textBox1.Focus();
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

        private void timer4_Tick(object sender, EventArgs e)
        {
            p1generate();
            p1bnr.Visible = false;
            p1slh.Visible = false;
            timer4.Enabled = false;
        }

        private void timer5_Tick(object sender, EventArgs e)
        {
            p2generate();
            p2bnr.Visible = false;
            p2slh.Visible = false;
            timer5.Enabled = false;
        }

        private void label17_Click(object sender, EventArgs e)
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
    public class senjata
    {
        public Image img;
        public char urutan;
        public senjata(Image gbre,char urutan)
        {
            this.img = gbre;
            this.urutan = urutan;
        }
    }
}
