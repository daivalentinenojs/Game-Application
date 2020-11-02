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
    public partial class Form_Count_The_Plants : Form
    {
        public Form_Count_The_Plants()
        {
            InitializeComponent();
        }

        internal Form_Count_The_Plants(int suara)
        {
            InitializeComponent();
            sound = suara;
        }

        #region Method
        public int RollPic()
        {
            Random rnd = new Random();
            int hasil = rnd.Next(1, 6);
            return hasil;
        }

        public int Tanda()
        {
            Random rnd = new Random();
            int hasil = rnd.Next(1, 3);
            return hasil;
        }
        #endregion

        System.Media.SoundPlayer SoundChange = new System.Media.SoundPlayer(Application.StartupPath + "\\Music\\HomeEnter.wav");
        System.Media.SoundPlayer SoundGame2 = new System.Media.SoundPlayer(Application.StartupPath + "\\Music\\Game2.wav");
        System.Media.SoundPlayer SoundWin = new System.Media.SoundPlayer(Application.StartupPath + "\\Music\\Ending.wav");

        #region Deklarasi
        int[] tampung = new int[20];
        int coba = 0, angka = 1, jawaban = 0, tanda = 0, soal2, nilai1 = 0, nilai2 = 0, nilai3 = 0, nilai4 = 0, nilai5 = 0;
        int hasil = 0, soal = 0, benar = 0, sound = 0;
        #endregion

        private void Form_Count_The_Plants_Load(object sender, EventArgs e)
        {
            if (sound == 1)
            {
                SoundGame2.PlayLooping();
                picSound.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombolSoundOn.png");
            }
            else if (sound == 0)
            {
                SoundGame2.Stop();
                picSound.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombolSoundOff.png");
            }


            this.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Game2\\2-6-INGAME.jpg");
            picNext.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombolMulaiBermain.png");
            //picNext2.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombol-06.png");
            picBack.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombol-07.png");
            picExit.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombol-04.png");
            pictureBox21.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombol-06.png");
            //picNext2.Visible = false;
            picCheck.Image = Image.FromFile(Application.StartupPath + "\\Button\\cek hasil-03.png");
            picCheck.Visible = false;

            pic1.Image = Image.FromFile(Application.StartupPath + "\\Button\\1-02.png");
            pic2.Image = Image.FromFile(Application.StartupPath + "\\Button\\2-02.png");
            pic3.Image = Image.FromFile(Application.StartupPath + "\\Button\\3-02.png");
            pic4.Image = Image.FromFile(Application.StartupPath + "\\Button\\4-02.png");
            pic5.Image = Image.FromFile(Application.StartupPath + "\\Button\\5-02.png");
            pic6.Image = Image.FromFile(Application.StartupPath + "\\Button\\6-02.png");
            pic7.Image = Image.FromFile(Application.StartupPath + "\\Button\\7-02.png");
            pic8.Image = Image.FromFile(Application.StartupPath + "\\Button\\8-02.png");
            pic9.Image = Image.FromFile(Application.StartupPath + "\\Button\\9-02.png");
            pic0.Image = Image.FromFile(Application.StartupPath + "\\Button\\0-02.png");
            picAC.Image = Image.FromFile(Application.StartupPath + "\\Button\\ac-02.png");
        }

        #region Button Click Hover Leave Umum
        private void picExit_Click(object sender, EventArgs e)
        {
            SoundGame2.Stop();
            picExit.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombolDown-04.png");
            Application.Exit();
        }

        private void picExit_MouseHover(object sender, EventArgs e)
        {
            if (sound == 1 && benar >= 5)
            {
                SoundChange.Play();
            }
            picExit.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombolHover-04.png");
        }

        private void picExit_MouseLeave(object sender, EventArgs e)
        {
            picExit.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombol-04.png");
        }

        private void picBack_Click(object sender, EventArgs e)
        {
            SoundGame2.Stop();
            picBack.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombolDown-07.png");

            Story_Line_4 form = new Story_Line_4(5, sound);
            this.Hide();
            form.ShowDialog();
            this.Close();
        }

        private void picBack_MouseHover(object sender, EventArgs e)
        {
            if (sound == 1 && benar >= 5)
            {
                SoundChange.Play();
            }
            picBack.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombolHover-07.png");
        }

        private void picBack_MouseLeave(object sender, EventArgs e)
        {
            picBack.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombol-07.png");
        }

        private void pic1_MouseHover(object sender, EventArgs e)
        {
            if (sound == 1 && benar>=5)
            {
                SoundChange.Play();
            }
            pic1.Image = Image.FromFile(Application.StartupPath + "\\Button\\1h-02.png");
        }

        private void pic2_MouseHover(object sender, EventArgs e)
        {
            if (sound == 1 && benar >= 5)
            {
                SoundChange.Play();
            }
            pic2.Image = Image.FromFile(Application.StartupPath + "\\Button\\2h-02.png");
        }

        private void pic3_MouseHover(object sender, EventArgs e)
        {
            if (sound == 1 && benar >= 5)
            {
                SoundChange.Play();
            }
            pic3.Image = Image.FromFile(Application.StartupPath + "\\Button\\3h-02.png");
        }

        private void pic4_MouseHover(object sender, EventArgs e)
        {
            if (sound == 1 && benar >= 5)
            {
                SoundChange.Play();
            }
            pic4.Image = Image.FromFile(Application.StartupPath + "\\Button\\4h-02.png");
        }

        private void pic5_MouseHover(object sender, EventArgs e)
        {
            if (sound == 1 && benar >= 5)
            {
                SoundChange.Play();
            }
            pic5.Image = Image.FromFile(Application.StartupPath + "\\Button\\5h-02.png");
        }

        private void pic6_MouseHover(object sender, EventArgs e)
        {
            if (sound == 1 && benar >= 5)
            {
                SoundChange.Play();
            }
            pic6.Image = Image.FromFile(Application.StartupPath + "\\Button\\6h-02.png");
        }

        private void pic7_MouseHover(object sender, EventArgs e)
        {
            if (sound == 1 && benar >= 5)
            {
                SoundChange.Play();
            }
            pic7.Image = Image.FromFile(Application.StartupPath + "\\Button\\7h-02.png");
        }

        private void pic8_MouseHover(object sender, EventArgs e)
        {
            if (sound == 1 && benar >= 5)
            {
                SoundChange.Play();
            }
            pic8.Image = Image.FromFile(Application.StartupPath + "\\Button\\8h-02.png");
        }

        private void pic9_MouseHover(object sender, EventArgs e)
        {
            if (sound == 1 && benar >= 5)
            {
                SoundChange.Play();
            }
            pic9.Image = Image.FromFile(Application.StartupPath + "\\Button\\9h-02.png");
        }

        private void pic0_MouseHover(object sender, EventArgs e)
        {
            if (sound == 1 && benar >= 5)
            {
                SoundChange.Play();
            }
            pic0.Image = Image.FromFile(Application.StartupPath + "\\Button\\0h-02.png");
        }

        private void picAC_MouseHover(object sender, EventArgs e)
        {
            if (sound == 1 && benar >= 5)
            {
                SoundChange.Play();
            }
            picAC.Image = Image.FromFile(Application.StartupPath + "\\Button\\ach-02.png");
        }

        private void pic1_MouseLeave(object sender, EventArgs e)
        {
            pic1.Image = Image.FromFile(Application.StartupPath + "\\Button\\1-02.png");
        }

        private void pic2_MouseLeave(object sender, EventArgs e)
        {
            pic2.Image = Image.FromFile(Application.StartupPath + "\\Button\\2-02.png");
        }

        private void pic3_MouseLeave(object sender, EventArgs e)
        {
            pic3.Image = Image.FromFile(Application.StartupPath + "\\Button\\3-02.png");
        }

        private void pic4_MouseLeave(object sender, EventArgs e)
        {
            pic4.Image = Image.FromFile(Application.StartupPath + "\\Button\\4-02.png");
        }

        private void pic5_MouseLeave(object sender, EventArgs e)
        {
            pic5.Image = Image.FromFile(Application.StartupPath + "\\Button\\5-02.png");
        }

        private void pic6_MouseLeave(object sender, EventArgs e)
        {
            pic6.Image = Image.FromFile(Application.StartupPath + "\\Button\\6-02.png");
        }

        private void pic7_MouseLeave(object sender, EventArgs e)
        {
            pic7.Image = Image.FromFile(Application.StartupPath + "\\Button\\7-02.png");
        }

        private void pic8_MouseLeave(object sender, EventArgs e)
        {
            pic8.Image = Image.FromFile(Application.StartupPath + "\\Button\\8-02.png");
        }

        private void pic9_MouseLeave(object sender, EventArgs e)
        {
            pic9.Image = Image.FromFile(Application.StartupPath + "\\Button\\9-02.png");
        }

        private void pic0_MouseLeave(object sender, EventArgs e)
        {
            pic0.Image = Image.FromFile(Application.StartupPath + "\\Button\\0-02.png");
        }

        private void picAC_MouseLeave(object sender, EventArgs e)
        {
            picAC.Image = Image.FromFile(Application.StartupPath + "\\Button\\ac-02.png");
        }

        private void picCheck_MouseHover(object sender, EventArgs e)
        {
            if (sound == 1 && benar >= 5)
            {
                SoundChange.Play();
            }
            picCheck.Image = Image.FromFile(Application.StartupPath + "\\Button\\cek hasil hover-03.png");
        }

        private void picCheck_MouseLeave(object sender, EventArgs e)
        {
            picCheck.Image = Image.FromFile(Application.StartupPath + "\\Button\\cek hasil-03.png");
        }

        private void picNext_MouseHover(object sender, EventArgs e)
        {
            if (sound == 1 && benar >= 5)
            {
                SoundChange.Play();
            }
            if (coba == 0)
            {
                picNext.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombolMulaiBermainHover.png");
            }
            else
            {
                picNext.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombolHover-06.png");
            }
        }

        private void picNext_MouseLeave(object sender, EventArgs e)
        {
            if (coba == 0)
            {
                picNext.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombolMulaiBermain.png");
            }
            else
            {
                picNext.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombol-06.png");
            }
        }

        private void pictureBox21_MouseHover(object sender, EventArgs e)
        {
            if (pictureBox21.Visible == true)
            {
                if (sound == 1 && benar >= 5)
                {
                    SoundChange.Play();
                }
                pictureBox21.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombolHover-06.png");
            }
        }

        private void pictureBox21_MouseLeave(object sender, EventArgs e)
        {
            if (pictureBox21.Visible == true)
            {
                pictureBox21.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombol-06.png");
            }
        }

        private void pictureBox21_Click(object sender, EventArgs e)
        {
            SoundGame2.Stop();
            pictureBox21.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombolDown-06.png");

            Story_Line_5 form = new Story_Line_5(1, sound);
            this.Hide();
            form.ShowDialog();
            this.Close();
        }
        #endregion

        #region Check Jawaban dan Soal Selanjutnya
        private void picNext_Click(object sender, EventArgs e)
        {
            picBack.Visible = false;
            label1.Visible = true;
            lblJawaban.Visible = true;
            picSoal.Visible = true;
            lblTanda.Visible = true;
            lblHasil2.Visible = true;

            angka = 1;
            lblangka1.Visible = false;
            lblangka2.Visible = false;
            lblangka3.Visible = false;
            lblangka4.Visible = false;
            lblangka5.Visible = false;
            lblangka6.Visible = false;
            lblangka7.Visible = false;
            lblangka8.Visible = false;
            lblangka9.Visible = false;
            lblangka10.Visible = false;
            lblangka11.Visible = false;
            lblangka12.Visible = false;
            lblangka13.Visible = false;
            lblangka14.Visible = false;
            lblangka15.Visible = false;
            lblangka16.Visible = false;
            lblangka17.Visible = false;
            lblangka18.Visible = false;
            lblangka19.Visible = false;
            lblangka20.Visible = false;

            pic1.Visible = true;
            pic2.Visible = true;
            pic3.Visible = true;
            pic4.Visible = true; 
            pic5.Visible = true;
            pic6.Visible = true;
            pic7.Visible = true; 
            pic8.Visible = true;
            pic9.Visible = true;
            pic0.Visible = true;
            picAC.Visible = true;

            lblJawaban.Focus();
            lblJawaban.Text = "";
            lblComment.Text = "";
            jawaban = 0; tanda = 0;
            nilai1 = 0; nilai2 = 0; nilai3 = 0; nilai4 = 0; nilai5 = 0;
            hasil = 0; soal = 0; soal2 = 0;

            picNext.Visible = false;
          
            hasil = RollPic();
            picSoal.Image = Image.FromFile(Application.StartupPath + "\\Game2\\" + hasil + ".png");

            tampung[0] = RollPic();
            if (tampung[0] == 1)
                nilai1++;
            else if (tampung[0] == 2)
                nilai2++;
            else if (tampung[0] == 3)
                nilai3++;
            else if (tampung[0] == 4)
                nilai4++;
            else if (tampung[0] == 5)
                nilai5++;

            for (int i = 1; i < 20; i++)
            {
                soal = RollPic();
                while (soal == tampung[i - 1])
                {
                    soal = RollPic();
                }
                tampung[i] = soal;
                if (tampung[i] == 1)
                    nilai1++;
                else if (tampung[i] == 2)
                    nilai2++;
                else if (tampung[i] == 3)
                    nilai3++;
                else if (tampung[i] == 4)
                    nilai4++;
                else if (tampung[i] == 5)
                    nilai5++;
            }

            tanda = Tanda();
            if (tanda == 1)
                lblTanda.Text = "+";
            else
                lblTanda.Text = "*";

            soal2 = RollPic();
            lblHasil2.Text = soal2.ToString();
            if (hasil == 1 && tanda == 1)
                jawaban = nilai1 + soal2;
            else if (hasil == 1 && tanda == 2)
                jawaban = nilai1 * soal2;
            else if (hasil == 2 && tanda == 1)
                jawaban = nilai2 + soal2;
            else if (hasil == 2 && tanda == 2)
                jawaban = nilai2 * soal2;
            else if (hasil == 3 && tanda == 1)
                jawaban = nilai3 + soal2;
            else if (hasil == 3 && tanda == 2)
                jawaban = nilai3 * soal2;
            else if (hasil == 4 && tanda == 1)
                jawaban = nilai4 + soal2;
            else if (hasil == 4 && tanda == 2)
                jawaban = nilai4 * soal2;
            else if (hasil == 5 && tanda == 1)
                jawaban = nilai5 + soal2;
            else if (hasil == 5 && tanda == 2)
                jawaban = nilai5 * soal2;

            pictureBox1.Image = Image.FromFile(Application.StartupPath + "\\Game2\\" + tampung[0] + ".png");
            pictureBox2.Image = Image.FromFile(Application.StartupPath + "\\Game2\\" + tampung[1] + ".png");
            pictureBox3.Image = Image.FromFile(Application.StartupPath + "\\Game2\\" + tampung[2] + ".png");
            pictureBox4.Image = Image.FromFile(Application.StartupPath + "\\Game2\\" + tampung[3] + ".png");
            pictureBox5.Image = Image.FromFile(Application.StartupPath + "\\Game2\\" + tampung[4] + ".png");
            pictureBox6.Image = Image.FromFile(Application.StartupPath + "\\Game2\\" + tampung[5] + ".png");
            pictureBox7.Image = Image.FromFile(Application.StartupPath + "\\Game2\\" + tampung[6] + ".png");
            pictureBox8.Image = Image.FromFile(Application.StartupPath + "\\Game2\\" + tampung[7] + ".png");
            pictureBox9.Image = Image.FromFile(Application.StartupPath + "\\Game2\\" + tampung[8] + ".png");
            pictureBox10.Image = Image.FromFile(Application.StartupPath + "\\Game2\\" + tampung[9] + ".png");
            pictureBox11.Image = Image.FromFile(Application.StartupPath + "\\Game2\\" + tampung[10] + ".png");
            pictureBox12.Image = Image.FromFile(Application.StartupPath + "\\Game2\\" + tampung[11] + ".png");
            pictureBox13.Image = Image.FromFile(Application.StartupPath + "\\Game2\\" + tampung[12] + ".png");
            pictureBox14.Image = Image.FromFile(Application.StartupPath + "\\Game2\\" + tampung[13] + ".png");
            pictureBox15.Image = Image.FromFile(Application.StartupPath + "\\Game2\\" + tampung[14] + ".png");
            pictureBox16.Image = Image.FromFile(Application.StartupPath + "\\Game2\\" + tampung[15] + ".png");
            pictureBox17.Image = Image.FromFile(Application.StartupPath + "\\Game2\\" + tampung[16] + ".png");
            pictureBox18.Image = Image.FromFile(Application.StartupPath + "\\Game2\\" + tampung[17] + ".png");
            pictureBox19.Image = Image.FromFile(Application.StartupPath + "\\Game2\\" + tampung[18] + ".png");
            pictureBox20.Image = Image.FromFile(Application.StartupPath + "\\Game2\\" + tampung[19] + ".png");
        } 

        private void picCheck_Click(object sender, EventArgs e)
        {
            coba++;
            pic0.Visible = false;
            pic1.Visible = false;
            pic2.Visible = false;
            pic3.Visible = false;
            pic4.Visible = false;
            pic5.Visible = false;
            pic6.Visible = false;
            pic7.Visible = false;
            pic8.Visible = false;
            pic9.Visible = false;
            picAC.Visible = false;
            for (int i = 0; i<20; i++)
            {
                if (tampung[i] == hasil)
                {
                    if (i == 0)
                    { lblangka1.Visible = true;
                    lblangka1.Text = angka.ToString();
                    angka++;
                    }
                    else if (i == 1)
                    {
                        lblangka2.Visible = true;
                        lblangka2.Text = angka.ToString();
                        angka++;
                    }
                    else if (i == 2)
                    {
                        lblangka3.Visible = true;
                        lblangka3.Text = angka.ToString();
                        angka++;
                    }
                    else if (i == 3)
                    {
                        lblangka4.Visible = true;
                        lblangka4.Text = angka.ToString();
                        angka++;
                    }
                    else if (i == 4)
                    {
                        lblangka5.Visible = true;
                        lblangka5.Text = angka.ToString();
                        angka++;
                    }
                    else if (i == 5)
                    {
                        lblangka6.Visible = true;
                        lblangka6.Text = angka.ToString();
                        angka++;
                    }
                    else if (i == 6)
                    {
                        lblangka7.Visible = true;
                        lblangka7.Text = angka.ToString();
                        angka++;
                    }
                    else if (i == 7)
                    {
                        lblangka8.Visible = true;
                        lblangka8.Text = angka.ToString();
                        angka++;
                    }
                    else if (i == 8)
                    {
                        lblangka9.Visible = true;
                        lblangka9.Text = angka.ToString();
                        angka++;
                    }
                    else if (i == 9)
                    {
                        lblangka10.Visible = true;
                        lblangka10.Text = angka.ToString();
                        angka++;
                    }
                    else if (i == 10)
                    {
                        lblangka11.Visible = true;
                        lblangka11.Text = angka.ToString();
                        angka++;
                    }
                    else if (i == 11)
                    {
                        lblangka12.Visible = true;
                        lblangka12.Text = angka.ToString();
                        angka++;
                    }
                    else if (i == 12)
                    {
                        lblangka13.Visible = true;
                        lblangka13.Text = angka.ToString();
                        angka++;
                    }
                    else if (i == 13)
                    {
                        lblangka14.Visible = true;
                        lblangka14.Text = angka.ToString();
                        angka++;
                    }
                    else if (i == 14)
                    {
                        lblangka15.Visible = true;
                        lblangka15.Text = angka.ToString();
                        angka++;
                    }
                    else if (i == 15)
                    {
                        lblangka16.Visible = true;
                        lblangka16.Text = angka.ToString();
                        angka++;
                    }
                    else if (i == 16)
                    {
                        lblangka17.Visible = true;
                        lblangka17.Text = angka.ToString();
                        angka++;
                    }
                    else if (i == 17)
                    {
                        lblangka18.Visible = true;
                        lblangka18.Text = angka.ToString();
                        angka++;
                    }
                    else if (i == 18)
                    {
                        lblangka19.Visible = true;
                        lblangka19.Text = angka.ToString();
                        angka++;
                    }
                    else if (i == 19)
                    {
                        lblangka20.Visible = true;
                        lblangka20.Text = angka.ToString();
                        angka++;
                    }
                }
            }

            if (coba > 0)
            {
                picNext.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombol-06.png");
            }

            if (lblJawaban.Text == "")
            {
                lblComment.Text = "Jawaban Siska Salah !!";
            }
            else
            {
                label1.Visible = false;
                lblJawaban.Visible = false;
                picSoal.Visible = false;
                lblTanda.Visible = false;
                lblHasil2.Visible = false;

  
                if (int.Parse(lblJawaban.Text) == jawaban)
                {
                    lblComment.Text = "Jawaban Siska Benar !!";
                    benar++;
                }
                else
                {
                    lblComment.Text = "Jawaban Siska Salah !!";
                }

                picCheck.Visible = false;

                if (benar < 5)
                {
                    picNext.Visible = true;
                }
                else if (sound == 1 && benar >= 5)
                {
                    SoundGame2.Stop();
                    SoundWin.Play();
                    sound = 1;
                    pictureBox21.Visible = true;
                }
                else if (sound == 0 && benar >= 5)
                {
                    SoundGame2.Stop();
                    pictureBox21.Visible = true;
                }
            }
        }
        #endregion

        #region Tombol Isi Jawaban
        private void pic1_Click(object sender, EventArgs e)
        {
            lblJawaban.Text += "1";
            picCheck.Visible = true;
        }

        private void pic2_Click(object sender, EventArgs e)
        {
            lblJawaban.Text += "2";
            picCheck.Visible = true;
        }

        private void pic3_Click(object sender, EventArgs e)
        {
            lblJawaban.Text += "3";
            picCheck.Visible = true;
        }

        private void pic4_Click(object sender, EventArgs e)
        {
            lblJawaban.Text += "4";
            picCheck.Visible = true;
        }

        private void pic5_Click(object sender, EventArgs e)
        {
            lblJawaban.Text += "5";
            picCheck.Visible = true;
        }

        private void pic6_Click(object sender, EventArgs e)
        {

            lblJawaban.Text += "6";
            picCheck.Visible = true;
        }

        private void pic7_Click(object sender, EventArgs e)
        {
            lblJawaban.Text += "7";
            picCheck.Visible = true;
        }

        private void pic8_Click(object sender, EventArgs e)
        {
            lblJawaban.Text += "8";
            picCheck.Visible = true;
        }

        private void pic9_Click(object sender, EventArgs e)
        {
            lblJawaban.Text += "9";
            picCheck.Visible = true;
        }

        private void pic0_Click(object sender, EventArgs e)
        {
            lblJawaban.Text += "0";
            picCheck.Visible = true;
        }

        private void picAC_Click(object sender, EventArgs e)
        {
            lblJawaban.Text = "";
            picCheck.Visible = false;
        }
        #endregion

        private void picSound_Click(object sender, EventArgs e)
        {
            if (sound == 1)
            {
                sound = 0;
                picSound.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombolSoundOff.png");
                SoundGame2.Stop();
            }
            else if (sound == 0)
            {
                sound = 1;
                picSound.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombolSoundOn.png");
                SoundGame2.PlayLooping();
            }
        }

    }
}