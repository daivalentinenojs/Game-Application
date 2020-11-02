using UnityEngine;
using System.Collections;

public class btnHireGamelan : MonoBehaviour {
    public Sprite gamelanTrue;
    public Sprite gamelanFalse;
    public Sprite gamelanSewaTrue;
    public Sprite gamelanSewaFalse;
    public GameObject objectGambar;

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
        if (Database.hireGamelan == false)
        {
            Database.minPembeliDatang += 10;
            Database.maxPembeliDatang += 10;
            btnBuy.GetComponent<SpriteRenderer>().sprite = hover;
        }
        else
        {
            Database.minPembeliDatang -= 10;
            Database.maxPembeliDatang -= 10;
            btnBuy.GetComponent<SpriteRenderer>().sprite = hoverU;
        }

        if (Database.hireGamelan == false)
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
        if (Database.hireGamelan == false)
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
        if (Database.hireGamelan == false)
        {
            btnBuy.GetComponent<SpriteRenderer>().sprite = click;
        }
        else
        {
            btnBuy.GetComponent<SpriteRenderer>().sprite = clickU;
        }

        if (Database.hireGamelan == false)
        {
            if (Database.uang <= 300)
            {
                print("Uang Anda Tidak Cukup !");
            }
            else
            {
                Database.uang -= 300;
                Database.hireGamelan = true;
                Database.minPembeliDatang += 2;
                Database.maxPembeliDatang += 2;
                objectGambar.GetComponent<SpriteRenderer>().sprite = gamelanTrue;
                btnBuy.GetComponent<SpriteRenderer>().sprite = normalU;
                print("1");
            }
        }
        else
        {
            Database.uang += 300;
            Database.hireGamelan = false;
            Database.minPembeliDatang -= 2;
            Database.maxPembeliDatang -= 2;
            objectGambar.GetComponent<SpriteRenderer>().sprite = gamelanFalse;
            btnBuy.GetComponent<SpriteRenderer>().sprite = normal;
            print("1");
        }

        print("Uang Anda Tersisa : " + Database.uang + " Status Sewa gamelan : " + Database.hireGamelan);
        //Application.LoadLevel(1);
    }

	// Use this for initialization
	void Start () {
        btnBuy.GetComponent<SpriteRenderer>().sprite = normal;
        //Database.uang = 1000;
        //Database.hireGamelan = false;
        //objectGambar.GetComponent<SpriteRenderer>().sprite = gamelanFalse;
        btnBuy.GetComponent<Renderer>().enabled = true;

        gameObject.AddComponent<AudioSource>();
        source.clip = sound;
        source.playOnAwake = false;

        if (Database.hireGamelan == false)
        {
            objectGambar.GetComponent<SpriteRenderer>().sprite = gamelanFalse;
            btnBuy.GetComponent<SpriteRenderer>().sprite = normal;
        }
        else
        {
            objectGambar.GetComponent<SpriteRenderer>().sprite = gamelanTrue;
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
