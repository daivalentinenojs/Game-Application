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
    public partial class Form_Pay_Use_Card : Form
    {
        public Form_Pay_Use_Card()
        {
            InitializeComponent();
        }

        internal Form_Pay_Use_Card(Pemain orang, Tanah lahan)
        {
            InitializeComponent();
            manusia = orang;
            bangunan = lahan;
        }

        Pemain manusia;
        Tanah bangunan;
        private void picUseCard_Click(object sender, EventArgs e)
        {
            if (manusia.Kartu1.NamaKartu == -1 && manusia.Kartu2.NamaKartu == -1 && manusia.Kartu3.NamaKartu == -1)
            {
                MessageBox.Show("Anda Tidak Mempunyai Kartu, Silahkan Membayar Biaya Sewa !!");
            }
            else
            {
                Form_Use_Card form = new Form_Use_Card(1, manusia, bangunan);
                this.Hide();
                form.ShowDialog();
                this.Close();
            }
        }
        System.Media.SoundPlayer SoundChange = new System.Media.SoundPlayer(Application.StartupPath + "\\Music\\HomeEnter.wav");
        private void Form_Pay_Use_Card_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = Image.FromFile(Application.StartupPath + "\\FormPayUseCard\\FormPayUseCard.jpg");
            picPay.Visible = true;
            picUseCard.Visible = true;
            picPay.Image = Image.FromFile(Application.StartupPath + "\\FormPayUseCard\\TombolPay.png");
            picUseCard.Image = Image.FromFile(Application.StartupPath + "\\FormPayUseCard\\TombolUseCard.png");
            
            string nama = "";
            if (bangunan.pemilik.karakter == 0)
                nama = "Eevee";
            else if (bangunan.pemilik.karakter == 1)
                nama = "Flareon";
            else if (bangunan.pemilik.karakter == 2)
                nama = "Jolteon";
            else if (bangunan.pemilik.karakter == 3)
                nama = "Vaporeon";
            else if (bangunan.pemilik.karakter == 4)
                nama = "Espeon";
            else if (bangunan.pemilik.karakter == 5)
                nama = "Umbreon";
            else if (bangunan.pemilik.karakter == 6)
                nama = "Leafeon";
            else if (bangunan.pemilik.karakter == 7)
                nama = "Glaceon";

            lblNama.Text = nama;
            lblBiaya.Text = (bangunan.LemparSewa()).ToString();
            lblUang.Text = manusia.uang.ToString();
            lblSisa.Text = (manusia.uang - bangunan.Sewa).ToString();

            picGambar.Image = Image.FromFile(Application.StartupPath + "\\FormKartu\\KartuTanah\\"+manusia.posisi.ToString()+".png");

            if(manusia.Kartu1.NamaKartu != -1)
            pictureBox1.Image = Image.FromFile(Application.StartupPath + "\\FormUseCard\\"+manusia.Kartu1.NamaKartu+".jpg");
            if (manusia.Kartu2.NamaKartu != -1)
                pictureBox2.Image = Image.FromFile(Application.StartupPath + "\\FormUseCard\\" + manusia.Kartu2.NamaKartu + ".jpg");
            if (manusia.Kartu3.NamaKartu != -1)
                pictureBox3.Image = Image.FromFile(Application.StartupPath + "\\FormUseCard\\" + manusia.Kartu3.NamaKartu + ".jpg");
        }

        private void picPay_MouseLeave(object sender, EventArgs e)
        {
            picPay.Image = Image.FromFile(Application.StartupPath + "\\FormPayUseCard\\TombolPay.png");
        }

        private void picUseCard_MouseLeave(object sender, EventArgs e)
        {
            picUseCard.Image = Image.FromFile(Application.StartupPath + "\\FormPayUseCard\\TombolUseCard.png");
        }

        private void picPay_MouseHover(object sender, EventArgs e)
        {
            SoundChange.Play();
            picPay.Image = Image.FromFile(Application.StartupPath + "\\FormPayUseCard\\TombolPayHover.png");
        }

        private void picUseCard_MouseHover(object sender, EventArgs e)
        {
            SoundChange.Play();
            picUseCard.Image = Image.FromFile(Application.StartupPath + "\\FormPayUseCard\\TombolUseCardHover.png");
        }

        private void picPay_Click(object sender, EventArgs e)
        {
            if (bangunan.Mortage == 0)
            {
                int rent = bangunan.LemparSewa();
                if (manusia.uang - rent >= 0)
                {
                    bangunan.BayarLahanSewa(manusia);
                    bangunan.DapatBayarSewa(bangunan.pemilik);
                    MessageBox.Show("Anda Telah Membayar Uang Biaya Sewa", "Informasi");
                }
                else
                {
                    MessageBox.Show("Anda Tidak Cukup Uang Untuk Membayar Sewa, Anda Kalah!!!");
                    manusia.skip = 15;
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Lahan Dalam Keadaan Status Mortage, Anda Tidak Perlu Membayar Biaya Sewa", "Informasi");
                this.Close();
            }
        }
    }
}
