using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project_PBO_Monopoly
{
    class Blok2 : Tanah
    {
        public Blok2(int harga)
            : base()
        {
            HargaBeli = harga;
            hargaRumah = 60000;
            hargaHotel = 85000;
            hargaCastle = 110000;

        }
        public Blok2(int harga, int lvlBangunan)
            : base()
        {
            HargaBeli = harga;
            hargaRumah = 60000;
            hargaHotel = 85000;
            hargaCastle = 110000;
            LevelBangungan = lvlBangunan;
        }

        public int hargaPembangunan()
        {
            int a = 0;
            if (LevelBangungan == 0)
            {
                a = hargaRumah;
            }
            else if (LevelBangungan == 1)
            {
                a = hargaHotel;
            }
            else if (LevelBangungan == 2)
            {
                a = hargaCastle;
            }

            return a;
        }

        public string statusBangunan()
        {
            string a = "";
            if (LevelBangungan == 0)
            {
                a = "Tanah Kosong";
            }
            else if (LevelBangungan == 1)
            {
                a = "Rumah";
            }
            else if (LevelBangungan == 2)
            {
                a = "Hotel";
            }
            else if (LevelBangungan == 3)
            {
                a = "Castle";
            }
            return a;
        }

        public override string format()
        {
            string a = base.format();
            a += "Status Bangunan : " + statusBangunan() + "\n";
            a += "Harga Pembangun : " + hargaPembangunan() + "\n";
            return a;
        }

        public override int LemparSewa()
        {
            return base.LemparSewa();
        }
    }
}
