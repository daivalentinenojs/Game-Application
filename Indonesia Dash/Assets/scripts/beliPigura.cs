using UnityEngine;
using System.Collections;

public class beliPigura : MonoBehaviour {
    public Sprite piguraLV0;
    public Sprite piguraLV1;
    public Sprite piguraLV2;
    public Sprite piguraLV3;
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

        if (Database.upgradePigura == 0)
        {
            balon.GetComponent<SpriteRenderer>().sprite = balonLv1;
            balonCost.GetComponent<SpriteRenderer>().sprite = costLvl1;  
        }
        else if (Database.upgradePigura == 1)
        {
            balon.GetComponent<SpriteRenderer>().sprite = balonLv2;
            balonCost.GetComponent<SpriteRenderer>().sprite = costLvl2; 
        }
        else if (Database.upgradePigura == 2)
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

        if (Database.upgradePigura == 0)
        {
            objectGambar.GetComponent<SpriteRenderer>().sprite = gbrLvl1;
        }
        if (Database.upgradePigura == 1)
        {
            objectGambar.GetComponent<SpriteRenderer>().sprite = gbrLvl2;
        }
        else if (Database.upgradePigura == 2)
        {
            objectGambar.GetComponent<SpriteRenderer>().sprite = gbrLvl3;
        }
    }

    void OnMouseDown()
    {
        btnBuy.GetComponent<SpriteRenderer>().sprite = click;
        if (Database.upgradePigura == 0)
        {
            if (Database.uang <= 7500)
            {
                print("Uang Anda Tidak Cukup !");
            }
            else
            {
                Database.uang -= 7500;
                Database.upgradePigura++;
                Database.minPembeliDatang += 3;
                objectGambar.GetComponent<SpriteRenderer>().sprite = gbrLvl1;
                print("1");
            }
        }
        else if (Database.upgradePigura == 1)
        {
            if (Database.uang <= 10000)
            {
                print("Uang Anda Tidak Cukup !");
            }
            else
            {
                Database.uang -= 10000;
                Database.upgradePigura++;
                Database.maxPembeliDatang += 3;
                objectGambar.GetComponent<SpriteRenderer>().sprite = gbrLvl2;
                print("2");
            }
        }
        else if (Database.upgradePigura == 2)
        {
            if (Database.uang <= 15000)
            {
                print("Uang Anda Tidak Cukup !");
            }
            else
            {
                Database.uang -= 15000;
                Database.upgradePigura++;
                Database.minPembeliDatang += 3;
                Database.maxPembeliDatang += 3;
                objectGambar.GetComponent<SpriteRenderer>().sprite = gbrLvl3;
                //gameObject.GetComponent<SpriteRenderer>().color = new Color(0.4f, 0.4f, 0.4f);
                print("MAX");
            }
        }
        print("Uang Anda Tersisa : " + Database.uang + " Level Pigura : " + Database.upgradePigura);
        //Application.LoadLevel(1);
    }

	// Use this for initialization
	void Start () {
        objectGambar.GetComponent<SpriteRenderer>().sprite = gbrLvl1;
        btnBuy.GetComponent<SpriteRenderer>().sprite = normal;
        //Database.uang = 700;
        //Database.upgradePigura = 0;

        

        gameObject.AddComponent<AudioSource>();
        source.clip = sound;
        source.playOnAwake = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
