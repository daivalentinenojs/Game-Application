using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Project_PBO_Monopoly
{
    class Tanah
    {
        private int m_namaTanah;
        private int m_mortage;
        private bool m_statusBeli; // Menyimpan Status Lahan false = Belum Dimiliki Siapa" true = Sudah Dimiliki oleh Seorang Pemain
        private int m_sewa;// Harga Sewa
        private int m_hargaBeli;
        private int m_hargaJual;
        private int m_totalHargaBangunan; // Harga bangunan plus harga tanah
        private int m_levelBangunan;// 0=tanah 1=rumah 2=apartment 3=villa 4=hotel 5=castle
        private int m_hargaSemuaBangunan;// Untuk Menyimpan Seluruh Harga Dari Semua Properti Yang Dipunyai Pemain
        private string m_jenisLahan;// Rumah Atau Hotel
        private Pemain m_pemilik = new Pemain();
        private int m_hargaApartment;
        private int m_hargaRumah;
        private int m_hargaVilla;
        private int m_hargaHotel;
        private int m_hargaCastle;

        public int NamaTanah
        {
            get { return m_namaTanah; }
            set { m_namaTanah = value; }
        }

        public int Mortage
        {
            get { return m_mortage; }
            set { m_mortage = value; }
        }

        public Tanah()
        {
            m_totalHargaBangunan = 0;
            m_hargaSemuaBangunan = 0;
            statusBeli = false;
        }

        public bool statusBeli
        {
            get { return m_statusBeli; }
            set { m_statusBeli = value; }
        }

        public Pemain pemilik
        {
            set { m_pemilik = value; }
            get { return m_pemilik; }
        }

        public int Sewa
        {
            get { return m_sewa; }
            set { m_sewa = value; }
        }
        public int HargaBeli
        {
            get { return m_hargaBeli; }
            set { m_hargaBeli = value; }
        }
        public int HargaJual
        {
            get { return m_hargaJual; }
            set { m_hargaJual = value; }
        }
        public int LevelBangungan
        {
            get{return m_levelBangunan;}
            set{m_levelBangunan = value;}
        }
        public int TotalHargaBangunan
        {
            get { return m_totalHargaBangunan; }
            set { m_totalHargaBangunan = value; }
        }
        public int HargaSemuaBangunan
        {
            get{return m_hargaSemuaBangunan;}
            set{m_hargaSemuaBangunan = value;}
        }
        public string JenisLahan
        {
            get{ return m_jenisLahan;}
            set{ m_jenisLahan = value;}
        }
        public int hargaApartment
        {
            get { return m_hargaApartment; }
            set { m_hargaApartment = value; }
        }
        public int hargaRumah
        {
            get { return m_hargaRumah; }
            set { m_hargaRumah = value; }
        }
        public int hargaVilla
        {
            get { return m_hargaVilla; }
            set { m_hargaVilla = value; }
        }
        public int hargaHotel
        {
            get { return m_hargaHotel; }
            set { m_hargaHotel = value; }
        }
        public int hargaCastle
        {
            get { return m_hargaCastle; }
            set { m_hargaCastle = value; }
        }
        //public Pemain UbahStatusPemilik // Mengubah Status Kepemilikan Lahan di Class Pemain
        //{
        //    set { m_pemilik.TambahLahan = int.Parse(value); }
        //}

        #region Method Hitung Total Harta
        public void TotalHargaRumahHotel() //Hitung Harga Lahan + Rumah/Hotel
        {         
            // Check Sesuai Level Bangunan
            if (LevelBangungan == 0)
            {
                TotalHargaBangunan = m_hargaBeli;
            }
            else if (LevelBangungan == 1)
            {
                TotalHargaBangunan = m_hargaBeli + hargaApartment;
            }
            else if (LevelBangungan == 2)
            {
                TotalHargaBangunan = m_hargaBeli + hargaApartment + hargaRumah;
            }
            else if (LevelBangungan == 3)
            {
                TotalHargaBangunan = m_hargaBeli + hargaVilla + hargaApartment + hargaRumah;
            }
            else if (LevelBangungan == 4)
            {
                TotalHargaBangunan = m_hargaBeli + hargaHotel;
            }
            else if (LevelBangungan == 5)
            {
                TotalHargaBangunan = m_hargaBeli + hargaCastle + hargaHotel;
            }
        }
        public void TotalSeluruhBangunan(Pemain x)// Buat Hitung Total Semua Bangunan Yang Dimiliki Pemain
        {
            HargaSemuaBangunan += TotalHargaBangunan;
            x.totalHarta = x.uang + HargaSemuaBangunan;
        }
        #endregion

        #region Method Bayar Sewa
        public void BayarLahanSewa(Pemain x)// Membayar Harga Sewa
        {
            if (LevelBangungan == 0)
            {
                Sewa = (int)(HargaBeli * 0.2);
            }
            else if (LevelBangungan == 1)
            {
                Sewa = (int)((HargaBeli + hargaApartment) * 0.2);
            }
            else if (LevelBangungan == 2)
            {
                Sewa = (int)((HargaBeli + hargaRumah + hargaApartment) * 0.2);
            }
            else if (LevelBangungan == 3)
            {
                Sewa = (int)((HargaBeli + hargaRumah + hargaApartment + hargaVilla) * 0.2);
            }
            else if (LevelBangungan == 4)
            {
                Sewa = (int)((HargaBeli) * 0.2);
            }
            else if (LevelBangungan == 5)
            {
                Sewa = (int)((HargaBeli + hargaCastle) * 0.2);
            }
            x.uang -= Sewa;
            x.totalHarta -= Sewa;
        }
        public void DapatBayarSewa(Pemain x)// Mendapat Harga Sewa
        {
            // Check Lahan Yang Diinjak
            if (LevelBangungan == 0)
            {
                Sewa = (int)(HargaBeli * 0.2);
            }
            else if (LevelBangungan == 1)
            {
                Sewa = (int)((HargaBeli + hargaApartment) * 0.2);
            }
            else if (LevelBangungan == 2)
            {
                Sewa = (int)((HargaBeli + hargaRumah + hargaApartment) * 0.2);
            }
            else if (LevelBangungan == 3)
            {
                Sewa = (int)((HargaBeli + hargaRumah + hargaApartment + hargaVilla) * 0.2);
            }
            else if (LevelBangungan == 4)
            {
                Sewa = (int)((HargaBeli) * 0.2);
            }
            else if (LevelBangungan == 5)
            {
                Sewa = (int)((HargaBeli + hargaCastle) * 0.2);
            }
            x.uang += Sewa;
            x.totalHarta += Sewa;
        }
        #endregion

        #region Method Buy Sell
        public void BeliLahan(Pemain x)
        {
            statusBeli = true;
            x.uang -= TotalHargaBangunan;
        }

        public void JualLahan(Pemain x)
        {
            statusBeli = false;
            //Check Lahan yang Dipilih
            if (LevelBangungan == 0)
            {
                HargaJual = (int)(HargaBeli * 1.5);
            }
            else if (LevelBangungan == 1)
            {
                HargaJual = (int)((HargaBeli + hargaApartment) * 1.5);
            }
            else if (LevelBangungan == 2)
            {
                HargaJual = (int)((HargaBeli + hargaRumah + hargaApartment) * 1.5);
            }
            else if (LevelBangungan == 3)
            {
                HargaJual = (int)((HargaBeli + hargaRumah + hargaApartment + hargaVilla) * 1.5);
            }
            else if (LevelBangungan == 4)
            {
                HargaJual = (int)((HargaBeli) * 1.5);
            }
            else if (LevelBangungan == 5)
            {
                HargaJual = (int)((HargaBeli + hargaCastle) * 1.5);
            }
            x.uang += HargaJual;
            x.totalHarta += HargaJual-TotalHargaBangunan;
        }
        #endregion

        #region Method Build
        public void BangunLahan(Pemain x) // Method Buat Bangun Rumah Atau Hotel
        {
                if (LevelBangungan == 0)
                {
                    LevelBangungan = 1;
                    x.uang -= hargaApartment;
                    MessageBox.Show("Apartment Sudah Dibangun");
                }
                else if (LevelBangungan == 1)
                {
                    LevelBangungan = 2;
                    x.uang -= hargaRumah;
                    MessageBox.Show("Rumah Sudah Dibangun");
                }
                else if (LevelBangungan == 2)
                {
                    LevelBangungan = 3;
                    x.uang -= hargaVilla;
                    MessageBox.Show("Villa Sudah Dibangun");
                }
                else if (LevelBangungan == 6)
                {
                    LevelBangungan = 4;
                    x.uang -= hargaHotel;
                    MessageBox.Show("Hotel Sudah Dibangun");
                }
                else if (LevelBangungan == 4)
                {
                    LevelBangungan = 5;
                    x.uang -= hargaCastle;
                    MessageBox.Show("Castle Sudah Dibangun");
                }
                else
                {
                    MessageBox.Show("Level Bangunan Sudah Paling Tinggi");
                }
            
        }
        #endregion

        public virtual string format()
        {
            string a = "";
            a += "Nama Pemilik : " + pemilik.nama() + "\n";
            return a;
        }
        public virtual int LemparSewa()// Lempar Membayar Harga Sewa
        {
            if (LevelBangungan == 0)
            {
                Sewa = (int)(HargaBeli * 0.2);
            }
            else if (LevelBangungan == 1)
            {
                Sewa = (int)((HargaBeli + hargaApartment) * 0.2);
            }
            else if (LevelBangungan == 2)
            {
                Sewa = (int)((HargaBeli + hargaRumah + hargaApartment) * 0.2);
            }
            else if (LevelBangungan == 3)
            {
                Sewa = (int)((HargaBeli + hargaRumah + hargaApartment + hargaVilla) * 0.2);
            }
            else if (LevelBangungan == 4)
            {
                Sewa = (int)((HargaBeli) * 0.2);
            }
            else if (LevelBangungan == 5)
            {
                Sewa = (int)((HargaBeli + hargaCastle) * 0.2);
            }
            return Sewa;
        }
        public int HargaPembangunan()
        {
            int price = 0;
            if (LevelBangungan == 0)
            {
                price = hargaApartment;
            }
            else if (LevelBangungan == 1)
            {
                price = hargaRumah;
            }
            else if (LevelBangungan == 2)
            {
                price = hargaVilla;
            }
            else if (LevelBangungan == 6)
            {
                price = hargaHotel;
            }
            else if (LevelBangungan == 4)
            {
                price = hargaCastle;
            }
            return price;
        }
    }
}

