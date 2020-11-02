using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;

namespace Project_PBO_Monopoly
{
    public partial class Form_Main_Menu : Form
    {
        public Form_Main_Menu()
        {
            InitializeComponent();
        }

        System.Media.SoundPlayer SoundChange = new System.Media.SoundPlayer(Application.StartupPath + "\\Music\\HomeEnter.wav");
        private void Form_Main_Menu_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = Image.FromFile(Application.StartupPath+"\\FormMainMenu\\Main Menu.jpg");
            picNewGame.Image = Image.FromFile(Application.StartupPath + "\\FormMainMenu\\New Game.png");
            picHighScores.Image = Image.FromFile(Application.StartupPath + "\\FormMainMenu\\High Score.png");
            picExit.Image = Image.FromFile(Application.StartupPath + "\\FormMainMenu\\Exit.png");
            picAbout.Image = Image.FromFile(Application.StartupPath + "\\FormMainMenu\\About.png");
        }


        private void picExit_Click(object sender, EventArgs e)
        {
            Form_Exit form = new Form_Exit();
            this.Hide();
            form.ShowDialog();
            this.Close();
        }

        private void picHighScores_Click(object sender, EventArgs e)
        {
            Form_High_Scores form = new Form_High_Scores();
            this.Hide();
            form.ShowDialog();
            this.Close();
        }

        private void picNewGame_Click(object sender, EventArgs e)
        {
             Form_Select_Character form = new Form_Select_Character();
            this.Hide();
            form.ShowDialog();
            this.Close();
        }

        private void picNewGame_MouseHover(object sender, EventArgs e)
        {
            SoundChange.Play();
            picNewGame.Image = Image.FromFile(Application.StartupPath + "\\FormMainMenu\\NewGameHover.png");
        }

        private void picNewGame_MouseLeave(object sender, EventArgs e)
        {
            picNewGame.Image = Image.FromFile(Application.StartupPath + "\\FormMainMenu\\New Game.png");
        }

        private void picHighScores_MouseLeave(object sender, EventArgs e)
        {
            picHighScores.Image = Image.FromFile(Application.StartupPath + "\\FormMainMenu\\High Score.png");
        }

        private void picExit_MouseLeave(object sender, EventArgs e)
        {
            picExit.Image = Image.FromFile(Application.StartupPath + "\\FormMainMenu\\Exit.png");
        }

        private void picHighScores_MouseHover(object sender, EventArgs e)
        {
            SoundChange.Play();
            picHighScores.Image = Image.FromFile(Application.StartupPath + "\\FormMainMenu\\HighScoreHover.png");
        }

        private void picExit_MouseHover(object sender, EventArgs e)
        {
            SoundChange.Play();
            picExit.Image = Image.FromFile(Application.StartupPath + "\\FormMainMenu\\ExitHover.png");
        }

        private void picAbout_MouseLeave(object sender, EventArgs e)
        {
            picAbout.Image = Image.FromFile(Application.StartupPath + "\\FormMainMenu\\About.png");
        }

        private void picAbout_MouseHover(object sender, EventArgs e)
        {
            SoundChange.Play();
            picAbout.Image = Image.FromFile(Application.StartupPath + "\\FormMainMenu\\AboutHover.png");
        }

        private void picAbout_Click(object sender, EventArgs e)
        {
            Form_About form = new Form_About();
            this.Hide();
            form.ShowDialog();
            this.Close();
        }
    }
}
