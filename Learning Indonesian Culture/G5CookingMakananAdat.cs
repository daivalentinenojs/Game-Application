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
    public partial class picMakananP1 : Form
    {
        Player p1, p2;
        int stage;
        public picMakananP1(Player p1,Player p2,int stage)
        {
            InitializeComponent();
            this.p1 = p1;
            this.p2 = p2;
            this.stage=stage;
        }

        int waktuMain = 0, pointP1 = 0, pointP2 = 0, makananP1 = 0, indexP1 = 0, makananP2 = 0, indexP2 = 0, jumlahBenarP1 = 0, jumlahBenarP2 = 0;
        int [] arrMakananP1 = new int[8];
        int [] arrMakananP2 = new int[8];
        Random rnd = new Random();
        System.Media.SoundPlayer SoundMain = new System.Media.SoundPlayer(Application.StartupPath + "\\Music\\G5.wav");

        private void tmrG5_Tick(object sender, EventArgs e)
        {
            waktuMain++;
            pp1.Text = pointP1.ToString();
            pp2.Text = pointP2.ToString();

            if ((60 - waktuMain) >= 10)
                lblDetik.Text = "00 : " + (60 - waktuMain).ToString();
            else
                lblDetik.Text = "00 : 0" + (60 - waktuMain).ToString();

            if (waktuMain >= 60 || jumlahBenarP1 >= 5 || jumlahBenarP2 >= 5)
            {
                tmrG5.Enabled = false;
                lblDetik.Text = "00 : 00";
                lblHasil.Visible = true;

                if (pointP1 > pointP2)
                    lblHasil.Text = "Pemenang 1 Menang !";
                else if (pointP2 > pointP1)
                    lblHasil.Text = "Pemenang 2 Menang !";
                else
                    lblHasil.Text = "Permainan Seri !";
                System.Threading.Thread.Sleep(4000);
                Player.RecordScore(5, p1.Name, p2.Name, pointP1, pointP2);
                hs t = new hs(5);
                t.ShowDialog();
                t.BringToFront();
                t.center();
                timer1.Enabled = true;
            }
        }

        private void G5CookingMakananAdat_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            SoundMain.PlayLooping();
            label6.Text = "";
            label8.Text = "";
            
        }

        private void picMakananP1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == 'a' || e.KeyChar == 'A') && checktimer == 1)
            {
                if (indexP1 - 1 < 0)
                    indexP1 = arrMakananP1.Length-1;
                else
                    indexP1 = indexP1 - 1;

                p1Kiri.Image = Image.FromFile(Application.StartupPath + "\\G5CookingMakananAdat\\ab.png");
                picBahanP1.Image = Image.FromFile(Application.StartupPath + "\\G5CookingMakananAdat\\" + makananP1 + arrMakananP1[indexP1] + ".png");
            }

            if ((e.KeyChar == 'd' || e.KeyChar == 'D') && checktimer == 1)
            {
                if (indexP1 + 1 > (arrMakananP1.Length-1))
                    indexP1 = 0;
                else
                    indexP1 = indexP1 + 1;

                p1Kanan.Image = Image.FromFile(Application.StartupPath + "\\G5CookingMakananAdat\\db.png");
                picBahanP1.Image = Image.FromFile(Application.StartupPath + "\\G5CookingMakananAdat\\" + makananP1 + arrMakananP1[indexP1] + ".png");
            }

            if (e.KeyChar == 's' || e.KeyChar == 'S')
            {
                if ((makananP1 == 1 && arrMakananP1[indexP1] != 1 && arrMakananP1[indexP1] != 4 && arrMakananP1[indexP1] != 6)
                    || (makananP1 == 2 && arrMakananP1[indexP1] != 2 && arrMakananP1[indexP1] != 3 && arrMakananP1[indexP1] != 4)
                    || (makananP1 == 3 && arrMakananP1[indexP1] != 0 && arrMakananP1[indexP1] != 3 && arrMakananP1[indexP1] != 7))
                {
                    jumlahBenarP1++;

                    new System.Threading.Thread(() =>
                    {
                        var c = new System.Windows.Media.MediaPlayer();
                        c.Open(new System.Uri(@Application.StartupPath + "\\Music\\G5Benar.wav"));
                        c.Play();
                    }).Start();

                    label8.Text = "";
                    pointP1 += 100;
                    int indexBantu = indexP1, iBaru = 0;
                    int[] arrBantu = new int[arrMakananP1.Length - 1];

                    picHiddenP1.Visible = true;
                    picHiddenP1.Image = Image.FromFile(Application.StartupPath + "\\G5CookingMakananAdat\\" + makananP1 + arrMakananP1[indexP1] + ".png");
                    tmrHidden1.Enabled = true;

                    for (int i = 0; i < arrMakananP1.Length; i++)
                    {
                        if (i != indexP1)
                        {
                            arrBantu[iBaru] = arrMakananP1[i];
                            iBaru++;
                        }
                    }

                    arrMakananP1 = new int[arrBantu.Length];
                    for (int i = 0; i < arrBantu.Length; i++)
                    {
                        arrMakananP1[i] = arrBantu[i];
                        label8.Text += arrMakananP1[i].ToString();
                    }

                    if (indexP1 - 1 < 0)
                    {
                        indexP1 = arrMakananP1.Length - 1;
                    }
                    else
                    {
                        indexP1--;
                    }
                }
                else
                {
                    

                    if (pointP1 - 50 >= 0)
                        pointP1 -= 50;

                    new System.Threading.Thread(() =>
                    {
                        var c = new System.Windows.Media.MediaPlayer();
                        c.Open(new System.Uri(@Application.StartupPath + "\\Music\\G5Salah.wav"));
                        c.Play();
                    }).Start();

                    tmrSalahP1.Enabled = true;
                }
                picBahanP1.Image = Image.FromFile(Application.StartupPath + "\\G5CookingMakananAdat\\" + makananP1 + arrMakananP1[indexP1] + ".png");
            }

            // Player 2
            if ((e.KeyChar == 'j' || e.KeyChar == 'J') && checktimer == 1)
            {
                if (indexP2 - 1 < 0)
                    indexP2 = arrMakananP2.Length - 1;
                else
                    indexP2 = indexP2 - 1;

                p2Kiri.Image = Image.FromFile(Application.StartupPath + "\\G5CookingMakananAdat\\jb.png");
                picBahanP2.Image = Image.FromFile(Application.StartupPath + "\\G5CookingMakananAdat\\" + makananP2 + arrMakananP2[indexP2] + ".png");
            }

            if ((e.KeyChar == 'l' || e.KeyChar == 'L') && checktimer == 1)
            {
                if (indexP2 + 1 > (arrMakananP2.Length - 1))
                    indexP2 = 0;
                else
                    indexP2 = indexP2 + 1;

                p2Kanan.Image = Image.FromFile(Application.StartupPath + "\\G5CookingMakananAdat\\lb.png");
                picBahanP2.Image = Image.FromFile(Application.StartupPath + "\\G5CookingMakananAdat\\" + makananP2 + arrMakananP2[indexP2] + ".png");
            }

            if (e.KeyChar == 'k' || e.KeyChar == 'K')
            {
                if ((makananP2 == 1 && arrMakananP2[indexP2] != 1 && arrMakananP2[indexP2] != 4 && arrMakananP2[indexP2] != 6)
                    || (makananP2 == 2 && arrMakananP2[indexP2] != 2 && arrMakananP2[indexP2] != 3 && arrMakananP2[indexP2] != 4)
                    || (makananP2 == 3 && arrMakananP2[indexP2] != 0 && arrMakananP2[indexP2] != 3 && arrMakananP2[indexP2] != 7))
                {
                    jumlahBenarP2++;
                    new System.Threading.Thread(() =>
                    {
                        var c = new System.Windows.Media.MediaPlayer();
                        c.Open(new System.Uri(@Application.StartupPath + "\\Music\\G5Benar.wav"));
                        c.Play();
                    }).Start();

                    //label8.Text = "";
                    pointP2 += 100;
                    int indexBantu2 = indexP2, iBaru2 = 0;
                    int[] arrBantu2 = new int[arrMakananP2.Length - 1];

                    picHiddenP2.Visible = true;
                    picHiddenP2.Image = Image.FromFile(Application.StartupPath + "\\G5CookingMakananAdat\\" + makananP2 + arrMakananP2[indexP2] + ".png");
                    tmrHidden2.Enabled = true;

                    for (int i = 0; i < arrMakananP2.Length; i++)
                    {
                        if (i != indexP2)
                        {
                            arrBantu2[iBaru2] = arrMakananP2[i];
                            iBaru2++;
                        }
                    }

                    arrMakananP2 = new int[arrBantu2.Length];
                    for (int i = 0; i < arrBantu2.Length; i++)
                    {
                        arrMakananP2[i] = arrBantu2[i];
                        //label8.Text += arrMakananP1[i].ToString();
                    }

                    if (indexP2 - 1 < 0)
                    {
                        indexP2 = arrMakananP2.Length - 1;
                    }
                    else
                    {
                        indexP2--;
                    }
                }
                else
                {
                    if (pointP2 - 50 >= 0)
                        pointP2 -= 50;
                    new System.Threading.Thread(() =>
                    {
                        var c = new System.Windows.Media.MediaPlayer();
                        c.Open(new System.Uri(@Application.StartupPath + "\\Music\\G5Salah.wav"));
                        c.Play();
                    }).Start();
                    tmrSalahP2.Enabled = true;
                }
                picBahanP2.Image = Image.FromFile(Application.StartupPath + "\\G5CookingMakananAdat\\" + makananP2 + arrMakananP2[indexP2] + ".png");
            }
        }

        int waktuHidden1 = 0, waktuHidden2 = 0;
        private void tmrHidden1_Tick(object sender, EventArgs e)
        {
            waktuHidden1++;
            picHiddenP1.Location = new Point(picHiddenP1.Location.X, picHiddenP1.Location.Y + 50);


                p1BS.Image = Image.FromFile(Application.StartupPath + "\\G5CookingMakananAdat\\o.png");
                p1BS.Visible = true;

            if (waktuHidden1 == 3)
            {
                p1BS.Visible = false;
                tmrHidden1.Enabled = false;
                picHiddenP1.Visible = false;
                picHiddenP1.Location = picBahanP1.Location;
                waktuHidden1 = 0;
            }
        }

        private void tmrHidden2_Tick(object sender, EventArgs e)
        {
            waktuHidden2++;
            picHiddenP2.Location = new Point(picHiddenP2.Location.X, picHiddenP2.Location.Y + 50);

                p2BS.Image = Image.FromFile(Application.StartupPath + "\\G5CookingMakananAdat\\o.png");
                p2BS.Visible = true;

            if (waktuHidden2 == 3)
            {
                p2BS.Visible = false;
                tmrHidden2.Enabled = false;
                picHiddenP2.Visible = false;
                picHiddenP2.Location = picBahanP2.Location;
                waktuHidden2 = 0;
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

        private void picMakananP1_FormClosed(object sender, FormClosedEventArgs e)
        {
            SoundMain.Stop();
        }

        int phase = 0;
        int checktimer = 0;
        private void timer2_Tick(object sender, EventArgs e)
        {

            phase++;
            switch (phase)
            {
                case 0:
                    label17.Text = "3";
                    break;
                case 1:
                    label17.Text = "2";
                    break;
                case 2:
                    label17.Text = "1";
                    checktimer = 1;
                    break;
                case 3:
                    label17.Left -= 100;
                    label17.Text = "Mulai!";
                    timer2.Interval = 350;
                    tmrG5.Enabled = true;
                    
                    makananP1 = rnd.Next(1, 4);
                    makananP2 = rnd.Next(1, 4);
                    picMakanP1.Image = Image.FromFile(Application.StartupPath + "\\G5CookingMakananAdat\\" + makananP1 + ".png");
            picBahanP1.Image = Image.FromFile(Application.StartupPath + "\\G5CookingMakananAdat\\" + makananP1 + arrMakananP1[indexP1] + ".png");
            picMakanP2.Image = Image.FromFile(Application.StartupPath + "\\G5CookingMakananAdat\\" + makananP2 + ".png");
            picBahanP2.Image = Image.FromFile(Application.StartupPath + "\\G5CookingMakananAdat\\" + makananP2 + arrMakananP2[indexP2] + ".png");
            
            for (int i = 0; i < 8; i++)
            {
                arrMakananP1[i] = rnd.Next(0, 8);
                for (int j = 0; j < i; j++)
                {
                    while (arrMakananP1[i] == arrMakananP1[j])
                    {
                        arrMakananP1[i] = rnd.Next(0, 8);
                        j = 0;
                    }
                }
            }

            for (int i = 0; i < 8; i++)
            {
                arrMakananP2[i] = rnd.Next(0, 8);
                for (int j = 0; j < i; j++)
                {
                    while (arrMakananP2[i] == arrMakananP2[j])
                    {
                        arrMakananP2[i] = rnd.Next(0, 8);
                        j = 0;
                    }
                }
            }

            for (int i = 0; i < 8; i++)
            {
                label6.Text += arrMakananP1[i] + " ";
            }
                    /*new System.Threading.Thread(() =>
                    {
                        var c = new System.Windows.Media.MediaPlayer();
                        c.Open(new System.Uri(@Application.StartupPath + "\\s3\\sounds\\start.wav"));
                        c.Play();
                    }).Start();*/
                    break;
                case 4:

                    label17.Dispose();
                    break;
            }
        }

        private void picExit_MouseHover(object sender, EventArgs e)
        {
            picExit.Image = Image.FromFile(Application.StartupPath + "\\Button\\quithover.png");
        }

        private void picExit_MouseLeave(object sender, EventArgs e)
        {
            picExit.Image = Image.FromFile(Application.StartupPath + "\\Button\\quit.png");
        }

        private void picMakananP1_KeyUp(object sender, KeyEventArgs e)
        {
            
            if ((e.KeyCode == Keys.A) && checktimer == 1)
            {
                p1Kiri.Image = Image.FromFile(Application.StartupPath + "\\G5CookingMakananAdat\\a.png");
            }

            if ((e.KeyCode == Keys.D) && checktimer == 1)
            {
                p1Kanan.Image = Image.FromFile(Application.StartupPath + "\\G5CookingMakananAdat\\d.png");
            }

            if ((e.KeyCode == Keys.J) && checktimer == 1)
            {
                p2Kiri.Image = Image.FromFile(Application.StartupPath + "\\G5CookingMakananAdat\\j.png");
            }

            if ((e.KeyCode == Keys.L) && checktimer == 1)
            {
                p2Kanan.Image = Image.FromFile(Application.StartupPath + "\\G5CookingMakananAdat\\l.png");
            }
            
        }

        private void picMakananP1_KeyDown(object sender, KeyEventArgs e)
        {
            /*
            if ((e.KeyChar == 'a' || e.KeyChar == 'A') && checktimer == 1)
            {
                if (indexP1 - 1 < 0)
                    indexP1 = arrMakananP1.Length - 1;
                else
                    indexP1 = indexP1 - 1;

                //p1Kiri.Image = Image.FromFile(Application.StartupPath + "\\G5CookingMakananAdat\\ab.png");
                picBahanP1.Image = Image.FromFile(Application.StartupPath + "\\G5CookingMakananAdat\\" + makananP1 + arrMakananP1[indexP1] + ".png");
            }

            if ((e.KeyChar == 'd' || e.KeyChar == 'D') && checktimer == 1)
            {
                if (indexP1 + 1 > (arrMakananP1.Length - 1))
                    indexP1 = 0;
                else
                    indexP1 = indexP1 + 1;

                //p1Kanan.Image = Image.FromFile(Application.StartupPath + "\\G5CookingMakananAdat\\db.png");
                picBahanP1.Image = Image.FromFile(Application.StartupPath + "\\G5CookingMakananAdat\\" + makananP1 + arrMakananP1[indexP1] + ".png");
            }

            if (e.KeyChar == 's' || e.KeyChar == 'S')
            {
                if ((makananP1 == 1 && arrMakananP1[indexP1] != 1 && arrMakananP1[indexP1] != 4 && arrMakananP1[indexP1] != 6)
                    || (makananP1 == 2 && arrMakananP1[indexP1] != 2 && arrMakananP1[indexP1] != 3 && arrMakananP1[indexP1] != 4)
                    || (makananP1 == 3 && arrMakananP1[indexP1] != 0 && arrMakananP1[indexP1] != 3 && arrMakananP1[indexP1] != 7))
                {
                    jumlahBenarP1++;
                    new System.Threading.Thread(() =>
                    {
                        var c = new System.Windows.Media.MediaPlayer();
                        c.Open(new System.Uri(@Application.StartupPath + "\\Music\\G5Benar.wav"));
                        c.Play();
                    }).Start();

                    label8.Text = "";
                    pointP1 += 100;
                    int indexBantu = indexP1, iBaru = 0;
                    int[] arrBantu = new int[arrMakananP1.Length - 1];

                    picHiddenP1.Visible = true;
                    picHiddenP1.Image = Image.FromFile(Application.StartupPath + "\\G5CookingMakananAdat\\" + makananP1 + arrMakananP1[indexP1] + ".png");
                    tmrHidden1.Enabled = true;

                    for (int i = 0; i < arrMakananP1.Length; i++)
                    {
                        if (i != indexP1)
                        {
                            arrBantu[iBaru] = arrMakananP1[i];
                            iBaru++;
                        }
                    }

                    arrMakananP1 = new int[arrBantu.Length];
                    for (int i = 0; i < arrBantu.Length; i++)
                    {
                        arrMakananP1[i] = arrBantu[i];
                        label8.Text += arrMakananP1[i].ToString();
                    }

                    if (indexP1 - 1 < 0)
                    {
                        indexP1 = arrMakananP1.Length - 1;
                    }
                    else
                    {
                        indexP1--;
                    }
                }
                else
                {
                    if (pointP1 - 50 >= 0)
                        pointP1 -= 50;
                    new System.Threading.Thread(() =>
                    {
                        var c = new System.Windows.Media.MediaPlayer();
                        c.Open(new System.Uri(@Application.StartupPath + "\\Music\\G5Salah.wav"));
                        c.Play();
                    }).Start();
                }
                picBahanP1.Image = Image.FromFile(Application.StartupPath + "\\G5CookingMakananAdat\\" + makananP1 + arrMakananP1[indexP1] + ".png");
            }

            // Player 2
            if ((e.KeyChar == 'j' || e.KeyChar == 'J') && checktimer == 1)
            {
                if (indexP2 - 1 < 0)
                    indexP2 = arrMakananP2.Length - 1;
                else
                    indexP2 = indexP2 - 1;

                //p2Kiri.Image = Image.FromFile(Application.StartupPath + "\\G5CookingMakananAdat\\jb.png");
                picBahanP2.Image = Image.FromFile(Application.StartupPath + "\\G5CookingMakananAdat\\" + makananP2 + arrMakananP2[indexP2] + ".png");
            }

            if ((e.KeyCode == Keys.L) && checktimer == 1)
            {
                //p2Kanan.Image = Image.FromFile(Application.StartupPath + "\\G5CookingMakananAdat\\lb.png");
                picBahanP2.Image = Image.FromFile(Application.StartupPath + "\\G5CookingMakananAdat\\" + makananP2 + arrMakananP2[indexP2] + ".png");
            }
            
            if (e.KeyChar == 'k' || e.KeyChar == 'K')
            {
                if ((makananP2 == 1 && arrMakananP2[indexP2] != 1 && arrMakananP2[indexP2] != 4 && arrMakananP2[indexP2] != 6)
                    || (makananP2 == 2 && arrMakananP2[indexP2] != 2 && arrMakananP2[indexP2] != 3 && arrMakananP2[indexP2] != 4)
                    || (makananP2 == 3 && arrMakananP2[indexP2] != 0 && arrMakananP2[indexP2] != 3 && arrMakananP2[indexP2] != 7))
                {
                    jumlahBenarP2++;
                    new System.Threading.Thread(() =>
                    {
                        var c = new System.Windows.Media.MediaPlayer();
                        c.Open(new System.Uri(@Application.StartupPath + "\\Music\\G5Benar.wav"));
                        c.Play();
                    }).Start();

                    //label8.Text = "";
                    pointP2 += 100;
                    int indexBantu2 = indexP2, iBaru2 = 0;
                    int[] arrBantu2 = new int[arrMakananP2.Length - 1];

                    picHiddenP2.Visible = true;
                    picHiddenP2.Image = Image.FromFile(Application.StartupPath + "\\G5CookingMakananAdat\\" + makananP2 + arrMakananP2[indexP2] + ".png");
                    tmrHidden2.Enabled = true;

                    for (int i = 0; i < arrMakananP2.Length; i++)
                    {
                        if (i != indexP2)
                        {
                            arrBantu2[iBaru2] = arrMakananP2[i];
                            iBaru2++;
                        }
                    }

                    arrMakananP2 = new int[arrBantu2.Length];
                    for (int i = 0; i < arrBantu2.Length; i++)
                    {
                        arrMakananP2[i] = arrBantu2[i];
                        //label8.Text += arrMakananP1[i].ToString();
                    }

                    if (indexP2 - 1 < 0)
                    {
                        indexP2 = arrMakananP2.Length - 1;
                    }
                    else
                    {
                        indexP2--;
                    }
                }
                else
                {
                    if (pointP2 - 50 >= 0)
                        pointP2 -= 50;
                    new System.Threading.Thread(() =>
                    {
                        var c = new System.Windows.Media.MediaPlayer();
                        c.Open(new System.Uri(@Application.StartupPath + "\\Music\\G5Salah.wav"));
                        c.Play();
                    }).Start();
                }
                picBahanP2.Image = Image.FromFile(Application.StartupPath + "\\G5CookingMakananAdat\\" + makananP2 + arrMakananP2[indexP2] + ".png");
            }
            */
        }

        int salah1 = 0, salah2 = 0;
        private void tmrSalahP1_Tick(object sender, EventArgs e)
        {
            salah1++;
            
            p1BS.Image = Image.FromFile(Application.StartupPath + "\\G5CookingMakananAdat\\x.png");
            p1BS.Visible = true;
            if (salah1 == 2)
            {
                p1BS.Visible = false;
                tmrSalahP1.Enabled = false;
                salah1=0;
            }

        }

        private void tmrSalahP2_Tick(object sender, EventArgs e)
        {
            salah2++;
           
            p2BS.Image = Image.FromFile(Application.StartupPath + "\\G5CookingMakananAdat\\x.png");
            p2BS.Visible = true;
            if (salah2 == 2)
            {
                tmrSalahP2.Enabled = false;
                p2BS.Visible = false;
                salah2 = 0;
            }
        }

    }
}
