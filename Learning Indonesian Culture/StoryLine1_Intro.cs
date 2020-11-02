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
    public partial class StoryLine1_Intro : Form
    {
        Player p1, p2;
        int story, permainan;
        public Form theParent;
        public StoryLine1_Intro(Player p1, Player p2, int nilai)
        {
            InitializeComponent();
            this.p1 = p1;
            this.p2 = p2;
            //this.Text = "Stage: " + stage.ToString();
            story = nilai;
            //permainan = stage;
            //this.label9.Text = p1.Name;
            //this.label5.Text = p2.Name;
        }

        private void picExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        SoundPlayer p = new SoundPlayer(Application.StartupPath + "\\Music\\Intro.wav");

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            G0RandomGame form = new G0RandomGame(p1,p2);
            this.Hide();
            form.ShowDialog();
            this.Close();
        }

        private void StoryLine1_Intro_Load(object sender, EventArgs e)
        {
            CenterToScreen();
            p.PlayLooping();
            if (story == 1)
                this.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Intro\\OpStory1.jpg");
            else if (story == 3)
                this.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Intro\\OpStory3.jpg");
        }

        private void picExit_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            story--;
            if (story == 1)
            {
                //pictureBox2.Visible = false;
                this.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Intro\\OpStory1.jpg");
            }
            else if (story == 2)
            {
                pictureBox2.Visible = true;
                this.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Intro\\OpStory2.jpg");
            }
            else if (story == 3)
            {
                pictureBox2.Visible = true;
                this.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Intro\\OpStory3.jpg");
            }
            else if (story <= 0)
            {
                G0MainMenu form = new G0MainMenu();
                //form.theParent = this.theParent;
                this.Hide();
                form.ShowDialog();
                this.Close();
            }
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            story++;
            if (story >= 4)
            {
                p.Stop();
                G0RandomGame form = new G0RandomGame(p1, p2);
                //form.theParent = this.theParent;
                this.Hide();
                form.ShowDialog();
                this.Close();
            }
            else if (story == 2)
            {
                pictureBox2.Visible = true;
                this.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Intro\\OpStory2.jpg");
            }
            else if (story == 3)
            {
                this.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Intro\\OpStory3.jpg");
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
