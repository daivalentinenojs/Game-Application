using UnityEngine;
using System.Collections;
using System;

public class beliKecepatanMakanan : MonoBehaviour {
    public Sprite makananLV0;
    public Sprite makananLV1;
    public Sprite makananLV2;
    public Sprite makananLV3;
    public GameObject objectGambar;
    public Sprite max;
    public Sprite balonNormal;
    public Sprite balonLv1;
    public Sprite balonLv2;
    public Sprite balonLv3;
    public GameObject balon;

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

        if (Database.upgradeKecepatanMakanan == 0)
        {
            balon.GetComponent<SpriteRenderer>().sprite = balonLv1;
            balonCost.GetComponent<SpriteRenderer>().sprite = costLvl1;  
        }
        else if (Database.upgradeKecepatanMakanan == 1)
        {
            balon.GetComponent<SpriteRenderer>().sprite = balonLv2;
            balonCost.GetComponent<SpriteRenderer>().sprite = costLvl2;  
        }
        else if (Database.upgradeKecepatanMakanan == 2)
        {
            balon.GetComponent<SpriteRenderer>().sprite = balonLv3;
            balonCost.GetComponent<SpriteRenderer>().sprite = costLvl3;  
        }
        else
        {
            balon.GetComponent<SpriteRenderer>().sprite = max;
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

        if (Database.upgradeKecepatanMakanan == 0)
        {
            objectGambar.GetComponent<SpriteRenderer>().sprite = gbrLvl1;
        }
        if (Database.upgradeKecepatanMakanan == 1)
        {
            objectGambar.GetComponent<SpriteRenderer>().sprite = gbrLvl2;
        }
        else if (Database.upgradeKecepatanMakanan == 2)
        {
            objectGambar.GetComponent<SpriteRenderer>().sprite = gbrLvl3;
        }
    }

    void OnMouseDown()
    {
        btnBuy.GetComponent<SpriteRenderer>().sprite = click;
        if (Database.upgradeKecepatanMakanan == 0)
        {
            if (Database.uang <= 13000)
            {
                print("Uang Anda Tidak Cukup !");
            }
            else
            {
                Database.uang -= 13000;
                Database.upgradeKecepatanMakanan++;

                Database.lamaBuatCotoMakassar = new TimeSpan(0, 0, 4);
                Database.lamaPecel = new TimeSpan(0, 0, 6);
                Database.lamaRujak = new TimeSpan(0, 0, 8);

                //Database.kecepatanChef += 0.2f;
                objectGambar.GetComponent<SpriteRenderer>().sprite = gbrLvl1;
                print("1");
            }
        }
        else if (Database.upgradeKecepatanMakanan == 1)
        {
            if (Database.uang <= 14000)
            {
                print("Uang Anda Tidak Cukup !");
            }
            else
            {
                Database.uang -= 14000;
                Database.upgradeKecepatanMakanan++;
                Database.lamaBuatCotoMakassar = new TimeSpan(0, 0, 3);
                Database.lamaPecel = new TimeSpan(0, 0, 5);
                Database.lamaRujak = new TimeSpan(0, 0, 7);
                //Database.kecepatanChef += 0.2f;
                objectGambar.GetComponent<SpriteRenderer>().sprite = gbrLvl2;
                print("2");
            }
        }
        else if (Database.upgradeKecepatanMakanan == 2)
        {
            if (Database.uang <= 15000)
            {
                print("Uang Anda Tidak Cukup !");
            }
            else
            {
                Database.uang -= 15000;
                Database.upgradeKecepatanMakanan++;
                Database.lamaBuatCotoMakassar = new TimeSpan(0, 0, 2);
                Database.lamaPecel = new TimeSpan(0, 0, 4);
                Database.lamaRujak = new TimeSpan(0, 0, 6);
                //Database.kecepatanChef += 0.2f;
                objectGambar.GetComponent<SpriteRenderer>().sprite = gbrLvl3;
                //gameObject.GetComponent<SpriteRenderer>().color = new Color(0.4f, 0.4f, 0.4f);
                print("MAX");
            }
        }
        print("Uang Anda Tersisa : " + Database.uang + " Level Kecepatan Tangan : " + Database.upgradeKecepatanMakanan);
        //Application.LoadLevel(1);
    }

	// Use this for initialization
	void Start () {
        btnBuy.GetComponent<SpriteRenderer>().sprite = normal;
        //Database.uang = 700;
        //Database.upgradeKecepatanMakanan = 0;

        objectGambar.GetComponent<SpriteRenderer>().sprite = gbrLvl1;

        gameObject.AddComponent<AudioSource>();
        source.clip = sound;
        source.playOnAwake = false;
	}
	
	// Update is called once per frame
	void Update () {

	}
}
