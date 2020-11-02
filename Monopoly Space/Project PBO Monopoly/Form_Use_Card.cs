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
    public partial class Form_Use_Card : Form
    {
        public Form_Use_Card()
        {
            InitializeComponent();
        }

        internal Form_Use_Card(int nilai, Pemain orang, Tanah bangunan)
        {
            InitializeComponent();
            lemparan = nilai;
            manusia = orang;
            lahan = bangunan;
        }
        
        int lemparan;
        Pemain manusia;
        Tanah lahan;
        System.Media.SoundPlayer SoundChange = new System.Media.SoundPlayer(Application.StartupPath + "\\Music\\HomeEnter.wav");
        private void Form_Use_Card_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = Image.FromFile(Application.StartupPath + "\\FormUseCard\\FormUseCard.jpg");
            picBack.Image = Image.FromFile(Application.StartupPath+"\\FormUseCard\\TombolBack.png");
            picUse.Image = Image.FromFile(Application.StartupPath + "\\FormUseCard\\Use.png");
            if (lemparan == 0)
            {
               picUse.Visible = false;
            }
            else if (lemparan == 1)
            {
               picUse.Visible = true;
               picBack.Visible = false;
               picUse.Image = Image.FromFile(Application.StartupPath + "\\FormUseCard\\Use.png");
            }
            if(manusia.Kartu1.NamaKartu != -1)
                picCard1.Image = Image.FromFile(Application.StartupPath + "\\FormUseCard\\" + manusia.Kartu1.NamaKartu.ToString() + ".jpg");
            if (manusia.Kartu2.NamaKartu != -1)
                picCard2.Image = Image.FromFile(Application.StartupPath + "\\FormUseCard\\" + manusia.Kartu2.NamaKartu.ToString() + ".jpg");
            if (manusia.Kartu3.NamaKartu != -1)
                picCard3.Image = Image.FromFile(Application.StartupPath + "\\FormUseCard\\" + manusia.Kartu3.NamaKartu.ToString() + ".jpg");
        }

        private void picBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void picUse_Click(object sender, EventArgs e)
        {
            if (usecard == 1)
            {
                lahan.HargaBeli = lahan.TotalHargaBangunan;
                lahan.statusBeli = false;
                lahan.pemilik.totalHarta -= lahan.HargaJual;
            }
            else if (usecard == 2)
            {
                if (lahan.LevelBangungan == 3)
                {
                    lahan.LevelBangungan = 2;
                    lahan.pemilik.totalHarta -= lahan.hargaVilla;
                    lahan.TotalHargaBangunan -= lahan.hargaVilla;
                }
                else if (lahan.LevelBangungan == 2)
                {
                    lahan.LevelBangungan = 1;
                    lahan.pemilik.totalHarta -= lahan.hargaRumah;
                    lahan.TotalHargaBangunan -= lahan.hargaRumah;
                }
                else if (lahan.LevelBangungan == 1)
                {
                    lahan.LevelBangungan = 0;
                    lahan.pemilik.totalHarta -= lahan.hargaApartment;
                    lahan.TotalHargaBangunan -= lahan.hargaApartment;
                }
                else
                {
                    MessageBox.Show("No Effect !! Anda Salah Menggunakan Kartu !!", "Informasi");
                }

            }
            else if (usecard == 3)
            {
                if (lahan.LevelBangungan == 5)
                {
                    lahan.LevelBangungan = 4;
                    lahan.pemilik.totalHarta -= lahan.hargaCastle;
                    lahan.TotalHargaBangunan -= lahan.hargaCastle;
                }
                else if (lahan.LevelBangungan == 4)
                {
                    lahan.LevelBangungan = 6;
                    lahan.pemilik.totalHarta -= lahan.hargaHotel;
                    lahan.TotalHargaBangunan -= lahan.hargaHotel;
                }
                else
                {
                    MessageBox.Show("No Effect !! Anda Salah Menggunakan Kartu !!", "Informasi");
                }
            }
            else if (usecard == 4)
            {
                if (lahan.LevelBangungan == 5)
                {
                    lahan.LevelBangungan = 4;
                    lahan.pemilik.totalHarta -= lahan.hargaCastle;
                    lahan.TotalHargaBangunan -= lahan.hargaCastle;
                }
                else if (lahan.LevelBangungan == 4)
                {
                    lahan.LevelBangungan = 6;
                    lahan.pemilik.totalHarta -= lahan.hargaHotel;
                    lahan.TotalHargaBangunan -= lahan.hargaHotel;
                }
                else if (lahan.LevelBangungan == 3)
                {
                    lahan.LevelBangungan = 2;
                    lahan.pemilik.totalHarta -= lahan.hargaVilla;
                    lahan.TotalHargaBangunan -= lahan.hargaVilla;
                }
                else if (lahan.LevelBangungan == 2)
                {
                    lahan.LevelBangungan = 1;
                    lahan.pemilik.totalHarta -= lahan.hargaRumah;
                    lahan.TotalHargaBangunan -= lahan.hargaRumah;
                }
                else if (lahan.LevelBangungan == 1)
                {
                    lahan.LevelBangungan = 0;
                    lahan.pemilik.totalHarta -= lahan.hargaApartment;
                    lahan.TotalHargaBangunan -= lahan.hargaApartment;
                }
                else
                {
                    MessageBox.Show("No Effect !! Anda Salah Menggunakan Kartu !!", "Informasi");
                }
            }
            else if (usecard == 5)
            {
                if (lahan.LevelBangungan == 5)
                {
                    lahan.pemilik.totalHarta -= lahan.TotalHargaBangunan;
                    lahan.TotalHargaBangunan = lahan.HargaBeli;
                    lahan.LevelBangungan = 6;
                }
                else if (lahan.LevelBangungan == 4)
                {
                    lahan.pemilik.totalHarta -= lahan.TotalHargaBangunan;
                    lahan.TotalHargaBangunan = lahan.HargaBeli;
                    lahan.LevelBangungan = 6;
                }
                else if (lahan.LevelBangungan == 3)
                {
                    lahan.pemilik.totalHarta -= lahan.TotalHargaBangunan;
                    lahan.TotalHargaBangunan = lahan.HargaBeli;
                    lahan.LevelBangungan = 0;
                }
                else if (lahan.LevelBangungan == 2)
                {
                    lahan.pemilik.totalHarta -= lahan.TotalHargaBangunan;
                    lahan.TotalHargaBangunan = lahan.HargaBeli;
                    lahan.LevelBangungan = 0;
                }
                else if (lahan.LevelBangungan == 1)
                {
                    lahan.pemilik.totalHarta -= lahan.TotalHargaBangunan;
                    lahan.TotalHargaBangunan = lahan.HargaBeli;
                    lahan.LevelBangungan = 0;
                }
                else
                {
                    MessageBox.Show("No Effect !! Anda Salah Menggunakan Kartu !!", "Informasi");
                }
   
            }
            else if (usecard == 6)
            {
                lahan.pemilik.skip = -2;
            }
            else if (usecard == 7)
            {
                if (lahan.pemilik.uang - 500 >= 0)
                {
                    lahan.pemilik.uang -= 500;
                    lahan.pemilik.totalHarta -= 500;
                    manusia.totalHarta += 500;
                    manusia.uang += 500;
                }
                else if(lahan.pemilik.uang - 500 < 0)
                {
                    MessageBox.Show("Uang " + lahan.pemilik.nama() + " Habis Karena Di Rampok, " + lahan.pemilik.nama() + " Kalah!!!");
                    lahan.pemilik.skip = 15;
                }
            }
            else if (usecard == 8)
            {
                if (lahan.pemilik.uang - 1000 >= 0)
                {
                lahan.pemilik.uang -= 1000;
                lahan.pemilik.totalHarta -= 1000;
                manusia.totalHarta += 1000;
                manusia.uang += 1000;
                }
                else if (lahan.pemilik.uang - 1000 < 0)
                {
                    MessageBox.Show("Uang " + lahan.pemilik.nama() + " Habis Karena Di Rampok, " + lahan.pemilik.nama() + " Kalah!!!");
                    lahan.pemilik.skip = 15;
                }
            }
            else if (usecard == 9)
            {
                if (lahan.pemilik.uang - 3000 >= 0)
                {
                    lahan.pemilik.uang -= 3000;
                    lahan.pemilik.totalHarta -= 3000;
                    manusia.totalHarta += 3000;
                    manusia.uang += 3000;
                }
                else if (lahan.pemilik.uang - 3000 < 0)
                {
                    MessageBox.Show("Uang " + lahan.pemilik.nama() + " Habis Karena Di Rampok, " + lahan.pemilik.nama() + " Kalah!!!");
                    lahan.pemilik.skip = 15;
                }
            }
            else if (usecard == 10)
            {
                if (lahan.pemilik.uang - 5000 >= 0)
                {
                lahan.pemilik.uang -= 5000;
                lahan.pemilik.totalHarta -= 5000;
                manusia.totalHarta += 5000;
                manusia.uang += 5000;
                }
                else if(lahan.pemilik.uang - 5000 < 0)
                {
                    MessageBox.Show("Uang " + lahan.pemilik.nama() + " Habis Karena Di Rampok, " + lahan.pemilik.nama() + " Kalah!!!");
                    lahan.pemilik.skip = 15;
                }
            }
            else
            {
                MessageBox.Show("Pilih Salah Satu Kartu Untuk Digunakan !!");
            }

            if (pilih == 1)
            {
                manusia.Kartu1.NamaKartu = -1;
                this.Close();
            }
            else if (pilih == 2)
            {
                manusia.Kartu2.NamaKartu = -1;
                this.Close();
            }
            else if (pilih == 3)
            {
                manusia.Kartu3.NamaKartu = -1;
                this.Close();
            }
            
        }

        int usecard = 0;
        int use = 0;
        int pilih = 0;
        private void picCard1_Click(object sender, EventArgs e)
        {
            if (use == 0 && manusia.Kartu1.NamaKartu != -1)
            {
                if (lemparan == 1)
                {
                    usecard = manusia.Kartu1.NamaKartu;
                    use = 1;      
                    pilih = 1;
                }
              
            }
        }

        private void picCard2_Click(object sender, EventArgs e)
        {
            if (use == 0 && manusia.Kartu2.NamaKartu != -1)
            {
                if (lemparan == 1)
                {
                    usecard = manusia.Kartu2.NamaKartu;
                    use = 1;
                    pilih = 2;
                }
                
            }
        }

        private void picCard3_Click(object sender, EventArgs e)
        {
            if (use == 0 && manusia.Kartu3.NamaKartu != -1)
            {
                if (lemparan == 1 && manusia.Kartu3.NamaKartu != -1)
                {
                    usecard = manusia.Kartu3.NamaKartu;
                    pilih = 3;
                    use = 1;
                }
            }
        }

        private void picBack_MouseLeave(object sender, EventArgs e)
        {
            picBack.Image = Image.FromFile(Application.StartupPath + "\\FormUseCard\\TombolBack.png");
        }

        private void picUse_MouseLeave(object sender, EventArgs e)
        {
            picUse.Image = Image.FromFile(Application.StartupPath + "\\FormUseCard\\Use.png");
        }

        private void picUse_MouseHover(object sender, EventArgs e)
        {
            SoundChange.Play();
            picUse.Image = Image.FromFile(Application.StartupPath + "\\FormUseCard\\TombolUseCardHover.png");
        }

        private void picBack_MouseHover(object sender, EventArgs e)
        {
            SoundChange.Play();
            picBack.Image = Image.FromFile(Application.StartupPath + "\\FormUseCard\\TombolBackHover.png");
        }

        private void picCard1_MouseHover(object sender, EventArgs e)
        {
            if (use == 0 && lemparan == 1 && manusia.Kartu1.NamaKartu != -1)
            {
                pictureBox1.Visible = true;
                SoundChange.Play();
                pictureBox1.Image = Image.FromFile(Application.StartupPath + "\\FormGo\\yes.png");
            }
        }

        private void picCard2_MouseHover(object sender, EventArgs e)
        {
            if (use == 0 && lemparan == 1 && manusia.Kartu2.NamaKartu != -1)
            {
                pictureBox2.Visible = true;
                SoundChange.Play();
                pictureBox2.Image = Image.FromFile(Application.StartupPath + "\\FormGo\\yes.png");
            }
        }

        private void picCard3_MouseHover(object sender, EventArgs e)
        {
            if (use == 0 && lemparan == 1 && manusia.Kartu3.NamaKartu != -1)
            {
                pictureBox3.Visible = true;
                SoundChange.Play();
                pictureBox3.Image = Image.FromFile(Application.StartupPath + "\\FormGo\\yes.png");
            }
        }

        private void picCard1_MouseLeave(object sender, EventArgs e)
        {
            if (use == 0 && lemparan == 1 && manusia.Kartu1.NamaKartu != -1)
            {
                pictureBox1.Visible = false;
            }
            if (use == 1 && pilih == 1 && lemparan == 1 && manusia.Kartu1.NamaKartu != -1)
            {
                pictureBox1.Visible = true;
                pictureBox1.Image = Image.FromFile(Application.StartupPath + "\\FormGo\\yes.png");
            }
        }

        private void picCard2_MouseLeave(object sender, EventArgs e)
        {
            if (use == 0 && lemparan == 1 && manusia.Kartu2.NamaKartu != -1)
            {
                pictureBox2.Visible = false;
            }
            if (use == 1 && pilih == 2 && lemparan == 1 && manusia.Kartu2.NamaKartu != -1)
            {
                pictureBox2.Visible = true;
                pictureBox2.Image = Image.FromFile(Application.StartupPath + "\\FormGo\\yes.png");
            }
        }

        private void picCard3_MouseLeave(object sender, EventArgs e)
        {
            if (use == 0 && lemparan == 1 && manusia.Kartu3.NamaKartu != -1)
            {
                pictureBox3.Visible = false;
            }
            if (use == 1 && pilih == 3 && lemparan == 1 && manusia.Kartu3.NamaKartu != -1)
            {
                pictureBox3.Visible = true;
                pictureBox3.Image = Image.FromFile(Application.StartupPath + "\\FormGo\\yes.png");
            }
        }
    }
}
