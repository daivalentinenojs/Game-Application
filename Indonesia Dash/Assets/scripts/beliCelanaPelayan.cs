using UnityEngine;
using System.Collections;

public class beliCelanaPelayan : MonoBehaviour {
    public Sprite celanaLV0;
    public Sprite celanaLV1;
    public Sprite celanaLV2;
    public Sprite celanaLV3;
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

        if (Database.upgradeCelanaPelayan == 0)
        {
            balon.GetComponent<SpriteRenderer>().sprite = balonLv1;
            balonCost.GetComponent<SpriteRenderer>().sprite = costLvl1;  
        }
        else if (Database.upgradeCelanaPelayan == 1)
        {
            balon.GetComponent<SpriteRenderer>().sprite = balonLv2;
            balonCost.GetComponent<SpriteRenderer>().sprite = costLvl2;  
        }
        else if (Database.upgradeCelanaPelayan == 2)
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

        if (Database.upgradeCelanaPelayan == 0)
        {
            objectGambar.GetComponent<SpriteRenderer>().sprite = gbrLvl1;
        }
        if (Database.upgradeCelanaPelayan == 1)
        {
            objectGambar.GetComponent<SpriteRenderer>().sprite = gbrLvl2;
        }
        else if (Database.upgradeCelanaPelayan == 2)
        {
            objectGambar.GetComponent<SpriteRenderer>().sprite = gbrLvl3;
        }
    }
    void OnMouseDown()
    {
        btnBuy.GetComponent<SpriteRenderer>().sprite = click;
        if (Database.upgradeCelanaPelayan == 0)
        {
            if (Database.uang <= 1500)
            {
                print("Uang Anda Tidak Cukup !");
            }
            else
            {
                Database.uang -= 1500;
                Database.upgradeCelanaPelayan++;
                Database.kecepatanLayanan += 0.2f;
                objectGambar.GetComponent<SpriteRenderer>().sprite = gbrLvl1;
                print("1");
            }
        }
        else if (Database.upgradeCelanaPelayan == 1)
        {
            if (Database.uang <= 3000)
            {
                print("Uang Anda Tidak Cukup !");
            }
            else
            {
                Database.uang -= 3000;
                Database.upgradeCelanaPelayan++;
                Database.kecepatanLayanan += 0.2f;
                objectGambar.GetComponent<SpriteRenderer>().sprite = gbrLvl2;
                print("2");
            }
        }
        else if (Database.upgradeCelanaPelayan == 2)
        {
            if (Database.uang <= 5000)
            {
                print("Uang Anda Tidak Cukup !");
            }
            else
            {
                Database.uang -= 5000;
                Database.upgradeCelanaPelayan++;
                Database.kecepatanLayanan += 0.2f;
                objectGambar.GetComponent<SpriteRenderer>().sprite = gbrLvl3;
                //gameObject.GetComponent<SpriteRenderer>().color = new Color(0.4f, 0.4f, 0.4f);
                print("MAX");
            }
        }
        print("Uang Anda Tersisa : " + Database.uang + " Level Celana Pelayan : " + Database.upgradeCelanaPelayan);
        //Application.LoadLevel(1);
    }

	// Use this for initialization
	void Start () {
        btnBuy.GetComponent<SpriteRenderer>().sprite = normal;
        //Database.uang = 700;
        //Database.upgradeCelanaPelayan = 0;

        objectGambar.GetComponent<SpriteRenderer>().sprite = gbrLvl1;

        gameObject.AddComponent<AudioSource>();
        source.clip = sound;
        source.playOnAwake = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
