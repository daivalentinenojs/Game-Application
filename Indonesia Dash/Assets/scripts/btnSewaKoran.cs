﻿using UnityEngine;
using System.Collections;

public class btnSewaKoran : MonoBehaviour {

    public Sprite koranTrue;
    public Sprite koranFalse;
    public Sprite koranSewaTrue;
    public Sprite koranSewaFalse;
    public GameObject objectGambar;
    public Sprite maxCost;
    public Sprite costNormal;
    public Sprite costLvl1;

    public GameObject balonCost;
    public Sprite balonNormal;
    public Sprite balonLv1;
    public Sprite cancel;
    public GameObject balon;

    public GameObject btnBuy;
    public Sprite normal;
    public Sprite hover;
    public Sprite click;

    public Sprite normalU;
    public Sprite hoverU;
    public Sprite clickU;

    public AudioClip sound;

    private AudioSource source { get { return GetComponent<AudioSource>(); } }

    void OnMouseEnter()
    {
        if (Database.sewaKoran == false)
        {
            btnBuy.GetComponent<SpriteRenderer>().sprite = hover;
            balonCost.GetComponent<SpriteRenderer>().sprite = costLvl1; 
        }
        else
        {
            btnBuy.GetComponent<SpriteRenderer>().sprite = hoverU;
            balonCost.GetComponent<SpriteRenderer>().sprite = maxCost;  
        }

        if (Database.sewaKoran == false)
        {
            balon.GetComponent<SpriteRenderer>().sprite = balonLv1;
        }
        else
        {
            balon.GetComponent<SpriteRenderer>().sprite = cancel;
        }

        source.PlayOneShot(sound);
    }

    void OnMouseExit()
    {
        balon.GetComponent<SpriteRenderer>().sprite = balonNormal;
        balonCost.GetComponent<SpriteRenderer>().sprite = costNormal;  
        if (Database.sewaKoran == false)
        {
            btnBuy.GetComponent<SpriteRenderer>().sprite = normal;
        }
        else
        {
            btnBuy.GetComponent<SpriteRenderer>().sprite = normalU;
        }
    }

    void OnMouseDown()
    {
        if (Database.sewaKoran == false)
        {
            Database.minPembeliDatang += 2;
            Database.maxPembeliDatang += 2;
            btnBuy.GetComponent<SpriteRenderer>().sprite = click;
        }
        else
        {
            Database.minPembeliDatang -= 2;
            Database.maxPembeliDatang -= 2;
            btnBuy.GetComponent<SpriteRenderer>().sprite = clickU;
        }


        if (Database.sewaKoran == false)
        {
            if (Database.uang <= 150)
            {
                print("Uang Anda Tidak Cukup !");
            }
            else
            {
                Database.uang -= 150;
                Database.sewaKoran = true;
                Database.minPembeliDatang += 3;
                btnBuy.GetComponent<SpriteRenderer>().sprite = normalU;
                print("1");
            }
        }
        else
        {
            Database.uang += 150;
            Database.sewaKoran = false;
            Database.minPembeliDatang -= 3;
            btnBuy.GetComponent<SpriteRenderer>().sprite = normal;
            print("1");
        }
      
        print("Uang Anda Tersisa : " + Database.uang + " Status Sewa Koran : " + Database.sewaKoran);
        //Application.LoadLevel(1);
    }

	// Use this for initialization
	void Start () {
        btnBuy.GetComponent<SpriteRenderer>().sprite = normal;
        //Database.uang = 1000;
        //Database.sewaKoran = false;
        //objectGambar.GetComponent<SpriteRenderer>().sprite = koranFalse;
        btnBuy.GetComponent<Renderer>().enabled = true;

        gameObject.AddComponent<AudioSource>();
        source.clip = sound;
        source.playOnAwake = false;

        if (Database.sewaKoran == false)
        {
            btnBuy.GetComponent<SpriteRenderer>().sprite = normal;
        }
        else
        {
            btnBuy.GetComponent<SpriteRenderer>().sprite = normalU;
        }
	}

    void PlaySound()
    {
        source.PlayOneShot(sound);
    }

	// Update is called once per frame
	void Update () {
	
	}
}
