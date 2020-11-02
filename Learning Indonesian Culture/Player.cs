using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Media;
using System.Windows.Media;

namespace MIB_2015
{
    public class Player
    {
        private int m_score;

        public int Score
        {
            get { return m_score; }
            set { m_score = value; }
        }

        private string m_name;

        public string Name
        {
            get { return m_name; }
            set { m_name = value; }
        }


        private int m_wins;

        public int Win
        {
            get { return m_wins; }
            set { m_wins = value; }
        }

        public Player()
        {
            m_name = "-";
            m_score = 0;
        }

        public static void RecordScore(int gameID, string p1name, string p2name, int p1score, int p2score)
        {
            string data = "";
            string[] games;
            if (File.Exists(Application.StartupPath + "\\data.hs"))
            {
                StreamReader rd = new StreamReader(Application.StartupPath + "\\data.hs");
                while (!rd.EndOfStream)
                {
                    data += rd.ReadLine() + "\n";
                }
                rd.Close();
            }

            games = data.Split('@');
            string[] pgames = new string[9];
            for (int a = 1; a < games.Length; a++)
            {
                if (games[a].Length > 1)
                    pgames[int.Parse(games[a][0].ToString())] = games[a];
            }
            StreamWriter wr = new StreamWriter(Application.StartupPath + "\\data.hs");
            string writethis = "";
            if (pgames[gameID] != null || pgames[gameID] != "")
                writethis += pgames[gameID];
            writethis += p1name + "\t" + p1score.ToString() + "\n";
            writethis += p2name + "\t" + p2score.ToString() + "\n";
            pgames[gameID] = writethis;
            writethis = "";
            
            for (int a = 1; a < 9; a++)
            {
                //while (pgames[a]!=null && pgames[a].IndexOf('\n') != -1)
                //    pgames[a] = pgames[a].Substring(0, pgames[a].Length - 1);
                writethis += (pgames[a] == null) ? "" : ("@" + a.ToString() + "\n" + pgames[a].Substring(1));
            }
            wr.WriteLine(writethis);
            wr.Close();
        }
    }
}
