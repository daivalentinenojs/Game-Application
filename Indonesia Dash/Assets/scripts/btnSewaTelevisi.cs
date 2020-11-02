using UnityEngine;
using System.Collections;

public class btnSewaTelevisi : MonoBehaviour {
    public Sprite televisiTrue;
    public Sprite televisiFalse;
    public Sprite televisiSewaTrue;
    public Sprite televisiSewaFalse;
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
        if (Database.sewaTelevisi == false)
        {
            //Database.minPembeliDatang += 7;
            //Database.maxPembeliDatang += 7;
            btnBuy.GetComponent<SpriteRenderer>().sprite = hover;
            balonCost.GetComponent<SpriteRenderer>().sprite = costLvl1; 
        }
        else
        {
            //Database.minPembeliDatang -= 7;
            //Database.maxPembeliDatang -= 7;
            btnBuy.GetComponent<SpriteRenderer>().sprite = hoverU;
            balonCost.GetComponent<SpriteRenderer>().sprite = maxCost;  
        }

        if (Database.sewaTelevisi == false)
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
        if (Database.sewaTelevisi == false)
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
        if (Database.sewaTelevisi == false)
        {
            btnBuy.GetComponent<SpriteRenderer>().sprite = click;
        }
        else
        {
            btnBuy.GetComponent<SpriteRenderer>().sprite = clickU;
        }


        if (Database.sewaTelevisi == false)
        {
            if (Database.uang <= 300)
            {
                print("Uang Anda Tidak Cukup !");
            }
            else
            {
                Database.uang -= 300;
                Database.sewaTelevisi = true;
                Database.minPembeliDatang += 2;
                Database.maxPembeliDatang += 2;
                btnBuy.GetComponent<SpriteRenderer>().sprite = normalU;
                print("1");
            }
        }
        else
        {
            Database.uang += 300;
            Database.sewaTelevisi = false;
            Database.minPembeliDatang -= 2;
            Database.maxPembeliDatang -= 2;
            btnBuy.GetComponent<SpriteRenderer>().sprite = normal;
            print("1");
        }

        print("Uang Anda Tersisa : " + Database.uang + " Status Sewa Televisi : " + Database.sewaTelevisi);
        //Application.LoadLevel(1);
    }

	// Use this for initialization
	void Start () {
        btnBuy.GetComponent<SpriteRenderer>().sprite = normal;
        //Database.uang = 1000;
        //Database.sewaTelevisi = false;
        //objectGambar.GetComponent<SpriteRenderer>().sprite = televisiFalse;
        btnBuy.GetComponent<Renderer>().enabled = true;

        gameObject.AddComponent<AudioSource>();
        source.clip = sound;
        source.playOnAwake = false;

        if (Database.sewaTelevisi == false)
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
