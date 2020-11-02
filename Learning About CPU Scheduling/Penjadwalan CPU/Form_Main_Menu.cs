using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;

namespace Penjadwalan_CPU
{
    public partial class Form_Main_Menu : Form
    {
        public Form_Main_Menu()
        {
            InitializeComponent();
        }

        private void Form_Main_Menu_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = Image.FromFile(Application.StartupPath + "\\MainMenu\\Main.png");
            picPlay.BackgroundImage = Image.FromFile(Application.StartupPath + "\\MainMenu\\ButtonAPlay.png");
            picExit.BackgroundImage = Image.FromFile(Application.StartupPath + "\\MainMenu\\ButtonAExit.png");
            //SoundLoad.Play();
        }

        private void picPlay_Click(object sender, EventArgs e)
        {
            //SoundLoad.Stop();
            Story_Line_1 form = new Story_Line_1();
            this.Hide();
            form.ShowDialog();
            this.Close();
        }

        private void picExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        System.Media.SoundPlayer SoundButton = new System.Media.SoundPlayer(Application.StartupPath + "\\Music\\HomeEnter.wav");
        //System.Media.SoundPlayer SoundLoad = new System.Media.SoundPlayer(Application.StartupPath + "\\Music\\SangSinDaiPingYa.wav");
        private void picPlay_MouseHover(object sender, EventArgs e)
        {            
            SoundButton.Play();
            picPlay.BackgroundImage = Image.FromFile(Application.StartupPath + "\\MainMenu\\ButtonBPlay.png");
        }

        private void picExit_MouseHover(object sender, EventArgs e)
        {
            SoundButton.Play();
            picExit.BackgroundImage = Image.FromFile(Application.StartupPath + "\\MainMenu\\ButtonBExit.png");
        }

        private void picPlay_MouseLeave(object sender, EventArgs e)
        {
            //SoundLoad.Play();
            picPlay.BackgroundImage = Image.FromFile(Application.StartupPath + "\\MainMenu\\ButtonAPlay.png");
        }

        private void picExit_MouseLeave(object sender, EventArgs e)
        {
            //SoundLoad.Play();
            picExit.BackgroundImage = Image.FromFile(Application.StartupPath + "\\MainMenu\\ButtonAExit.png");
        }
    }
}
