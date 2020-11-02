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
    public partial class Form_About : Form
    {
        public Form_About()
        {
            InitializeComponent();
        }

        internal Form_About(int suara)
        {
            InitializeComponent();
            sound = suara;
        }

        int sound;

        System.Media.SoundPlayer SoundStory = new System.Media.SoundPlayer(Application.StartupPath + "\\Music\\About.wav");

        private void Form_About_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = Image.FromFile(Application.StartupPath + "\\FormMainMenu\\About.png");
            picExit.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombol-04.png");
            picBack.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombol-07.png");

            if (sound == 1)
            {
                SoundStory.PlayLooping();
                picSound.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombolSoundOn.png");
            }
            else if (sound == 0)
            {
                SoundStory.Stop();
                picSound.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombolSoundOff.png");
            }

          
        }

        private void picBack_Click(object sender, EventArgs e)
        {
            SoundStory.Stop();
            Form_Main_Menu form = new Form_Main_Menu(sound);
            this.Hide();
            form.ShowDialog();
            this.Close();
        }

        private void picSound_Click(object sender, EventArgs e)
        {
            if (sound == 1)
            {
                sound = 0;
                picSound.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombolSoundOff.png");
                SoundStory.Stop();
            }
            else if (sound == 0)
            {
                sound = 1;
                picSound.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombolSoundOn.png");
                SoundStory.PlayLooping();
            }
        }

        private void picExit_Click(object sender, EventArgs e)
        {
            picExit.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombolDown-04.png");
            Application.Exit();
        }

        private void picExit_MouseHover(object sender, EventArgs e)
        {
            picExit.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombolHover-04.png");
        }

        private void picExit_MouseLeave(object sender, EventArgs e)
        {
            picExit.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombol-04.png");
        }

        private void picBack_MouseHover(object sender, EventArgs e)
        {
            picBack.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombolHover-07.png");
        }

        private void picBack_MouseLeave(object sender, EventArgs e)
        {
            picBack.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombol-07.png");
        }
    }
}
