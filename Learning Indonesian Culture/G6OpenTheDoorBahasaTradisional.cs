using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MIB_2015
{
    public partial class G6OpenTheDoorBahasaTradisional : Form
    {
        Player p1, p2;
        int stage;
        public G6OpenTheDoorBahasaTradisional(Player p1,Player p2,int stage)
        {
            InitializeComponent();
            this.p1 = p1;
            this.p2 = p2;
            this.stage = stage;
        }

        Random rnd = new Random();
        int [] arrSoal1 = new int [4];
        int [] arrSoal2 = new int[4];
        String [] AngkaSatu = {"Siji", "Shettong", "Sada", "Mese", "Sa", "Sidi", "Asa"};
        String [] AngkaDua = {"Loro", "Dhuwwe", "Dua", "Nua", "Duwa", "Duwa", "Dua"};
        String [] AngkaTiga = {"Telu", "Tello", "Tolu", "Teun", "Lhee", "Tellu", "Talu"};
        String [] AngkaEmpat = {"Papat", "Ampa", "Opat", "Ha", "Peuet", "Eppa", "Ampat"};
        int waktuMain = 0, indexP1 = 0, pointP1 = 0, pointP2 = 0, jumlahBenarP1 = 0, jumlahTotalBenarP1 = 0, indexP2 = 0, jumlahBenarP2 = 0, jumlahTotalBenarP2 = 0;
        System.Media.SoundPlayer SoundMain = new System.Media.SoundPlayer(Application.StartupPath + "\\Music\\G6.wav");

        private void acakSoalP1()
        {
            for (int i = 0; i < 4; i++)
            {
                arrSoal1[i] = rnd.Next(0, 4);
                for (int j = 0; j < i; j++)
                {
                    while (arrSoal1[i] == arrSoal1[j])
                    {
                        arrSoal1[i] = rnd.Next(0, 4);
                        j = 0;
                    }
                }
                label1.Text += arrSoal1[i]+1;
            }
        }

        private void acakSoalP2()
        {
            for (int i = 0; i < 4; i++)
            {
                arrSoal2[i] = rnd.Next(0, 4);
                for (int j = 0; j < i; j++)
                {
                    while (arrSoal2[i] == arrSoal2[j])
                    {
                        arrSoal2[i] = rnd.Next(0, 4);
                        j = 0;
                    }
                }
                label8.Text += arrSoal2[i] + 1;
            }
        }

        private void tampilKodeP1()
        {   
            for (int i = 0; i < 4; i++)
            {
                int bahasa1 = rnd.Next(0, 7);
                if (arrSoal1[i] == 0)
                    lblSoal1.Text += AngkaSatu[bahasa1] + " ";
                else if (arrSoal1[i] == 1)
                    lblSoal1.Text += AngkaDua[bahasa1] + " ";
                else if (arrSoal1[i] == 2)
                    lblSoal1.Text += AngkaTiga[bahasa1] + " ";
                else if (arrSoal1[i] == 3)
                    lblSoal1.Text += AngkaEmpat[bahasa1] + " ";
            }
            //lblSoal1.Text = AngkaSatu[bahasa1] + AngkaDua[bahasa2] + AngkaTiga[bahasa3] + AngkaEmpat[bahasa4];   
            picP1Angka1.Image = Image.FromFile(Application.StartupPath + "\\G6OpenTheDoorBahasaTradisional\\1-02.png");
            picP1Angka2.Image = Image.FromFile(Application.StartupPath + "\\G6OpenTheDoorBahasaTradisional\\2-02.png");
            picP1Angka3.Image = Image.FromFile(Application.StartupPath + "\\G6OpenTheDoorBahasaTradisional\\3-02.png");
            picP1Angka4.Image = Image.FromFile(Application.StartupPath + "\\G6OpenTheDoorBahasaTradisional\\4-02.png");
        }

        private void tampilKodeP2()
        {
            for (int i = 0; i < 4; i++)
            {
                int bahasa2 = rnd.Next(0, 7);
                if (arrSoal2[i] == 0)
                    lblSoal2.Text += AngkaSatu[bahasa2] + " ";
                else if (arrSoal2[i] == 1)
                    lblSoal2.Text += AngkaDua[bahasa2] + " ";
                else if (arrSoal2[i] == 2)
                    lblSoal2.Text += AngkaTiga[bahasa2] + " ";
                else if (arrSoal2[i] == 3)
                    lblSoal2.Text += AngkaEmpat[bahasa2] + " ";
            }
            //lblSoal1.Text = AngkaSatu[bahasa1] + AngkaDua[bahasa2] + AngkaTiga[bahasa3] + AngkaEmpat[bahasa4];   
            picP2Angka1.Image = Image.FromFile(Application.StartupPath + "\\G6OpenTheDoorBahasaTradisional\\1-02.png");
            picP2Angka2.Image = Image.FromFile(Application.StartupPath + "\\G6OpenTheDoorBahasaTradisional\\2-02.png");
            picP2Angka3.Image = Image.FromFile(Application.StartupPath + "\\G6OpenTheDoorBahasaTradisional\\3-02.png");
            picP2Angka4.Image = Image.FromFile(Application.StartupPath + "\\G6OpenTheDoorBahasaTradisional\\4-02.png");
        }

        public void UlangP1()
        {
            if (jumlahBenarP1 == 4)
            {
                pointP1 += 100;
                indexP1 = 0;
                jumlahBenarP1 = 0;
                label1.Text = "";
                lblSoal1.Text = "";
                jumlahTotalBenarP1++;
                acakSoalP1();
                tampilKodeP1();

                picP1Angka1.Visible = false;
                picP1Angka2.Visible = false;
                picP1Angka3.Visible = false;
                picP1Angka4.Visible = false;
                lblSoal1.Visible = false;
                label1.Visible = false;

                tmrTirai1.Enabled = true;
                picTirai1Ke2.Visible = true;
            }
        }

        public void UlangP2()
        {
            if (jumlahBenarP2 == 4)
            {
                pointP2 += 100;
                indexP2 = 0;
                jumlahBenarP2 = 0;
                label8.Text = "";
                lblSoal2.Text = "";
                jumlahTotalBenarP2++;
                acakSoalP2();
                tampilKodeP2();

                picP2Angka1.Visible = false;
                picP2Angka2.Visible = false;
                picP2Angka3.Visible = false;
                picP2Angka4.Visible = false;
                lblSoal2.Visible = false;
                label8.Visible = false;

                tmrTirai2.Enabled = true;
                picTirai2Ke2.Visible = true;
            }
        }

        private void G6OpenTheDoorBahasaTradisional_Load(object sender, EventArgs e)
        {
            tmrG6.Enabled = true;
            SoundMain.PlayLooping();
            this.CenterToScreen();

            label1.Text = "";
            lblSoal1.Text = "";

            label8.Text = "";
            lblSoal2.Text = "";

            label1.Visible = false;
            label8.Visible = false;

            acakSoalP1();
            tampilKodeP1();

            acakSoalP2();
            tampilKodeP2();
            /*
            picP1Angka1.Parent = picTirai1Ke1;
            picP1Angka2.Parent = picTirai1Ke1;
            picP1Angka3.Parent = picTirai1Ke1;
            picP1Angka4.Parent = picTirai1Ke1;
            lblSoal1.Parent = picTirai1Ke1;
            label3.Parent = picTirai1Ke1;
            //lblHasil.Parent = picTirai1Ke2;

            label7.Parent = picTirai2Ke1;
            label2.Parent = picTirai2Ke1;
            lblDetik.Parent = picTirai2Ke1;
            
            picP2Angka1.Parent = picTirai2Ke1;
            picP2Angka2.Parent = picTirai2Ke1;
            picP2Angka3.Parent = picTirai2Ke1;
            picP2Angka4.Parent = picTirai2Ke1;
            
            lblSoal2.Parent = picTirai2Ke1;
            */
        }

        private void G6OpenTheDoorBahasaTradisional_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == 'w' || e.KeyChar == 'W') && (tmrG6.Enabled == true))
            {
                if (arrSoal1[indexP1] == 0)
                {
                    new System.Threading.Thread(() =>
                    {
                        var c = new System.Windows.Media.MediaPlayer();
                        c.Open(new System.Uri(@Application.StartupPath + "\\Music\\G6Angka.wav"));
                        c.Play();
                    }).Start();

                    picP1Angka1.Image = Image.FromFile(Application.StartupPath + "\\G6OpenTheDoorBahasaTradisional\\1h-02.png");
                    jumlahBenarP1++;
                    indexP1++;

                    UlangP1();
                }
                else
                {
                    new System.Threading.Thread(() =>
                    {
                        var c = new System.Windows.Media.MediaPlayer();
                        c.Open(new System.Uri(@Application.StartupPath + "\\Music\\G5Salah.wav"));
                        c.Play();
                    }).Start();

                    if (pointP1 - 50 >= 0)
                        pointP1 -= 50;
                }
            }

            if ((e.KeyChar == 'a' || e.KeyChar == 'A') && (tmrG6.Enabled == true))
            {
                if (arrSoal1[indexP1] == 1)
                {
                    new System.Threading.Thread(() =>
                    {
                        var c = new System.Windows.Media.MediaPlayer();
                        c.Open(new System.Uri(@Application.StartupPath + "\\Music\\G6Angka.wav"));
                        c.Play();
                    }).Start();

                    picP1Angka2.Image = Image.FromFile(Application.StartupPath + "\\G6OpenTheDoorBahasaTradisional\\2h-02.png");
                    jumlahBenarP1++;
                    indexP1++;

                    UlangP1();
                }
                else
                {
                    new System.Threading.Thread(() =>
                    {
                        var c = new System.Windows.Media.MediaPlayer();
                        c.Open(new System.Uri(@Application.StartupPath + "\\Music\\G5Salah.wav"));
                        c.Play();
                    }).Start();

                    if (pointP1 - 50 >= 0)
                        pointP1 -= 50;
                }
            }

            if ((e.KeyChar == 'd' || e.KeyChar == 'D') && (tmrG6.Enabled == true))
            {
                if (arrSoal1[indexP1] == 2)
                {
                    new System.Threading.Thread(() =>
                    {
                        var c = new System.Windows.Media.MediaPlayer();
                        c.Open(new System.Uri(@Application.StartupPath + "\\Music\\G6Angka.wav"));
                        c.Play();
                    }).Start();

                    picP1Angka3.Image = Image.FromFile(Application.StartupPath + "\\G6OpenTheDoorBahasaTradisional\\3h-02.png");
                    jumlahBenarP1++;
                    indexP1++;

                    UlangP1();
                }
                else
                {
                    new System.Threading.Thread(() =>
                    {
                        var c = new System.Windows.Media.MediaPlayer();
                        c.Open(new System.Uri(@Application.StartupPath + "\\Music\\G5Salah.wav"));
                        c.Play();
                    }).Start();

                    if (pointP1 - 50 >= 0)
                        pointP1 -= 50;
                }
            }

            if ((e.KeyChar == 's' || e.KeyChar == 'S') && (tmrG6.Enabled == true))
            {
                if (arrSoal1[indexP1] == 3)
                {
                    new System.Threading.Thread(() =>
                    {
                        var c = new System.Windows.Media.MediaPlayer();
                        c.Open(new System.Uri(@Application.StartupPath + "\\Music\\G6Angka.wav"));
                        c.Play();
                    }).Start();

                    picP1Angka4.Image = Image.FromFile(Application.StartupPath + "\\G6OpenTheDoorBahasaTradisional\\4h-02.png");
                    jumlahBenarP1++;
                    indexP1++;

                    UlangP1();
                }
                else
                {
                    new System.Threading.Thread(() =>
                    {
                        var c = new System.Windows.Media.MediaPlayer();
                        c.Open(new System.Uri(@Application.StartupPath + "\\Music\\G5Salah.wav"));
                        c.Play();
                    }).Start();

                    if (pointP1 - 50 >= 0)
                        pointP1 -= 50;
                }
            }

            if ((e.KeyChar == 'i' || e.KeyChar == 'I') && (tmrG6.Enabled == true))
            {
                if (arrSoal2[indexP2] == 0)
                {
                    new System.Threading.Thread(() =>
                    {
                        var c = new System.Windows.Media.MediaPlayer();
                        c.Open(new System.Uri(@Application.StartupPath + "\\Music\\G6Angka.wav"));
                        c.Play();
                    }).Start();

                    picP2Angka1.Image = Image.FromFile(Application.StartupPath + "\\G6OpenTheDoorBahasaTradisional\\1h-02.png");
                    jumlahBenarP2++;
                    indexP2++;

                    UlangP2();
                }
                else
                {
                    new System.Threading.Thread(() =>
                    {
                        var c = new System.Windows.Media.MediaPlayer();
                        c.Open(new System.Uri(@Application.StartupPath + "\\Music\\G5Salah.wav"));
                        c.Play();
                    }).Start();

                    if (pointP2 - 50 >= 0)
                        pointP2 -= 50;
                }
            }

            if ((e.KeyChar == 'j' || e.KeyChar == 'J') && (tmrG6.Enabled == true))
            {
                if (arrSoal2[indexP2] == 1)
                {
                    new System.Threading.Thread(() =>
                    {
                        var c = new System.Windows.Media.MediaPlayer();
                        c.Open(new System.Uri(@Application.StartupPath + "\\Music\\G6Angka.wav"));
                        c.Play();
                    }).Start();

                    picP2Angka2.Image = Image.FromFile(Application.StartupPath + "\\G6OpenTheDoorBahasaTradisional\\2h-02.png");
                    jumlahBenarP2++;
                    indexP2++;

                    UlangP2();
                }
                else
                {
                    new System.Threading.Thread(() =>
                    {
                        var c = new System.Windows.Media.MediaPlayer();
                        c.Open(new System.Uri(@Application.StartupPath + "\\Music\\G5Salah.wav"));
                        c.Play();
                    }).Start();

                    if (pointP2 - 50 >= 0)
                        pointP2 -= 50;
                }
            }

            if ((e.KeyChar == 'l' || e.KeyChar == 'L') && (tmrG6.Enabled == true))
            {
                if (arrSoal2[indexP2] == 2)
                {
                    new System.Threading.Thread(() =>
                    {
                        var c = new System.Windows.Media.MediaPlayer();
                        c.Open(new System.Uri(@Application.StartupPath + "\\Music\\G6Angka.wav"));
                        c.Play();
                    }).Start();

                    picP2Angka3.Image = Image.FromFile(Application.StartupPath + "\\G6OpenTheDoorBahasaTradisional\\3h-02.png");
                    jumlahBenarP2++;
                    indexP2++;

                    UlangP2();
                }
                else
                {
                    new System.Threading.Thread(() =>
                    {
                        var c = new System.Windows.Media.MediaPlayer();
                        c.Open(new System.Uri(@Application.StartupPath + "\\Music\\G5Salah.wav"));
                        c.Play();
                    }).Start();

                    if (pointP2 - 50 >= 0)
                        pointP2 -= 50;
                }
            }

            if ((e.KeyChar == 'k' || e.KeyChar == 'K') && (tmrG6.Enabled == true))
            {
                if (arrSoal2[indexP2] == 3)
                {
                    new System.Threading.Thread(() =>
                    {
                        var c = new System.Windows.Media.MediaPlayer();
                        c.Open(new System.Uri(@Application.StartupPath + "\\Music\\G6Angka.wav"));
                        c.Play();
                    }).Start();

                    picP2Angka4.Image = Image.FromFile(Application.StartupPath + "\\G6OpenTheDoorBahasaTradisional\\4h-02.png");
                    jumlahBenarP2++;
                    indexP2++;

                    UlangP2();
                }
                else
                {
                    new System.Threading.Thread(() =>
                    {
                        var c = new System.Windows.Media.MediaPlayer();
                        c.Open(new System.Uri(@Application.StartupPath + "\\Music\\G5Salah.wav"));
                        c.Play();
                    }).Start();

                    if (pointP2 - 50 >= 0)
                        pointP2 -= 50;
                }
            }
        }

        private void tmrG6_Tick(object sender, EventArgs e)
        {
            waktuMain++;
            pp1.Text = pointP1.ToString();
            pp2.Text = pointP2.ToString();

            if ((60 - waktuMain) >= 10)
                lblDetik.Text = "00 : " + (60 - waktuMain).ToString();
            else
                lblDetik.Text = "00 : 0" + (60 - waktuMain).ToString();

            if (waktuMain >= 60 || jumlahTotalBenarP1 == 5 || jumlahTotalBenarP2 == 5)
            {
                tmrG6.Enabled = false;
                lblDetik.Text = "00 : 00";
                
                lblSoal1.Visible = false;
                label1.Visible = false;

                lblSoal2.Visible = false;
                label8.Visible = false;
                /*
                label3.Parent = picTirai1Ke2;
                label7.Parent = picTirai2Ke2;
                label2.Parent = picTirai2Ke2;
                lblDetik.Parent = picTirai2Ke2;
                */
                picP1Angka1.Visible = false;
                picP1Angka2.Visible = false;
                picP1Angka3.Visible = false;
                picP1Angka4.Visible = false;
                picTirai1Ke2.Visible = false;

                picP2Angka1.Visible = false;
                picP2Angka2.Visible = false;
                picP2Angka3.Visible = false;
                picP2Angka4.Visible = false;
                picTirai2Ke2.Visible = false;

                lblHasil.Visible = true;
    
                if (pointP1 > pointP2)
                    lblHasil.Text = "Pemain 1 Menang !";
                else if (pointP2 > pointP1)
                    lblHasil.Text = "Pemain 2 Menang !";
                else
                    lblHasil.Text = "Permainan Seri !";

                System.Threading.Thread.Sleep(400);
                Player.RecordScore(6, p1.Name, p2.Name, pointP1, pointP2);
                hs t = new hs(6);
                t.ShowDialog();
                t.BringToFront();
                t.center();
                timer1.Enabled = true;
            }
        }

        int waktuP1Tirai = 0, waktuP2Tirai = 0;
        private void tmrTirai1_Tick(object sender, EventArgs e)
        {
            waktuP1Tirai++;
            if (waktuP1Tirai == 1)
            {
                new System.Threading.Thread(() =>
                {
                    var c = new System.Windows.Media.MediaPlayer();
                    c.Open(new System.Uri(@Application.StartupPath + "\\Music\\G6TiraiBuka.wav"));
                    c.Play();
                }).Start();
            }

            picTirai1Ke2.Location = new Point(picTirai1Ke2.Location.X - 75, picTirai1Ke2.Location.Y);
            if (waktuP1Tirai == 5)
            {
                if (jumlahTotalBenarP1 < 5)
                {
                    picP1Angka1.Visible = true;
                    picP1Angka2.Visible = true;
                    picP1Angka3.Visible = true;
                    picP1Angka4.Visible = true;
                    picTirai1Ke2.Visible = false;
                    lblSoal1.Visible = true;
                    //label1.Visible = true;
                }
                picTirai1Ke2.Location = new Point(2, 0);
                tmrTirai1.Enabled = false;
                waktuP1Tirai = 0;
            }
        }

        private void tmrTirai2_Tick(object sender, EventArgs e)
        {
            waktuP2Tirai++;
            if (waktuP2Tirai == 1)
            {
                new System.Threading.Thread(() =>
                {
                    var c = new System.Windows.Media.MediaPlayer();
                    c.Open(new System.Uri(@Application.StartupPath + "\\Music\\G6TiraiBuka.wav"));
                    c.Play();
                }).Start();
            }

            picTirai2Ke2.Location = new Point(picTirai2Ke2.Location.X + 75, picTirai2Ke2.Location.Y);
            if (waktuP2Tirai == 5)
            {
                if (jumlahTotalBenarP2 < 5)
                {
                    picP2Angka1.Visible = true;
                    picP2Angka2.Visible = true;
                    picP2Angka3.Visible = true;
                    picP2Angka4.Visible = true;
                    picTirai2Ke2.Visible = false;
                    lblSoal2.Visible = true;
                    //label8.Visible = true;
                }
                picTirai2Ke2.Location = new Point(508, 0);
                tmrTirai2.Enabled = false;
                waktuP2Tirai = 0;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            this.Hide();
            this.theParent.Show();
            this.theParent.Focus();

            G0RandomGame ae = (G0RandomGame)this.theParent;
            if (ae.counter < 5)
            {
                ae.tmrRandom.Enabled = true;
                ae._start = DateTime.UtcNow;
                ae.counter++; ae.p1.Score+=pointP1; ae.p2.Score+=pointP2;
            }
            this.Dispose();
        }
        public Form theParent;

        private void picExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void picTirai1Ke2_Click(object sender, EventArgs e)
        {

        }

        private void pp2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void lblSoal1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void picTirai2Ke2_Click(object sender, EventArgs e)
        {

        }

        private void G6OpenTheDoorBahasaTradisional_FormClosed(object sender, FormClosedEventArgs e)
        {
            SoundMain.Stop();
        }

        private void lblDetik_Click(object sender, EventArgs e)
        {

        }

        private void picExit_MouseHover(object sender, EventArgs e)
        {
            picExit.Image = Image.FromFile(Application.StartupPath + "\\Button\\quithover.png");
        }

        private void picExit_MouseLeave(object sender, EventArgs e)
        {
            picExit.Image = Image.FromFile(Application.StartupPath + "\\Button\\quit.png");
        }
    }
}
