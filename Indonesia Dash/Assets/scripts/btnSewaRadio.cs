using UnityEngine;
using System.Collections;

public class btnSewaRadio : MonoBehaviour {
    public Sprite radioSewaTrue;
    public Sprite radioSewaFalse;
    public GameObject objectGambar;

    public Sprite balonNormal;
    public Sprite balonLv1;
    public Sprite cancel;
    public GameObject balon;
    public Sprite maxCost;
    public Sprite costNormal;
    public Sprite costLvl1;

    public GameObject balonCost;
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
        if (Database.sewaRadio == false)
        {
            //Database.minPembeliDatang += 5;
            //Database.maxPembeliDatang += 5;
            btnBuy.GetComponent<SpriteRenderer>().sprite = hover;
            balonCost.GetComponent<SpriteRenderer>().sprite = costLvl1; 
        }
        else
        {
            //Database.minPembeliDatang -= 5;
            //Database.maxPembeliDatang -= 5;
            btnBuy.GetComponent<SpriteRenderer>().sprite = hoverU;
            balonCost.GetComponent<SpriteRenderer>().sprite = maxCost;  
        }

        if (Database.sewaRadio == false)
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
        if (Database.sewaRadio == false)
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
        if (Database.sewaRadio == false)
        {
            btnBuy.GetComponent<SpriteRenderer>().sprite = click;
        }
        else
        {
            btnBuy.GetComponent<SpriteRenderer>().sprite = clickU;
        }


        if (Database.sewaRadio == false)
        {
            if (Database.uang <= 200)
            {
                print("Uang Anda Tidak Cukup !");
            }
            else
            {
                Database.uang -= 200;
                Database.sewaRadio = true;
                Database.maxPembeliDatang += 3;
                btnBuy.GetComponent<SpriteRenderer>().sprite = normalU;
                print("1");
            }
        }
        else
        {
            Database.uang += 200;
            Database.sewaRadio = false;
            Database.maxPembeliDatang -= 3;
            btnBuy.GetComponent<SpriteRenderer>().sprite = normal;
            print("1");
        }

        print("Uang Anda Tersisa : " + Database.uang + " Status Sewa Radio : " + Database.sewaRadio);
        //Application.LoadLevel(1);
    }

	// Use this for initialization
	void Start () {
        btnBuy.GetComponent<SpriteRenderer>().sprite = normal;
        //Database.uang = 1000;
        //Database.sewaRadio = false;
        //objectGambar.GetComponent<SpriteRenderer>().sprite = radioFalse;
        btnBuy.GetComponent<Renderer>().enabled = true;

        gameObject.AddComponent<AudioSource>();
        source.clip = sound;
        source.playOnAwake = false;

        if (Database.sewaRadio == false)
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
