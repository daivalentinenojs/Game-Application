using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Project_PBO_Monopoly
{
    public partial class Form_Exit : Form
    {
        public Form_Exit()
        {
            InitializeComponent();
        }

        System.Media.SoundPlayer SoundChange = new System.Media.SoundPlayer(Application.StartupPath + "\\Music\\HomeEnter.wav");
        private void Form_Exit_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = Image.FromFile(Application.StartupPath + "\\FormExit\\FinalAreYouSure.jpg");
            picYes.Image = Image.FromFile(Application.StartupPath + "\\FormExit\\Yes.png");
            picNo.Image = Image.FromFile(Application.StartupPath + "\\FormExit\\No.png");
        }

        private void picNo_Click(object sender, EventArgs e)
        {
            Form_Main_Menu form = new Form_Main_Menu();
            this.Hide();
            form.ShowDialog();
            this.Close();
        }

        private void picYes_Click(object sender, EventArgs e)
        {
            Form_Thank_You form = new Form_Thank_You();
            this.Hide();
            form.ShowDialog();
            this.Close();
        }

        private void picYes_MouseLeave(object sender, EventArgs e)
        {
            picYes.Image = Image.FromFile(Application.StartupPath + "\\FormExit\\Yes.png");
        }

        private void picNo_MouseHover(object sender, EventArgs e)
        {
            SoundChange.Play();
            picNo.Image = Image.FromFile(Application.StartupPath + "\\FormExit\\NoHover.png");
        }

        private void picYes_MouseHover(object sender, EventArgs e)
        {
            SoundChange.Play();
            picYes.Image = Image.FromFile(Application.StartupPath + "\\FormExit\\YesHover.png");
        }

        private void picNo_MouseLeave(object sender, EventArgs e)
        {
            picNo.Image = Image.FromFile(Application.StartupPath + "\\FormExit\\No.png");
        }
    }
}
