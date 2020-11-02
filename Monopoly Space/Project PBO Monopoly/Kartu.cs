using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project_PBO_Monopoly
{
    class Kartu
    {
        private int m_namaKartu; // Field untuk mengetahui efek kartu
        private int m_kemampuan; // Field untuk mengetahui kemampuan dari suatu kartu, 1 - 5, kemampuan menunjukkan tingkat rare dari sebuah kartu
        private int m_statusKartu; // Field untuk mengecek apakah seorang pemain sudah mendapatkan kartu baru atau belum, jika menekan tombol back, dianggap pemain telah mendapatkan kartu baru, 0 = belum 1 =  sudah
        private int m_kartuPemain; // Field untuk menunjukkan Kartu Pemain yang dipilih, untuk digunakan efek dari kartu tersebut
        private int m_lemparan;

        //Pemain EfekPemain = new Pemain(); // Pemain yang akan dipassingkan
        //Tanah EfekTanah = new Tanah(); // Tanah yang akan dipassingkan

        public int Lemparan
        {
            get { return m_lemparan; }
            set { m_lemparan = value; }
        }
        public Kartu() // Default Constructor dari sebuah objek Kartu
        {
            m_namaKartu = -1;
            m_kemampuan = -1;
            m_statusKartu = 0;
        }

        public Kartu(int a) // Default Constructor dari sebuah objek Kartu
        {
            m_namaKartu = a;
            m_kemampuan = -1;
            m_statusKartu = 0;
        }

        public int NamaKartu // Property untuk mengetahui bentuk efek kartu, berisi angka 1 - 5
        {
            get { return m_namaKartu; }
            set { m_namaKartu = value; }
        }

        public int Kemampuan
        {
            get { return m_kemampuan; }
            set { m_kemampuan = value; }
        }

        public int Status  // Property untuk mengecek apakah seorang pemain sudah mendapatkan kartu baru atau belum, jika menekan tombol back, dianggap pemain telah mendapatkan kartu baru, 0 = belum 1 =  sudah
        {
            get { return m_statusKartu; }
            set { m_statusKartu = value; }
        }

        public int KartuPemain // Property untuk menunjukkan Kartu Pemain yang dipilih, untuk digunakan efek dari kartu tersebut 
        {
            get { return m_kartuPemain; }
            set { m_kartuPemain = value; }
        }

        #region Random Kartu
        public int RandomNamaKartu() // Method untuk merandom Nama Kartu yang dimilki pemain nantinya, bernilai 1-50
        {
            Random rnd = new Random();
            int hasil = rnd.Next(1, 101);
            return hasil;
        }
        #endregion

        public int Format(int nama) // Method untuk menampilkan jenis kartu yang sedang dimiliki oleh pemain pada form Use Card
        {
            int hasil = 1;
          
            if (nama >= 1 && nama <= 3)
            {
                hasil = 1;
            }
            else if (nama >= 4 && nama <= 18)
            {
                hasil = 2;
            }
            else if (nama >= 19 && nama <= 33)
            {
                hasil = 3;
            }
            else if (nama >= 34 && nama <= 43)
            {
                hasil = 4;
            }
            else if (nama >= 44 && nama <= 50)
            {
                hasil = 5;
            }
            if (nama >= 51 && nama <= 67)
            {
                hasil = 6;
            }
            else if (nama >= 68 && nama <= 80)
            {
                hasil = 7;
            }
            else if (nama >= 81 && nama <= 90)
            {
                hasil = 8;
            }
            else if (nama >= 91 && nama <= 97)
            {
                hasil = 9;
            }
            else if (nama >= 98 && nama <= 100)
            {
                hasil = 10;
            }
            return hasil;
        }
    }
}
