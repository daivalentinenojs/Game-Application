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
    public partial class Form_Peta : Form
    {
        public Form_Peta()
        {
            InitializeComponent();
        }

        internal Form_Peta(int nilai, int suara)
        {
            InitializeComponent();
            rumah = nilai;
            sound = suara;
        }

        System.Media.SoundPlayer SoundMap = new System.Media.SoundPlayer(Application.StartupPath + "\\Music\\Peta.wav");

        int rumah, sound;

        private void Form_Peta_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Peta\\map.jpg");
            picBack.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombol-07.png");
            picExit.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombol-04.png");

            if (rumah == 1)
            {
                picRumah1.Image = Image.FromFile(Application.StartupPath + "\\Peta\\tombolGudang.png");
                picRumah2.Image = Image.FromFile(Application.StartupPath + "\\Peta\\tombolTamanTerkunci.png");
                picRumah3.Image = Image.FromFile(Application.StartupPath + "\\Peta\\tombolRKTerkunci.png");
            }
            else if (rumah == 2)
            {
                picRumah1.Image = Image.FromFile(Application.StartupPath + "\\Peta\\tombolGudangSelesai.png");
                picRumah2.Image = Image.FromFile(Application.StartupPath + "\\Peta\\tombolTaman.png");
                picRumah3.Image = Image.FromFile(Application.StartupPath + "\\Peta\\tombolRKTerkunci.png");
            }
            else if (rumah == 3)
            {
                picRumah1.Image = Image.FromFile(Application.StartupPath + "\\Peta\\tombolGudangSelesai.png");
                picRumah2.Image = Image.FromFile(Application.StartupPath + "\\Peta\\tombolTamanSelesai.png");
                picRumah3.Image = Image.FromFile(Application.StartupPath + "\\Peta\\tombolRK.png");
            }

            if (sound == 1)
            {
                SoundMap.PlayLooping();
                picSound.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombolSoundOn.png");
            }
            else if (sound == 0)
            {
                SoundMap.Stop();
                picSound.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombolSoundOff.png");
            }
        }

        #region Button Click Hover Leave Umum
        private void picExit_Click(object sender, EventArgs e)
        {
            SoundMap.Stop();
            picExit.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombolDown-04.png");
            Application.Exit();
        }

        private void picBack_Click(object sender, EventArgs e)
        {
            if (rumah == 1)
            {
                SoundMap.Stop();
                Story_Line_1 form = new Story_Line_1(7,sound);
                this.Hide();
                form.ShowDialog();
                this.Close();
            }
            else if (rumah == 2)
            {
                SoundMap.Stop();
                Story_Line_3 form = new Story_Line_3(7, sound);
                this.Hide();
                form.ShowDialog();
                this.Close();
            }
            else
            {
                SoundMap.Stop();
                Story_Line_5 form = new Story_Line_5(6, sound);
                this.Hide();
                form.ShowDialog();
                this.Close();
            }
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

        private void picRumah1_Click(object sender, EventArgs e)
        {
            if (rumah == 1)
            {
                SoundMap.Stop();
                Story_Line_2 form = new Story_Line_2(1, sound);
                this.Hide();
                form.ShowDialog();
                this.Close();
            }
        }

        private void picRumah2_Click(object sender, EventArgs e)
        {
            if (rumah == 2)
            {
                SoundMap.Stop();
                Story_Line_4 form = new Story_Line_4(2, sound);
                this.Hide();
                form.ShowDialog();
                this.Close();
            }
        }

        private void picRumah3_Click(object sender, EventArgs e)
        {
            if (rumah == 3)
            {
                SoundMap.Stop();
                Story_Line_6 form = new Story_Line_6(1, sound);
                this.Hide();
                form.ShowDialog();
                this.Close();
            }
        }

        private void picRumah1_MouseHover(object sender, EventArgs e)
        {
            if (rumah == 1)
            {
                picRumah1.Image = Image.FromFile(Application.StartupPath + "\\Peta\\tombolGudanghover.png");
            }
        }

        private void picRumah1_MouseLeave(object sender, EventArgs e)
        {
            if (rumah == 1)
            {
                picRumah1.Image = Image.FromFile(Application.StartupPath + "\\Peta\\tombolGudang.png");
            }
        }

        private void picRumah2_MouseHover(object sender, EventArgs e)
        {
            if (rumah == 2)
            {
                picRumah2.Image = Image.FromFile(Application.StartupPath + "\\Peta\\tombolTamanhover.png");
            }
        }

        private void picRumah2_MouseLeave(object sender, EventArgs e)
        {
            if (rumah == 2)
            {
                picRumah2.Image = Image.FromFile(Application.StartupPath + "\\Peta\\tombolTaman.png");
            }
        }

        private void picRumah3_MouseHover(object sender, EventArgs e)
        {
            if (rumah == 3)
            {
                picRumah3.Image = Image.FromFile(Application.StartupPath + "\\Peta\\tombolRKhover.png");
            }
        }

        private void picRumah3_MouseLeave(object sender, EventArgs e)
        {
            if (rumah == 3)
            {
                picRumah3.Image = Image.FromFile(Application.StartupPath + "\\Peta\\tombolRK.png");
            }
        }
    #endregion

        private void picSound_Click(object sender, EventArgs e)
        {
            if (sound == 1)
            {
                sound = 0;
                picSound.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombolSoundOff.png");
                SoundMap.Stop();
            }
            else if (sound == 0)
            {
                sound = 1;
                picSound.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombolSoundOn.png");
                SoundMap.PlayLooping();
            }
        }
    }
}
