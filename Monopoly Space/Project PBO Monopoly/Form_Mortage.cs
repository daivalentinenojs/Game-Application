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
    public partial class Form_Mortage : Form
    {
        public Form_Mortage()
        {
            InitializeComponent();
        }

        internal Form_Mortage(Pemain orang)
        {
            InitializeComponent();
            manusia = orang;
        }

        Pemain manusia = new Pemain();
        System.Media.SoundPlayer SoundChange = new System.Media.SoundPlayer(Application.StartupPath + "\\Music\\HomeEnter.wav");
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form_Mortage_Load(object sender, EventArgs e)
        {
            
            this.BackgroundImage = Image.FromFile(Application.StartupPath + "\\FormMortage\\Mortage.jpg");
            pictureBox2.Image = Image.FromFile(Application.StartupPath + "\\FormMortage\\Tombol Back.png");
            if (manusia.Mortage1.NamaKartu != -1)
            {
            pictureBox1.Image = Image.FromFile(Application.StartupPath + "\\FormKartu\\KartuTanah\\" + manusia.Mortage1.NamaKartu.ToString() + ".png");
            }
            if (manusia.Mortage2.NamaKartu != -1)
            {
                pictureBox3.Image = Image.FromFile(Application.StartupPath + "\\FormKartu\\KartuTanah\\" + manusia.Mortage2.NamaKartu.ToString() + ".png");
            }
            if (manusia.Mortage3.NamaKartu != -1)
            {
                pictureBox4.Image = Image.FromFile(Application.StartupPath + "\\FormKartu\\KartuTanah\\" + manusia.Mortage3.NamaKartu.ToString() + ".png");
            }
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.Image = Image.FromFile(Application.StartupPath + "\\FormMortage\\Tombol Back.png");
        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            SoundChange.Play();
            pictureBox2.Image = Image.FromFile(Application.StartupPath + "\\FormMortage\\TombolBackHover.png");
        }
    }
}
