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
    public partial class CeritaG1 : Form
    {
        public CeritaG1()
        {
            InitializeComponent();
        }

        Player p1, p2;
        int story, permainan;
        public Form theParent;
        public CeritaG1(Player p1, Player p2, int stage, int nilai)
        {
            InitializeComponent();
            this.p1 = p1;
            this.p2 = p2;
            this.Text = "Stage: " + stage.ToString();
            story = nilai;
            permainan = stage;
            //this.label9.Text = p1.Name;
            //this.label5.Text = p2.Name;
        }

        private void picExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        SoundPlayer p = new SoundPlayer(Application.StartupPath + "\\Music\\Cerita1.wav");

        private void CeritaG1_Load(object sender, EventArgs e)
        {
            tmrCerita1.Enabled = true;
            p.PlayLooping();
            this.CenterToScreen();
            this.BackgroundImage = Image.FromFile(Application.StartupPath + "\\G1YesNoRumahAdat\\Proses1.png");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            story++;
            if (story >= 5)
            {
                p.Stop();
                G1YesNoRumahAdat form = new G1YesNoRumahAdat(p1, p2, permainan);
                form.theParent = this.theParent;
                this.Hide();
                form.ShowDialog();
                this.Close();
            }
            else if (story == 2)
            {
                pictureBox2.Visible = true;
                this.BackgroundImage = Image.FromFile(Application.StartupPath + "\\G1YesNoRumahAdat\\Cerita2.png");
            }
            else if (story == 3)
            {
                this.BackgroundImage = Image.FromFile(Application.StartupPath + "\\G1YesNoRumahAdat\\Cerita3.png");
            }
            else if (story == 4)
            {
                this.BackgroundImage = Image.FromFile(Application.StartupPath + "\\G1YesNoRumahAdat\\Cerita4.png");
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            story--;
            if (story == 1)
            {
                pictureBox2.Visible = false;
                this.BackgroundImage = Image.FromFile(Application.StartupPath + "\\G1YesNoRumahAdat\\Cerita1.png");
            }
            else if (story == 2)
            {
                pictureBox2.Visible = true;
                this.BackgroundImage = Image.FromFile(Application.StartupPath + "\\G1YesNoRumahAdat\\Cerita2.png");
            }
            else if (story == 3)
            {
                pictureBox2.Visible = true;
                this.BackgroundImage = Image.FromFile(Application.StartupPath + "\\G1YesNoRumahAdat\\Cerita3.png");
            }
         }

        int waktuCerita1 = 0;
        private void tmrCerita1_Tick(object sender, EventArgs e)
        {
            waktuCerita1++;
            if (waktuCerita1 == 5)
            {
                pictureBox1.Visible = true;
                if (story == 1)
                {
                    pictureBox2.Visible = false;
                    this.BackgroundImage = Image.FromFile(Application.StartupPath + "\\G1YesNoRumahAdat\\Cerita1.png");
                }
                else if (story == 4)
                {
                    this.BackgroundImage = Image.FromFile(Application.StartupPath + "\\G1YesNoRumahAdat\\Cerita4.png");
                }
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

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(Application.StartupPath + "\\Button\\nexthover.png");
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(Application.StartupPath + "\\Button\\next.png");
        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            pictureBox2.Image = Image.FromFile(Application.StartupPath + "\\Button\\beforehover.png");
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.Image = Image.FromFile(Application.StartupPath + "\\Button\\before.png");
        }
    }
}
