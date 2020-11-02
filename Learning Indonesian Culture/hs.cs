using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace MIB_2015
{
    public partial class hs : Form
    {
        int GID = 0;
        public hs(int gameID)
        {
            InitializeComponent();
            GID = gameID;
        }

        private void sort()
        {
            for (int a = 0; a < px.Count; a++)
            {
                for (int b = a + 1; b < px.Count; b++)
                {
                    if (px[a].Score < px[b].Score)
                    {
                        Player tmp = px[a];
                        px[a] = px[b];
                        px[b] = tmp;
                    }
                }
            }

        }

        public void center()
        {
            this.CenterToScreen();
        }

        List<Player> px = new List<Player>();
        private void hs_Load(object sender, EventArgs e)
        {
            string data = "";
            string[] games;
            StreamReader rd = new StreamReader(Application.StartupPath + "\\data.hs");
            while (!rd.EndOfStream)
            {
                data += rd.ReadLine() + "\n";
            }
            rd.Close();
            games = data.Split('@');
            string[] pgames = new string[9];
            for (int a = 1; a < games.Length; a++)
            {
                if (games[a].Length > 1)
                    pgames[int.Parse(games[a][0].ToString())] = games[a];
            }
            if (pgames[GID] != null)
            {
                string[] perline = pgames[GID].Split('\n');
                string[] scores;
                int c = 0;
                //string[] namess = perline[c].Split('\t');
                for (int a = 0; a < perline.Length * 2; a += 2)
                {
                    if (perline[c].Length > 1)
                    {
                        string[] names = perline[c].Split('\t');
                        Player tmp = new Player();
                        tmp.Name = names[0];
                        tmp.Score = int.Parse(names[1]);
                        px.Add(tmp);
                    }
                    c++;
                }
                sort();
                //for (int a = 0; a < px.Count; a++)
            }
            while (px.Count < 3)
                px.Add(new Player());
            for (int a = 0; a < 3; a++)
            {
                listBox1.Items.Add(px[a].Name);
                listBox2.Items.Add(px[a].Score);
            }
            int x;
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void picExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
