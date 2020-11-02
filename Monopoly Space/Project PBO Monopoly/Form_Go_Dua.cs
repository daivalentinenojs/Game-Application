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
    public partial class Form_Go_Dua : Form
    {
        public Form_Go_Dua()
        {
            InitializeComponent();
        }

        internal Form_Go_Dua(Pemain orang)
        {
            InitializeComponent();
            manusia = orang;
        }
        System.Media.SoundPlayer SoundChange = new System.Media.SoundPlayer(Application.StartupPath + "\\Music\\HomeEnter.wav");
        Pemain manusia = new Pemain();
        private void picBack_Click(object sender, EventArgs e) // Event untuk berpindah ke Form Peta
        {
            this.Close();
        }

        private void Form_Go_Dua_Load(object sender, EventArgs e) // Event untuk mengatur jumlah kartu yang ditampilkan
        {
            manusia.uang += 2000;
            manusia.totalHarta += 2000;

            this.BackgroundImage = Image.FromFile(Application.StartupPath + "\\FormGo\\Go2.jpg");
            picNewCard1.Image = Image.FromFile(Application.StartupPath + "\\FormGo\\BackCard.png");
            picNewCard2.Image = Image.FromFile(Application.StartupPath + "\\FormGo\\BackCard.png");
            picNewCard3.Image = Image.FromFile(Application.StartupPath + "\\FormGo\\BackCard.png");
            picBack.Image = Image.FromFile(Application.StartupPath + "\\FormGo\\Tombol Back.png");
        }

        int selected = 0;
        Kartu NKartu1 = new Kartu();
        string hKartu = "";
        int pilih = 0;
        private void picNewCard1_Click(object sender, EventArgs e) // Event ketika picNewCard1 dipilih
        {
            while (selected == 0)
            {
                int nama = NKartu1.RandomNamaKartu();
                hKartu = NKartu1.Format(nama).ToString();
                picNewCard1.Image = Image.FromFile(Application.StartupPath + "\\FormGo\\" + hKartu + ".jpg");

                if (manusia.Kartu1.NamaKartu == -1)
                {
                    manusia.Kartu1.NamaKartu = int.Parse(hKartu);
                }
                else if (manusia.Kartu2.NamaKartu == -1)
                {
                    manusia.Kartu2.NamaKartu = int.Parse(hKartu);
                }
                else if (manusia.Kartu3.NamaKartu == -1)
                {
                    manusia.Kartu3.NamaKartu = int.Parse(hKartu);
                }

                selected = 1;
                pilih = 1;
            }

            if (selected == 1 && pilih ==1)
            {
                pictureBox1.Visible = true;
                pictureBox1.Image = Image.FromFile(Application.StartupPath + "\\FormGo\\yes.png");
            }
        }

        private void picNewCard2_Click(object sender, EventArgs e) // Event ketika picNewCard2 dipilih
        {
            while (selected == 0)
            {
                int nama = NKartu1.RandomNamaKartu();
                hKartu = NKartu1.Format(nama).ToString();
                picNewCard2.Image = Image.FromFile(Application.StartupPath + "\\FormGo\\" + hKartu + ".jpg");

                if (manusia.Kartu1.NamaKartu == -1)
                {
                    manusia.Kartu1.NamaKartu = int.Parse(hKartu);
                }
                else if (manusia.Kartu2.NamaKartu == -1)
                {
                    manusia.Kartu2.NamaKartu = int.Parse(hKartu);
                }
                else if (manusia.Kartu3.NamaKartu == -1)
                {
                    manusia.Kartu3.NamaKartu = int.Parse(hKartu);
                }
                pilih = 2;
                selected = 1;
               
            }

            if (selected == 1 && pilih == 2)
            {
                pictureBox2.Visible = true;
                pictureBox2.Image = Image.FromFile(Application.StartupPath + "\\FormGo\\yes.png");
            }

        }

        private void picNewCard3_Click(object sender, EventArgs e) // Event ketika picNewCard3 dipilih
        {
            while (selected == 0)
            {
                int nama = NKartu1.RandomNamaKartu();
                hKartu = NKartu1.Format(nama).ToString();
                picNewCard3.Image = Image.FromFile(Application.StartupPath + "\\FormGo\\" + hKartu + ".jpg");

                if (manusia.Kartu1.NamaKartu == -1)
                {
                    manusia.Kartu1.NamaKartu = int.Parse(hKartu);
                }
                else if (manusia.Kartu2.NamaKartu == -1)
                {
                    manusia.Kartu2.NamaKartu = int.Parse(hKartu);
                }
                else if (manusia.Kartu3.NamaKartu == -1)
                {
                    manusia.Kartu3.NamaKartu = int.Parse(hKartu);
                }
                pilih = 3;
                selected = 1;
               
            }

            if (selected == 1 && pilih == 3)
            {
                pictureBox3.Visible = true;
                pictureBox3.Image = Image.FromFile(Application.StartupPath + "\\FormGo\\yes.png");
            }
        }

        private void picBack_MouseLeave(object sender, EventArgs e)
        {
            picBack.Image = Image.FromFile(Application.StartupPath + "\\FormGo\\Tombol Back.png");
        }

        private void picBack_MouseHover(object sender, EventArgs e)
        {
            SoundChange.Play();
            picBack.Image = Image.FromFile(Application.StartupPath + "\\FormGo\\TombolBackHover.png");
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

        private void picNewCard1_MouseLeave(object sender, EventArgs e)
        {
            if (selected == 0)
            {
                pictureBox1.Visible = false;
            }
            if (selected == 1 && pilih ==1)
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
            if (selected == 1 && pilih == 2)
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
            if (selected == 1 && pilih == 3)
            {
                pictureBox3.Visible = true;
                pictureBox3.Image = Image.FromFile(Application.StartupPath + "\\FormGo\\yes.png");
            }
        }
    }
}
