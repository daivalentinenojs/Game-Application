using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class Database : MonoBehaviour {
    /*Uang*/
    public static int uang=100000000;

    /*Efek*/
    public static int maxPembeliDatang=100;
    public static int minPembeliDatang=90;
    public static float kecepatanLayanan;
    public static float kecepatanChef;
    public static float kecepatanPelayan = 0.02f;
    public static int kemungkinanGaBeliMakan = 35;
    public static int kemungkinanGaBeliMinum = 35;

    /*Tutorial*/
    public static int urutanTutorial;
    /*Story*/
    public static int urutanStory;

    /*Preparing Day*/
    public static int hargaJualCotoMakassar=15;//1
    public static int hargaJualPecel=20;//2
    public static int hargaJualRujak=30;//3

    public static int hargaJualEsDawet=5;
    public static int hargaJualEsCendol=8;
    public static int hargaJualJamuSinom=10;

    public static int hargaJualRealCotoMakassar=0;
    public static int hargaJualRealPecel=0;
    public static int hargaJualRealRujak=0;

    public static int hargaJualRealEsDawet=0; //1
    public static int hargaJualRealEsCendol=0; //2
    public static int hargaJualRealJamuSinom=0; //3

    public static int jumlahResepSatuCotoMakassarDagingSapi=1;
    public static int jumlahResepDuaCotoMakassarBumbuHalus=1;
    public static int jumlahResepTigaCotoMakassarMinyakGoreng=1;

    public static int jumlahResepSatuPecelNasi=1;
    public static int jumlahResepDuaPecelBumbuPecel=1;
    public static int jumlahResepTigaPecelSayuran=1;

    public static int jumlahResepSatuRujakLontong=1;
    public static int jumlahResepDuaRujakSayuran=1;
    public static int jumlahResepTigaRujakCingur=1;

    public static int jumlahResepSatuEsDawetAir=1;
    public static int jumlahResepDuaEsDawetDawet = 1;
    public static int jumlahResepTigaEsDawetSanten = 1;

    public static int jumlahResepSatuEsCendolAir = 1;
    public static int jumlahResepDuaEsCendolCendol = 1;
    public static int jumlahResepTigaEsCendolSirup = 1;

    public static int jumlahResepSatuJamuSinomAir = 1;
    public static int jumlahResepDuaJamuSinomDaunAsamMuda = 1;
    public static int jumlahResepTigaJamuSinomTemulawak = 1;

    public static int stokDagingSapi = 0;
    public static int stokBumbuHalus = 0;
    public static int stokMinyakGoreng = 0;
    public static int stokNasi = 0;
    public static int stokBumbuPecel = 0;
    public static int stokSayuran = 0;
    public static int stokLontong = 0;
    public static int stokCingur = 0;
    public static int stokAir = 0;
    public static int stokDawet = 0;
    public static int stokSanten = 0;
    public static int stokCendol = 0;
    public static int stokSirup = 0;
    public static int stokDaunAsamMuda = 0;
    public static int stokTemulawak = 0;
    /*Playing Game*/
    public static bool sewaKoran = false;
    public static bool sewaRadio = false;
    public static bool sewaTelevisi = false;
    public static bool hireMarketing = false;
    public static bool hireSinden = false;
    public static bool hireGamelan = false;

    /*Fasilitas*/
    public static int upgradeMeja=0;
    //public static int upgradeKursi=1;

    public static int upgradeBackground=0;
    public static int upgradeLantai=0;
    public static int upgradeMusicPlayer=0;
    public static int upgradeTV=0;
    public static int upgradePendingin=0;
    public static int upgradePigura=0;
    public static int upgradeTanaman=0;
    public static int upgradeSertifikasi=0;

    /*Employee*/
    public static int upgradeKecepatanKaki=0;
    public static int upgradeKecepatanTangan=0;
    public static int upgradeKecepatanMakanan=0;
    public static int upgradeKecepatanMinuman=0;
    public static int upgradeBajuPelayan=0;
    public static int upgradeCelanaPelayan=0;
    
    /*Makanan*/
    public static bool beliResepCotoMakassar=true;//1
    public static int upgradeResepCotoMakassar=1;
    public static int hargaResepCotoMakassar;
    public static bool beliResepPecel=false;//2
    public static int upgradeResepPecel=0;
    public static int hargaResepPecel;
    public static bool beliResepRujak = false;//3
    public static int upgradeResepRujak=0;
    public static int hargaResepRujak;

    public static string[] namamakanan = { "Coto Makassar", "Pecel", "Rujak" };

    /*Minuman*/
    public static bool beliResepEsDawet=true;//1
    public static int upgradeResepEsDawet=1;
    public static int hargaResepEsDawet;
    public static bool beliResepEsCendol = false;//2
    public static int upgradeResepEsCendol=0;
    public static int hargaResepEsCendol;
    public static bool beliResepJamuSinom = false;//3
    public static int upgradeResepJamuSinom=0;
    public static int hargaResepJamuSinom;
    public static string[] namaminuman = { "Es Dawet", "Es Cendol", "Jamu Sinom" };
    public static bool upgradeSinden;
    public static int upgradeChef;

    /* Harga Bahan Baku */
    public static int HRGBahanNasi = 5;
    public static int HRGBahanLontong = 5;
    public static int HRGBahanBumbuHalus = 2;
    public static int HRGBahanBumbuPecel = 3;
    public static int HRGBahanSayuran = 3;
    public static int HRGBahanDagingSapi = 7;
    public static int HRGBahanCingur = 4;
    public static int HRGBahanMinyakGoreng = 1;
    public static int HRGBahanAirPutih = 1;
    public static int HRGBahanDawet = 1;
    public static int HRGBahanCendol = 1;
    public static int HRGBahanSanten = 1;
    public static int HRGBahanSirup = 2;
    public static int HRGBahanDaunAsamMuda = 1;
    public static int HRGBahanTemulawak = 3;

    /* lama waktu minum */
    public static TimeSpan lamaEsDawet = new TimeSpan(0, 0, 2);//1
    public static TimeSpan lamaCendol = new TimeSpan(0, 0, 2);//2
    public static TimeSpan lamaJamuSinom = new TimeSpan(0, 0, 2); //3
    public static TimeSpan[] lamaMinumArray;

    /* lama waktu makan */
    public static TimeSpan lamaCotoMakassar = new TimeSpan(0, 0, 5);//1
    public static TimeSpan lamaPecel = new TimeSpan(0, 0, 7);//2
    public static TimeSpan lamaRujak = new TimeSpan(0, 0, 9); //3
    public static TimeSpan[] lamaMakanArray;

    /* lama buat */
    public static TimeSpan lamaBuatCotoMakassar = new TimeSpan(0, 0, 5);//1
    public static TimeSpan lamaBuatPecel = new TimeSpan(0, 0, 4);//2
    public static TimeSpan lamaBuatRujak = new TimeSpan(0, 0, 3); //3
    public static TimeSpan[] lamaBuatArray;

    /* config */
    public static float kecepatanJalanCust = 0.04f;
    public static int lamaRound = 150;//300s
    public static int jumlahMeja;
    public static bool dayend = false;
    public static bool waktuAbis = false;

    /* waypoints */
    public GameObject[] exitWaypoints;
    public GameObject[] toTableManagerWaypoints;
    public GameObject[] pelayanWaypoints;

    /* game objects */
    public GameObject tableManager;
    public static int orangDiMeja;
    public GameObject entranceManager;

    /* Laporan saves*/
    public static int LapDapetTotalUang;
    public static int[] LapTotalMakananTerjual = new int[3];
    public static int[] LapTotalMinumanTerjual = new int[3];
    public static int LapTotalPembeliDatang;
    public static int LapTotalPembeliGagalBeli;
    public static int LapTotalIncome;

    /* sprites */
    public Sprite jalanKeMeja;
    public Sprite jalanKeTableManager;
    public Sprite sedangDilayani;
	// Use this for initialization
	void Start () {
	    lamaMakanArray=new TimeSpan[3];
        lamaMakanArray[0] = lamaCotoMakassar;
        lamaMakanArray[1] = lamaPecel;
        lamaMakanArray[2] = lamaRujak;

        lamaBuatArray = new TimeSpan[3];
        lamaBuatArray[0] = lamaBuatCotoMakassar;
        lamaBuatArray[1] = lamaBuatPecel;
        lamaBuatArray[2] = lamaBuatRujak;

        lamaMinumArray = new TimeSpan[3];
        lamaMinumArray[0] = lamaEsDawet;
        lamaMinumArray[1] = lamaCendol;
        lamaMinumArray[2] = lamaJamuSinom;
        tableManager = GameObject.Find("tableManager");
        entranceManager = GameObject.Find("entranceManager");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
