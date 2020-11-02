﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Penjadwalan_CPU
{
    public partial class Story_Line_4 : Form
    {
        public Story_Line_4()
        {
            InitializeComponent();
        }

        System.Media.SoundPlayer SoundButton = new System.Media.SoundPlayer(Application.StartupPath + "\\Music\\HomeEnter.wav");
        private void picBack_Click(object sender, EventArgs e)
        {
            Story_Line_3 form = new Story_Line_3();
            this.Hide();
            form.ShowDialog();
            this.Close();
        }

        private void picNext_Click(object sender, EventArgs e)
        {
            Map_2 form = new Map_2();
            this.Hide();
            form.ShowDialog();
            this.Close();

        }

        private void Story_Line_4_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = Image.FromFile(Application.StartupPath + "\\StoryLine\\4.png");
            picBack.Image = Image.FromFile(Application.StartupPath + "\\StoryLine\\Kembali.png");
            picNext.Image = Image.FromFile(Application.StartupPath + "\\StoryLine\\Lanjut.png");
        }

        private void picBack_MouseHover(object sender, EventArgs e)
        {
            SoundButton.Play();
            picBack.Image = Image.FromFile(Application.StartupPath + "\\StoryLine\\KembaliHover.png");
        }

        private void picBack_MouseLeave(object sender, EventArgs e)
        {
            picBack.Image = Image.FromFile(Application.StartupPath + "\\StoryLine\\Kembali.png");
        }

        private void picNext_MouseHover(object sender, EventArgs e)
        {
            SoundButton.Play();
            picNext.Image = Image.FromFile(Application.StartupPath + "\\StoryLine\\LanjutHover.png");
        }

        private void picNext_MouseLeave(object sender, EventArgs e)
        {
            picNext.Image = Image.FromFile(Application.StartupPath + "\\StoryLine\\Lanjut.png");
        }
    }
}