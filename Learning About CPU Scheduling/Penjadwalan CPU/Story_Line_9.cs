using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Penjadwalan_CPU
{
    public partial class Story_Line_9 : Form
    {
        public Story_Line_9()
        {
            InitializeComponent();
        }

        System.Media.SoundPlayer SoundButton = new System.Media.SoundPlayer(Application.StartupPath + "\\Music\\HomeEnter.wav");
        System.Media.SoundPlayer SoundEnding = new System.Media.SoundPlayer(Application.StartupPath + "\\Music\\Ending.wav");
        private void Story_Line_9_Load(object sender, EventArgs e)
        {
            SoundEnding.Play();
            this.BackgroundImage = Image.FromFile(Application.StartupPath + "\\StoryLine\\9.png");
            picBack.Image = Image.FromFile(Application.StartupPath + "\\StoryLine\\Kembali.png");
            btnExit.Image = Image.FromFile(Application.StartupPath + "\\StoryLine\\Keluar.png");
            btnPlay.Image = Image.FromFile(Application.StartupPath + "\\StoryLine\\Mulai.png");
        }

        private void picBack_Click(object sender, EventArgs e)
        {
            CPU_RR form = new CPU_RR();
            this.Hide();
            form.ShowDialog();
            this.Close();
        }

        private void picBack_MouseHover(object sender, EventArgs e)
        {
            SoundButton.Play();
            picBack.Image = Image.FromFile(Application.StartupPath + "\\StoryLine\\KembaliHover.png");
        }

        private void picBack_MouseLeave(object sender, EventArgs e)
        {
            picBack.Image = Image.FromFile(Application.StartupPath + "\\StoryLine\\Kembali.png");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            Form_Main_Menu form = new Form_Main_Menu();
            this.Hide();
            form.ShowDialog();
            this.Close();
        }

        private void btnPlay_MouseLeave(object sender, EventArgs e)
        {
            btnPlay.Image = Image.FromFile(Application.StartupPath + "\\StoryLine\\Mulai.png");
        }

        private void btnExit_MouseLeave(object sender, EventArgs e)
        {
            btnExit.Image = Image.FromFile(Application.StartupPath + "\\StoryLine\\Keluar.png");
        }

        private void btnPlay_MouseHover(object sender, EventArgs e)
        {
            SoundButton.Play();
            btnPlay.Image = Image.FromFile(Application.StartupPath + "\\StoryLine\\MulaiHover.png");
        }

        private void btnExit_MouseHover(object sender, EventArgs e)
        {
            SoundButton.Play();
            btnExit.Image = Image.FromFile(Application.StartupPath + "\\StoryLine\\KeluarHover.png");
        }
    }
}
