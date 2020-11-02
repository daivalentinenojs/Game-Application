
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project_PBO_Monopoly
{
    class Pemain
    {
        #region Michael
        private int m_karakter; // Field berisi karakter yang dipilih (bernilai 0 - 7)
        private int m_posisi; // Field menunjukkan posisi pemain terdapat pada index ke berapa pada array Peta pada Form Peta
        private Kartu m_kartu1 = new Kartu();
        private Kartu m_kartu2 = new Kartu();
        private Kartu m_kartu3 = new Kartu();
        private int m_uang; // Field berisi uang yang dimiliki oleh Pemain
        private int m_totalHarta; // Field berisi total harta yang dimiliki oleh Pemain
        private int m_skip; // Field untuk mengecheck turn pemain (berada di penjara / terkena kartu skip / player game over / melakukan roll dice)
        private int m_jumlahMortage;
        private Kartu m_mor1= new Kartu();
        private Kartu m_mor2= new Kartu();
        private Kartu m_mor3= new Kartu();

        public Kartu Mortage1
        {
            get { return m_mor1; }
            set { m_mor1 = value; }
        }

        public Kartu Mortage2
        {
            get { return m_mor2; }
            set { m_mor2 = value; }
        }

        public Kartu Mortage3
        {
            get { return m_mor3; }
            set { m_mor3 = value; }
        }

        public int JumlahMortage
        {
            get { return m_jumlahMortage; }
            set { m_jumlahMortage = value; }
        }

        public int skip // Property yang dimiliki pemain untuk mengecheck turn pemain (berada di penjara / terkena kartu skip / player game over / melakukan roll dice)
        {
            set
            {
                if (value > 4 && value < 10)
                    m_skip = 4;
                else if (value > 10)
                    m_skip = 15;
                else if (value < -2)
                    m_skip = -2;
                else
                    m_skip = value;
            }
            get { return m_skip; }
        }


        public int karakter // Property untuk menentukan karakter yang dipilih oleh masing - masing pemain
        {
            set
            {
                m_karakter = value;
            }
            get { return m_karakter; }
        }


        public int posisi //  Property menunjukkan posisi pemain terdapat pada index ke berapa pada array Peta pada Form Peta
        {
            set
            {
                if (value > 23)
                    m_posisi = 0;
                else if (value < 0)
                    m_posisi = 23;
                else
                    m_posisi = value;
            }
            get { return m_posisi; }
        }

        public int uang // Property berisi uang yang dimiliki oleh Pemain
        {
            set { m_uang = value; }
            get
            {
                if (m_uang < 0)
                    return 0;
                else
                    return m_uang;
            }
        }

        public int totalHarta // Property berisi total harta yang dimiliki oleh Pemain
        {
            set { m_totalHarta = value; }
            get
            {
                if (m_totalHarta < 0)
                    return 0;
                else
                    return m_totalHarta;
            }
        }

        public string format() // Property untuk membuat format penulisan di sebelah kiri form Peta (Format urutan pemain)
        {
            string a = "";
            switch (m_karakter)
            {
                case 0: a += "Nama : Eevee \n"; break;
                case 1: a += "Nama : Flareon \n"; break;
                case 2: a += "Nama : Jolteon \n"; break;
                case 3: a += "Nama : Vaporeon \n"; break;
                case 4: a += "Nama : Espeon \n"; break;
                case 5: a += "Nama : Umbreon \n"; break;
                case 6: a += "Nama : Leafeon \n"; break;
                case 7: a += "Nama : Glaceon \n"; break;
                default: break;
            }
            a += "Uang : " + uang + "\n";
            a += "Total Harta : " + totalHarta + "\n";
            return a;
        }

        public Pemain()
        {
            karakter = -1;
        }
        public Pemain(int passkarakter) // Constructor 1 parameter untuk menunjukkan nilai ketika objek Pemain dibuat dengan 1 passing parameter 
        {
            m_karakter = passkarakter;
            m_posisi = 12;
            m_uang = 5000;
            m_totalHarta = 5000;
            m_skip = 0;
            m_kartu1.NamaKartu = RandomKartu();
        }
        public Pemain(int passkarakter,int i) // Constructor 2 parameter untuk menunjukkan nilai ketika objek Pemain dibuat dengan 1 passing parameter 
        {
            m_karakter = passkarakter;
            m_posisi = 12;
            m_uang = 5000;
            m_totalHarta = 5000;
            m_skip = 0;
            m_kartu1.NamaKartu = RandomKartu();
            m_kartu2.NamaKartu = RandomKartu();
        }
        public int RandomKartu()
        {
            Random rnd = new Random();
            int hasil = rnd.Next(1, 11);
            return hasil;
        }
        public string nama() // Method untuk menampilkan urutan pemain yang mana (Contoh : Eevee's Turn!!)
        {
            string a = "";
            switch (m_karakter)
            {
                case 0: a = "Eevee"; break;
                case 1: a = "Flareon"; break;
                case 2: a = "Jolteon"; break;
                case 3: a = "Vaporeon"; break;
                case 4: a = "Espeon"; break;
                case 5: a = "Umbreon"; break;
                case 6: a = "Leafeon"; break;
                case 7: a = "Glaceon"; break;
            }
            return a;
        }
        #endregion

        #region Daiva
        public Kartu Kartu1
        {
            get { return m_kartu1; }
            set { m_kartu1 = value; }
        }

        public Kartu Kartu2
        {
            get { return m_kartu2; }
            set { m_kartu2 = value; }
        }

        public Kartu Kartu3
        {
            get { return m_kartu3; }
            set { m_kartu3 = value; }
        }
        
        public int RollDice() // Method untuk roll dice, bernilai angka 1 - 6
        {
            Random rnd = new Random();
            int hasil = rnd.Next(1, 7);
            return hasil;
        }

        public int Next(int[] selectCharacter, int[] notselectCharacter, int tombol)  // Method untuk memilih karakter yang tidak digunakan dari array notselectedCharacter dari index terkecil
        {
            int temp = selectCharacter[tombol];
            selectCharacter[tombol] = notselectCharacter[0];
            notselectCharacter[0] = temp;

            temp = notselectCharacter[0];
            for (int i = 0; i < 3; i++)
            {
                notselectCharacter[i] = notselectCharacter[i + 1];
                if (i == 2)
                {
                    notselectCharacter[3] = temp;
                }
            }

            return selectCharacter[tombol];
        }

        public int Back(int[] selectCharacter, int[] notselectCharacter, int tombol) // Method untuk memilih karakter yang tidak digunakan dari array notselectedCharacter dari index terbesar
        {
            int temp = selectCharacter[tombol];
            selectCharacter[tombol] = notselectCharacter[3];
            notselectCharacter[3] = temp;

            temp = notselectCharacter[3];
            for (int i = 0; i < 3; i++)
            {
                notselectCharacter[3 - i] = notselectCharacter[2 - i];
                if (i == 2)
                {
                    notselectCharacter[0] = temp;
                }
            }

            return selectCharacter[tombol];
        }
        #endregion

        public bool CheckJumlahKartu()
        {
            int tambah = 0;
            if (Kartu1.NamaKartu != -1)
            {
                tambah++;
            }
            if (Kartu2.NamaKartu != -1)
            {
                tambah++;
            }
            if (Kartu3.NamaKartu != -1)
            {
                tambah++;
            }
            if (tambah == 3)
                return true; // jika true ke form go satu
            else
                return false; // jika false ke form go dua
        }
    }
}
