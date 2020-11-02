using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Project_PBO_Monopoly
{
    public partial class Form_Go_Satu : Form
    {
        public Form_Go_Satu()
        {
            InitializeComponent();
        }
        internal Form_Go_Satu(Pemain orang)
        {
            InitializeComponent();
            manusia = orang;
        }

        Pemain manusia;
        private void picBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        System.Media.SoundPlayer SoundChange = new System.Media.SoundPlayer(Application.StartupPath + "\\Music\\HomeEnter.wav");
        private void Form_Go_Satu_Load(object sender, EventArgs e)
        {
            picBack.Image = Image.FromFile(Application.StartupPath + "\\FormGo\\Tombol Back.png");
            this.BackgroundImage = Image.FromFile(Application.StartupPath + "\\FormGo\\Go1.jpg");
            picChange.Image = Image.FromFile(Application.StartupPath + "\\FormGo\\Change.png");
            picNewCard1.Image = Image.FromFile(Application.StartupPath + "\\FormGo\\BackCard.png");
            picNewCard2.Image = Image.FromFile(Application.StartupPath + "\\FormGo\\BackCard.png");
            picNewCard3.Image = Image.FromFile(Application.StartupPath + "\\FormGo\\BackCard.png");
            manusia.uang += 2000;
            manusia.totalHarta += 2000;
            picOldCard1.Image = Image.FromFile(Application.StartupPath + "\\FormGo\\" + manusia.Kartu1.NamaKartu.ToString() + ".jpg");

            picOldCard2.Image = Image.FromFile(Application.StartupPath + "\\FormGo\\" + manusia.Kartu2.NamaKartu.ToString() + ".jpg");

            picOldCard3.Image = Image.FromFile(Application.StartupPath + "\\FormGo\\" + manusia.Kartu3.NamaKartu.ToString() + ".jpg");

            picBack.Visible = true;
            picChange.Visible = true;
        }

        Kartu NKartu1 = new Kartu();

        int selected = 0;
        string hKartu = "";
        int pilihbaru = 0;
        private void picNewCard1_Click(object sender, EventArgs e)
        {
            if (selected == 0)
            {
                int nama = NKartu1.RandomNamaKartu();
                hKartu = NKartu1.Format(nama).ToString();
                picNewCard1.Image = Image.FromFile(Application.StartupPath + "\\FormGo\\" + hKartu + ".jpg");
                selected = 1;
                pilihbaru = 1;
            }
        }

        private void picNewCard2_Click(object sender, EventArgs e)
        {
            if (selected == 0)
            {
                int nama = NKartu1.RandomNamaKartu();
                hKartu = NKartu1.Format(nama).ToString();
                picNewCard2.Image = Image.FromFile(Application.StartupPath + "\\FormGo\\" + hKartu + ".jpg");
                selected = 1;
                pilihbaru = 2;
            }
        }

        private void picNewCard3_Click(object sender, EventArgs e)
        {
            if (selected == 0)
            {
                int nama = NKartu1.RandomNamaKartu();
                hKartu = NKartu1.Format(nama).ToString(); ;
                picNewCard3.Image = Image.FromFile(Application.StartupPath + "\\FormGo\\" + hKartu + ".jpg");
                selected = 1;
                pilihbaru = 3;
            }
        }

        string[] listKartu = new string[3];
        int change = 0;
        int pilih = -1;
        private void picOldCard1_Click(object sender, EventArgs e)
        {
            if (change == 0)
            {
                if (hKartu == "")
                {
                    MessageBox.Show("Silahkan Pilih Kartu Baru Terlebih Dahulu !!");
                }
                else
                {
                    picOldCard1.Image = Image.FromFile(Application.StartupPath + "\\FormGo\\" + hKartu + ".jpg");
                    change = 1;
                    pilih = 1;
                }
            }
        }

        private void picOldCard2_Click(object sender, EventArgs e)
        {
            if (change == 0)
            {
                if (hKartu == "")
                {
                    MessageBox.Show("Silahkan Pilih Kartu Baru Terlebih Dahulu !!");
                }
                else
                {
                    picOldCard2.Image = Image.FromFile(Application.StartupPath + "\\FormGo\\" + hKartu + ".jpg");
                    change = 1;
                    pilih = 2;
                }
            }
        }

        private void picOldCard3_Click(object sender, EventArgs e)
        {
            if (change == 0)
            {
                if (hKartu == "")
                {
                    MessageBox.Show("Silahkan Pilih Kartu Baru Terlebih Dahulu !!");
                }
                else
                {
                    picOldCard3.Image = Image.FromFile(Application.StartupPath + "\\FormGo\\" + hKartu + ".jpg");
                    change = 1;
                    pilih = 3;
                }
            }
        }

        private void picChange_Click(object sender, EventArgs e)
        {
            if (pilih == 1)
            {
                manusia.Kartu1.NamaKartu = int.Parse(hKartu);
                picChange.Visible = false;
            }
            else if (pilih == 2)
            {
                manusia.Kartu2.NamaKartu = int.Parse(hKartu);
                picChange.Visible = false;
            }
            else if (pilih == 3)
            {
                manusia.Kartu3.NamaKartu = int.Parse(hKartu);
                picChange.Visible = false;
            }
            this.Close();
        }

        private void picBack_MouseHover(object sender, EventArgs e)
        {
            SoundChange.Play();
            picBack.Image = Image.FromFile(Application.StartupPath + "\\FormGo\\TombolBackHover.png");
        }

        private void picBack_MouseLeave(object sender, EventArgs e)
        {
            picBack.Image = Image.FromFile(Application.StartupPath + "\\FormGo\\Tombol Back.png");
        }

        private void picChange_MouseLeave(object sender, EventArgs e)
        {
            picChange.Image = Image.FromFile(Application.StartupPath + "\\FormGo\\Change.png");
        }

        private void picChange_MouseHover(object sender, EventArgs e)
        {
            SoundChange.Play();
            picChange.Image = Image.FromFile(Application.StartupPath + "\\FormGo\\TombolChangeHover.png");
        }

        private void picNewCard1_MouseHover(object sender, EventArgs e)
        {
            if (selected == 0)
            {
                pictureBox1.Visible = true;
                SoundChange.Play();
                pictureBox1.Image = Image.FromFile(Application.StartupPath + "\\FormGo\\yes.png");
            }
        }

        private void picNewCard2_MouseHover(object sender, EventArgs e)
        {
            if (selected == 0)
            {
                pictureBox2.Visible = true;
                SoundChange.Play();
                pictureBox2.Image = Image.FromFile(Application.StartupPath + "\\FormGo\\yes.png");
            }
        }

        private void picNewCard3_MouseHover(object sender, EventArgs e)
        {
            if (selected == 0)
            {
                pictureBox3.Visible = true;
                SoundChange.Play();
                pictureBox3.Image = Image.FromFile(Application.StartupPath + "\\FormGo\\yes.png");
            }
        }

        private void picOldCard1_MouseHover(object sender, EventArgs e)
        {
            if (change == 0)
            {
                pictureBox4.Visible = true;
                SoundChange.Play();
                pictureBox4.Image = Image.FromFile(Application.StartupPath + "\\FormGo\\yes.png");
            }
        }

        private void picOldCard2_MouseHover(object sender, EventArgs e)
        {
            if (change == 0)
            {
                pictureBox5.Visible = true;
                SoundChange.Play();
                pictureBox5.Image = Image.FromFile(Application.StartupPath + "\\FormGo\\yes.png");
            }
        }

        private void picOldCard3_MouseHover(object sender, EventArgs e)
        {
            if (change == 0)
            {
                pictureBox6.Visible = true;
                SoundChange.Play();
                pictureBox6.Image = Image.FromFile(Application.StartupPath + "\\FormGo\\yes.png");
            }
        }

        private void picNewCard1_MouseLeave(object sender, EventArgs e)
        {
            if (selected == 0)
            {
                pictureBox1.Visible = false;
            }
            if (selected == 1 && pilihbaru == 1)
            {
                pictureBox1.Visible = true;
                pictureBox1.Image = Image.FromFile(Application.StartupPath + "\\FormGo\\yes.png");
            }
        }

        private void picNewCard2_MouseLeave(object sender, EventArgs e)
        {
            if (selected == 0)
            {
                pictureBox2.Visible = false;
            }
            if (selected == 1 && pilihbaru == 2)
            {
                pictureBox2.Visible = true;
                pictureBox2.Image = Image.FromFile(Application.StartupPath + "\\FormGo\\yes.png");
            }
        }

        private void picNewCard3_MouseLeave(object sender, EventArgs e)
        {
            if (selected == 0)
            {
                pictureBox3.Visible = false;
            }
            if (selected == 1 && pilihbaru == 3)
            {
                pictureBox3.Visible = true;
                pictureBox3.Image = Image.FromFile(Application.StartupPath + "\\FormGo\\yes.png");
            }
        }

        private void picOldCard1_MouseLeave(object sender, EventArgs e)
        {
            if (change == 0)
            {
                pictureBox4.Visible = false;
            }
            if (change == 1 && pilih == 1)
            {
                pictureBox4.Visible = true;
                pictureBox4.Image = Image.FromFile(Application.StartupPath + "\\FormGo\\yes.png");
            }
        }

        private void picOldCard2_MouseLeave(object sender, EventArgs e)
        {
            if (change == 0)
            {
                pictureBox5.Visible = false;
            }
            if (change == 1 && pilih == 2)
            {
                pictureBox5.Visible = true;
                pictureBox5.Image = Image.FromFile(Application.StartupPath + "\\FormGo\\yes.png");
            }
        }

        private void picOldCard3_MouseLeave(object sender, EventArgs e)
        {
            if (change == 0)
            {
                pictureBox6.Visible = false;
            }
            if (change == 1 && pilih == 3)
            {
                pictureBox6.Visible = true;
                pictureBox6.Image = Image.FromFile(Application.StartupPath + "\\FormGo\\yes.png");
            }
        }

    }
}
