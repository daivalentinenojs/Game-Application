using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Core_DB_Competition
{
    public partial class Form_Main_Menu : Form
    {
        public Form_Main_Menu()
        {
            InitializeComponent();
        }

        internal Form_Main_Menu(int suara)
        {
            InitializeComponent();
            sound = suara;
        }

        System.Media.SoundPlayer SoundMain = new System.Media.SoundPlayer(Application.StartupPath + "\\Music\\MainMenu.wav");
    
        int sound = 1;
        private void Form_Main_Menu_Load(object sender, EventArgs e)
        {
          
            this.BackgroundImage = Image.FromFile(Application.StartupPath + "\\FormMainMenu\\Home.jpg");
            picNewGame.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombolMulaiBermain.png");
            picAbout.Image = Image.FromFile(Application.StartupPath + "\\Button\\Gear.png");
            picExit.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombol-04.png");
            if(sound == 1)
            {
                SoundMain.PlayLooping(); 
                picSound.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombolSoundOn.png");
            }
            else if (sound == 0)
            {
                SoundMain.Stop(); 
                picSound.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombolSoundOff.png");
            }
        }

        #region Button Click Hover Leave Umum
        private void picNewGame_Click(object sender, EventArgs e)
        {
            SoundMain.Stop();
            picNewGame.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombolMulaiBermainDown.png");
            Story_Line_1 form = new Story_Line_1(1,sound);
            this.Hide();
            form.ShowDialog();
            this.Close();
        }

        private void picExit_Click(object sender, EventArgs e)
        {
            SoundMain.Stop();
            picExit.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombolDown-04.png");
            Application.Exit();
        }

        private void picNewGame_MouseHover(object sender, EventArgs e)
        {
            picNewGame.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombolMulaiBermainHover.png");
        }

        private void picNewGame_MouseLeave(object sender, EventArgs e)
        {
            picNewGame.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombolMulaiBermain.png");
        }

        private void picExit_MouseHover(object sender, EventArgs e)
        {
            picExit.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombolHover-04.png");
        }

        private void picExit_MouseLeave(object sender, EventArgs e)
        {
            picExit.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombol-04.png");
        }
        #endregion

        private void picSound_Click(object sender, EventArgs e)
        {
            if (sound == 1)
            {
                sound = 0;
                picSound.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombolSoundOff.png");
                SoundMain.Stop();
            }
            else if (sound == 0)
            {
                sound = 1;
                picSound.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombolSoundOn.png");
                SoundMain.PlayLooping();
            }
        }

        private void picAbout_MouseHover(object sender, EventArgs e)
        {
            picAbout.Image = Image.FromFile(Application.StartupPath + "\\Button\\GearHover.png");
        }

        private void picAbout_MouseLeave(object sender, EventArgs e)
        {
            picAbout.Image = Image.FromFile(Application.StartupPath + "\\Button\\Gear.png");
        }

        private void picAbout_Click(object sender, EventArgs e)
        {
            SoundMain.Stop();
            Form_About form = new Form_About(sound);
            this.Hide();
            form.ShowDialog();
            this.Close();
        }
    }
}
