using UnityEngine;
using System.Collections;

public class btnHireMarketing : MonoBehaviour {
    public Sprite marketingTrue;
    public Sprite marketingFalse;
    public Sprite marketingSewaTrue;
    public Sprite marketingSewaFalse;
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
        if (Database.hireMarketing == false)
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

        if (Database.hireMarketing == false)
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
        if (Database.hireMarketing == false)
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
        if (Database.hireMarketing == false)
        {
            btnBuy.GetComponent<SpriteRenderer>().sprite = click;
        }
        else
        {
            btnBuy.GetComponent<SpriteRenderer>().sprite = clickU;
        }

        if (Database.hireMarketing == false)
        {
            if (Database.uang <= 200)
            {
                print("Uang Anda Tidak Cukup !");
            }
            else
            {
                Database.uang -= 200;
                Database.hireMarketing = true;
                Database.maxPembeliDatang += 2;
                btnBuy.GetComponent<SpriteRenderer>().sprite = normalU;
                print("1");
            }
        }
        else
        {
            Database.uang += 200;
            Database.hireMarketing = false;
            Database.maxPembeliDatang -= 2;
            btnBuy.GetComponent<SpriteRenderer>().sprite = normal;
            print("1");
        }

        print("Uang Anda Tersisa : " + Database.uang + " Status Sewa marketing : " + Database.hireMarketing);
        //Application.LoadLevel(1);
    }

	// Use this for initialization
	void Start () {
        btnBuy.GetComponent<SpriteRenderer>().sprite = normal;
        //Database.uang = 1000;
        //Database.hireMarketing = false;
        //objectGambar.GetComponent<SpriteRenderer>().sprite = marketingFalse;
        btnBuy.GetComponent<Renderer>().enabled = true;

        gameObject.AddComponent<AudioSource>();
        source.clip = sound;
        source.playOnAwake = false;

        if (Database.hireMarketing == false)
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
