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
    public partial class Form_Select_Character : Form
    {
        public Form_Select_Character()
        {
            InitializeComponent();
        }

        private void picBack_Click(object sender, EventArgs e)
        {
            Form_Main_Menu form = new Form_Main_Menu();
            this.Hide();
            form.ShowDialog();
            this.Close();
        }

        int i, j, k, Tinggi;
        int[] urutanPemain = new int[4];
        Pemain urutanP = new Pemain();

        private void picNext_Click(object sender, EventArgs e)
        {
             //Urutkan Nilai Dadu
            for (j = 1; j < 4; j++)
            {
                Tinggi = nilaiDadu[0, j - 1];
                k = j;
                for (i = 0; i < 4 - j; i++)
                {
                    if (Tinggi < nilaiDadu[0, k])
                    {
                        int temp = nilaiDadu[0, j - 1];
                        nilaiDadu[0, j - 1] = nilaiDadu[0, k];
                        nilaiDadu[0, k] = temp;
                        Tinggi = nilaiDadu[0, j - 1];

                        temp = nilaiDadu[1, j - 1];
                        nilaiDadu[1, j - 1] = nilaiDadu[1, k];
                        nilaiDadu[1, k] = temp;

                        temp = nilaiDadu[2, j - 1];
                        nilaiDadu[2, j - 1] = nilaiDadu[2, k];
                        nilaiDadu[2, k] = temp;

                        temp = nilaiDadu[3, j - 1];
                        nilaiDadu[3, j - 1] = nilaiDadu[3, k];
                        nilaiDadu[3, k] = temp;
                    }
                    k++;
                }
            }
            /*
            for (int i = 0; i<4; i++)
            {
                for (int j = 0; j<4; j++)
                {
                    label1.Text += nilaiDadu[i, j].ToString();
                }
                label1.Text += "\n";
            }
            */
            int finish = 0;
            for (int i = 0; i < 4; i++)
            {
                finish += nilaiDadu[3, i];
                urutanPemain[i] = nilaiDadu[2, i];
               // label2.Text += urutanPemain[i];
            }

            if (finish == 4)
            {
                picN1.Enabled = false;
                picN2.Enabled = false;
                picN3.Enabled = false;
                picN4.Enabled = false;
                picB1.Enabled = false;
                picB2.Enabled = false;
                picB3.Enabled = false;
                picB4.Enabled = false;

                /*
                string final = "";
                for (int p = 0; p < 4; p++)
                {
                    final += urutanPemain[p].ToString();
                }

                urutanP.UrutanPemain = final;
                */


                Form_Loading form = new Form_Loading(urutanPemain);
                this.Hide();
                form.ShowDialog();
                this.Close();
           
            }
            else
            {
                MessageBox.Show("Silahkan Roll Dice !!", "Peringatan");
            }
        }

        System.Media.SoundPlayer SoundChange = new System.Media.SoundPlayer(Application.StartupPath + "\\Music\\HomeEnter.wav");
        private void Form_Select_Character_Load(object sender, EventArgs e)
        {
            picNext.Image = Image.FromFile(Application.StartupPath + "\\FormSelectCharacter\\Next.png");
            picBack.Image = Image.FromFile(Application.StartupPath + "\\FormSelectCharacter\\Back.png");

            picB1.Image = Image.FromFile(Application.StartupPath + "\\FormSelectCharacter\\Back1.png");
            picB2.Image = Image.FromFile(Application.StartupPath + "\\FormSelectCharacter\\Back1.png");
            picB3.Image = Image.FromFile(Application.StartupPath + "\\FormSelectCharacter\\Back1.png");
            picB4.Image = Image.FromFile(Application.StartupPath + "\\FormSelectCharacter\\Back1.png");

            picN1.Image = Image.FromFile(Application.StartupPath + "\\FormSelectCharacter\\Next1.png");
            picN2.Image = Image.FromFile(Application.StartupPath + "\\FormSelectCharacter\\Next1.png");
            picN3.Image = Image.FromFile(Application.StartupPath + "\\FormSelectCharacter\\Next1.png");
            picN4.Image = Image.FromFile(Application.StartupPath + "\\FormSelectCharacter\\Next1.png");
            
            # region Tampil Gambar
            this.BackgroundImage = Image.FromFile(Application.StartupPath + "\\FormSelectCharacter\\Background.jpg");
            picRoll1.Image = Image.FromFile(Application.StartupPath+"\\FormSelectCharacter\\TombolRollDice.png");
            picRoll2.Image = Image.FromFile(Application.StartupPath + "\\FormSelectCharacter\\TombolRollDice.png");
            picRoll3.Image = Image.FromFile(Application.StartupPath + "\\FormSelectCharacter\\TombolRollDice.png");
            picRoll4.Image = Image.FromFile(Application.StartupPath + "\\FormSelectCharacter\\TombolRollDice.png");

            picChar1.Image = Image.FromFile(Application.StartupPath + "\\FormSelectCharacter\\0.jpg");
            picChar2.Image = Image.FromFile(Application.StartupPath + "\\FormSelectCharacter\\1.jpg");
            picChar3.Image = Image.FromFile(Application.StartupPath + "\\FormSelectCharacter\\2.jpg");
            picChar4.Image = Image.FromFile(Application.StartupPath + "\\FormSelectCharacter\\3.jpg");
            #endregion

            #region Nilai Awal
            for (int p = 0; p < 4; p++)
            {
                selectCharacter[p] = p;
            }

            for (int p = 0; p < 4; p++)
            {
                notselectCharacter[p] = p + 4;
            }

            for (int p = 0; p < 4; p++)
            {
                urutanPemain[p] = -1;
            }

            for (int p = 0; p < 4; p++)
            {
                nilaiDadu[1, p] = p;
            }

            for (int p = 0; p < 4; p++)
            {
                nilaiDadu[2, p] = p;
            }
            #endregion
        }

        #region Deklarasi Object
        Pemain pemain1 = new Pemain();
        Pemain pemain2 = new Pemain();
        Pemain pemain3 = new Pemain();
        Pemain pemain4 = new Pemain();
        #endregion

        #region Deklarasi Urutan Pemain
        int[,] nilaiDadu = new int[4, 4];

        #endregion

        #region Roll Dice
        private void picRoll1_Click(object sender, EventArgs e)
        {
            nilaiDadu[0, 0] = pemain1.RollDice();
            while (nilaiDadu[0, 0] == nilaiDadu[0, 1] || nilaiDadu[0, 0] == nilaiDadu[0, 2] || nilaiDadu[0, 0] == nilaiDadu[0, 3])
            {
                nilaiDadu[0, 0] = pemain1.RollDice();
            }
            nilaiDadu[3, 0] = 1;
            picDice1.Image = Image.FromFile(Application.StartupPath + "\\FormPeta\\D" + nilaiDadu[0, 0].ToString() + ".gif");
            picRoll1.Visible = false;
        }

        private void picRoll2_Click(object sender, EventArgs e)
        {
            nilaiDadu[0, 1] = pemain2.RollDice();
            while (nilaiDadu[0, 1] == nilaiDadu[0, 0] || nilaiDadu[0, 1] == nilaiDadu[0, 2] || nilaiDadu[0, 1] == nilaiDadu[0, 3])
            {
                nilaiDadu[0, 1] = pemain2.RollDice();
            }
            nilaiDadu[3, 1] = 1;
            picDice2.Image = Image.FromFile(Application.StartupPath + "\\FormPeta\\D" + nilaiDadu[0, 1].ToString() + ".gif");
            picRoll2.Visible = false;
        }

        private void picRoll3_Click(object sender, EventArgs e)
        {
            nilaiDadu[0, 2] = pemain3.RollDice();
            while (nilaiDadu[0, 2] == nilaiDadu[0, 0] || nilaiDadu[0, 2] == nilaiDadu[0, 1] || nilaiDadu[0, 2] == nilaiDadu[0, 3])
            {
                nilaiDadu[0, 2] = pemain3.RollDice();
            }
            nilaiDadu[3, 2] = 1;
            picDice3.Image = Image.FromFile(Application.StartupPath + "\\FormPeta\\D" + nilaiDadu[0, 2].ToString() + ".gif");
            picRoll3.Visible = false;
        }

        private void picRoll4_Click(object sender, EventArgs e)
        {
            nilaiDadu[0, 3] = pemain4.RollDice();
            while (nilaiDadu[0, 3] == nilaiDadu[0, 1] || nilaiDadu[0, 3] == nilaiDadu[0, 2] || nilaiDadu[0, 3] == nilaiDadu[0, 0])
            {
                nilaiDadu[0, 3] = pemain4.RollDice();
            }
            nilaiDadu[3, 3] = 1;
            picDice4.Image = Image.FromFile(Application.StartupPath + "\\FormPeta\\D" + nilaiDadu[0, 3].ToString() + ".gif");
            picRoll4.Visible = false;
        }
        #endregion

        #region Deklarasi Char Selected
        int[] selectCharacter = new int[4];
        int[] notselectCharacter = new int[4];
        #endregion

        #region Next
        private void picN1_Click(object sender, EventArgs e)
        {
            int tombol = 0;
            selectCharacter[0] = pemain1.Next(selectCharacter, notselectCharacter, tombol);
            nilaiDadu[2, 0] = selectCharacter[0];
            picChar1.Image = Image.FromFile(Application.StartupPath + "\\FormSelectCharacter\\" + selectCharacter[0] + ".jpg");
        }

        private void picN2_Click(object sender, EventArgs e)
        {
            int tombol = 1;
            selectCharacter[1] = pemain2.Next(selectCharacter, notselectCharacter, tombol);
            nilaiDadu[2, 1] = selectCharacter[1];
            picChar2.Image = Image.FromFile(Application.StartupPath + "\\FormSelectCharacter\\" + selectCharacter[1] + ".jpg");
        }

        private void picN3_Click(object sender, EventArgs e)
        {
            int tombol = 2;
            selectCharacter[2] = pemain3.Next(selectCharacter, notselectCharacter, tombol);
            nilaiDadu[2, 2] = selectCharacter[2];
            picChar3.Image = Image.FromFile(Application.StartupPath + "\\FormSelectCharacter\\" + selectCharacter[2] + ".jpg");
        }

        private void picN4_Click(object sender, EventArgs e)
        {
            int tombol = 3;
            selectCharacter[3] = pemain4.Next(selectCharacter, notselectCharacter, tombol);
            nilaiDadu[2, 3] = selectCharacter[3];
            picChar4.Image = Image.FromFile(Application.StartupPath + "\\FormSelectCharacter\\" + selectCharacter[3] + ".jpg");
        }
        #endregion

        #region Back
        private void picB1_Click(object sender, EventArgs e)
        {
            int tombol = 0;
            selectCharacter[0] = pemain1.Back(selectCharacter, notselectCharacter, tombol);
            nilaiDadu[2, 0] = selectCharacter[0];
            picChar1.Image = Image.FromFile(Application.StartupPath + "\\FormSelectCharacter\\" + selectCharacter[0] + ".jpg");
        }

        private void picB2_Click(object sender, EventArgs e)
        {
            int tombol = 1;
            selectCharacter[1] = pemain2.Back(selectCharacter, notselectCharacter, tombol);
            nilaiDadu[2, 1] = selectCharacter[1];
            picChar2.Image = Image.FromFile(Application.StartupPath + "\\FormSelectCharacter\\" + selectCharacter[1] + ".jpg");
        }

        private void picB3_Click(object sender, EventArgs e)
        {
            int tombol = 2;
            selectCharacter[2] = pemain3.Back(selectCharacter, notselectCharacter, tombol);
            nilaiDadu[2, 2] = selectCharacter[2];
            picChar3.Image = Image.FromFile(Application.StartupPath + "\\FormSelectCharacter\\" + selectCharacter[2] + ".jpg");
        }

        private void picB4_Click(object sender, EventArgs e)
        {
            int tombol = 3;
            selectCharacter[3] = pemain4.Back(selectCharacter, notselectCharacter, tombol);
            nilaiDadu[2, 3] = selectCharacter[3];
            picChar4.Image = Image.FromFile(Application.StartupPath + "\\FormSelectCharacter\\" + selectCharacter[3] + ".jpg");
        }
        #endregion

        private void picNext_MouseLeave(object sender, EventArgs e)
        {
            picNext.Image = Image.FromFile(Application.StartupPath + "\\FormSelectCharacter\\Next.png");
        }

        private void picBack_MouseLeave(object sender, EventArgs e)
        {
            picBack.Image = Image.FromFile(Application.StartupPath + "\\FormSelectCharacter\\Back.png");
        }

        private void picNext_MouseHover(object sender, EventArgs e)
        {
            SoundChange.Play();
            picNext.Image = Image.FromFile(Application.StartupPath + "\\FormSelectCharacter\\NextHover.png");
        }

        private void picBack_MouseHover(object sender, EventArgs e)
        {
            SoundChange.Play();
            picBack.Image = Image.FromFile(Application.StartupPath + "\\FormSelectCharacter\\BackHover.png");
        }

        private void picRoll1_MouseHover(object sender, EventArgs e)
        {
            SoundChange.Play();
            picRoll1.Image = Image.FromFile(Application.StartupPath + "\\FormSelectCharacter\\TombolRollDiceHover.png");
        }

        private void picRoll2_MouseHover(object sender, EventArgs e)
        {
            SoundChange.Play();
            picRoll2.Image = Image.FromFile(Application.StartupPath + "\\FormSelectCharacter\\TombolRollDiceHover.png");
        }

        private void picRoll3_MouseHover(object sender, EventArgs e)
        {
            SoundChange.Play();
            picRoll3.Image = Image.FromFile(Application.StartupPath + "\\FormSelectCharacter\\TombolRollDiceHover.png");
        }

        private void picRoll4_MouseHover(object sender, EventArgs e)
        {
            SoundChange.Play();
            picRoll4.Image = Image.FromFile(Application.StartupPath + "\\FormSelectCharacter\\TombolRollDiceHover.png");
        }

        private void picRoll1_MouseLeave(object sender, EventArgs e)
        {
            picRoll1.Image = Image.FromFile(Application.StartupPath + "\\FormSelectCharacter\\TombolRollDice.png");
        }

        private void picRoll2_MouseLeave(object sender, EventArgs e)
        {
            picRoll2.Image = Image.FromFile(Application.StartupPath + "\\FormSelectCharacter\\TombolRollDice.png");
        }

        private void picRoll3_MouseLeave(object sender, EventArgs e)
        {
            picRoll3.Image = Image.FromFile(Application.StartupPath + "\\FormSelectCharacter\\TombolRollDice.png");
        }

        private void picRoll4_MouseLeave(object sender, EventArgs e)
        {
            picRoll4.Image = Image.FromFile(Application.StartupPath + "\\FormSelectCharacter\\TombolRollDice.png");
        }

        private void picB1_MouseLeave(object sender, EventArgs e)
        {
            picB1.Image = Image.FromFile(Application.StartupPath + "\\FormSelectCharacter\\Back1.png");
           
        }

        private void picB2_MouseLeave(object sender, EventArgs e)
        {
            picB2.Image = Image.FromFile(Application.StartupPath + "\\FormSelectCharacter\\Back1.png");
          
        }

        private void picB3_MouseLeave(object sender, EventArgs e)
        {
            picB3.Image = Image.FromFile(Application.StartupPath + "\\FormSelectCharacter\\Back1.png");
           
        }

        private void picB4_MouseLeave(object sender, EventArgs e)
        {
            picB4.Image = Image.FromFile(Application.StartupPath + "\\FormSelectCharacter\\Back1.png");
        }

        private void picN1_MouseLeave(object sender, EventArgs e)
        {
            picN1.Image = Image.FromFile(Application.StartupPath + "\\FormSelectCharacter\\Next1.png");
         
        }

        private void picN2_MouseLeave(object sender, EventArgs e)
        {
            picN2.Image = Image.FromFile(Application.StartupPath + "\\FormSelectCharacter\\Next1.png");
          
        }

        private void picN3_MouseLeave(object sender, EventArgs e)
        {
            picN3.Image = Image.FromFile(Application.StartupPath + "\\FormSelectCharacter\\Next1.png");
           
        }

        private void picN4_MouseLeave(object sender, EventArgs e)
        {
            picN4.Image = Image.FromFile(Application.StartupPath + "\\FormSelectCharacter\\Next1.png");
        }

        private void picB1_MouseHover(object sender, EventArgs e)
        {
            SoundChange.Play();
            picB1.Image = Image.FromFile(Application.StartupPath + "\\FormSelectCharacter\\Back2.png");
        }

        private void picB2_MouseHover(object sender, EventArgs e)
        {
            SoundChange.Play();
            picB2.Image = Image.FromFile(Application.StartupPath + "\\FormSelectCharacter\\Back2.png");
        }

        private void picB3_MouseHover(object sender, EventArgs e)
        {
            SoundChange.Play();
            picB3.Image = Image.FromFile(Application.StartupPath + "\\FormSelectCharacter\\Back2.png");
        }

        private void picB4_MouseHover(object sender, EventArgs e)
        {
            SoundChange.Play();
            picB4.Image = Image.FromFile(Application.StartupPath + "\\FormSelectCharacter\\Back2.png");
        }

        private void picN1_MouseHover(object sender, EventArgs e)
        {
            SoundChange.Play();
            picN1.Image = Image.FromFile(Application.StartupPath + "\\FormSelectCharacter\\Next2.png");
        }

        private void picN2_MouseHover(object sender, EventArgs e)
        {
            SoundChange.Play();
            picN2.Image = Image.FromFile(Application.StartupPath + "\\FormSelectCharacter\\Next2.png");
        }

        private void picN3_MouseHover(object sender, EventArgs e)
        {
            SoundChange.Play();
            picN3.Image = Image.FromFile(Application.StartupPath + "\\FormSelectCharacter\\Next2.png");
        }

        private void picN4_MouseHover(object sender, EventArgs e)
        {
            SoundChange.Play();
            picN4.Image = Image.FromFile(Application.StartupPath + "\\FormSelectCharacter\\Next2.png");
        }
    }
}
