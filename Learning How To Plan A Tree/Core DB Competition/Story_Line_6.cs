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
    public partial class Story_Line_6 : Form
    {
        public Story_Line_6()
        {
            InitializeComponent();
        }

        internal Story_Line_6(int nilai, int suara)
        {
            InitializeComponent();
            story = nilai;
            sound = suara;
        }

        System.Media.SoundPlayer SoundStory = new System.Media.SoundPlayer(Application.StartupPath + "\\Music\\Story6.wav");
        System.Media.SoundPlayer SoundStory2 = new System.Media.SoundPlayer(Application.StartupPath + "\\Music\\Story6-2.wav");

        int story, sound;

        private void Story_Line_6_Load(object sender, EventArgs e)
        {
            if (sound == 1)
            {
                picSound.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombolSoundOn.png");

                if (story == 1)
                {
                    SoundStory.PlayLooping();
                    this.BackgroundImage = Image.FromFile(Application.StartupPath + "\\StoryLine6\\3-1.jpg");
                }
                else if (story == 7)
                {
                    SoundStory2.PlayLooping();
                    this.BackgroundImage = Image.FromFile(Application.StartupPath + "\\StoryLine6\\3-5.jpg");
                }
            }
            else if (sound == 0)
            {
               
                picSound.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombolSoundOff.png");
                if (story == 1)
                {
                    SoundStory.Stop();
                    this.BackgroundImage = Image.FromFile(Application.StartupPath + "\\StoryLine6\\3-1.jpg");
                }
                else if (story == 7)
                {
                    SoundStory2.Stop();
                    this.BackgroundImage = Image.FromFile(Application.StartupPath + "\\StoryLine6\\3-5.jpg");
                }
            }

            picNext.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombol-06.png");
            picBack.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombol-07.png");
            picExit.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombol-04.png");
        }


        #region Button Click Hover Leave Umum
        private void picExit_Click(object sender, EventArgs e)
        {
            SoundStory.Stop();
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
            picNext.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombolHover-06.png");
        }

        private void picNext_MouseLeave(object sender, EventArgs e)
        {
            picNext.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombol-06.png");
        }

        private void picBack_Click(object sender, EventArgs e)
        {
            story--;
            picBack.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombolDown-07.png");

            if (story <= 0)
            {
                SoundStory.Stop();
                Form_Peta form = new Form_Peta(3, sound);
                this.Hide();
                form.ShowDialog();
                this.Close();
            }
            else if (story == 1)
            {
                this.BackgroundImage = Image.FromFile(Application.StartupPath + "\\StoryLine6\\3-1.jpg");
            }
            else if (story == 2)
            {
                this.BackgroundImage = Image.FromFile(Application.StartupPath + "\\StoryLine6\\3-2a.jpg");
            }
            else if (story == 3)
            {
                this.BackgroundImage = Image.FromFile(Application.StartupPath + "\\StoryLine6\\3-2b.jpg");
            }
            else if (story == 4)
            {
                this.BackgroundImage = Image.FromFile(Application.StartupPath + "\\StoryLine6\\3-2c.jpg");
            }
            else if (story == 5)
            {
                if (sound == 1)
                {
                    SoundStory2.Stop();
                    SoundStory.Play();
                }
                else if (sound == 0)
                {
                    SoundStory2.Stop();
                    SoundStory.Stop();
                }
                this.BackgroundImage = Image.FromFile(Application.StartupPath + "\\StoryLine6\\3-3.jpg");
            }
            else if (story == 6)
            {
                this.BackgroundImage = Image.FromFile(Application.StartupPath + "\\StoryLine6\\3-4.jpg");
            }
        }

        private void picNext_Click(object sender, EventArgs e)
        {
            story++;
            picNext.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombolDown-06.png");

            if (story >= 8)
            {
                SoundStory2.Stop();
                Form_Kill_The_Hama form = new Form_Kill_The_Hama(sound);
                this.Hide();
                form.ShowDialog();
                this.Close();
            }
            else if (story == 7)
            {
                this.BackgroundImage = Image.FromFile(Application.StartupPath + "\\StoryLine6\\3-5.jpg");
            }
            else if (story == 6)
            {
                if (sound == 1)
                {
                    SoundStory.Stop();
                    SoundStory2.Play();
                }
                else if (sound == 0)
                {
                    SoundStory2.Stop();
                    SoundStory.Stop();
                }
                this.BackgroundImage = Image.FromFile(Application.StartupPath + "\\StoryLine6\\3-4.jpg");
            }
            else if (story == 2)
            {
                this.BackgroundImage = Image.FromFile(Application.StartupPath + "\\StoryLine6\\3-2a.jpg");
            }
            else if (story == 3)
            {
                this.BackgroundImage = Image.FromFile(Application.StartupPath + "\\StoryLine6\\3-2b.jpg");
            }
            else if (story == 4)
            {
                this.BackgroundImage = Image.FromFile(Application.StartupPath + "\\StoryLine6\\3-2c.jpg");
            }
            else if (story == 5)
            {
                this.BackgroundImage = Image.FromFile(Application.StartupPath + "\\StoryLine6\\3-3.jpg");
            }
        }
        #endregion

        private void picSound_Click(object sender, EventArgs e)
        {
            if (sound == 1 && story >= 6)
            {
                sound = 0;
                SoundStory2.Stop();
                picSound.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombolSoundOff.png");
            }
            else if (sound == 1 && story < 6)
            {
                sound = 0;
                SoundStory.Stop();
                picSound.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombolSoundOff.png");
            }
            else if (sound == 0 && story >= 6)
            {
                sound = 1;
                picSound.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombolSoundOn.png");
                SoundStory2.PlayLooping();
            }
            else if (sound == 0 && story < 6)
            {
                sound = 1;
                picSound.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombolSoundOn.png");
                SoundStory.PlayLooping();
            }
        }
    }
}
