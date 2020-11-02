using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project_PBO_Monopoly
{
    class Blok4 : Tanah
    {
        public Blok4(int harga)
            : base()
        {
            HargaBeli = harga;
            hargaApartment = 800;
            hargaRumah = 1050;
            hargaVilla = 1300;
            hargaHotel = 1300;
            hargaCastle = 1800;
        }
        public Blok4(int harga, int lvlBangunan)
            : base()
        {
            HargaBeli = harga;
            hargaApartment = 800;
            hargaRumah = 1050;
            hargaVilla = 1300;
            hargaHotel = 1300;
            hargaCastle = 1800;
            LevelBangungan = lvlBangunan;
        }
        public int hargaPembangunan()
        {
            int a = 0;
            if (LevelBangungan == 0)
            {
                a = hargaApartment;
            }
            else if (LevelBangungan == 1)
            {
                a = hargaRumah;
            }
            else if (LevelBangungan == 2)
            {
                a = hargaApartment;
            }
            else if (LevelBangungan == 3)
            {
                a = 0;
            }
            else if (LevelBangungan == 4)
            {
                a = hargaCastle;
            }
            else if (LevelBangungan == 5)
            {
                a = 0;
            }
            else if (LevelBangungan == 6)
            {
                a = hargaHotel;
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
                a = "Apartment";
            }
            else if (LevelBangungan == 2)
            {
                a = "Rumah";
            }
            else if (LevelBangungan == 3)
            {
                a = "Villa";
            }
            else if (LevelBangungan == 4)
            {
                a = "Hotel";
            }
            else if (LevelBangungan == 5)
            {
                a = "Castle";
            }
            else if (LevelBangungan == 6)
            {
                a = "Tanah Kosong";
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
