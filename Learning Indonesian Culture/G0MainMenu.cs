using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Media;
using System.Media;

namespace MIB_2015
{
    public partial class G0MainMenu : Form
    {
        public G0MainMenu()
        {
            InitializeComponent();
        }

        private void picExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        SoundPlayer p = new SoundPlayer(Application.StartupPath + "\\Music\\MainMenu.wav");

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (p1name.Text.Trim().Length >= 1 && p2name.Text.Trim().Length >= 1)
            {
                p.Stop();
                Player p1 = new Player();
                p1.Name = p1name.Text;
                Player p2 = new Player();
                p2.Name = p2name.Text;
                StoryLine1_Intro form = new StoryLine1_Intro(p1, p2, 1);
                this.Hide();
                form.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Silahkan isi nama dengan benar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                p1name.Focus();
            }
        }

        private void G0MainMenu_Load(object sender, EventArgs e)
        {
            CenterToScreen();
            pictureBox1.Image = Image.FromFile(Application.StartupPath+"\\random\\imgs\\mulai.png");
            p.PlayLooping();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(Application.StartupPath + "\\random\\imgs\\mulaihover.png");
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {

            pictureBox1.Image = Image.FromFile(Application.StartupPath + "\\random\\imgs\\mulai.png");
        }

        private void picExit_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
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
