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
    public partial class Form_Loading : Form
    {
        public Form_Loading()
        {
            InitializeComponent();
        }

        internal Form_Loading(int[] j)
        {
            InitializeComponent();
            for (int i = 0; i < 4; i++)
            {
                urutanPemain[i] = j[i];
            }
        }

        int[] urutanPemain = new int[4];
        string[] a = new string[100];
        int i = 0;
        int b = 20;
        private void frmLoading_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = Image.FromFile(Application.StartupPath + "\\Loading\\Background.jpg");
            lblJudul.Image = Image.FromFile(Application.StartupPath + "\\Loading\\Background.jpg");
            lblLoading.Image = Image.FromFile(Application.StartupPath + "\\Loading\\Background.jpg");
            picRocket.Image = Image.FromFile(Application.StartupPath + "\\Loading\\Rocket.gif");
            picMoon1.Image = Image.FromFile(Application.StartupPath + "\\Loading\\Blue Moon.png");
            picMoon2.Image = Image.FromFile(Application.StartupPath + "\\Loading\\Blue Moon.png");
            picMoon3.Image = Image.FromFile(Application.StartupPath + "\\Loading\\Blue Moon.png");
            picMoon4.Image = Image.FromFile(Application.StartupPath + "\\Loading\\Blue Moon.png");
            picMoon5.Image = Image.FromFile(Application.StartupPath + "\\Loading\\Moon.png");
            a[0] = "...\\Monopoly Space\\Data\\dt1.cpk";
            a[1] = "...\\Monopoly Space\\Data\\dt2.cpk";
            a[2] = "...\\Monopoly Space\\Data\\dt3.cpk";
            a[3] = "...\\Monopoly Space\\Data\\dt4.cpk";
            a[4] = "...\\Monopoly Space\\Data\\dt5.cpk";
            a[5] = "...\\Monopoly Space\\Data\\dt6.cpk";
            a[6] = "...\\Monopoly Space\\Data\\dt7.cpk";
            a[7] = "...\\Monopoly Space\\Data\\dt8.cpk";
            a[8] = "...\\Monopoly Space\\Data\\dt9.cpk";
            a[9] = "...\\Monopoly Space\\Data\\dt10.cpk";
            a[10] = "...\\Monopoly Space\\Data\\dt11.cpk";
            a[11] = "...\\Monopoly Space\\Data\\dt12.cpk";
            a[12] = "...\\Monopoly Space\\Data\\dt13.cpk";
            a[13] = "...\\Monopoly Space\\Data\\dt14.cpk";
            a[14] = "...\\Monopoly Space\\14mg\\dt00_e.15mg";
            a[15] = "...\\Monopoly Space\\img\\dt0a.img";
            a[16] = "...\\Monopoly Space\\img\\dt0b.img";
            a[16] = "...\\Monopoly Space\\img\\dt0c.img";
            a[17] = "...\\Monopoly Space\\img\\dt0e.img";
            a[19] = "...\\Monopoly Space\\img\\dt0d.img";
            a[20] = "...\\Monopoly Space\\img\\dt0f.img";
            a[21] = "...\\Monopoly Space\\img\\dt01.img";
            a[22] = "...\\Monopoly Space\\img\\dt02.img";
            a[23] = "...\\Monopoly Space\\img\\dt03.img";
            a[24] = "...\\Monopoly Space\\img\\dt04.img";
            a[25] = "...\\Monopoly Space\\img\\dt05.img";
            a[26] = "...\\Monopoly Space\\img\\dt06.img";
            a[27] = "...\\Monopoly Space\\img\\dt07.img";
            a[28] = "...\\Monopoly Space\\img\\dt10.img";
            a[29] = "...\\Monopoly Space\\img\\res\\pes_topBG_E_1.sfd";
            a[30] = "...\\Monopoly Space\\img\\res\\pes_topBG_E_2.sfd";
            a[31] = "...\\Monopoly Space\\img\\res\\pes12ci.sfd";
            a[32] = "...\\Monopoly Space\\img\\res\\pes13cl_a.sfd";
            a[33] = "...\\Monopoly Space\\img\\res\\pes13cl_b.sfd";
            a[34] = "...\\Monopoly Space\\img\\res\\pes13cl_c.sfd";
            a[35] = "...\\Monopoly Space\\img\\res\\pes13el_a.sfd";
            a[36] = "...\\Monopoly Space\\img\\res\\pes13pv.sfd";
            a[37] = "...\\Monopoly Space\\img\\map\\map.txt";
            a[38] = "Loading Player...";
            a[39] = "...\\Monopoly Space\\image\\player\\player 1";
            a[40] = "...\\Monopoly Space\\image\\player\\player 2";
            a[41] = "...\\Monopoly Space\\image\\player\\player 3";
            a[42] = "...\\Monopoly Space\\image\\player\\player 4";
            a[43] = "Loading Map...";
            a[44] = "...\\Monopoly Space\\image\\map\\space map";
            a[45] = "checking sound ...";
            a[46] = "checking player...";
            a[47] = "checking map...";
            a[48] = "checking graphic...";
            a[49] = "checking effect...";
            a[50] = "checking environment...";
            a[51] = "";
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            picRocket.Location = new Point(picRocket.Location.X + b, picRocket.Location.Y);
            if (picRocket.Location.X == picMoon1.Location.X)
            {
                picMoon1.Image = Image.FromFile(Application.StartupPath + "\\Loading\\explosion.gif");
            }
            if (picRocket.Location.X == picMoon2.Location.X)
            {
                picMoon2.Image = Image.FromFile(Application.StartupPath + "\\Loading\\explosion.gif");
            }
            if (picRocket.Location.X == picMoon3.Location.X)
            {
                picMoon3.Image = Image.FromFile(Application.StartupPath + "\\Loading\\explosion.gif");
            }
            if (picRocket.Location.X == picMoon4.Location.X)
            {
                picMoon4.Image = Image.FromFile(Application.StartupPath + "\\Loading\\explosion.gif");
            }
            if (picRocket.Location.X == picMoon5.Location.X)
            {
                picMoon5.Image = Image.FromFile(Application.StartupPath + "\\Loading\\explosion.gif");
                picRocket.Visible = false;
            }
        }

        private void tmrTextLoading_Tick(object sender, EventArgs e)
        {
            i++;
            if (i < 52)
            {
                lblLoading.Text = a[i];
            }
            if (i == 55)
            {
                Form_Peta form = new Form_Peta(urutanPemain);
                this.Hide();
                form.ShowDialog();
                this.Close();
            }
        }
    }
}
