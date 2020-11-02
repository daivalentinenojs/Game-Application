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
    public partial class Form_Kill_The_Hama : Form
    {
        public Form_Kill_The_Hama()
        {
            InitializeComponent();
        }

        internal Form_Kill_The_Hama(int suara)
        {
            InitializeComponent();
            sound = suara;
        }

        #region Deklarasi
        int hama = 0, musuh = 0, musuh2=0, hptanaman1 = 10, hptanaman2 = 10, hptanaman3 = 10, hptanaman4 = 10, hptanaman5 = 10;
        int hp1, hp2, hp3, hp4, hp5, kalah = 0, sound, gagal = 0;
        int[] tampung = new int[5];
        int[] tampungPupuk = new int[5];

        System.Media.SoundPlayer SoundChange = new System.Media.SoundPlayer(Application.StartupPath + "\\Music\\HomeEnter.wav");
        System.Media.SoundPlayer SoundWin = new System.Media.SoundPlayer(Application.StartupPath + "\\Music\\Ending.wav");
        System.Media.SoundPlayer SoundGame3 = new System.Media.SoundPlayer(Application.StartupPath + "\\Music\\Game3.wav");
        #endregion

        #region Method
        public int RollHama()
        {
            Random rnd = new Random();
            int hasil = rnd.Next(0, 5);
            return hasil;
        }

        public int RollPupuk()
        {
            Random rnd = new Random();
            int hasil = rnd.Next(0, 5);
            return hasil;
        }
        #endregion

        bool hold = false;
        private void Form_Kill_The_Hama_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();

            picShow.Visible = true;
            statusSiram = 0;
            statusPestisida = 0;
            statusPupuk = 0;
            picShow.Image = Image.FromFile(Application.StartupPath + "\\Game3\\penyiram.png");
            if (sound == 1)
            {
                SoundGame3.PlayLooping();
                picSound.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombolSoundOn.png");
            }
            else if (sound == 0)
            {
                SoundGame3.Stop();
                picSound.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombolSoundOff.png");
            }

            gagal = 0;
            this.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Game3\\3-6-INGAME.jpg");
            picNext.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombolMulaiBermain.png");
            picBack.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombol-07.png");
            picExit.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombol-04.png");
            picUlang.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombolUlangiGame3.png");
            pictureBox1.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombol-06.png");
            picUlang.Visible = false;
            lblComment.Visible = false;

            picPot1.Image = Image.FromFile(Application.StartupPath + "\\Game3\\3.png");
            picPot2.Image = Image.FromFile(Application.StartupPath + "\\Game3\\3.png");
            picPot3.Image = Image.FromFile(Application.StartupPath + "\\Game3\\3.png");
            picPot4.Image = Image.FromFile(Application.StartupPath + "\\Game3\\3.png");
            picPot5.Image = Image.FromFile(Application.StartupPath + "\\Game3\\3.png");
            picHama1.Image = Image.FromFile(Application.StartupPath + "\\Game3\\hama.png");
            picHama2.Image = Image.FromFile(Application.StartupPath + "\\Game3\\hama.png");
            picHama3.Image = Image.FromFile(Application.StartupPath + "\\Game3\\hama.png");
            picHama4.Image = Image.FromFile(Application.StartupPath + "\\Game3\\hama.png");
            picHama5.Image = Image.FromFile(Application.StartupPath + "\\Game3\\hama.png");

            picPupuk1.Image = Image.FromFile(Application.StartupPath + "\\Game3\\pupuk.png");
            picPupuk2.Image = Image.FromFile(Application.StartupPath + "\\Game3\\pupuk.png");
            picPupuk3.Image = Image.FromFile(Application.StartupPath + "\\Game3\\pupuk.png");
            picPupuk4.Image = Image.FromFile(Application.StartupPath + "\\Game3\\pupuk.png");
            picPupuk5.Image = Image.FromFile(Application.StartupPath + "\\Game3\\pupuk.png");

            picTanah1.Image = Image.FromFile(Application.StartupPath + "\\Game3\\sekopkecil.png");
            picTanah2.Image = Image.FromFile(Application.StartupPath + "\\Game3\\sekopkecil.png");
            picTanah3.Image = Image.FromFile(Application.StartupPath + "\\Game3\\sekopkecil.png");
            picTanah4.Image = Image.FromFile(Application.StartupPath + "\\Game3\\sekopkecil.png");
            picTanah5.Image = Image.FromFile(Application.StartupPath + "\\Game3\\sekopkecil.png");

            picAir1.Image = Image.FromFile(Application.StartupPath + "\\Game3\\penyiram.png");
            picAir2.Image = Image.FromFile(Application.StartupPath + "\\Game3\\penyiram.png");
            picAir3.Image = Image.FromFile(Application.StartupPath + "\\Game3\\penyiram.png");
            picAir4.Image = Image.FromFile(Application.StartupPath + "\\Game3\\penyiram.png");
            picAir5.Image = Image.FromFile(Application.StartupPath + "\\Game3\\penyiram.png");

            picNext.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombolMulaiBermain.png");
            progressBar1.Maximum = 10;
            progressBar2.Maximum = 10;
            progressBar3.Maximum = 10;
            progressBar4.Maximum = 10;
            progressBar5.Maximum = 10;
            progressBar1.Value = 10;
            progressBar2.Value = 10;
            progressBar3.Value = 10;
            progressBar4.Value = 10;
            progressBar5.Value = 10;

            for (int i = 0; i<5; i++)
            {
                tampung[i] = -1;
            }

            for (int i = 0; i < 5; i++)
            {
                tampungPupuk[i] = -1;
            }
        }

        int hama2 = 0, down=60, waktuulang = 0;
        int siram1=0, siram2=0, siram3=0, siram4=0, siram5=0;

        #region Timer Tick Win Lose
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (hptanaman1 == 0)
            {
                picSiram1.Visible = false;
                picTanah1.Visible = false;
                picPupuk1.Visible = false;
                picAir1.Visible = false;
                tampungPupuk[0] = 0;
                tampung[0] = 0;
                picHama1.Visible = false;
                progressBar1.Visible = false;
            }

            if (hptanaman2 == 0)
            {
                picSiram2.Visible = false;
                picTanah2.Visible = false;
                picPupuk2.Visible = false;
                picAir2.Visible = false;
                tampungPupuk[1] = 0;
                tampung[1] = 0;
                picHama2.Visible = false;
                progressBar2.Visible = false;
            }

            if (hptanaman3 == 0)
            {
                picSiram3.Visible = false;
                picTanah3.Visible = false;
                picPupuk3.Visible = false;
                picAir3.Visible = false;
                tampungPupuk[2] = 0;
                tampung[2] = 0;
                picHama3.Visible = false;
                progressBar3.Visible = false;
            }

            if (hptanaman4 == 0)
            {
                picSiram4.Visible = false;
                picTanah4.Visible = false;
                picPupuk4.Visible = false;
                picAir4.Visible = false;
                tampungPupuk[3] = 0;
                tampung[3] = 0;
                picHama4.Visible = false;
                progressBar4.Visible = false;
            }

            if (hptanaman5 == 0)
            {
                picSiram5.Visible = false;
                picTanah5.Visible = false;
                picPupuk5.Visible = false;
                picAir5.Visible = false;
                tampungPupuk[4] = 0;
                tampung[4] = 0;
                picHama5.Visible = false;
                progressBar5.Visible = false;
            }

            if (hptanaman1 > 6)
            {
                picPot1.Image = Image.FromFile(Application.StartupPath + "\\Game3\\3.png");
            }
            else if (hptanaman1 <= 6 && hptanaman1 >3)
            {
                picPot1.Image = Image.FromFile(Application.StartupPath + "\\Game3\\2.png");
            }
            else if (hptanaman1 <= 3 && hptanaman1 > 0)
            {
                picPot1.Image = Image.FromFile(Application.StartupPath + "\\Game3\\1.png");
            }
            else if (hptanaman1 == 0)
            {
                picPot1.Image = Image.FromFile(Application.StartupPath + "\\Game3\\0.png");
            }

            if (hptanaman2 > 6)
            {
                picPot2.Image = Image.FromFile(Application.StartupPath + "\\Game3\\3.png");
            }
            else if (hptanaman2 <= 6 && hptanaman2 > 3)
            {
                picPot2.Image = Image.FromFile(Application.StartupPath + "\\Game3\\2.png");
            }
            else if (hptanaman2 <= 3 && hptanaman2 > 0)
            {
                picPot2.Image = Image.FromFile(Application.StartupPath + "\\Game3\\1.png");
            }
            else if (hptanaman2 == 0)
            {
                picPot2.Image = Image.FromFile(Application.StartupPath + "\\Game3\\0.png");
            }

            if (hptanaman3 > 6)
            {
                picPot3.Image = Image.FromFile(Application.StartupPath + "\\Game3\\3.png");
            }
            else if (hptanaman3 <= 6 && hptanaman3 > 3)
            {
                picPot3.Image = Image.FromFile(Application.StartupPath + "\\Game3\\2.png");
            }
            else if (hptanaman3 <= 3 && hptanaman3 > 0)
            {
                picPot3.Image = Image.FromFile(Application.StartupPath + "\\Game3\\1.png");
            }
            else if (hptanaman3 == 0)
            {
                picPot3.Image = Image.FromFile(Application.StartupPath + "\\Game3\\0.png");
            }

            if (hptanaman4 > 6)
            {
                picPot4.Image = Image.FromFile(Application.StartupPath + "\\Game3\\3.png");
            }
            else if (hptanaman4 <= 6 && hptanaman4 > 3)
            {
                picPot4.Image = Image.FromFile(Application.StartupPath + "\\Game3\\2.png");
            }
            else if (hptanaman4 <= 3 && hptanaman4 > 0)
            {
                picPot4.Image = Image.FromFile(Application.StartupPath + "\\Game3\\1.png");
            }
            else if (hptanaman4 == 0)
            {
                picPot4.Image = Image.FromFile(Application.StartupPath + "\\Game3\\0.png");
            }

            if (hptanaman5 > 6)
            {
                picPot5.Image = Image.FromFile(Application.StartupPath + "\\Game3\\3.png");
            }
            else if (hptanaman5 <= 6 && hptanaman5 > 3)
            {
                picPot5.Image = Image.FromFile(Application.StartupPath + "\\Game3\\2.png");
            }
            else if (hptanaman5 <= 3 && hptanaman5 > 0)
            {
                picPot5.Image = Image.FromFile(Application.StartupPath + "\\Game3\\1.png");
            }
            else if (hptanaman5 == 0)
            {
                picPot5.Image = Image.FromFile(Application.StartupPath + "\\Game3\\0.png");
            }

            down--;
            // siram air
            if (hptanaman1 < 5 && hptanaman1 > 0)
            {
                siram1 = 1;
                picAir1.Visible = true;
            }
            if (hptanaman2 < 5 && hptanaman2 > 0)
            {
                siram2 = 1;
                picAir2.Visible = true;
            }
            if (hptanaman3 < 5 && hptanaman3 > 0)
            {
                siram3 = 1;
                picAir3.Visible = true;
            }
            if (hptanaman4 < 5 && hptanaman4 > 0)
            {
                siram4 = 1;
                picAir4.Visible = true;
            }
            if (hptanaman5 < 5 && hptanaman5 > 0)
            {
                siram5 = 1;
                picAir5.Visible = true;
            }

            if (statustotal == 1)
            {
                statusSiram = 1;
                statusPestisida = 0;
                statusPupuk = 0;
            }
            else if (statustotal == 2)
            {
                statusSiram = 0;
                statusPestisida = 0;
                statusPupuk = 1;
            }
            else if (statustotal == 3)
            {
                statusSiram = 0;
                statusPestisida = 1;
                statusPupuk = 0;
            }

            hama++;
            hama2++;
            kalah = 0;
            if (hama >= 1)
            {
                label1.Text = "01";
                if (waktuulang==1)
                {
                    label1.Text = "00";
                }
                if (down >= 10)
                {
                    label2.Text = down.ToString();
                }
                else
                {
                    label2.Text = "0" + down.ToString();
                }
                if (down == 0 && waktuulang == 0)
                {
                    down = 60;
                    waktuulang = 1;
                }
            }

            tbtime.Text = hama.ToString();
            tbhp1.Text = hptanaman1.ToString();
            tbhp2.Text = hptanaman2.ToString();
            tbhp3.Text = hptanaman3.ToString();
            tbhp4.Text = hptanaman4.ToString();
            tbhp5.Text = hptanaman5.ToString();

            if (hama % 5 == 0)
            {
                musuh = RollHama();
                while (tampung[musuh] != -1)
                {
                    musuh = RollHama();
                }
                tampung[musuh] = 1;


                if (tampung[0] == 1)
                {
                    picHama1.Visible = true;
                    hp1 = 5;
                }
                else if (tampung[1] == 1)
                {
                    picHama2.Visible = true;
                    hp2 = 5;
                }
                else if (tampung[2] == 1)
                {
                    picHama3.Visible = true;
                    hp3 = 5;
                }
                else if (tampung[3] == 1)
                {
                    picHama4.Visible = true;
                    hp4 = 5;
                }
                else if (tampung[4] == 1)
                {
                    picHama5.Visible = true;
                    hp5 = 5;
                }
            }

            if (hama2 % 8 == 0)
            {
                musuh2 = RollPupuk();
                while (tampungPupuk[musuh2] != -1)
                {
                    musuh2 = RollPupuk();
                }
                tampungPupuk[musuh2] = 1;


                if (tampungPupuk[0] == 1)
                {
                    tanah1 = 1;
                    picPupuk1.Visible = true;
                }
                else if (tampungPupuk[1] == 1)
                {
                    tanah2 = 1;
                    picPupuk2.Visible = true;
                }
                else if (tampungPupuk[2] == 1)
                {
                    tanah3 = 1;
                    picPupuk3.Visible = true;
                }
                else if (tampungPupuk[3] == 1)
                {
                    tanah4 = 1;
                    picPupuk4.Visible = true;
                }
                else if (tampungPupuk[4] == 1)
                {
                    tanah5 = 1;
                    picPupuk5.Visible = true;
                }
            }

            if (picHama1.Visible == true || tanah1 == 1)
            {
                if (hptanaman1 >= 1)
                {
                    progressBar1.Value--;
                    hptanaman1--;
                }
                if (hptanaman1 == 6)
                {
                    picPot1.Image = Image.FromFile(Application.StartupPath + "\\Game3\\2.png");
                }
                else if (hptanaman1 == 3)
                {
                    picPot1.Image = Image.FromFile(Application.StartupPath + "\\Game3\\1.png");
                }
                else if (hptanaman1 == 0)
                {
                    picPot1.Image = Image.FromFile(Application.StartupPath + "\\Game3\\0.png");
                    picHama1.Visible = false;
                    progressBar1.Visible = false;
                    tampung[0] = 0;
                }
            }
            if (picHama2.Visible == true || tanah2 == 1)
            {
                if (hptanaman2 >= 1)
                {
                    progressBar2.Value--;
                    hptanaman2--;
                }
                if (hptanaman2 == 6)
                {
                    picPot2.Image = Image.FromFile(Application.StartupPath + "\\Game3\\2.png");
                }
                else if (hptanaman2 == 3)
                {
                    picPot2.Image = Image.FromFile(Application.StartupPath + "\\Game3\\1.png");
                }
                else if (hptanaman2 == 0)
                {
                    picPot2.Image = Image.FromFile(Application.StartupPath + "\\Game3\\0.png");
                    picHama2.Visible = false;
                    progressBar2.Visible = false;
                    tampung[1] = 0;
                }
            }
            if (picHama3.Visible == true || tanah3 == 1)
            {
                if (hptanaman3 >= 1)
                {
                    progressBar3.Value--;
                    hptanaman3--;
                }
                if (hptanaman3 == 6)
                {
                    picPot3.Image = Image.FromFile(Application.StartupPath + "\\Game3\\2.png");
                }
                else if (hptanaman3 == 3)
                {
                    picPot3.Image = Image.FromFile(Application.StartupPath + "\\Game3\\1.png");
                }
                else if (hptanaman3 == 0)
                {
                    picPot3.Image = Image.FromFile(Application.StartupPath + "\\Game3\\0.png");
                    picHama3.Visible = false;
                    progressBar3.Visible = false;
                    tampung[2] = 0;
                }
            }
            if (picHama4.Visible == true || tanah4 == 1)
            {
                if (hptanaman4 >= 1)
                {
                    progressBar4.Value--;
                    hptanaman4--;
                }
                if (hptanaman4 == 6)
                {
                    picPot4.Image = Image.FromFile(Application.StartupPath + "\\Game3\\2.png");
                }
                else if (hptanaman4 == 3)
                {
                    picPot4.Image = Image.FromFile(Application.StartupPath + "\\Game3\\1.png");
                }
                else if (hptanaman4 == 0)
                {
                    picPot4.Image = Image.FromFile(Application.StartupPath + "\\Game3\\0.png");
                    picHama4.Visible = false;
                    progressBar4.Visible = false;
                    tampung[3] = 0;
                }
            }
            if (picHama5.Visible == true || tanah5 == 1)
            {
                if (hptanaman5 >= 1)
                {
                    progressBar5.Value--;
                    hptanaman5--;
                }
                if (hptanaman5 == 6)
                {
                    picPot5.Image = Image.FromFile(Application.StartupPath + "\\Game3\\2.png");
                }
                else if (hptanaman5 == 3)
                {
                    picPot5.Image = Image.FromFile(Application.StartupPath + "\\Game3\\1.png");
                }
                else if (hptanaman5 == 0)
                {
                    picPot5.Image = Image.FromFile(Application.StartupPath + "\\Game3\\0.png");
                    picHama5.Visible = false;
                    progressBar5.Visible = false;
                    tampung[4] = 0;
                }
            }

            if (hama < 120)
            {
                for (int i = 0; i < 5; i++)
                {
                    if (tampung[i] == 0)
                        kalah++;
                }
                if (kalah >= 3)
                {
                    timer1.Enabled = false;
                    picUlang.Visible = true;

                    picHama1.Visible = false;
                    picHama2.Visible = false;
                    picHama3.Visible = false;
                    picHama4.Visible = false;
                    picHama5.Visible = false;

                    progressBar1.Visible = false;
                    progressBar2.Visible = false;
                    progressBar3.Visible = false;
                    progressBar4.Visible = false;
                    progressBar5.Visible = false;

                    picSprayer1.Visible = false;
                    picSprayer2.Visible = false;
                    picSprayer3.Visible = false;
                    picSprayer4.Visible = false;
                    picSprayer5.Visible = false;

                    picPupuk1.Visible = false;
                    picPupuk2.Visible = false;
                    picPupuk3.Visible = false;
                    picPupuk4.Visible = false;
                    picPupuk5.Visible = false;

                    picAir1.Visible = false;
                    picAir2.Visible = false;
                    picAir3.Visible = false;
                    picAir4.Visible = false;
                    picAir5.Visible = false;

                    picSiram1.Visible = false;
                    picSiram2.Visible = false;
                    picSiram3.Visible = false;
                    picSiram4.Visible = false;
                    picSiram5.Visible = false;

                    picShow.Visible = false;
                    gagal++;
                }
            }
            else if (hama == 120)
            {

                for (int i = 0; i < 5; i++)
                {
                    if (tampung[i] == 0)
                        kalah++;
                }
                if (kalah >= 3)
                {
                    gagal++;
                    picUlang.Visible = true;
                }
                else if (kalah < 3 && sound == 1)
                {
                    gagal = 0;
                    SoundWin.Play();
                    sound = 1;
                    lblComment.Visible = true;
                    pictureBox1.Visible = true;
                    picShow.Visible = false;
                    picAir1.Visible = false;
                    picTanah1.Visible = false;
                    picPupuk1.Visible = false;
                    picSiram1.Visible = false;

                    picAir2.Visible = false;
                    picTanah2.Visible = false;
                    picPupuk2.Visible = false;
                    picSiram2.Visible = false;

                    picAir3.Visible = false;
                    picTanah3.Visible = false;
                    picPupuk3.Visible = false;
                    picSiram3.Visible = false;

                    picAir4.Visible = false;
                    picTanah4.Visible = false;
                    picPupuk4.Visible = false;
                    picSiram4.Visible = false;

                    picAir5.Visible = false;
                    picTanah5.Visible = false;
                    picPupuk5.Visible = false;
                    picSiram5.Visible = false;
                }
                else if (kalah < 3 && sound == 0)
                {
                    gagal = 0;
                    lblComment.Visible = true;
                    pictureBox1.Visible = true;

                    picAir1.Visible = false;
                    picTanah1.Visible = false;
                    picPupuk1.Visible = false;
                    picSiram1.Visible = false;

                    picAir2.Visible = false;
                    picTanah2.Visible = false;
                    picPupuk2.Visible = false;
                    picSiram2.Visible = false;

                    picAir3.Visible = false;
                    picTanah3.Visible = false;
                    picPupuk3.Visible = false;
                    picSiram3.Visible = false;

                    picAir4.Visible = false;
                    picTanah4.Visible = false;
                    picPupuk4.Visible = false;
                    picSiram4.Visible = false;

                    picAir5.Visible = false;
                    picTanah5.Visible = false;
                    picPupuk5.Visible = false;
                    picSiram5.Visible = false;
                }
                timer1.Enabled = false;
                picHama1.Visible = false;
                picHama2.Visible = false;
                picHama3.Visible = false;
                picHama4.Visible = false;
                picHama5.Visible = false;
                picSprayer1.Visible = false;
                picSprayer2.Visible = false;
                picSprayer3.Visible = false;
                picSprayer4.Visible = false;
                picSprayer5.Visible = false;
                progressBar1.Visible = false;
                progressBar2.Visible = false;
                progressBar3.Visible = false;
                progressBar4.Visible = false;
                progressBar5.Visible = false;

                picPupuk1.Visible = false;
                picPupuk2.Visible = false;
                picPupuk3.Visible = false;
                picPupuk4.Visible = false;
                picPupuk5.Visible = false;

                picAir1.Visible = false;
                picAir2.Visible = false;
                picAir3.Visible = false;
                picAir4.Visible = false;
                picAir5.Visible = false;
            }

        }
        #endregion

        #region Hama Hidup Mati
        private void picHama3_Click(object sender, EventArgs e)
        {
            if (statusPestisida == 1)
            { hp3--; }

            if (picHama3.Visible == true && statusPestisida == 1)
            {
                picSprayer3.Visible = true;
                picSprayer3.Image = Image.FromFile(Application.StartupPath + "\\Game3\\sprayer.png");
            }
            else
            {
                picSprayer3.Visible = false;
            }

            if (hp3 == 0)
            {
                picHama3.Visible = false;
                statusPestisida = 0;
                if (hptanaman3 != 0)
                    tampung[2] = -1;
            }
        }

        private void picHama1_Click(object sender, EventArgs e)
        {
            if (statusPestisida == 1)
            { hp1--; }

            if (picHama1.Visible == true && statusPestisida == 1)
            {
                picSprayer1.Visible = true;
                picSprayer1.Image = Image.FromFile(Application.StartupPath + "\\Game3\\sprayer.png");
            }
            else
            {
                picSprayer1.Visible = false;
            }

            if (hp1 == 0)
            {
                picHama1.Visible = false;
                statusPestisida = 0;
                if (hptanaman1 != 0)
                    tampung[0] = -1;
            }
        }

        private void picHama2_Click(object sender, EventArgs e)
        {
            if (statusPestisida == 1)
            { hp2--; }

            if (picHama2.Visible == true && statusPestisida == 1)
            {
                picSprayer2.Visible = true;
                picSprayer2.Image = Image.FromFile(Application.StartupPath + "\\Game3\\sprayer.png");
            }
            else
            {
                picSprayer2.Visible = false;
            }

            if (hp2 == 0)
            {
                picHama2.Visible = false;
                statusPestisida = 0;
                if (hptanaman2 != 0)
                    tampung[1] = -1;
            }
        }

        private void picHama5_Click(object sender, EventArgs e)
        {
            if (statusPestisida == 1)
            { hp5--; }

            if (picHama5.Visible == true && statusPestisida == 1)
            {
                picSprayer5.Visible = true;
                picSprayer5.Image = Image.FromFile(Application.StartupPath + "\\Game3\\sprayer.png");
            }
            else
            {
                picSprayer5.Visible = false;
            }

            if (hp5 == 0)
            {
                picHama5.Visible = false;
                statusPestisida = 0;
                if (hptanaman5 != 0)
                    tampung[4] = -1;
            }
        }

        private void picHama4_Click(object sender, EventArgs e)
        {
            if (statusPestisida == 1)
            { hp4--; }

            if (picHama4.Visible == true && statusPestisida == 1)
            {
                picSprayer4.Visible = true;
                picSprayer4.Image = Image.FromFile(Application.StartupPath + "\\Game3\\sprayer.png");
            }
            else
            {
                picSprayer4.Visible = false;
            }

            if (hp4 == 0)
            {
                picHama4.Visible = false;
                statusPestisida = 0;
                if (hptanaman4 != 0)
                    tampung[3] = -1;
            }
        }
        #endregion

        #region Button Click Hover Leave Umum
        private void picExit_Click(object sender, EventArgs e)
        {
            SoundGame3.Stop();
            picExit.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombolDown-04.png");
            Application.Exit();
        }

        private void picExit_MouseHover(object sender, EventArgs e)
        {
            if (sound == 1 && lblComment.Visible == true)
            {
                SoundChange.Play();
            }
            picExit.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombolHover-04.png");
        }

        private void picExit_MouseLeave(object sender, EventArgs e)
        {
            picExit.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombol-04.png");
        }

        private void picBack_MouseHover(object sender, EventArgs e)
        {
            picBack.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombolHover-07.png");
            if (sound == 1 && lblComment.Visible == true)
            {
                SoundChange.Play();
            }    
        }

        private void picBack_MouseLeave(object sender, EventArgs e)
        {
            picBack.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombol-07.png");
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            if (sound == 1 && lblComment.Visible == true)
            {
                SoundChange.Play();
            }
            pictureBox1.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombolHover-06.png");
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombol-06.png");
        }

        private void picNext_MouseHover(object sender, EventArgs e)
        {
            picNext.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombolMulaiBermainHover.png");
        }

        private void picNext_MouseLeave(object sender, EventArgs e)
        {
            picNext.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombolMulaiBermain.png");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            SoundGame3.Stop();
            pictureBox1.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombolDown-06.png");

            Story_Line_7 form = new Story_Line_7(1, sound);
            this.Hide();
            form.ShowDialog();
            this.Close();
        }

        private void picBack_Click(object sender, EventArgs e)
        {
            SoundGame3.Stop();
            Story_Line_6 form = new Story_Line_6(7, sound);
            this.Hide();
            form.ShowDialog();
            this.Close();
        }
        #endregion

        #region Basmi Ulang
        private void picNext_Click(object sender, EventArgs e)
        {
            if (gagal > 0 && sound ==1)
            {
                SoundGame3.PlayLooping();
            }
            else if (gagal > 0 && sound ==0)
            {

            }
            picNext.Visible = false;
            picBack.Visible = false;
            timer1.Enabled = true;
        }

        private void picUlang_MouseHover(object sender, EventArgs e)
        {
            picUlang.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombolUlangiGame3Hover.png");
            if (sound == 1 && lblComment.Visible == true)
            {
                SoundChange.Play();
            }
        }

        private void picUlang_MouseLeave(object sender, EventArgs e)
        {
            picUlang.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombolUlangiGame3.png");
        }

        private void picUlang_Click(object sender, EventArgs e)
        {
            siram1 = 0;
            siram2 = 0;
            siram3 = 0;
            siram4 = 0;
            siram5 = 0;

            tanah1 = 0;
            tanah2 = 0;
            tanah3 = 0;
            tanah4 = 0;
            tanah5 = 0;

            musuh2 = 0;
            down = 60;
            waktuulang = 0;
            hama2 = 0;

            picAir1.Visible = false;
            picSiram1.Visible = false;
            picTanah1.Visible = false;
            picPupuk1.Visible = false;

            picAir2.Visible = false;
            picSiram2.Visible = false;
            picTanah2.Visible = false;
            picPupuk2.Visible = false;

            picAir3.Visible = false;
            picSiram3.Visible = false;
            picTanah3.Visible = false;
            picPupuk3.Visible = false;

            picAir4.Visible = false;
            picSiram4.Visible = false;
            picTanah4.Visible = false;
            picPupuk4.Visible = false;

            picAir5.Visible = false;
            picSiram5.Visible = false;
            picTanah5.Visible = false;
            picPupuk5.Visible = false;

            picUlang.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombolUlangiGame3Down.png");
            picUlang.Visible = false;

            picPot1.Image = Image.FromFile(Application.StartupPath + "\\Game3\\3.png");
            picPot2.Image = Image.FromFile(Application.StartupPath + "\\Game3\\3.png");
            picPot3.Image = Image.FromFile(Application.StartupPath + "\\Game3\\3.png");
            picPot4.Image = Image.FromFile(Application.StartupPath + "\\Game3\\3.png");
            picPot5.Image = Image.FromFile(Application.StartupPath + "\\Game3\\3.png");

            picHama1.Visible = false;
            picHama2.Visible = false;
            picHama3.Visible = false;
            picHama4.Visible = false;
            picHama5.Visible = false;
            picNext.Visible = true;

            lblComment.Visible = false;
            progressBar1.Maximum = 10;
            progressBar2.Maximum = 10;
            progressBar3.Maximum = 10;
            progressBar4.Maximum = 10;
            progressBar5.Maximum = 10;
            progressBar1.Value = 10;
            progressBar2.Value = 10;
            progressBar3.Value = 10;
            progressBar4.Value = 10;
            progressBar5.Value = 10;

            progressBar1.Visible = true;
            progressBar2.Visible = true;
            progressBar3.Visible = true;
            progressBar4.Visible = true;
            progressBar5.Visible = true;

            for (int i = 0; i < 5; i++)
            {
                tampung[i] = -1;
                tampungPupuk[i] = -1;
            }

            hama = 0;
            musuh = 0;
            hptanaman1 = 10; hptanaman2 = 10; hptanaman3 = 10; hptanaman4 = 10; hptanaman5 = 10;
            label1.Text = "02";
            label2.Text = "00";
            kalah = 0;
            timer1.Enabled = false;
            pictureBox1.Visible = false;

        }
        #endregion
        
        #region Muncul Sprayer
        private void picHama1_MouseHover(object sender, EventArgs e)
        {
            if (picHama1.Visible == true && statusPestisida==1)
            {
                picSprayer1.Visible = true;
                picSprayer1.Image = Image.FromFile(Application.StartupPath + "\\Game3\\sprayer.png");
            }
            else
            {
                picSprayer1.Visible = false;
            }
        }

        private void picHama2_MouseHover(object sender, EventArgs e)
        {
            if (picHama2.Visible == true && statusPestisida == 1)
            {
                picSprayer2.Visible = true;
                picSprayer2.Image = Image.FromFile(Application.StartupPath + "\\Game3\\sprayer.png");
            }
            else
            {
                picSprayer2.Visible = false;
            }
        }

        private void picHama3_MouseHover(object sender, EventArgs e)
        {
            if (picHama3.Visible == true && statusPestisida == 1)
            {
                picSprayer3.Visible = true;
                picSprayer3.Image = Image.FromFile(Application.StartupPath + "\\Game3\\sprayer.png");
            }
            else
            {
                picSprayer3.Visible = false;
            }
        }

        private void picHama4_MouseHover(object sender, EventArgs e)
        {
            if (picHama4.Visible == true && statusPestisida == 1)
            {
                picSprayer4.Visible = true;
                picSprayer4.Image = Image.FromFile(Application.StartupPath + "\\Game3\\sprayer.png");
            }
            else
            {
                picSprayer4.Visible = false;
            }
        }

        private void picHama5_MouseHover(object sender, EventArgs e)
        {
            if (picHama5.Visible == true && statusPestisida == 1)
            {
                picSprayer5.Visible = true;
                picSprayer5.Image = Image.FromFile(Application.StartupPath + "\\Game3\\sprayer.png");
            }
            else
            {
                picSprayer5.Visible = false;
            }
        }

        private void picHama1_MouseLeave(object sender, EventArgs e)
        {
            picSprayer1.Visible = false;
        }

        private void picHama2_MouseLeave(object sender, EventArgs e)
        {
            picSprayer2.Visible = false;
        }

        private void picHama3_MouseLeave(object sender, EventArgs e)
        {
            picSprayer3.Visible = false;
        }

        private void picHama4_MouseLeave(object sender, EventArgs e)
        {
            picSprayer4.Visible = false;
        }

        private void picHama5_MouseLeave(object sender, EventArgs e)
        {
            picSprayer5.Visible = false;
        }
        #endregion
        
        private void picSound_Click(object sender, EventArgs e)
        {
            if (sound == 1)
            {
                sound = 0;
                picSound.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombolSoundOff.png");
                SoundGame3.Stop();
            }
            else if (sound == 0)
            {
                sound = 1;
                picSound.Image = Image.FromFile(Application.StartupPath + "\\Button\\tombolSoundOn.png");
                SoundGame3.PlayLooping();
            }
        }

        #region Tantangan
        int statusSiram = 0, statusPestisida = 0, statusPupuk = 0, statustotal=0;

        private void Form_Kill_The_Hama_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'q' || e.KeyChar == 'Q')
            {
                picShow.Visible = true;
                statusSiram = 1;
                statusPestisida = 0;
                statusPupuk = 0;
                statustotal = 1;
                picShow.Image = Image.FromFile(Application.StartupPath + "\\Game3\\penyiram.png");
            }
            if (e.KeyChar == 'w' || e.KeyChar == 'W')
            {
                statusSiram = 0;
                statusPestisida = 0;
                statusPupuk = 1;
                statustotal = 2;
                picShow.Image = Image.FromFile(Application.StartupPath + "\\Game3\\sekopKecil.png");
            }
            if (e.KeyChar == 'e' || e.KeyChar == 'E')
            {
                statusSiram = 0;
                statusPestisida = 1;
                statusPupuk = 0;
                statustotal = 3;
                picShow.Image = Image.FromFile(Application.StartupPath + "\\Game3\\sprayer2.png");
            }
        }
        #endregion

        int tanah1 = 0, tanah2 = 0, tanah3 = 0, tanah4 = 0, tanah5 = 0;
        private void picPot1_Click(object sender, EventArgs e)
        {
            if (tanah1==1 && statusPupuk ==1)
            { tanah1 = 0;
            tampungPupuk[0] = -1;
            picTanah1.Visible = false;
            picPupuk1.Visible = false;
            }

            if (siram1 == 1 && statusSiram == 1 && hptanaman1>0)
            {
                siram1 = 0;
                hptanaman1 += 3;
                picSiram1.Visible = false;
                picAir1.Visible = false;
                progressBar1.Value += 3;
            }
        }

        private void picPot2_Click(object sender, EventArgs e)
        {
            if (tanah2 == 1 && statusPupuk == 1)
            {
                tanah2 = 0;
                picTanah2.Visible = false;
            tampungPupuk[1] = -1;
            picPupuk2.Visible = false;
            }

            if (siram2 == 1 && statusSiram == 1 && hptanaman2 > 0)
            {
                siram2 = 0;
                hptanaman2 += 3;
                picSiram2.Visible = false;
                picAir2.Visible = false;
                progressBar2.Value += 3;
            }
        }

        private void picPot3_Click(object sender, EventArgs e)
        {
            if (tanah3 == 1 && statusPupuk == 1)
            { tanah3 = 0;
            picTanah3.Visible = false;
            picPupuk3.Visible = false;
            tampungPupuk[2] = -1;
            }

            if (siram3 == 1 && statusSiram == 1 && hptanaman3 > 0)
            {
                siram3 = 0;
                hptanaman3 += 3;
                picSiram3.Visible = false;
                picAir3.Visible = false;
                progressBar3.Value += 3;
            }
        }

        private void picPot4_Click(object sender, EventArgs e)
        {
            if (tanah4 == 1 && statusPupuk == 1)
            { tanah4 = 0;
            picTanah4.Visible = false;
            picPupuk4.Visible = false;
            tampungPupuk[3] = -1;
            }

            if (siram4 == 1 && statusSiram == 1 && hptanaman4 > 0)
            {
                siram4 = 0;
                hptanaman4 += 3;
                picSiram4.Visible = false;
                picAir4.Visible = false;
                progressBar4.Value += 3;
            }
        }

        private void picPot5_Click(object sender, EventArgs e)
        {
            if (tanah5 == 1 && statusPupuk == 1)
            { tanah5 = 0;
            picTanah5.Visible = false;
            picPupuk5.Visible = false;
            tampungPupuk[4] = -1;
            }

            if (siram5 == 1 && statusSiram == 1 && hptanaman5 > 0)
            {
                siram5 = 0;
                hptanaman5 += 3;
                picSiram5.Visible = false;
                picAir5.Visible = false;
                progressBar5.Value += 3;
            }
        }

        private void picPot1_MouseHover(object sender, EventArgs e)
        {
          //  if (tanah1==1 && picPupuk1.Visible == true)
          //  {
         //       picTanah1.Visible = true;
         //   }
        }

        private void picPot2_MouseHover(object sender, EventArgs e)
        {
       //     if (tanah2 == 1 && picPupuk2.Visible == true)
         //   {
         //       picTanah2.Visible = true;
         //   }
        }

        private void picPot3_MouseHover(object sender, EventArgs e)
        {
        //    if (tanah3 == 1 && picPupuk3.Visible == true)
          //  {
          //      picTanah3.Visible = true;
          //  }
        }

        private void picPot4_MouseHover(object sender, EventArgs e)
        {
           // if (tanah4 == 1 && picPupuk4.Visible == true)
           // {
           //     picTanah4.Visible = true;
           // }
        }

        private void picPot5_MouseHover(object sender, EventArgs e)
        {
          //  if (tanah5 == 1 && picPupuk5.Visible == true)
          //  {
          //      picTanah5.Visible = true;
          //  }
        }

        private void picPot1_MouseLeave(object sender, EventArgs e)
        {
          //  picTanah1.Visible = true;
        }

        private void picPot2_MouseLeave(object sender, EventArgs e)
        {
           // picTanah2.Visible = true;
        }

        private void picPot3_MouseLeave(object sender, EventArgs e)
        {
           // picTanah3.Visible = true;
        }

        private void picPot4_MouseLeave(object sender, EventArgs e)
        {
           // picTanah4.Visible = true;
        }

        private void picPot5_MouseLeave(object sender, EventArgs e)
        {
           // picTanah5.Visible = true;
        }

        int xx, yy;
        private void Form_Kill_The_Hama_MouseDown(object sender, MouseEventArgs e)
        {
            hold = true;
            xx = e.X;
            yy = e.Y;
        }

        private void Form_Kill_The_Hama_MouseUp(object sender, MouseEventArgs e)
        {
            hold = false;
        }

        int x1, y1;
        private void Form_Kill_The_Hama_MouseMove(object sender, MouseEventArgs e)
        {
            if (x1 != Cursor.Position.X && y1 != Cursor.Position.Y)
            {
                x1 = Cursor.Position.X;
                y1 = Cursor.Position.Y;
                if (hold)
                {
                    this.Left = x1 - xx;
                    this.Top = y1 - yy;

                }
            }
        }

    }
}
