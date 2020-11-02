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
    public partial class Story_Line_7 : Form
    {
        public Story_Line_7()
        {
            InitializeComponent();
        }

        internal Story_Line_7(int nilai, int suara)
        {
            InitializeComponent();
            story = nilai;
            sound = suara;
        }

        System.Media.SoundPlayer SoundStory = new System.Media.SoundPlayer(Application.StartupPath + "\\Music\\Story7-2.wav");

        int story, sound;

        private void Story_Line_7_Load(object sender, EventArgs e)
        {
            if (story == 1)
            {
                this.BackgroundImage = Image.FromFile(Application.StartupPath + "\\StoryLine7\\3-7.jpg");
            }

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

            picNext.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombol-06.png");
            picBack.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombol-07.png");
            picExit.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombol-04.png");
            picMulai.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombol-08.png");
        }

        #region Button Click Hover Leave Umum
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

        private void picNext_MouseHover(object sender, EventArgs e)
        {
            if (picNext.Visible == true)
            {
                picNext.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombolHover-06.png");
            }
        }

        private void picNext_MouseLeave(object sender, EventArgs e)
        {
            if (picNext.Visible == true)
            {
               picNext.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombol-06.png");
            }
        }

        private void picBack_Click(object sender, EventArgs e)
        {
            story--;
            picBack.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombolDown-07.png");

            if (story <= 0)
            {
                SoundStory.Stop();
                Form_Kill_The_Hama form = new Form_Kill_The_Hama(sound);
                this.Hide();
                form.ShowDialog();
                this.Close();
            }
            else if (story == 1)
            {
                picMulai.Visible = false;
                picNext.Visible = true;
                this.BackgroundImage = Image.FromFile(Application.StartupPath + "\\StoryLine7\\3-7.jpg");
            }
        }

        private void picNext_Click(object sender, EventArgs e)
        {
            story++;
            picNext.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombolDown-06.png");

            if (story >= 2)
            {
                this.BackgroundImage = Image.FromFile(Application.StartupPath + "\\StoryLine7\\3-8_ULANGI.jpg");
                picNext.Visible = false;
                picMulai.Visible = true;
            }
        }

        private void picMulai_Click(object sender, EventArgs e)
        {
            SoundStory.Stop();
            Story_Line_1 form = new Story_Line_1(1,sound);
            this.Hide();
            form.ShowDialog();
            this.Close();
        }

        private void picMulai_MouseHover(object sender, EventArgs e)
        {
            if (picMulai.Visible == true)
            {
                picMulai.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombolHover-08.png");
            }
        }

        private void picMulai_MouseLeave(object sender, EventArgs e)
        {
            if (picMulai.Visible == true)
            {
                picMulai.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombol-08.png");
            }
        }
        #endregion

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
    }
}
