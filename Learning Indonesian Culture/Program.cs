using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Media;

namespace MIB_2015
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Player p1 = new Player(), p2 = new Player();
            p1.Score = 100;
            p2.Score = 100;
            p1.Name = "AmSD";
            p2.Name = "JmKL";
            //Application.Run(new kykAudi(p1,p2, 3));
            Application.Run(new G0MainMenu());
            //Application.Run(new hs(2));
            //Application.Run(new Akhir(p1, p2));
        }
    }
}
