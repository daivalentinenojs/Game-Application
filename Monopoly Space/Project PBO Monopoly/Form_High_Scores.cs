using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Project_PBO_Monopoly
{
    public partial class Form_High_Scores : Form
    {
        public Form_High_Scores()
        {
            InitializeComponent();
        }
        System.Media.SoundPlayer SoundChange = new System.Media.SoundPlayer(Application.StartupPath + "\\Music\\HomeEnter.wav");

        private void Form_High_Scores_Load(object sender, EventArgs e)
        {
            picBack.Image = Image.FromFile(Application.StartupPath + "\\FormHighScores\\Tombol Back.png");
            this.BackgroundImage = Image.FromFile(Application.StartupPath + "\\FormHighScores\\Form High Score.jpg");
            lblHighScore3.Text = "";
            lblHighScore2.Text = "";
            lblHighScore1.Text = "";
            lblHighScore4.Text = "";
            lblHighScore5.Text = "";

            int[] highscore = new int[5];
            Label[] lblhighscore = new Label[5];
            lblhighscore[0] = lblHighScore1;
            lblhighscore[1] = lblHighScore2;
            lblhighscore[2] = lblHighScore3;
            lblhighscore[3] = lblHighScore4;
            lblhighscore[4] = lblHighScore5;

            TextReader myfile = new StreamReader(Application.StartupPath + "\\Others\\Data.txt");
            for (int i = 0; i < lblhighscore.Length; i++)
            {
                lblhighscore[i].Text = myfile.ReadLine();
            }
            myfile.Close();
        }

        private void picBack_Click(object sender, EventArgs e)
        {
            Form_Main_Menu form = new Form_Main_Menu();
            this.Hide();
            form.ShowDialog();
            this.Close();
        }

        private void picBack_MouseLeave(object sender, EventArgs e)
        {
            picBack.Image = Image.FromFile(Application.StartupPath + "\\FormHighScores\\Tombol Back.png");
        }

        private void picBack_MouseHover(object sender, EventArgs e)
        {
            SoundChange.Play();
            picBack.Image = Image.FromFile(Application.StartupPath + "\\FormHighScores\\TombolBackHover.png");
        }
    }
}
