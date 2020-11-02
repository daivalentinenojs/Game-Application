using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Media;
using System.Media;

namespace MIB_2015
{
    public partial class G0RandomGame : Form
    {
        public Player p1, p2;
        public G0RandomGame(Player p1, Player p2)
        {
            InitializeComponent();
            this.p1 = p1;
            this.p2 = p2;
        }

        private void picExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        SoundPlayer p = new SoundPlayer(Application.StartupPath + "\\Music\\Random.wav");

        Random rnd = new Random();
        public DateTime _start;
        public int counter=0;
        private void G0RandomGame_Load(object sender, EventArgs e)
        {
            CenterToScreen();
                _start = DateTime.UtcNow;
                tmrRandom.Enabled = true;
                p.PlayLooping();
        }

        Image[] bg = { Image.FromFile(Application.StartupPath+"\\random\\imgs\\0.png"),
                         Image.FromFile(Application.StartupPath+"\\random\\imgs\\1.png"),
                         Image.FromFile(Application.StartupPath+"\\random\\imgs\\2.png"),
                         Image.FromFile(Application.StartupPath+"\\random\\imgs\\3.png"),
                         Image.FromFile(Application.StartupPath+"\\random\\imgs\\4.png"),
                         Image.FromFile(Application.StartupPath+"\\random\\imgs\\5.png"),
                         Image.FromFile(Application.StartupPath+"\\random\\imgs\\6.png")
                     };
        Image[] bgs = { Image.FromFile(Application.StartupPath+"\\random\\imgs\\0s.png"),
                         Image.FromFile(Application.StartupPath+"\\random\\imgs\\1s.png"),
                         Image.FromFile(Application.StartupPath+"\\random\\imgs\\2s.png"),
                         Image.FromFile(Application.StartupPath+"\\random\\imgs\\3s.png"),
                         Image.FromFile(Application.StartupPath+"\\random\\imgs\\4s.png"),
                         Image.FromFile(Application.StartupPath+"\\random\\imgs\\5s.png"),
                         Image.FromFile(Application.StartupPath+"\\random\\imgs\\6s.png")
                     };
        Image[] use = new Image[7];
        bool[] done = { false, false, false, false, false, false, false };
        int select;

        private void go()
        {
            System.Threading.Thread.Sleep(1000);
            select = 1;
            p.Stop();
            switch (select)
            {
                case 0: // Sudah (yesno)
                    CeritaG1 g1 = new CeritaG1(p1, p2, counter, 1);
                    g1.theParent = this;
                    this.Hide();
                    g1.ShowDialog();
                    break;
                case 1: // Sudah - kurang 3,2,1;
                    CeritaG2 g2 = new CeritaG2(p1, p2,counter,1);
                    g2.theParent = this;
                    this.Hide();
                    g2.ShowDialog();
                    break;
                case 2: // Sudah (kykaudi)
                    CeritaG3 g3 = new CeritaG3(p1, p2, counter,1);
                    g3.theParent = this;
                    this.Hide();
                    g3.ShowDialog();
                    break;
                case 3: // sudah (titah raja)
                    CeritaG4 g4 = new CeritaG4(p1, p2,counter,1);
                    g4.theParent = this;
                    this.Hide();
                    g4.ShowDialog();
                    break;
                case 4: // Sudah (cooking)
                    CeritaG5 g5 = new CeritaG5(p1, p2,counter,1);
                    g5.theParent = this;
                    this.Hide();
                    g5.ShowDialog();
                    break;
                case 5: // Sudah (open door)
                    CeritaG6 g6 = new CeritaG6(p1, p2,counter,1);
                    g6.theParent = this;
                    this.Hide();
                    g6.ShowDialog();
                    break;
                case 6:// sudah (senjata)
                    CeritaG7 g7 = new CeritaG7(p1, p2, counter,1);
                    g7.theParent = this;
                    this.Hide();
                    g7.ShowDialog();
                    break; 
            }
            // p.Stop();
        }

        private void tmrRandom_Tick(object sender, EventArgs e)
        {
            if (counter < 2)
            {
                lblJudul.Text = "Acak Permainan ke - " + (counter+1).ToString();
                new System.Threading.Thread(() =>
                {
                    var c = new System.Windows.Media.MediaPlayer();
                    c.Open(new System.Uri(@Application.StartupPath + "\\random\\c.wav"));
                    c.Play();
                }).Start();
                if ((_start.AddSeconds(3) - DateTime.UtcNow).Ticks <= 0) tmrRandom.Interval = tmrRandom.Interval + 50;
                if ((_start.AddMilliseconds(6000) - DateTime.UtcNow).Ticks <= 0)
                {
                    do
                    {
                        if (!done[select])
                        {
                            tmrRandom.Enabled = false;
                            tmrRandom.Interval = 55;
                            done[select] = true;
                            go();
                            break;
                        }
                        else
                        select = rnd.Next(0, 7);
                    } while ((done[select]));
                }
                select = rnd.Next(0, 7);
                for (int a = 0; a < 7; a++)
                {
                    if (a != select)
                        use[a] = bg[a];
                    else
                        use[a] = bgs[a];
                }
                label0.Image = use[0];
                label1.Image = use[1];
                label2.Image = use[2];
                label3.Image = use[3];
                label4.Image = use[4];
                label5.Image = use[5];
                label6.Image = use[6];
            }
            else
            {
                tmrRandom.Enabled = false;
                Akhir akhir = new Akhir(p1, p2);
                p.Stop();
                this.Hide();
                akhir.ShowDialog();
            }
        }


        private void picExit_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
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

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
