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
    public partial class Form_Where_Are_The_Tools : Form
    {
        public Form_Where_Are_The_Tools()
        {
            InitializeComponent();
        }

        internal Form_Where_Are_The_Tools(int suara)
        {
            InitializeComponent();
            sound = suara;
        }

        #region Deklarasi
        int[] Tools = new int[6];
        int Find = 0, Chosen = -1, sound;
        int salah = 0;
        int main = 0;
        #endregion

        System.Media.SoundPlayer SoundGame1 = new System.Media.SoundPlayer(Application.StartupPath + "\\Music\\Game1.wav");
        System.Media.SoundPlayer SoundChange = new System.Media.SoundPlayer(Application.StartupPath + "\\Music\\HomeEnter.wav");
        System.Media.SoundPlayer SoundWin = new System.Media.SoundPlayer(Application.StartupPath + "\\Music\\Ending.wav");

        #region Method
        public int RollChar()
        {
            Random rnd = new Random();
            int hasil = rnd.Next(0, 6);
            return hasil;
        }

        public string FormatBenda(int benda)
        {
            if (benda == 0)
            {
                Chosen = 0;
                return "Gunting";
            }
            else if (benda == 1)
            {
                Chosen = 1;
                return "Sarung Tangan";
            }
            else if (benda == 2)
            {
                Chosen = 2;
                return "Watering Can";
            }
            else if (benda == 3)
            {
                Chosen = 3;
                return "Sprayer";
            }
            else if (benda == 4)
            {
                Chosen = 4;
                return "Skop Kecil";
            }
            else
            {
                Chosen = 5;
                return "Pot";
            }
        }

        public string FormatHintBenda(int benda)
        {
            if (benda == 0)
            {
                Chosen = 0;
                return "Hint : pegangan gunting berwarna coklat dan digunakan untuk memotong daun yang sudah menguning atau layu";
            }
            else if (benda == 1)
            {
                Chosen = 1;
                return "Hint : berwarna biru kehijauan digunakan untuk menjaga tangan tetap bersih saat menanam pohon.";
            }
            else if (benda == 2)
            {
                Chosen = 2;
                return "Hint : alat yang digunakan untuk menyiram tanaman dan berwarna hijau";
            }
            else if (benda == 3)
            {
                Chosen = 3;
                return "Hint : alat penyemprot yang memiliki tabung untuk menyimpan bahan yang berbentuk zat cair";
            }
            else if (benda == 4)
            {
                Chosen = 4;
                return "Hint : alat yang digunakan untuk menyekop tanah dan bentuk utamanya melengkung";
            }
            else
            {
                Chosen = 5;
                return "Hint : Berbentuk tabung yang tidak memiliki tutup dan berwarna coklat,\ndigunakan untuk wadah atau tempat menanam tumbuhan";
            }
        }

        #endregion

        private void Form_Where_Are_The_Tools_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Game1\\1-3 INGAME.jpg");
            picNext.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombolMulaiBermain.png");
            picNext2.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombol-06.png");
            picBack.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombol-07.png");
            picExit.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombol-04.png");
            picNext2.Visible = false;

            picSkopKecil.Image = Image.FromFile(Application.StartupPath + "\\Game1\\sekopKecil.png");
            picRake.Image = Image.FromFile(Application.StartupPath + "\\Game1\\garpu.png");
            picSabit.Image = Image.FromFile(Application.StartupPath + "\\Game1\\sabit.png");
            
            picKapak.Image = Image.FromFile(Application.StartupPath + "\\Game1\\kapak.png");
            picTanggaUtuh.Visible = false;
            picTanggaPotong.Visible = true;
            picSarungTangan.Visible = true;
            picTanggaPotong.Image = Image.FromFile(Application.StartupPath + "\\Game1\\tambahan\\tanggaPotong.jpg");
            picTanggaUtuh.Image = Image.FromFile(Application.StartupPath + "\\Game1\\tambahan\\tangga-utuh.jpg");
            picSarungTangan.Image = Image.FromFile(Application.StartupPath + "\\Game1\\tambahan\\sarung-tangan.jpg");

            picPenyiram.Visible = true;
            picBanPotong.Visible = true;
            picBanUtuh.Visible = false;
            picPenyiram.Image = Image.FromFile(Application.StartupPath + "\\Game1\\tambahan\\penyiram.jpg");
            picBanPotong.Image = Image.FromFile(Application.StartupPath + "\\Game1\\tambahan\\banPotong.jpg");
            picBanUtuh.Image = Image.FromFile(Application.StartupPath + "\\Game1\\tambahan\\ban-utuh.jpg");

            picPot.Visible = true;
            picKayuPotong.Visible = true;
            picKayuUtuh.Visible = false;
            picPot.Image = Image.FromFile(Application.StartupPath + "\\Game1\\tambahan\\pot.jpg");
            picKayuPotong.Image = Image.FromFile(Application.StartupPath + "\\Game1\\tambahan\\kayuPotong.jpg");
            picKayuUtuh.Image = Image.FromFile(Application.StartupPath + "\\Game1\\tambahan\\kayu-utuh.jpg");

            picSprayer.Visible = true;
            picGergajiPotong.Visible = true;
            picGergajiUtuh.Visible = false;
            picSprayer.Image = Image.FromFile(Application.StartupPath + "\\Game1\\tambahan\\sprayer.jpg");
            picGergajiPotong.Image = Image.FromFile(Application.StartupPath + "\\Game1\\tambahan\\gergajiPotong.jpg");
            picGergajiUtuh.Image = Image.FromFile(Application.StartupPath + "\\Game1\\tambahan\\gergaji-utuh.jpg");

            picGunting.Visible = true;
            picJaketPotong.Visible = true;
            picJaketUtuh.Visible = false;
            picGunting.Image = Image.FromFile(Application.StartupPath + "\\Game1\\tambahan\\gunting.jpg");
            picJaketPotong.Image = Image.FromFile(Application.StartupPath + "\\Game1\\tambahan\\jasLabPotong.jpg");
            picJaketUtuh.Image = Image.FromFile(Application.StartupPath + "\\Game1\\tambahan\\jasLab-utuh.jpg");

            picLampu.Image = Image.FromFile(Application.StartupPath + "\\Game1\\tambahan\\lampu.png");

            lblHint.Visible = false;
            lblFind.Text = "";
            lblHint.Text = "";

            for (int i = 0; i < 6; i++)
            {
                Tools[i] = -1;
            }

            if (sound == 1)
            {
                SoundGame1.PlayLooping();
                picSound.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombolSoundOn.png");
            }
            else if (sound == 0)
            {
                SoundGame1.Stop();
                picSound.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombolSoundOff.png");
            }

           
        }

       

        #region Click Benda
        private void picSarungTangan_Click(object sender, EventArgs e)
        {
            if (Chosen == 1)
            {
                Find++;
                picSarungTangan.Visible = false;
                picTanggaPotong.Visible = false;
                picTanggaUtuh.Visible = true;

                if (Find < 6)
                {
                    picNext.Visible = false;
                }
                else if (Find >= 6 && sound == 1)
                {
                    lblFind.Text = "Good Job Siska !";
                    SoundWin.Play();
                }
                else if (Find >= 6 && sound == 0)
                {
                    lblFind.Text = "Good Job Siska !";
                }
                picNext2.Visible = true;
                picNext2.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombol-06.png");
                salah = 0;
                lblHint.Visible = false;
            }
            else
            {
                if (picNext2.Visible == true)
                {
                }
                else
                {
                    salah++;
                    if (salah >= 3 && main == 1)
                    {
                        lblHint.Text = FormatHintBenda(Chosen);
                        lblHint.Visible = true;
                    }
                }
            }
        }

        private void picGunting_Click(object sender, EventArgs e)
        {
            if (Chosen == 0)
            {
                Find++;

                picGunting.Visible = false;
                picJaketPotong.Visible = false;
                picJaketUtuh.Visible = true;

                picGunting.Visible = false;

                if (Find < 6)
                {
                    picNext.Visible = false;
                }
                else if (Find >= 6 && sound == 1)
                {
                    lblFind.Text = "Good Job Siska !";
                    SoundWin.Play();
                }
                else if (Find >= 6 && sound == 0)
                {
                    lblFind.Text = "Good Job Siska !";
                }
                picNext2.Visible = true;
                picNext2.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombol-06.png");
                salah = 0;
                lblHint.Visible = false;
            }
            else
            {
                if (picNext2.Visible == true)
                {
                }
                else
                {
                    salah++;
                    if (salah >= 3 && main == 1)
                    {
                        lblHint.Text = FormatHintBenda(Chosen);
                        lblHint.Visible = true;
                    }
                }
            }
        }

        private void picPenyiram_Click(object sender, EventArgs e)
        {
            if (Chosen == 2)
            {
                Find++;

                picPenyiram.Visible = false;
                picBanPotong.Visible = false;
                picBanUtuh.Visible = true;

                if (Find < 6)
                {
                    picNext.Visible = false;
                }
                else if (Find >= 6 && sound == 1)
                {
                    lblFind.Text = "Good Job Siska !";
                    SoundWin.Play();
                }
                else if (Find >= 6 && sound == 0)
                {
                    lblFind.Text = "Good Job Siska !";
                }
                picNext2.Visible = true;
                picNext2.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombol-06.png");
                salah = 0;
                lblHint.Visible = false;
            }
            else
            {
                if (picNext2.Visible == true)
                {
                }
                else
                {
                    salah++;
                    if (salah >= 3 && main == 1)
                    {
                        lblHint.Text = FormatHintBenda(Chosen);
                        lblHint.Visible = true;
                    }
                }
            }
        }

        private void picSkopKecil_Click(object sender, EventArgs e)
        {
            if (Chosen == 4)
            {
                Find++;

                picSkopKecil.Visible = false;

                if (Find < 6)
                {
                    picNext.Visible = false;
                }
                else if (Find >= 6 && sound == 1)
                {
                    lblFind.Text = "Good Job Siska !";
                    SoundWin.Play();
                }
                else if (Find >= 6 && sound == 0)
                {
                    lblFind.Text = "Good Job Siska !";
                }
                picNext2.Visible = true;
                picNext2.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombol-06.png");
                salah = 0;
                lblHint.Visible = false;
            }
            else
            {
                if (picNext2.Visible == true)
                {
                }
                else
                {
                    salah++;
                    if (salah >= 3 &&main==1)
                    {
                        lblHint.Text = FormatHintBenda(Chosen);
                        lblHint.Visible = true;
                    }
                }
            }
        }

        private void picPot_Click(object sender, EventArgs e)
        {
            if (Chosen == 5)
            {
                picPot.Visible = false;
                picKayuPotong.Visible = false;
                picKayuUtuh.Visible = true;

                Find++;

                picPot.Visible = false;

                if (Find < 6)
                {
                    picNext.Visible = false;
                }
                else if (Find >= 6 && sound == 1)
                {
                    lblFind.Text = "Good Job Siska !";
                    SoundWin.Play();
                }
                else if (Find >= 6 && sound == 0)
                {
                    lblFind.Text = "Good Job Siska !";
                }
                picNext2.Visible = true;
                picNext2.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombol-06.png");
                salah = 0;
                lblHint.Visible = false;
            }
            else
            {
                if (picNext2.Visible == true)
                {
                }
                else
                {
                    salah++;
                    if (salah >= 3 && main == 1)
                    {
                        lblHint.Text = FormatHintBenda(Chosen);
                        lblHint.Visible = true;
                    }
                }
            }
        }

        private void picSprayer_Click(object sender, EventArgs e)
        {
            if (Chosen == 3)
            {
                Find++;

                picSprayer.Visible = false;
                picGergajiPotong.Visible = false;
                picGergajiUtuh.Visible = true;

                picSprayer.Visible = false;
                if (Find < 6)
                {
                    picNext.Visible = false;
                }
                else if (Find >= 6 && sound == 1)
                {
                    lblFind.Text = "Good Job Siska !";
                    SoundWin.Play();
                }
                else if (Find >= 6 && sound == 0)
                {
                    lblFind.Text = "Good Job Siska !";
                }
                picNext2.Visible = true;
                picNext2.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombol-06.png");
                salah = 0;
                lblHint.Visible = false;
            }
            else
            {
                if (picNext2.Visible == true)
                {
                }
                else
                {
                    salah++;
                    if (salah >= 3 && main == 1)
                    {
                        lblHint.Text = FormatHintBenda(Chosen);
                        lblHint.Visible = true;
                    }
                }
            }
        }
        #endregion

        #region Button Click Hover Leave Umum
        private void picNext_MouseHover(object sender, EventArgs e)
        {
            if (picNext.Visible == true)
            {
                if (sound == 1 && Find >= 6)
                {
                    SoundChange.Play();
                }
                picNext.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombolMulaiBermainHover.png");
            }
        }

        private void picNext_MouseLeave(object sender, EventArgs e)
        {
            if (picNext.Visible == true)
            {
                picNext.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombolMulaiBermain.png");
            }
        }

        private void picExit_MouseHover(object sender, EventArgs e)
        {
            if (sound == 1 && Find >=6)
            {
                SoundChange.Play();
            }
            picExit.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombolHover-04.png");
        }

        private void picExit_MouseLeave(object sender, EventArgs e)
        {
            picExit.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombol-04.png");
        }

        private void picExit_Click(object sender, EventArgs e)
        {
            SoundGame1.Stop();
            picExit.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombolDown-04.png");
            Application.Exit();
        }

        private void picBack_Click(object sender, EventArgs e)
        {
            SoundGame1.Stop();

            picBack.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombolDown-07.png");

            Story_Line_2 form = new Story_Line_2(2, sound);
            this.Hide();
            form.ShowDialog();
            this.Close();
        }

        private void picBack_MouseHover(object sender, EventArgs e)
        {
            if (sound == 1 && Find>=6)
            {
                SoundChange.Play();
            }
            picBack.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombolHover-07.png");
        }

        private void picBack_MouseLeave(object sender, EventArgs e)
        {
            picBack.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombol-07.png");
        }

        private void picNext2_MouseHover(object sender, EventArgs e)
        {
            if (picNext2.Visible == true)
            {
                picNext2.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombolHover-06.png");
                if (sound == 1 && Find>=6)
                {
                    SoundChange.Play();
                }
            }
        }

        private void picNext2_MouseLeave(object sender, EventArgs e)
        {
            if (picNext2.Visible == true)
            {
               picNext2.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombol-06.png");
            }
        }
        #endregion

        #region Soal Selanjutnya
        private void picNext2_Click(object sender, EventArgs e)
        {
            picBack.Visible = false;
            picNext2.Visible = false;
            lblFind.Text = "";
            picNext2.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombolDown-06.png");

            if (Find < 6)
            {
                int hasil = RollChar();

                while (hasil == Tools[0] || hasil == Tools[1] || hasil == Tools[2] || hasil == Tools[3] || hasil == Tools[4] || hasil == Tools[5])
                {
                    hasil = RollChar();
                }

                Tools[Find] = hasil;
                lblFind.Text = "Temukan : " + FormatBenda(Tools[Find]);
            }
            else
            {
                SoundGame1.Stop();

                picNext2.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombolDown-06.png");

                Story_Line_3 form = new Story_Line_3(1, sound);
                this.Hide();
                form.ShowDialog();
                this.Close();
            }
        }

        private void picNext_Click(object sender, EventArgs e)
        {
            main = 1;
            picBack.Visible = false;
            picNext.Visible = false;
            lblFind.Text = "";
            int hasil = RollChar();
            picNext.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombolMulaiBermainDown.png");

            while (hasil == Tools[0] || hasil == Tools[1] || hasil == Tools[2] || hasil == Tools[3] || hasil == Tools[4] || hasil == Tools[5])
            {
                hasil = RollChar();
            }

            Tools[Find] = hasil;
            lblFind.Text = "Temukan : " + FormatBenda(Tools[Find]);
        }
        #endregion

        private void picSound_Click(object sender, EventArgs e)
        {
            if (sound == 1)
            {
                sound = 0;
                picSound.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombolSoundOff.png");
                SoundGame1.Stop();
            }
            else if (sound == 0)
            {
                sound = 1;
                picSound.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombolSoundOn.png");
                SoundGame1.PlayLooping();
            }
        }

        private void picTanggaPotong_Click(object sender, EventArgs e)
        {
            salah++;
            if (salah >= 3 && main == 1)
            {
                lblHint.Text = FormatHintBenda(Chosen);
                lblHint.Visible = true;
            }
        }

        private void picKayuPotong_Click(object sender, EventArgs e)
        {
            salah++;
            if (salah >= 3 && main == 1)
            {
                lblHint.Text = FormatHintBenda(Chosen);
                lblHint.Visible = true;
            }
        }

        private void picGergajiPotong_Click(object sender, EventArgs e)
        {
            salah++;
            if (salah >= 3 && main == 1)
            {
                lblHint.Text = FormatHintBenda(Chosen);
                lblHint.Visible = true;
            }
        }

        private void picJaketPotong_Click(object sender, EventArgs e)
        {
            salah++;
            if (salah >= 3 && main == 1)
            {
                lblHint.Text = FormatHintBenda(Chosen);
                lblHint.Visible = true;
            }
        }

        private void picBanUtuh_Click(object sender, EventArgs e)
        {
            salah++;
            if (salah >= 3 && main == 1)
            {
                lblHint.Text = FormatHintBenda(Chosen);
                lblHint.Visible = true;
            }
        }

        private void picKapak_Click(object sender, EventArgs e)
        {
            salah++;
            if (salah >= 3 && main == 1)
            {
                lblHint.Text = FormatHintBenda(Chosen);
                lblHint.Visible = true;
            }
        }

        private void picTanggaUtuh_Click(object sender, EventArgs e)
        {
            salah++;
            if (salah >= 3 && main == 1)
            {
                lblHint.Text = FormatHintBenda(Chosen);
                lblHint.Visible = true;
            }
        }

        private void picLampu_Click(object sender, EventArgs e)
        {
            salah++;
            if (salah >= 3 && main == 1)
            {
                lblHint.Text = FormatHintBenda(Chosen);
                lblHint.Visible = true;
            }
        }

        private void picBanPotong_Click(object sender, EventArgs e)
        {
            salah++;
            if (salah >= 3 && main == 1)
            {
                lblHint.Text = FormatHintBenda(Chosen);
                lblHint.Visible = true;
            }
        }

        private void picJamTangan_Click(object sender, EventArgs e)
        {
            salah++;
            if (salah >= 3 && main == 1)
            {
                lblHint.Text = FormatHintBenda(Chosen);
                lblHint.Visible = true;
            }
        }

        private void picSabit_Click(object sender, EventArgs e)
        {
            salah++;
            if (salah >= 3 && main == 1)
            {
                lblHint.Text = FormatHintBenda(Chosen);
                lblHint.Visible = true;
            }
        }

        private void picRake_Click(object sender, EventArgs e)
        {
            salah++;
            if (salah >= 3 && main == 1)
            {
                lblHint.Text = FormatHintBenda(Chosen);
                lblHint.Visible = true;
            }
        }

        private void picKayuUtuh_Click(object sender, EventArgs e)
        {
            salah++;
            if (salah >= 3 && main == 1)
            {
                lblHint.Text = FormatHintBenda(Chosen);
                lblHint.Visible = true;
            }
        }

        private void picGergajiUtuh_Click(object sender, EventArgs e)
        {
            salah++;
            if (salah >= 3 && main == 1)
            {
                lblHint.Text = FormatHintBenda(Chosen);
                lblHint.Visible = true;
            }
        }

        private void picJaketUtuh_Click(object sender, EventArgs e)
        {
            salah++;
            if (salah >= 3 && main == 1)
            {
                lblHint.Text = FormatHintBenda(Chosen);
                lblHint.Visible = true;
            }
        }


    }
}
