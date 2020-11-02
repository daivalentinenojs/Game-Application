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
    public partial class Form_About : Form
    {
        public Form_About()
        {
            InitializeComponent();
        }

        private void picBack_Click(object sender, EventArgs e)
        {
            Form_Main_Menu form = new Form_Main_Menu();
            this.Hide();
            form.ShowDialog();
            this.Close();
        }

        System.Media.SoundPlayer SoundChange = new System.Media.SoundPlayer(Application.StartupPath + "\\Music\\HomeEnter.wav");

        private void picBack_MouseHover(object sender, EventArgs e)
        {
            SoundChange.Play();
            picBack.Image = Image.FromFile(Application.StartupPath + "\\FormHighScores\\TombolBackHover.png");
        }

        private void picBack_MouseLeave(object sender, EventArgs e)
        {
            picBack.Image = Image.FromFile(Application.StartupPath + "\\FormHighScores\\Tombol Back.png");
        }

        private void Form_About_Load(object sender, EventArgs e)
        {
            picBack.Image = Image.FromFile(Application.StartupPath + "\\FormHighScores\\Tombol Back.png");
            this.BackgroundImage = Image.FromFile(Application.StartupPath + "\\FormMainMenu\\ab.png");
        }
    }
}
