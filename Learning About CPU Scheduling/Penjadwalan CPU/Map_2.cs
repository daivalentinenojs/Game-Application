using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Penjadwalan_CPU
{
    public partial class Map_2 : Form
    {
        public Map_2()
        {
            InitializeComponent();
        }

        System.Media.SoundPlayer SoundButton = new System.Media.SoundPlayer(Application.StartupPath + "\\Music\\HomeClick.wav");
        private void Map_2_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Map\\Map.png");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Belajarlah Dahulu Di Rumah SJF Preemptive !!", "Informasi");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Belajarlah Dahulu Di Rumah SJF Preemptive !!", "Informasi");
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            CPU_SJF_E form = new CPU_SJF_E();
            this.Hide();
            form.ShowDialog();
            this.Close();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Belajarlah Dahulu Di Rumah SJF Preemptive !!", "Informasi");
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            SoundButton.Play();
            pictureBox5.Visible = true;
            pictureBox5.Image = Image.FromFile(Application.StartupPath + "\\Map\\no.png");
        }

        private void pictureBox3_MouseHover(object sender, EventArgs e)
        {
            SoundButton.Play();
            pictureBox6.Visible = true;
            pictureBox6.Image = Image.FromFile(Application.StartupPath + "\\Map\\yes.png");
        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            SoundButton.Play();
            pictureBox7.Visible = true;
            pictureBox7.Image = Image.FromFile(Application.StartupPath + "\\Map\\no.png");
        }

        private void pictureBox4_MouseHover(object sender, EventArgs e)
        {
            SoundButton.Play();
            pictureBox8.Visible = true;
            pictureBox8.Image = Image.FromFile(Application.StartupPath + "\\Map\\no.png");
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox5.Visible = false;
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox6.Visible = false;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox7.Visible = false;
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            pictureBox8.Visible = false;
        }
    }
}
