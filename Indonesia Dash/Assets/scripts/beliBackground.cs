using UnityEngine;
using System.Collections;

public class beliBackground : MonoBehaviour {
    public Sprite backgroundLV0;
    public Sprite backgroundLV1;
    public Sprite backgroundLV2;
    public Sprite backgroundLV3;
    public GameObject objectGambar;
    public Sprite max;
    public Sprite balonNormal;
    public Sprite balonLv1;
    public Sprite balonLv2;
    public Sprite balonLv3;
    public GameObject balon;
    public GameObject balonCost;
    public Sprite maxCost;
    public Sprite costNormal;
    public Sprite costLvl1;
    public Sprite costLvl2;
    public Sprite costLvl3;

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

        if (Database.upgradeBackground == 0)
        {
            balon.GetComponent<SpriteRenderer>().sprite = balonLv1;
            balonCost.GetComponent<SpriteRenderer>().sprite = costLvl1; 
        }
        else if (Database.upgradeBackground == 1)
        {
            balon.GetComponent<SpriteRenderer>().sprite = balonLv2;
            balonCost.GetComponent<SpriteRenderer>().sprite = costLvl2; 
        }
        else if (Database.upgradeBackground == 2)
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

        if (Database.upgradeBackground == 1)
        {
            objectGambar.GetComponent<SpriteRenderer>().sprite = gbrLvl2;
        }
        else if (Database.upgradeBackground == 2)
        {
            objectGambar.GetComponent<SpriteRenderer>().sprite = gbrLvl3;
        }
    }

    void OnMouseDown()
    {
        btnBuy.GetComponent<SpriteRenderer>().sprite = click;
        if (Database.upgradeBackground == 0)
        {
            if (Database.uang <= 750)
            {
                print("Uang Anda Tidak Cukup !");
            }
            else
            {
                objectGambar.GetComponent<SpriteRenderer>().sprite = gbrLvl2;
                Database.uang -= 750;
                Database.upgradeBackground++;
                Database.minPembeliDatang += 2;
                print("1");
            }
        }
        else if (Database.upgradeBackground == 1)
        {
            if (Database.uang <= 1000)
            {
                print("Uang Anda Tidak Cukup !");
            }
            else
            {
                Database.uang -= 1000;
                Database.upgradeBackground++;
                Database.maxPembeliDatang += 2;
                objectGambar.GetComponent<SpriteRenderer>().sprite = gbrLvl3;
                print("2");
            }
        }
        else if (Database.upgradeBackground == 2)
        {
            if (Database.uang <= 1500)
            {
                print("Uang Anda Tidak Cukup !");
            }
            else
            {
                Database.uang -= 1500;
                Database.upgradeBackground++;
                Database.minPembeliDatang += 2;
                Database.maxPembeliDatang += 2;
                objectGambar.GetComponent<SpriteRenderer>().sprite = gbrLvl3;
                //gameObject.GetComponent<SpriteRenderer>().color = new Color(0.4f, 0.4f, 0.4f);
                print("MAX");
            }
        }
        print("Uang Anda Tersisa : " + Database.uang + " Level Background : " + Database.upgradeBackground);
        //Application.LoadLevel(1);
    }

	// Use this for initialization
	void Start () {
        objectGambar.GetComponent<SpriteRenderer>().sprite = gbrLvl2;
        btnBuy.GetComponent<SpriteRenderer>().sprite = normal;
        //Database.uang = 100000;
        //Database.upgradeBackground = 0;

        gameObject.AddComponent<AudioSource>();
        source.clip = sound;
        source.playOnAwake = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
