using System;
using System.Drawing;
using System.Windows.Forms;

namespace Project_PBO_Monopoly
{
    public partial class Form_Buy_Sell_Build : Form
    {
        public Form_Buy_Sell_Build()
        {
            InitializeComponent();
        }

        internal Form_Buy_Sell_Build(int nilai, Pemain orang, Tanah bangunan)
        {
            InitializeComponent();
            lemparan = nilai;
            manusia = orang;
            lahan = bangunan;
        }

        int lemparan = 0;
        Tanah lahan;
        Pemain manusia;
        System.Media.SoundPlayer SoundChange = new System.Media.SoundPlayer(Application.StartupPath + "\\Music\\HomeEnter.wav");

        private string FormatMortage()
        {
            string hasil = "";
            hasil += "Jumlah Uang Anda Saat Ini\t: " + manusia.uang.ToString() + "\n";
            hasil += "Uang Yang Di Dapat Dari Mortage \t:" + lahan.TotalHargaBangunan.ToString() + "\n";
            hasil += "Uang Anda Tersisa \t:" + (manusia.uang + lahan.TotalHargaBangunan).ToString();
            return hasil;
        }

        private string FormatUnmortage()
        {
            string hasil = "";
            hasil += "Jumlah Uang Anda Saat Ini\t: " + manusia.uang.ToString() + "\n";
            hasil += "Harga Yang Dibutuhkan\nUntuk Unmortage \t:" + (lahan.TotalHargaBangunan*2).ToString() + "\n";
            hasil += "Uang Anda Tersisa \t:" + (manusia.uang - (lahan.TotalHargaBangunan * 2)).ToString();
            return hasil;
        }

        private string FormatBeli()
        {
            string hasil = "";
            hasil += "Jumlah Uang Anda Saat Ini\t: " + manusia.uang.ToString() + "\n";
            hasil += "Harga Beli Tanah \t:" + lahan.HargaBeli.ToString() + "\n";
            hasil += "Uang Anda Tersisa \t:" + (manusia.uang - lahan.HargaBeli).ToString();
            return hasil;
        }

        private string FormatJual()
        {
            string hasil = "";
            hasil += "Jumlah Uang Anda Saat Ini\t: " + manusia.uang.ToString() + "\n";
            hasil += "Harga Jual Tanah \t:" + (lahan.TotalHargaBangunan*1.5).ToString() + "\n";
            hasil += "Uang Anda Menjadi \t:" + (manusia.uang + (lahan.TotalHargaBangunan * 1.5)).ToString();
            return hasil;
        }

        private string FormatBangun()
        {
            string hasil = "";
            int bangun=0;
            hasil += "Jumlah Uang Anda Saat Ini\t: " + manusia.uang.ToString() + "\n";
            
            if (lahan.LevelBangungan == 0)
            {
                bangun = lahan.hargaApartment;
            }
            else if (lahan.LevelBangungan == 1)
            {
                bangun = lahan.hargaRumah;
            }
            else if (lahan.LevelBangungan == 2)
            {
                bangun = lahan.hargaApartment;
            }
            else if (lahan.LevelBangungan == 3)
            {
                bangun = 0;
            }
            else if (lahan.LevelBangungan == 4)
            { 
                bangun = lahan.hargaCastle;
            }
            else if (lahan.LevelBangungan == 5)
            {
                bangun = 0;
            }
            else if (lahan.LevelBangungan == 6)
            {
                bangun = lahan.hargaHotel;
            }
            hasil += "Harga Pembangunan \t:" + bangun.ToString() + "\n";
            hasil += "Uang Anda Berkurang Menjadi \t:" + (manusia.uang - bangun).ToString();
            return hasil;
        }

        private void Form_Buy_Sell_Build_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = Image.FromFile(Application.StartupPath + "\\FormBuySellBuild\\FormBuild.jpg");
            if (lemparan == 0)
            {
                lblTampil.Text = FormatBeli();
            }
            else if (lemparan == 1)
            {
                lblTampil.Text = FormatJual();
            }

            pictureBox1.Image = Image.FromFile(Application.StartupPath+"\\FormKartu\\KartuTanah\\"+manusia.posisi.ToString()+".png");

            if (lemparan == 0)
            {
                picBack2.Visible = false;
                picSell2.Visible = false;
                picBuild2.Visible = false;
                picBack1.Image = Image.FromFile(Application.StartupPath + "\\FormBuySellBuild\\TombolBack.png");
                picBuy1.Image = Image.FromFile(Application.StartupPath + "\\FormBuySellBuild\\TombolBuy.png");
                picUnmortage.Visible = false;
                picMortage.Visible = false;
            }
            else
            {
                picBack1.Visible = false;
                picBuy1.Visible = false;
                picBack2.Image = Image.FromFile(Application.StartupPath + "\\FormBuySellBuild\\TombolBack.png");
                picSell2.Image = Image.FromFile(Application.StartupPath + "\\FormBuySellBuild\\TombolSell.png");
                picBuild2.Image = Image.FromFile(Application.StartupPath + "\\FormBuySellBuild\\TombolBuild.png");
                picMortage.Image = Image.FromFile(Application.StartupPath + "\\FormBuySellBuild\\Tombol Mortage.png");
                picUnmortage.Image = Image.FromFile(Application.StartupPath + "\\FormBuySellBuild\\Tombol Unmortage.png");
            }
        }

        private void picBack1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void picBack2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void picBuy1_Click(object sender, EventArgs e)
        {
            if (manusia.uang - lahan.HargaBeli < 0)
            {
                MessageBox.Show("Anda Tidak Dapat Membeli Tanah !!", "Peringatan");
            }
            else
            {
                if (lahan.LevelBangungan == 6)
                {
                    lahan.BeliLahan(manusia);
                    lahan.statusBeli = true;
                    lahan.TotalHargaBangunan += lahan.HargaBeli;
                    lahan.LevelBangungan = 4;
                    lahan.pemilik = manusia;
                    manusia.uang -= lahan.HargaBeli;
                }
                else
                {
                    lahan.BeliLahan(manusia);
                    lahan.statusBeli = true;
                    lahan.TotalHargaBangunan += lahan.HargaBeli;
                    lahan.pemilik = manusia;
                    manusia.uang -= lahan.HargaBeli;
                }
            }
            
            this.Close();
        }

        private void picSell2_Click(object sender, EventArgs e)
        {
            if (lahan.Mortage == 0)
            {
                lahan.JualLahan(manusia);
                this.Close();
            }
            else
            {
                MessageBox.Show("Silahkan Unmortage Lahan Dahulu !!");
            }
        }

        private void picBuild2_Click(object sender, EventArgs e)
        {
            if (manusia.uang - lahan.HargaPembangunan() < 0)
            {
                MessageBox.Show("Anda Tidak Dapat Membangun Bangunan", "Peringatan");
            }
            else if (lahan.Mortage == 0)
            {
                lahan.BangunLahan(manusia);
                lahan.TotalHargaRumahHotel();
                this.Close();
            }
            else
            {
                MessageBox.Show("Silahkan Unmortage Lahan Dahulu !!");
            }
        }

        private void picBuy1_MouseHover(object sender, EventArgs e)
        {
            SoundChange.Play();
            picBuy1.Image = Image.FromFile(Application.StartupPath + "\\FormBuySellBuild\\TombolBuyHover.png");
        }

        private void picBuy1_MouseLeave(object sender, EventArgs e)
        {
            picBuy1.Image = Image.FromFile(Application.StartupPath + "\\FormBuySellBuild\\TombolBuy.png");
        }

        private void picBack1_MouseHover(object sender, EventArgs e)
        {
            SoundChange.Play();
            picBack1.Image = Image.FromFile(Application.StartupPath + "\\FormBuySellBuild\\TombolBackHover.png");
        }

        private void picBack1_MouseLeave(object sender, EventArgs e)
        {
            picBack1.Image = Image.FromFile(Application.StartupPath + "\\FormBuySellBuild\\TombolBack.png");
        }

        private void picSell2_MouseHover(object sender, EventArgs e)
        {
            SoundChange.Play();
            picSell2.Image = Image.FromFile(Application.StartupPath + "\\FormBuySellBuild\\TombolSellHover.png");
            lblTampil.Text = FormatJual();
        }

        private void picSell2_MouseLeave(object sender, EventArgs e)
        {
            picSell2.Image = Image.FromFile(Application.StartupPath + "\\FormBuySellBuild\\TombolSell.png");
            lblTampil.Text = FormatJual();
        }

        private void picBuild2_MouseHover(object sender, EventArgs e)
        {
            SoundChange.Play();
            picBuild2.Image = Image.FromFile(Application.StartupPath + "\\FormBuySellBuild\\TombolBuildHover.png");
            lblTampil.Text = FormatBangun();
        }

        private void picBuild2_MouseLeave(object sender, EventArgs e)
        {
            picBuild2.Image = Image.FromFile(Application.StartupPath + "\\FormBuySellBuild\\TombolBuild.png");
            lblTampil.Text = FormatBangun();
        }

        private void picBack2_MouseHover(object sender, EventArgs e)
        {
            SoundChange.Play();
            picBack2.Image = Image.FromFile(Application.StartupPath + "\\FormBuySellBuild\\TombolBackHover.png");
        }

        private void picBack2_MouseLeave(object sender, EventArgs e)
        {
            picBack2.Image = Image.FromFile(Application.StartupPath + "\\FormBuySellBuild\\TombolBack.png");
        }

        private void picMortage_MouseLeave(object sender, EventArgs e)
        {
            picMortage.Image = Image.FromFile(Application.StartupPath + "\\FormBuySellBuild\\Tombol Mortage.png");
            lblTampil.Text = FormatMortage();
        }

        private void picUnmortage_MouseLeave(object sender, EventArgs e)
        {
            picUnmortage.Image = Image.FromFile(Application.StartupPath + "\\FormBuySellBuild\\Tombol Unmortage.png");
            lblTampil.Text = FormatUnmortage();
        }

        private void picMortage_MouseHover(object sender, EventArgs e)
        {
            SoundChange.Play();
            lblTampil.Text = FormatMortage();
            picMortage.Image = Image.FromFile(Application.StartupPath + "\\FormBuySellBuild\\TombolMortageHover.png");
        }

        private void picUnmortage_MouseHover(object sender, EventArgs e)
        {
            SoundChange.Play();
            lblTampil.Text = FormatUnmortage();
            picUnmortage.Image = Image.FromFile(Application.StartupPath + "\\FormBuySellBuild\\TombolUnmortage.png");
        }

        private void picMortage_Click(object sender, EventArgs e)
        {
            if (lahan.Mortage == 0 && manusia.JumlahMortage<3)
            {
                lahan.Mortage = 1;
                manusia.JumlahMortage++;
                manusia.uang += lahan.TotalHargaBangunan;
                MessageBox.Show("Tanah Sudah Di Mortage !!");

                if (manusia.Mortage1.NamaKartu == -1)
                { manusia.Mortage1.NamaKartu = lahan.pemilik.posisi; }
                else if (manusia.Mortage2.NamaKartu == -1)
                { manusia.Mortage2.NamaKartu = lahan.pemilik.posisi; }
                else if (manusia.Mortage3.NamaKartu == -1)
                { manusia.Mortage3.NamaKartu = lahan.pemilik.posisi; }
                this.Close();
            }
            else if (manusia.JumlahMortage >= 3)
            {
                MessageBox.Show("Jumlah Mortage Maximum adalah 3 !!");
            }
            else
            {
                MessageBox.Show("Tanah Sudah Dalam Status Mortage !!");
            }
        }

        private void picUnmortage_Click(object sender, EventArgs e)
        {
            if (lahan.Mortage == 1)
            {
                if (manusia.uang - (lahan.TotalHargaBangunan * 2) >= 0)
                {
                    lahan.Mortage = 0;
                    manusia.JumlahMortage--;
                    manusia.uang -= (lahan.TotalHargaBangunan) * 2;
                    MessageBox.Show("Tanah Sudah Di Unmortage !!");

                    if (manusia.posisi == manusia.Mortage1.NamaKartu)
                    { manusia.Mortage1.NamaKartu = -1; }
                    else if (manusia.posisi == manusia.Mortage2.NamaKartu)
                    { manusia.Mortage2.NamaKartu = -1; }
                    else if (manusia.posisi == manusia.Mortage3.NamaKartu)
                    { manusia.Mortage3.NamaKartu = -1; }

                    if (manusia.Mortage3.NamaKartu != -1 && manusia.Mortage2.NamaKartu == -1)
                    {
                        manusia.Mortage2.NamaKartu = manusia.Mortage3.NamaKartu;
                        manusia.Mortage3.NamaKartu = -1;
                    }
                    if (manusia.Mortage2.NamaKartu != -1 && manusia.Mortage1.NamaKartu == -1)
                    {
                        manusia.Mortage1.NamaKartu = manusia.Mortage2.NamaKartu;
                        manusia.Mortage2.NamaKartu = -1;
                    }
                    if (manusia.Mortage3.NamaKartu != -1 && manusia.Mortage2.NamaKartu == -1)
                    {
                        manusia.Mortage2.NamaKartu = manusia.Mortage3.NamaKartu;
                        manusia.Mortage3.NamaKartu = -1;
                    }
                    if (manusia.Mortage2.NamaKartu != -1 && manusia.Mortage1.NamaKartu == -1)
                    {
                        manusia.Mortage1.NamaKartu = manusia.Mortage2.NamaKartu;
                        manusia.Mortage2.NamaKartu = -1;
                    }
                    if (manusia.Mortage3.NamaKartu != -1 && manusia.Mortage2.NamaKartu == -1)
                    {
                        manusia.Mortage2.NamaKartu = manusia.Mortage3.NamaKartu;
                        manusia.Mortage3.NamaKartu = -1;
                    }
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Anda Tidak Mencukupi Uang Untuk Unmortage Lahan Ini !!", "Informasi");
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Tanah Tidak Dalam Status Mortage !!", "Informasi");
            }
        }
    }
}
