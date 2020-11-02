using UnityEngine;
using System.Collections;
using System;
public class exitBaru : MonoBehaviour {

    public GameObject btnBack;
    public Sprite normal;
    public Sprite hover;
    public Sprite click;

    public AudioClip sound;

    private AudioSource source { get { return GetComponent<AudioSource>(); } }

    void OnMouseEnter()
    {
        btnBack.GetComponent<SpriteRenderer>().sprite = hover;
        source.PlayOneShot(sound);
    }

    void OnMouseExit()
    {
        btnBack.GetComponent<SpriteRenderer>().sprite = normal;
    }

    void OnMouseDown()
    {
        btnBack.GetComponent<SpriteRenderer>().sprite = click;
        Database.uang = 100000;
        /*Efek*/
        Database.maxPembeliDatang=100;
        Database.minPembeliDatang=90;
        Database.kecepatanPelayan = 0.02f;
        Database.kemungkinanGaBeliMakan = 35;

        /*Preparing Day*/
        Database.hargaJualCotoMakassar=15;//1
        Database.hargaJualPecel=20;//2
        Database.hargaJualRujak=30;//3

        Database.hargaJualEsDawet=5;
        Database.hargaJualEsCendol=8;
        Database.hargaJualJamuSinom=10;

        Database.hargaJualRealCotoMakassar=0;
        Database.hargaJualRealPecel=0;
        Database.hargaJualRealRujak=0;

        Database.hargaJualRealEsDawet=0; //1
        Database.hargaJualRealEsCendol=0; //2
        Database.hargaJualRealJamuSinom=0; //3

        Database.jumlahResepSatuCotoMakassarDagingSapi=1;
        Database.jumlahResepDuaCotoMakassarBumbuHalus=1;
        Database.jumlahResepTigaCotoMakassarMinyakGoreng=1;

        Database.jumlahResepSatuPecelNasi=1;
        Database.jumlahResepDuaPecelBumbuPecel=1;
        Database.jumlahResepTigaPecelSayuran=1;

        Database.jumlahResepSatuRujakLontong=1;
        Database.jumlahResepDuaRujakSayuran=1;
        Database.jumlahResepTigaRujakCingur=1;

        Database.jumlahResepSatuEsDawetAir=1;
        Database.jumlahResepDuaEsDawetDawet = 1;
        Database.jumlahResepTigaEsDawetSanten = 1;

        Database.jumlahResepSatuEsCendolAir = 1;
        Database.jumlahResepDuaEsCendolCendol = 1;
        Database.jumlahResepTigaEsCendolSirup = 1;

        Database.jumlahResepSatuJamuSinomAir = 1;
        Database.jumlahResepDuaJamuSinomDaunAsamMuda = 1;
        Database.jumlahResepTigaJamuSinomTemulawak = 1;

        Database.stokDagingSapi = 0;
        Database.stokBumbuHalus = 0;
        Database.stokMinyakGoreng = 0;
        Database.stokNasi = 0;
        Database.stokBumbuPecel = 0;
        Database.stokSayuran = 0;
        Database.stokLontong = 0;
        Database.stokCingur = 0;
        Database.stokAir = 0;
        Database.stokDawet = 0;
        Database.stokSanten = 0;
        Database.stokCendol = 0;
        Database.stokSirup = 0;
        Database.stokDaunAsamMuda = 0;
        Database.stokTemulawak = 0;
        /*Playing Game*/
        Database.sewaKoran = false;
        Database.sewaRadio = false;
        Database.sewaTelevisi = false;
        Database.hireMarketing = false;
        Database.hireSinden = false;
        Database.hireGamelan = false;

        /*Fasilitas*/
        Database.upgradeMeja=0;
        //Database.upgradeKursi=1;

        Database.upgradeBackground=0;
        Database.upgradeLantai=0;
        Database.upgradeMusicPlayer=0;
        Database.upgradeTV=0;
        Database.upgradePendingin=0;
        Database.upgradePigura=0;
        Database.upgradeTanaman=0;
        Database.upgradeSertifikasi=0;

        /*Employee*/
        Database.upgradeKecepatanKaki=0;
        Database.upgradeKecepatanTangan=0;
        Database.upgradeKecepatanMakanan=0;
        Database.upgradeKecepatanMinuman=0;
        Database.upgradeBajuPelayan=0;
        Database.upgradeCelanaPelayan=0;
    
        /*Makanan*/
        Database.beliResepCotoMakassar=true;//1
        Database.upgradeResepCotoMakassar=1;
        Database.beliResepPecel=false;//2
        Database.upgradeResepPecel=0;
        Database.beliResepRujak = false;//3
        Database.upgradeResepRujak=0;

        /*Minuman*/
        Database.beliResepEsDawet=true;//1
        Database.upgradeResepEsDawet=1;
        Database.beliResepEsCendol = false;//2
        Database.upgradeResepEsCendol=0;
        Database.beliResepJamuSinom = false;//3
        Database.upgradeResepJamuSinom=0;

        /* Harga Bahan Baku */
        Database.HRGBahanNasi = 5;
        Database.HRGBahanLontong = 5;
        Database.HRGBahanBumbuHalus = 2;
        Database.HRGBahanBumbuPecel = 3;
        Database.HRGBahanSayuran = 3;
        Database.HRGBahanDagingSapi = 7;
        Database.HRGBahanCingur = 4;
        Database.HRGBahanMinyakGoreng = 1;
        Database.HRGBahanAirPutih = 1;
        Database.HRGBahanDawet = 1;
        Database.HRGBahanCendol = 1;
        Database.HRGBahanSanten = 1;
        Database.HRGBahanSirup = 2;
        Database.HRGBahanDaunAsamMuda = 1;
        Database.HRGBahanTemulawak = 3;

        Database.lamaEsDawet = new TimeSpan(0, 0, 2);
        Database.lamaCendol = new TimeSpan(0, 0, 2);
        Database.lamaJamuSinom = new TimeSpan(0, 0, 2);

        Database.lamaCotoMakassar = new TimeSpan(0, 0, 5);//1
        Database.lamaPecel = new TimeSpan(0, 0, 7);//2
        Database.lamaRujak = new TimeSpan(0, 0, 9); //3

        /* lama buat */
    Database.lamaBuatCotoMakassar = new TimeSpan(0, 0, 5);//1
    Database.lamaBuatPecel = new TimeSpan(0, 0, 4);//2
    Database.lamaBuatRujak = new TimeSpan(0, 0, 3); //3

    /* config */
    Database.kecepatanJalanCust = 0.04f;
    Database.lamaRound = 300;//300s
        Database.jumlahMeja = 4;
    Database.dayend = false;
    Database.waktuAbis = false;

        Database.upgradeSinden = false;
        Database.upgradeChef = 0;
        Database.kecepatanLayanan = 0.02f;
        Database.hargaResepEsDawet=0;
        Database.hargaResepEsCendol = 0;
        Database.hargaResepJamuSinom = 0;
        Database.LapDapetTotalUang = 0;
        Database.LapTotalMakananTerjual = new int[3];
        Database.LapTotalMinumanTerjual = new int[3];
        Database.LapTotalPembeliDatang = 0;
        Database.LapTotalPembeliGagalBeli = 0;
        Database.LapTotalIncome = 0;
        Database.LapTotalMakananTerjual = new int[3];
        Database.LapTotalMinumanTerjual = new int[3];

        Application.LoadLevel(0);
    }
	// Use this for initialization
	void Start () {
        btnBack.GetComponent<SpriteRenderer>().sprite = normal;
        //a = Database.urutanTutorial;
        //Database.urutanTutorial = a;

        gameObject.AddComponent<AudioSource>();
        source.clip = sound;
        source.playOnAwake = false;
	}

    void PlaySound()
    {
        source.PlayOneShot(sound);
    }

	// Update is called once per frame
	void Update () {
	
	}
}
