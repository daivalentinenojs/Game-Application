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
    public partial class Form_Thank_You : Form
    {
        public Form_Thank_You()
        {
            InitializeComponent();
        }

        int tampung = 0;
        private void Thank_You_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = Image.FromFile(Application.StartupPath + "\\FormExit\\ThankYou.jpg");
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            tampung++;
            if (tampung == 25)
            {
                Application.Exit();
            }
        }
    }
}
