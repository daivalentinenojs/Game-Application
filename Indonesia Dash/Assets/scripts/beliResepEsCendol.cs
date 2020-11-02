using UnityEngine;
using System.Collections;

public class beliResepEsCendol : MonoBehaviour {
    public Sprite esCendolLV0;
    public Sprite esCendolLV1;
    public Sprite esCendolLV2;
    public Sprite esCendolLV3;
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
    public Sprite maxBeli;
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

        if (Database.upgradeResepEsCendol == 0)
        {
            balon.GetComponent<SpriteRenderer>().sprite = balonLv1;
            balonCost.GetComponent<SpriteRenderer>().sprite = costLvl1; 
        }
        else if (Database.upgradeResepEsCendol == 1)
        {
            balon.GetComponent<SpriteRenderer>().sprite = balonLv2;
            balonCost.GetComponent<SpriteRenderer>().sprite = costLvl2; 
        }
        else if (Database.upgradeResepEsCendol == 2)
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

        if (Database.upgradeResepEsCendol == 0)
        {
            objectGambar.GetComponent<SpriteRenderer>().sprite = gbrLvl1;
        }
        if (Database.upgradeResepEsCendol == 1)
        {
            objectGambar.GetComponent<SpriteRenderer>().sprite = gbrLvl2;
        }
        else if (Database.upgradeResepEsCendol == 2)
        {
            objectGambar.GetComponent<SpriteRenderer>().sprite = gbrLvl3;
        }
    }

    void OnMouseDown()
    {
        btnBuy.GetComponent<SpriteRenderer>().sprite = click;
        if (Database.upgradeResepEsCendol == 0 && Database.beliResepEsCendol == false)
        {
            if (Database.uang <= 20000)
            {
                print("Uang Anda Tidak Cukup !");
            }
            else
            {
                Database.uang -= 20000;
                Database.beliResepEsCendol = true;
                Database.upgradeResepEsCendol++;
                Database.hargaJualEsCendol += 8;
                objectGambar.GetComponent<SpriteRenderer>().sprite = gbrLvl1;
                print("0");
            }
        }
        else if (Database.upgradeResepEsCendol == 1 && Database.beliResepEsCendol == true)
        {
            if (Database.uang <= 40000)
            {
                print("Uang Anda Tidak Cukup !");
            }
            else
            {
                Database.uang -= 40000;
                Database.beliResepEsCendol = true;
                Database.upgradeResepEsCendol++;
                Database.hargaJualEsCendol += 8;
                objectGambar.GetComponent<SpriteRenderer>().sprite = gbrLvl2;
                print("1");
            }
        }
        else if (Database.upgradeResepEsCendol == 2 && Database.beliResepEsCendol == true)
        {
            if (Database.uang <= 60000)
            {
                print("Uang Anda Tidak Cukup !");
            }
            else
            {
                Database.uang -= 60000;
                Database.upgradeResepEsCendol++;
                Database.hargaJualEsCendol += 8;
                objectGambar.GetComponent<SpriteRenderer>().sprite = maxBeli;
                print("MAX");
            }
        }
        
        print("Uang Anda Tersisa : " + Database.uang + " Level Es Cendol : " + Database.upgradeResepEsCendol);
        //Application.LoadLevel(1);
    }

	// Use this for initialization
	void Start () {
        btnBuy.GetComponent<SpriteRenderer>().sprite = normal;
        //Database.uang = 700;
        //Database.upgradeResepCotoMakassar = 1;
        //Database.upgradeResepEsCendol = 1;
        //Database.upgradeResepPecel = 0;
        //Database.upgradeResepRujak = 0;
        //Database.upgradeResepEsDawet = 0;
        //Database.upgradeResepJamuSinom = 0;
        //Database.beliResepCotoMakassar = true;
        //Database.beliResepPecel = false;
        //Database.beliResepRujak = false;
        //Database.beliResepEsCendol = true;
        //Database.beliResepEsDawet = false;
        //Database.beliResepJamuSinom = false;

        objectGambar.GetComponent<SpriteRenderer>().sprite = gbrLvl1;

        gameObject.AddComponent<AudioSource>();
        source.clip = sound;
        source.playOnAwake = false;
	}
	
	// Update is called once per frame
	void Update () {
       
	}
}
