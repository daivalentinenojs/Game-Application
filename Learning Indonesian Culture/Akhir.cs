using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;

namespace MIB_2015
{
    public partial class Akhir : Form
    {
        Player p1, p2;
        public Akhir(Player p1,Player p2)
        {
            InitializeComponent();
            this.p1 = p1;
            this.p2 = p2;
        }

        SoundPlayer p = new SoundPlayer(Application.StartupPath + "\\Music\\Final.wav");

        private void Akhir_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            label4.Text = p1.Name;
            label5.Text = p2.Name;
            p.PlayLooping();
        }
        int c = 0;
        PictureBox winner;
        Player winn;
        private void go()
        {
            if (c == 2) {
                if (p1.Score > p2.Score)
                {
                    pb1.BackgroundImage = Image.FromFile(Application.StartupPath + "\\s3\\imgs\\sm.png");
                    pb2.BackgroundImage = Image.FromFile(Application.StartupPath + "\\s3\\imgs\\p2f.png");
                    winner = pb1;
                    winn = p1;
                    timer3.Enabled = true;
                }
                else if (p1.Score < p2.Score)
                {

                    pb1.BackgroundImage = Image.FromFile(Application.StartupPath + "\\s3\\imgs\\p1f.png");
                    pb2.BackgroundImage = Image.FromFile(Application.StartupPath + "\\s3\\imgs\\im.png");
                    winner = pb2;
                    winn = p2;
                    timer3.Enabled = true;
                }
                else
                {
                    pb1.BackgroundImage = Image.FromFile(Application.StartupPath + "\\s3\\imgs\\p1f.png");
                    pb2.BackgroundImage = Image.FromFile(Application.StartupPath + "\\s3\\imgs\\p2f.png");
                    winner = null;
                    winn = new Player();
                    winn.Name = "Tidak ada yang";
                }
            }
        }
       const int movefactor=2;
        private void timer2_Tick(object sender, EventArgs e)
        {

            if (pb2.Top > label2.Top)
                pb2.Top -= movefactor;
            else if (pb2.Left > label2.Left)
                pb2.Left -= movefactor;
            else
            {
                c++;
                go();
                timer2.Enabled = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(pb1.Top>label2.Top)
                pb1.Top -= movefactor;
            else if (pb1.Left < label2.Left)
                pb1.Left += movefactor;
            else
            {
                c++;
                go();
                timer1.Enabled = false;
            }

        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (winner.Top > label3.Top)
                winner.Top -= movefactor;
            else if (winner.Left < label3.Left)
                winner.Left += movefactor;
            else
            {
                panel1.Visible = true;
                label1.Text = winn.Name + " menang!";
                label1.Visible = true;
                label1.Left = this.Width / 2 - label1.Width / 2;
                Player.RecordScore(8, p1.Name, p2.Name, p1.Score, p2.Score);
                hs d = new hs(8);
                d.ShowDialog();
                d.center();
                d.BringToFront();
                timer3.Enabled = false;
            }
        }

        private void panel1_MouseEnter(object sender, EventArgs e)
        {
            panel1.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Button\\menuutamahover.png");
        }

        private void panel1_MouseLeave(object sender, EventArgs e)
        {

            panel1.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Button\\menuutama.png");
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void picExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Akhir_FormClosed(object sender, FormClosedEventArgs e)
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
    }
}
