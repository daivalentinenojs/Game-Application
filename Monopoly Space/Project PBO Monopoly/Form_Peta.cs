using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Project_PBO_Monopoly
{
    public partial class Form_Peta : Form
    {
        public Form_Peta()
        {
            InitializeComponent();
        }

        internal Form_Peta(int[] j)
        {
            InitializeComponent();
            for (int i = 0; i < 3; i++)
            {
                orang[i] = new Pemain(i);
                orang[i].karakter = j[i];
            }
            orang[3] = new Pemain(3, 1);
            orang[3].karakter = j[3];
        }

        Pemain[] orang = new Pemain[4];
        PictureBox[] picLahanPermainan = new PictureBox[24];
        PictureBox[] picPemain = new PictureBox[4];
        PictureBox[] picBangunan = new PictureBox[24];
        Tanah[] tanahPermainan = new Tanah[24];

        int urutan = 0;
        bool cek = false;
        int dadu = 0;
        int dadujalan;

        System.Media.SoundPlayer SoundChange = new System.Media.SoundPlayer(Application.StartupPath + "\\Music\\HomeEnter.wav");
        System.Media.SoundPlayer SoundJalan = new System.Media.SoundPlayer(Application.StartupPath + "\\Music\\HomeClick.wav");
        private void Form_Peta_Load(object sender, EventArgs e)
        {
            
            this.BackgroundImage = Image.FromFile(Application.StartupPath.ToString() + "\\FormPeta\\FinalPeta.jpg");
            picEnd.Image = Image.FromFile(Application.StartupPath.ToString() + "\\FormPeta\\end.png");
            picCard.Image = Image.FromFile(Application.StartupPath + "\\FormPeta\\Tombol Card.png");
            picMortage.Image = Image.FromFile(Application.StartupPath + "\\FormPeta\\Tombol Mortage.png");
            picRoll.Image = Image.FromFile(Application.StartupPath + "\\FormPeta\\Tombol Roll Dice.png");
            picSave.Image = Image.FromFile(Application.StartupPath + "\\FormPeta\\Tombol Save Game.png");

            #region pic lahan & bangunan & tanah
            int j = 0;
            int hargaTanahBesar = 1300;
            int hargaTanahKecil = 500;
            for (int i = 0; i <= 23; i++)
            {
                switch (i)
                {
                    case 0: picLahanPermainan[i] = picLahan0; picBangunan[i] = picFBangunan0; picPemain[i] = picFPemain0; break;
                    case 1: picLahanPermainan[i] = picLahan1; picBangunan[i] = picFBangunan1; picPemain[i] = picFPemain1; break;
                    case 2: picLahanPermainan[i] = picLahan2; picBangunan[i] = picFBangunan2; picPemain[i] = picFPemain2; break;
                    case 3: picLahanPermainan[i] = picLahan3; picBangunan[i] = picFBangunan3; picPemain[i] = picFPemain3; break;
                    case 4: picLahanPermainan[i] = picLahan4; picBangunan[i] = picFBangunan4; break;
                    case 5: picLahanPermainan[i] = picLahan5; picBangunan[i] = picFBangunan5; break;
                    case 6: picLahanPermainan[i] = picLahan6; picBangunan[i] = picFBangunan6; break;
                    case 7: picLahanPermainan[i] = picLahan7; picBangunan[i] = picFBangunan7; break;
                    case 8: picLahanPermainan[i] = picLahan8; picBangunan[i] = picFBangunan8; break;
                    case 9: picLahanPermainan[i] = picLahan9; picBangunan[i] = picFBangunan9; break;
                    case 10: picLahanPermainan[i] = picLahan10; picBangunan[i] = picFBangunan10; break;
                    case 11: picLahanPermainan[i] = picLahan11; picBangunan[i] = picFBangunan11; break;
                    case 12: picLahanPermainan[i] = picLahan12; picBangunan[i] = picFBangunan12; break;
                    case 13: picLahanPermainan[i] = picLahan13; picBangunan[i] = picFBangunan13; break;
                    case 14: picLahanPermainan[i] = picLahan14; picBangunan[i] = picFBangunan14; break;
                    case 15: picLahanPermainan[i] = picLahan15; picBangunan[i] = picFBangunan15; break;
                    case 16: picLahanPermainan[i] = picLahan16; picBangunan[i] = picFBangunan16; break;
                    case 17: picLahanPermainan[i] = picLahan17; picBangunan[i] = picFBangunan17; break;
                    case 18: picLahanPermainan[i] = picLahan18; picBangunan[i] = picFBangunan18; break;
                    case 19: picLahanPermainan[i] = picLahan19; picBangunan[i] = picFBangunan19; break;
                    case 20: picLahanPermainan[i] = picLahan20; picBangunan[i] = picFBangunan20; break;
                    case 21: picLahanPermainan[i] = picLahan21; picBangunan[i] = picFBangunan21; break;
                    case 22: picLahanPermainan[i] = picLahan22; picBangunan[i] = picFBangunan22; break;
                    case 23: picLahanPermainan[i] = picLahan23; picBangunan[i] = picFBangunan23; break;
                    default: break;
                }
                //picBangunan[i].Image = Image.FromFile(Application.StartupPath.ToString() + "\\FormPeta\\b4.png"); //check tempat bangunan
                #region bangunan
                if (i <= 0)
                {
                    picLahanPermainan[i].Location = new Point(200, 0);
                    picBangunan[i].Dispose();
                }
                else if (i <= 7)
                {
                    j = picLahanPermainan[i - 1].Location.X + picLahanPermainan[i - 1].Width;
                    picLahanPermainan[i].Location = new Point(j, picLahanPermainan[0].Location.Y);
                    picBangunan[i].Location = new Point(picLahanPermainan[i].Location.X + picLahanPermainan[i].Width / 2 - picBangunan[i].Width / 2, picLahanPermainan[i].Location.Y + picLahanPermainan[i].Height);

                    tanahPermainan[i] = new Blok3(hargaTanahBesar);
                    hargaTanahBesar += 150;
                    if (i == 7)
                    {
                        hargaTanahBesar -= 300;
                        picBangunan[i].Dispose();
                    }
                }
                else if (i <= 12)
                {
                    hargaTanahBesar += 200;
                    j = picLahanPermainan[i - 1].Location.Y + picLahanPermainan[i - 1].Height;
                    picLahanPermainan[i].Location = new Point(picLahanPermainan[7].Location.X, j);
                    picBangunan[i].Location = new Point(picLahanPermainan[i].Location.X - picBangunan[i].Width, picLahanPermainan[i].Location.Y + picLahanPermainan[i].Height / 2 - picBangunan[i].Height / 2);

                    tanahPermainan[i] = new Blok4(hargaTanahBesar);
                    if (i == 12)
                        picBangunan[i].Dispose();
                }
                else if (i <= 19)
                {
                    j = picLahanPermainan[i - 1].Location.X - picLahanPermainan[i].Width;
                    picLahanPermainan[i].Location = new Point(j, picLahanPermainan[12].Location.Y);
                    picBangunan[i].Location = new Point(picLahanPermainan[i].Location.X + picLahanPermainan[i].Width / 2 - picBangunan[i].Width / 2, picLahanPermainan[i].Location.Y - picBangunan[i].Height);

                    tanahPermainan[i] = new Blok1(hargaTanahKecil);
                    hargaTanahKecil += 50;
                    if (i == 19)
                    {
                        hargaTanahKecil -= 100;
                        picBangunan[i].Dispose();
                    }
                }
                else
                {
                    hargaTanahKecil += 100;
                    j = picLahanPermainan[i - 1].Location.Y - picLahanPermainan[i].Height;
                    picLahanPermainan[i].Location = new Point(picLahanPermainan[19].Location.X, j);
                    picBangunan[i].Location = new Point(picLahanPermainan[i].Location.X + picLahanPermainan[i].Width, picLahanPermainan[i].Location.Y + picLahanPermainan[i].Height / 2 - picBangunan[i].Height / 2);

                    tanahPermainan[i] = new Blok2(hargaTanahKecil);
                }
                
                #endregion
            }
            #endregion

            // Hotel di Blok 1
            tanahPermainan[17] = new Blok1(1700, 6);
            // Hotel di Blok 2
            tanahPermainan[20] = new Blok2(1950, 6);
            tanahPermainan[23] = new Blok2(2250, 6);
            // Hotel di Blok 3
            tanahPermainan[2] = new Blok3(2650, 6);
            tanahPermainan[5] = new Blok3(3100, 6);
            // Hotel di Blok 4
            tanahPermainan[9] = new Blok4(3750, 6);
            tanahPermainan[10] = new Blok4(3950, 6);
            tanahPermainan[11] = new Blok4(4150, 6);
            #region pic Pemain
            for (int i = 0; i <= 3; i++)
            {
                picPemain[i].Image = Image.FromFile(Application.StartupPath.ToString() + "\\FormPeta\\" + orang[i].karakter + ".png");
                jalan(i);
            }
            #endregion

            tampilLabelPemain();
        }

        #region Method
        private void jalan(int a)
        {
            if (a == 0)
                picPemain[0].Location = new Point(picLahanPermainan[orang[0].posisi].Location.X + picLahanPermainan[orang[0].posisi].Width / 2 - picPemain[0].Width - 5, picLahanPermainan[orang[0].posisi].Location.Y + picLahanPermainan[orang[0].posisi].Height / 2 - picPemain[0].Height - 5);
            else if (a == 1)
                picPemain[1].Location = new Point(picLahanPermainan[orang[1].posisi].Location.X + picLahanPermainan[orang[1].posisi].Width / 2 + 5, picLahanPermainan[orang[1].posisi].Location.Y + picLahanPermainan[orang[1].posisi].Height / 2 - picPemain[1].Height - 5);
            else if (a == 2)
                picPemain[2].Location = new Point(picLahanPermainan[orang[2].posisi].Location.X + picLahanPermainan[orang[2].posisi].Width / 2 - picPemain[2].Width - 5, picLahanPermainan[orang[2].posisi].Location.Y + picLahanPermainan[orang[2].posisi].Height / 2 + 5);
            else if (a == 3)
                picPemain[3].Location = new Point(picLahanPermainan[orang[3].posisi].Location.X + picLahanPermainan[orang[3].posisi].Width / 2 + 5, picLahanPermainan[orang[3].posisi].Location.Y + picLahanPermainan[orang[3].posisi].Height / 2 + 5);
        }
        private int random()
        {
            Random rnd = new Random();
            int a = rnd.Next(1, 7);
            return a;
        }
        private int urutanPlus(int x)
        {
            int y = urutan;
            y += x;
            if (y > 3)
                y -= 4;
            return y;
        }
        private void tampilLabelPemain()
        {

            pUrutan1.Image = Image.FromFile(Application.StartupPath + "\\FormPeta\\" + orang[urutan].karakter + ".png");
            pUrutan2.Image = Image.FromFile(Application.StartupPath + "\\FormPeta\\" + orang[urutanPlus(1)].karakter + ".png");
            pUrutan3.Image = Image.FromFile(Application.StartupPath + "\\FormPeta\\" + orang[urutanPlus(2)].karakter + ".png");
            pUrutan4.Image = Image.FromFile(Application.StartupPath + "\\FormPeta\\" + orang[urutanPlus(3)].karakter + ".png");

            lblpemain1.Text = orang[urutan].format();
            lblpemain2.Text = orang[urutanPlus(1)].format();
            lblpemain3.Text = orang[urutanPlus(2)].format();
            lblpemain4.Text = orang[urutanPlus(3)].format();
        }
        public void formatHover(int x)
        {
            pichHoverLahan.Image = Image.FromFile(Application.StartupPath + "\\FormKartu\\KartuTanah\\" + x + ".png");
            lblHover.Text = tanahPermainan[x].format();
            pblHover.Visible = true;
            if (tanahPermainan[x].statusBeli == false)
                picHoverPemain.Visible = false;
            else
            {
                picHoverPemain.Image = Image.FromFile(Application.StartupPath + "\\FormPeta\\" + tanahPermainan[x].pemilik.karakter + ".png");
                picHoverPemain.Visible = true;
            }
        }
        public void kalah(int x)
        {
            for (int i = 1; i < 24; i++)
                if (tanahPermainan[i].pemilik == orang[x])
                {
                    tanahPermainan[i].statusBeli = false;
                    tanahPermainan[i].pemilik = new Pemain();
                }
            picPemain[x].Visible = false;
            orang[x].totalHarta = 0;
            orang[x].uang = 0;
            tampilLabelPemain();
            int jumlahmenang = 0;
            for (int i = 0; i < 4; i++)
                if (orang[i].uang <= 0 && orang[i].totalHarta <= 0)
                    jumlahmenang++;
            if (jumlahmenang >= 3)
            {
                int pemenang = -1;
                for (int i = 0; i < 4; i++)
                    if (orang[i].uang > 0)
                    {
                        pemenang = i;
                    }
                menang(pemenang);
            }
        }
        public void menang(int x)
        {
            string[] highscore = new string[5];
            int[] checkhigh = new int[5];
            int tampung = 0;
            string tampungstring = "";
            string z = orang[x].nama() + ", " + orang[x].uang + ", " + orang[x].totalHarta;

            TextReader baca = new StreamReader(Application.StartupPath + "\\Others\\Highscore.txt");
            TextReader baca2 = new StreamReader(Application.StartupPath + "\\Others\\Data.txt");
            for (int i = 0; i < 5; i++)
            {
                checkhigh[i] = int.Parse(baca.ReadLine());
                highscore[i] = baca2.ReadLine();
            }
            baca.Close();
            baca2.Close();
            TextWriter myfile = new StreamWriter(Application.StartupPath + "\\Others\\Highscore.txt");
            TextWriter myfile2 = new StreamWriter(Application.StartupPath + "\\Others\\Data.txt");
            for (int i = 0; i < 5; i++)
            {
                if (checkhigh[i] <= orang[x].totalHarta)
                {
                    tampung = checkhigh[i];
                    checkhigh[i] = orang[x].totalHarta;
                    orang[x].totalHarta = tampung;
                    tampungstring = highscore[i];
                    highscore[i] = z;
                    z = tampungstring;
                }
                myfile.WriteLine(checkhigh[i]);
                myfile2.WriteLine(highscore[i]);
            }
            myfile.Close();
            myfile2.Close();
            Form_Main_Menu form = new Form_Main_Menu();
            this.Hide();
            form.ShowDialog();
            this.Close();
        }
        #endregion

        bool turn = true;
        private void picRoll_Click(object sender, EventArgs e)
        {
            if (turn == true)
            {
                dadu = random();
                picDadu.Image = Image.FromFile(Application.StartupPath.ToString() + "\\FormPeta\\dadu\\" + dadu + ".gif");
                cek = true;
                tmrJalan.Enabled = true;
                turn = false;
            }
        }

        
        private void tmrJalan_Tick(object sender, EventArgs e)
        {
            if (cek)
            {
                dadujalan = 1;
                cek = false;
                picNumber.Visible = true;
            }

            #region waktu jalan
            if (dadujalan <= dadu)
            {
                picNumber.Image = Image.FromFile(Application.StartupPath.ToString() + "\\FormPeta\\number\\" + dadujalan + ".jpg");
                SoundJalan.Play();
                orang[urutan].posisi = orang[urutan].posisi + 1;
                jalan(urutan);

                #region melewati go
                if (orang[urutan].posisi == 12)
                {
                    tmrJalan.Enabled = false;

                    if (orang[urutan].CheckJumlahKartu() == true)
                    {
                        Form_Go_Satu form = new Form_Go_Satu(orang[urutan]);
                        form.Owner = this;
                        form.ShowDialog();

                        tampilLabelPemain();
                    }
                    else
                    {
                        Form_Go_Dua form = new Form_Go_Dua(orang[urutan]);
                        form.Owner = this;
                        form.ShowDialog();

                        tampilLabelPemain();
                    }
                    tmrJalan.Enabled = true;
                }
                #endregion
            }
            #endregion
            dadujalan++;

            #region jalan akhir
            if (dadujalan > dadu + 1)
            {
                tmrJalan.Enabled = false;
                if (orang[urutan].posisi == 7)
                {
                    orang[urutan].posisi = 19;
                    jalan(urutan);
                    orang[urutan].skip = 4;
                    MessageBox.Show(orang[urutan].nama() + " go to jail ! !\nSkip for 3 turn");
                }
                else if ((orang[urutan].posisi > 0 && orang[urutan].posisi < 12) || (orang[urutan].posisi > 12 && orang[urutan].posisi < 19) || (orang[urutan].posisi > 19 && orang[urutan].posisi <= 23))
                {

                    if (tanahPermainan[orang[urutan].posisi].statusBeli == false)
                    {
                        Form_Buy_Sell_Build form = new Form_Buy_Sell_Build(0, orang[urutan], tanahPermainan[orang[urutan].posisi]);
                        form.Owner = this;
                        form.ShowDialog();

                        tampilLabelPemain();
                    }
                    else if (tanahPermainan[orang[urutan].posisi].pemilik == orang[urutan])
                    {
                        Form_Buy_Sell_Build form = new Form_Buy_Sell_Build(1, orang[urutan], tanahPermainan[orang[urutan].posisi]);
                        form.Owner = this;
                        form.ShowDialog();

                        tampilLabelPemain();
                        picBangunan[orang[urutan].posisi].Image = Image.FromFile(Application.StartupPath + "\\FormPeta\\b" + tanahPermainan[orang[urutan].posisi].LevelBangungan + ".png");
                    }
                    else
                    {
                        Form_Pay_Use_Card form = new Form_Pay_Use_Card(orang[urutan], tanahPermainan[orang[urutan].posisi]);
                        form.Owner = this;
                        form.ShowDialog();

                        tampilLabelPemain();
                        picBangunan[orang[urutan].posisi].Image = Image.FromFile(Application.StartupPath + "\\FormPeta\\b" + tanahPermainan[orang[urutan].posisi].LevelBangungan + ".png");
                        for (int i = 0; i < 4; i++)
                            if (orang[i].skip > 10)
                            {
                                kalah(i);
                            }
                    }

                    if (tanahPermainan[orang[urutan].posisi].LevelBangungan != 0)
                    {
                        picBangunan[orang[urutan].posisi].Image = Image.FromFile(Application.StartupPath.ToString() + "\\FormPeta\\b" + tanahPermainan[orang[urutan].posisi].LevelBangungan + ".png");
                    }
                }
                else
                {
                }

                picEnd.Visible = true;
            }
            #endregion
        }

        private void picEnd_Click(object sender, EventArgs e)
        {
            picNumber.Visible = false;
            picEnd.Visible = false;
            do
            {
                urutan++;
                if (urutan >= 4)
                    urutan = 0;
                tampilLabelPemain();
                if (orang[urutan].skip > 0)
                {
                    orang[urutan].skip--;
                    if (orang[urutan].skip > 0 && orang[urutan].skip < 5)
                        if (4 - orang[urutan].skip == 1)
                            MessageBox.Show(orang[urutan].nama() + " got jailed\n 1st skip turn");
                        else if (4 - orang[urutan].skip == 2)
                            MessageBox.Show(orang[urutan].nama() + " got jailed\n 2nd skip turn");
                        else
                            MessageBox.Show(orang[urutan].nama() + " got jailed\n 3rd skip turn");
                    else if(orang[urutan].skip == 0)
                    {
                        MessageBox.Show("Bayar denda 1000 !!");
                        orang[urutan].uang -= 1000;
                        orang[urutan].totalHarta -= 1000;

                        if (orang[urutan].uang < 0)
                        {
                            MessageBox.Show("Anda Tidak Sanggup Membayar Denda, Anda Kalah!!!");
                            orang[urutan].skip = 15;
                            kalah(urutan);
                        }
                    }
                }
                if (orang[urutan].skip < 0)
                {
                    orang[urutan].skip++;
                    if (orang[urutan].skip <= -1)
                        MessageBox.Show(orang[urutan].nama() + "'s turn, \n But You Got Skip Card Effect !!");
                }
            } while (orang[urutan].skip != 0);

            turn = true;
            MessageBox.Show(orang[urutan].nama() + "'s turn");
            picRoll.Enabled = true;
        }

        #region button
        private void picMortage_Click(object sender, EventArgs e)
        {
            Form_Mortage form = new Form_Mortage(orang[urutan]);
            form.Owner = this;
            form.ShowDialog();
            
        }

        private void picCard_Click(object sender, EventArgs e)
        {
            Form_Use_Card form = new Form_Use_Card(0, orang[urutan], tanahPermainan[orang[urutan].posisi]);
            form.Owner = this;
            form.ShowDialog();
        }
        private void picMortage_MouseLeave(object sender, EventArgs e)
        {
            picMortage.Image = Image.FromFile(Application.StartupPath + "\\FormPeta\\Tombol Mortage.png");
        }

        private void picCard_MouseLeave(object sender, EventArgs e)
        {
            picCard.Image = Image.FromFile(Application.StartupPath + "\\FormPeta\\Tombol Card.png");
        }

        private void picRoll_MouseLeave(object sender, EventArgs e)
        {
            picRoll.Image = Image.FromFile(Application.StartupPath + "\\FormPeta\\Tombol Roll Dice.png");
        }

        private void picSave_MouseLeave(object sender, EventArgs e)
        {
            picSave.Image = Image.FromFile(Application.StartupPath + "\\FormPeta\\Tombol Save Game.png");
        }

        private void picMortage_MouseHover(object sender, EventArgs e)
        {
            SoundChange.Play();
            picMortage.Image = Image.FromFile(Application.StartupPath + "\\FormPeta\\TombolMortageHover.png");
        }

        private void picCard_MouseHover(object sender, EventArgs e)
        {
            SoundChange.Play();
            picCard.Image = Image.FromFile(Application.StartupPath + "\\FormPeta\\TombolCardHover.png");
        }

        private void picRoll_MouseHover(object sender, EventArgs e)
        {
            SoundChange.Play();
            picRoll.Image = Image.FromFile(Application.StartupPath + "\\FormPeta\\TombolRollDiceHover.png");
        }

        private void picSave_MouseHover(object sender, EventArgs e)
        {
            SoundChange.Play();
            picSave.Image = Image.FromFile(Application.StartupPath + "\\FormPeta\\TombolSaveGameHover.png");
        }

        private void picEnd_MouseHover(object sender, EventArgs e)
        {
            SoundChange.Play();
            picEnd.Image = Image.FromFile(Application.StartupPath + "\\FormPeta\\endHover.png");
        }

        private void picEnd_MouseLeave(object sender, EventArgs e)
        {
            picEnd.Image = Image.FromFile(Application.StartupPath + "\\FormPeta\\end.png");
        }
        #endregion

        #region hover
        private void picLahan1_MouseEnter(object sender, EventArgs e)
        {
            formatHover(1);
        }

        private void picLahan2_MouseEnter(object sender, EventArgs e)
        {
            formatHover(2);
        }

        private void picLahan3_MouseEnter(object sender, EventArgs e)
        {
            formatHover(3);
        }

        private void picLahan4_MouseEnter(object sender, EventArgs e)
        {
            formatHover(4);
        }

        private void picLahan5_MouseEnter(object sender, EventArgs e)
        {
            formatHover(5);
        }

        private void picLahan6_MouseEnter(object sender, EventArgs e)
        {
            formatHover(6);
        }

        private void picLahan8_MouseEnter(object sender, EventArgs e)
        {
            formatHover(8);
        }

        private void picLahan9_MouseEnter(object sender, EventArgs e)
        {
            formatHover(9);
        }

        private void picLahan10_MouseEnter(object sender, EventArgs e)
        {
            formatHover(10);
        }

        private void picLahan11_MouseEnter(object sender, EventArgs e)
        {
            formatHover(11);
        }

        private void picLahan13_MouseEnter(object sender, EventArgs e)
        {
            formatHover(13);
        }

        private void picLahan14_MouseEnter(object sender, EventArgs e)
        {
            formatHover(14);
        }

        private void picLahan15_MouseEnter(object sender, EventArgs e)
        {
            formatHover(15);
        }

        private void picLahan16_MouseEnter(object sender, EventArgs e)
        {
            formatHover(16);
        }

        private void picLahan17_MouseEnter(object sender, EventArgs e)
        {
            formatHover(17);
        }

        private void picLahan18_MouseEnter(object sender, EventArgs e)
        {
            formatHover(18);
        }

        private void picLahan20_MouseEnter(object sender, EventArgs e)
        {
            formatHover(20);
        }

        private void picLahan21_MouseEnter(object sender, EventArgs e)
        {
            formatHover(21);
        }

        private void picLahan22_MouseEnter(object sender, EventArgs e)
        {
            formatHover(22);
        }

        private void picLahan23_MouseEnter(object sender, EventArgs e)
        {
            formatHover(23);
        }

        private void picLahan0_MouseLeave(object sender, EventArgs e)
        {
            pblHover.Visible = false;
        }
        #endregion

        private void picSave_Click(object sender, EventArgs e)
        {
            DialogResult pesan;
            pesan = MessageBox.Show("Apakah Anda Yakin ?", "Peringatan", MessageBoxButtons.OKCancel);
            if (pesan == DialogResult.OK)
            {
                Form_Main_Menu form = new Form_Main_Menu();
                this.Hide();
                form.ShowDialog();
                this.Close();
            }
        }

    }
}
