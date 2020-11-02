using UnityEngine;
using System.Collections;

public class beliSarungTangan : MonoBehaviour {
    public Sprite sarungLV0;
    public Sprite sarungLV1;
    public Sprite sarungLV2;
    public Sprite sarungLV3;
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

        if (Database.upgradeKecepatanTangan == 0)
        {
            balon.GetComponent<SpriteRenderer>().sprite = balonLv1;
            balonCost.GetComponent<SpriteRenderer>().sprite = costLvl1;  
        }
        else if (Database.upgradeKecepatanTangan == 1)
        {
            balon.GetComponent<SpriteRenderer>().sprite = balonLv2;
            balonCost.GetComponent<SpriteRenderer>().sprite = costLvl2;  
        }
        else if (Database.upgradeKecepatanTangan == 2)
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

        if (Database.upgradeKecepatanTangan == 0)
        {
            objectGambar.GetComponent<SpriteRenderer>().sprite = gbrLvl1;
        }
        if (Database.upgradeKecepatanTangan == 1)
        {
            objectGambar.GetComponent<SpriteRenderer>().sprite = gbrLvl2;
        }
        else if (Database.upgradeKecepatanTangan == 2)
        {
            objectGambar.GetComponent<SpriteRenderer>().sprite = gbrLvl3;
        }
    }

    void OnMouseDown()
    {
        btnBuy.GetComponent<SpriteRenderer>().sprite = click;
        if (Database.upgradeKecepatanTangan == 0)
        {
            if (Database.uang <= 10000)
            {
                print("Uang Anda Tidak Cukup !");
            }
            else
            {
                Database.uang -= 10000;
                Database.upgradeKecepatanTangan++;
                Database.kecepatanChef += 0.2f;
                objectGambar.GetComponent<SpriteRenderer>().sprite = gbrLvl1;
                print("1");
            }
        }
        else if (Database.upgradeKecepatanTangan == 1)
        {
            if (Database.uang <= 11000)
            {
                print("Uang Anda Tidak Cukup !");
            }
            else
            {
                Database.uang -= 11000;
                Database.upgradeKecepatanTangan++;
                Database.kecepatanChef += 0.2f;
                objectGambar.GetComponent<SpriteRenderer>().sprite = gbrLvl2;
                print("2");
            }
        }
        else if (Database.upgradeKecepatanTangan == 2)
        {
            if (Database.uang <= 12000)
            {
                print("Uang Anda Tidak Cukup !");
            }
            else
            {
                Database.uang -= 12000;
                Database.upgradeKecepatanTangan++;
                Database.kecepatanChef += 0.2f;
                objectGambar.GetComponent<SpriteRenderer>().sprite = gbrLvl3;
                //gameObject.GetComponent<SpriteRenderer>().color = new Color(0.4f, 0.4f, 0.4f);
                print("MAX");
            }
        }
        print("Uang Anda Tersisa : " + Database.uang + " Level Kecepatan Tangan : " + Database.upgradeKecepatanTangan);
        //Application.LoadLevel(1);
    }

	// Use this for initialization
	void Start () {
        btnBuy.GetComponent<SpriteRenderer>().sprite = normal;
        //Database.uang = 700;
        //Database.upgradeKecepatanTangan = 0;

        objectGambar.GetComponent<SpriteRenderer>().sprite = gbrLvl1;

        gameObject.AddComponent<AudioSource>();
        source.clip = sound;
        source.playOnAwake = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
