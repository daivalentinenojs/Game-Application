using UnityEngine;
using System.Collections;

public class beliSertifikasi : MonoBehaviour {
    public Sprite sertifikasiLV0;
    public Sprite sertifikasiLV1;
    public Sprite sertifikasiLV2;
    public Sprite sertifikasiLV3;
    public GameObject objectGambar;
    public Sprite max;
    public Sprite balonNormal;
    public Sprite balonLv1;
    public Sprite balonLv2;
    public Sprite balonLv3;
    public GameObject balon;
    public Sprite Win;
    public Sprite ULvl1;
    public Sprite ULvl2;
    public Sprite ULvl3;
    public Sprite maxCost;
    public Sprite costNormal;
    public Sprite costLvl1;
    public Sprite costLvl2;
    public Sprite costLvl3;

    public GameObject balonCost;
    public Sprite gbrLvl1;
    public Sprite gbrLvl2;
    public Sprite gbrLvl3;

    public GameObject btnBuy;
    public Sprite normal;
    public Sprite hover;
    public Sprite click;

    public AudioClip sound;

    private AudioSource source { get { return GetComponent<AudioSource>(); } }

    void OnMouseEnter()
    {
        btnBuy.GetComponent<SpriteRenderer>().sprite = hover;
        source.PlayOneShot(sound);

        if (Database.upgradeSertifikasi == 0)
        {
            balon.GetComponent<SpriteRenderer>().sprite = balonLv1;
            balonCost.GetComponent<SpriteRenderer>().sprite = costLvl1;  
        }
        else if (Database.upgradeSertifikasi == 1)
        {
            balon.GetComponent<SpriteRenderer>().sprite = balonLv2;
            balonCost.GetComponent<SpriteRenderer>().sprite = costLvl2;  
        }
        else if (Database.upgradeSertifikasi == 2)
        {
            balon.GetComponent<SpriteRenderer>().sprite = balonLv3;
            balonCost.GetComponent<SpriteRenderer>().sprite = costLvl3;  
        }
        else
        {
            balon.GetComponent<SpriteRenderer>().sprite = max;
            balonCost.GetComponent<SpriteRenderer>().sprite = maxCost;  
        }
    }

    void PlaySound()
    {
        source.PlayOneShot(sound);
    }

    void OnMouseExit()
    {
        balon.GetComponent<SpriteRenderer>().sprite = balonNormal;
        balonCost.GetComponent<SpriteRenderer>().sprite = costNormal;  
        btnBuy.GetComponent<SpriteRenderer>().sprite = normal;

        if (Database.upgradeSertifikasi == 0)
        {
            objectGambar.GetComponent<SpriteRenderer>().sprite = gbrLvl1;
        }
        if (Database.upgradeSertifikasi == 1)
        {
            objectGambar.GetComponent<SpriteRenderer>().sprite = gbrLvl2;
        }
        else if (Database.upgradeSertifikasi == 2)
        {
            objectGambar.GetComponent<SpriteRenderer>().sprite = gbrLvl3;
        }
    }

    void OnMouseDown()
    {
        btnBuy.GetComponent<SpriteRenderer>().sprite = click;
        if (Database.upgradeBackground == 1 && Database.upgradeMusicPlayer == 1 && Database.upgradeLantai == 1 && Database.upgradeTV == 1 &&
            Database.upgradePigura == 1 && Database.upgradeMeja == 1 && Database.upgradeTanaman == 1 &&
            Database.upgradeSertifikasi != 1 &&
            Database.upgradeKecepatanTangan == 1 && Database.upgradeKecepatanTangan == 1 && Database.upgradeBajuPelayan == 1 &&
            Database.upgradeCelanaPelayan == 1 && Database.upgradeKecepatanMakanan == 1 && Database.upgradeKecepatanMinuman == 1 &&
            Database.upgradeResepCotoMakassar == 1 && Database.upgradeResepEsCendol == 1 && Database.upgradeResepEsDawet == 1 &&
            Database.upgradeResepJamuSinom == 1 && Database.upgradeResepPecel == 1 && Database.upgradeResepRujak == 1)
        {
            print("A");
            if (Database.upgradeSertifikasi == 0)
            {
                if (Database.uang <= 50000)
                {
                    print("Uang Anda Tidak Cukup !");
                }
                else
                {
                    Database.uang -= 50000;
                    Database.upgradeSertifikasi++;
                    Database.minPembeliDatang += 5;
                    Database.kecepatanLayanan += 0.02f;
                    objectGambar.GetComponent<SpriteRenderer>().sprite = gbrLvl1;
                    print("1");
                }
            }
        }
        else if (Database.upgradeBackground < 1 || Database.upgradeMusicPlayer < 1 || Database.upgradeLantai < 1 || Database.upgradeTV < 1 ||
            Database.upgradePigura < 1 || Database.upgradeMeja < 1 || Database.upgradeTanaman < 1 || 
            Database.upgradeKecepatanTangan < 1 || Database.upgradeKecepatanTangan < 1 || Database.upgradeBajuPelayan < 1 ||
            Database.upgradeCelanaPelayan < 1 || Database.upgradeKecepatanMakanan < 1 || Database.upgradeKecepatanMinuman < 1 ||
            Database.upgradeResepCotoMakassar < 1 || Database.upgradeResepEsCendol < 1 || Database.upgradeResepEsDawet < 1 ||
            Database.upgradeResepJamuSinom < 1 || Database.upgradeResepPecel < 1 || Database.upgradeResepRujak < 1)
        {
            print("B");
            balon.GetComponent<SpriteRenderer>().sprite = ULvl1;
        }
        else if (Database.upgradeBackground == 2 && Database.upgradeMusicPlayer == 2 && Database.upgradeLantai == 2 && Database.upgradeTV == 2 &&
            Database.upgradePigura == 2 && Database.upgradeMeja == 2 && Database.upgradeTanaman == 2 && 
            Database.upgradeSertifikasi != 2 &&
            Database.upgradeKecepatanTangan == 2 && Database.upgradeKecepatanTangan == 2 && Database.upgradeBajuPelayan == 2 &&
            Database.upgradeCelanaPelayan == 2 && Database.upgradeKecepatanMakanan == 2 && Database.upgradeKecepatanMinuman == 2 &&
            Database.upgradeResepCotoMakassar == 2 && Database.upgradeResepEsCendol == 2 && Database.upgradeResepEsDawet == 2 &&
            Database.upgradeResepJamuSinom == 2 && Database.upgradeResepPecel == 2 && Database.upgradeResepRujak == 2)
        {
            print("C");
            if (Database.upgradeSertifikasi == 1)
            {
                if (Database.uang <= 100000)
                {
                    print("Uang Anda Tidak Cukup !");
                }
                else
                {
                    Database.uang -= 100000;
                    Database.upgradeSertifikasi++;
                    Database.maxPembeliDatang += 8;
                    Database.kecepatanChef += 0.02f;
                    objectGambar.GetComponent<SpriteRenderer>().sprite = gbrLvl2;
                    print("2");
                }
            }
        }
        else if (Database.upgradeBackground < 2 || Database.upgradeMusicPlayer < 2 || Database.upgradeLantai < 2 || Database.upgradeTV < 2 ||
        Database.upgradePigura < 2 || Database.upgradeMeja < 2 || Database.upgradeTanaman < 2 || 
            Database.upgradeKecepatanTangan < 2 || Database.upgradeKecepatanTangan < 2 || Database.upgradeBajuPelayan < 2 ||
            Database.upgradeCelanaPelayan < 2 || Database.upgradeKecepatanMakanan < 2 || Database.upgradeKecepatanMinuman < 2 ||
            Database.upgradeResepCotoMakassar < 2 || Database.upgradeResepEsCendol < 2 || Database.upgradeResepEsDawet < 2 ||
            Database.upgradeResepJamuSinom < 2 || Database.upgradeResepPecel < 2 || Database.upgradeResepRujak < 2)
        {
            print("D");
            balon.GetComponent<SpriteRenderer>().sprite = ULvl2;
        }
        else if (Database.upgradeBackground == 3 && Database.upgradeMusicPlayer == 3 && Database.upgradeLantai == 3 && Database.upgradeTV == 3 &&
            Database.upgradePigura == 3 && Database.upgradeMeja == 3 && Database.upgradeTanaman == 3 &&
            Database.upgradeSertifikasi != 3 &&
            Database.upgradeKecepatanTangan == 3 && Database.upgradeKecepatanTangan == 3 && Database.upgradeBajuPelayan == 3 &&
            Database.upgradeCelanaPelayan == 3 && Database.upgradeKecepatanMakanan == 3 && Database.upgradeKecepatanMinuman == 3 &&
            Database.upgradeResepCotoMakassar == 3 && Database.upgradeResepEsCendol == 3 && Database.upgradeResepEsDawet == 3 &&
            Database.upgradeResepJamuSinom == 3 && Database.upgradeResepPecel == 3 && Database.upgradeResepRujak == 3)
        {
            print("E");
            if (Database.upgradeSertifikasi == 2)
            {
                if (Database.uang <= 200000)
                {
                    print("Uang Anda Tidak Cukup !");
                }
                else
                {
                    Database.uang -= 200000;
                    Database.upgradeSertifikasi++;
                    Database.minPembeliDatang += 10;
                    Database.maxPembeliDatang += 10;
                    objectGambar.GetComponent<SpriteRenderer>().sprite = gbrLvl3;
                    //gameObject.GetComponent<SpriteRenderer>().color = new Color(0.4f, 0.4f, 0.4f);
                    print("MAX");
                }
            }
        }
        else if (Database.upgradeBackground < 3 || Database.upgradeMusicPlayer < 3 || Database.upgradeLantai < 3 || Database.upgradeTV < 3 ||
        Database.upgradePigura < 3 || Database.upgradeMeja < 3 || Database.upgradeTanaman < 3 ||
             Database.upgradeKecepatanTangan < 3 || Database.upgradeKecepatanTangan < 3 || Database.upgradeBajuPelayan < 3 ||
            Database.upgradeCelanaPelayan < 3 || Database.upgradeKecepatanMakanan < 3 || Database.upgradeKecepatanMinuman < 3 ||
            Database.upgradeResepCotoMakassar < 3 || Database.upgradeResepEsCendol < 3 || Database.upgradeResepEsDawet < 3 ||
            Database.upgradeResepJamuSinom < 3 || Database.upgradeResepPecel < 3 || Database.upgradeResepRujak < 3)
        {
            print("F");
            balon.GetComponent<SpriteRenderer>().sprite = ULvl3;
        }
        else
        {
            balon.GetComponent<SpriteRenderer>().sprite = Win;
        }
        print("Uang Anda Tersisa : " + Database.uang + " Level Sertifikasi : " + Database.upgradeSertifikasi);
        //Application.LoadLevel(1);
    }

	// Use this for initialization
	void Start () {
        btnBuy.GetComponent<SpriteRenderer>().sprite = normal;
        //Database.uang = 700;
        //Database.upgradeSertifikasi = 0;

        objectGambar.GetComponent<SpriteRenderer>().sprite = gbrLvl1;
        gameObject.AddComponent<AudioSource>();
        source.clip = sound;
        source.playOnAwake = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
