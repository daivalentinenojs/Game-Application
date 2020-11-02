using UnityEngine;
using System.Collections;

public class beliPendingin : MonoBehaviour {
    public Sprite pendinginLV0;
    public Sprite pendinginLV1;
    public Sprite pendinginLV2;
    public Sprite pendinginLV3;
    public GameObject objectGambar;
    public Sprite max;
    public Sprite balonNormal;
    public Sprite balonLv1;
    public Sprite balonLv2;
    public Sprite balonLv3;
    public GameObject balon;

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

        if (Database.upgradePendingin == 0)
        {
            balon.GetComponent<SpriteRenderer>().sprite = balonLv1;
        }
        else if (Database.upgradePendingin == 1)
        {
            balon.GetComponent<SpriteRenderer>().sprite = balonLv2;
        }
        else if (Database.upgradePendingin == 2)
        {
            balon.GetComponent<SpriteRenderer>().sprite = balonLv3;
        }
        else
        {
            balon.GetComponent<SpriteRenderer>().sprite = max;
        }
    }

    void PlaySound()
    {
        source.PlayOneShot(sound);
    }

    void OnMouseExit()
    {
        balon.GetComponent<SpriteRenderer>().sprite = balonNormal; 
        btnBuy.GetComponent<SpriteRenderer>().sprite = normal;
    }

    void OnMouseDown()
    {
        btnBuy.GetComponent<SpriteRenderer>().sprite = click;
        if (Database.upgradePendingin == 0)
        {
            if (Database.uang <= 3000)
            {
                print("Uang Anda Tidak Cukup !");
            }
            else
            {
                Database.uang -= 3000;
                Database.upgradePendingin++;
                Database.minPembeliDatang += 3;
                objectGambar.GetComponent<SpriteRenderer>().sprite = pendinginLV1;
                print("1");
            }
        }
        else if (Database.upgradePendingin == 1)
        {
            if (Database.uang <= 6000)
            {
                print("Uang Anda Tidak Cukup !");
            }
            else
            {
                Database.uang -= 6000;
                Database.upgradePendingin++;
                Database.maxPembeliDatang += 3;
                objectGambar.GetComponent<SpriteRenderer>().sprite = pendinginLV2;
                print("2");
            }
        }
        else if (Database.upgradePendingin == 2)
        {
            if (Database.uang <= 10000)
            {
                print("Uang Anda Tidak Cukup !");
            }
            else
            {
                Database.uang -= 10000;
                Database.upgradePendingin++;
                Database.minPembeliDatang += 3;
                Database.maxPembeliDatang += 3;
                objectGambar.GetComponent<SpriteRenderer>().sprite = pendinginLV3;
                //gameObject.GetComponent<SpriteRenderer>().color = new Color(0.4f, 0.4f, 0.4f);
                print("MAX");
            }
        }
        print("Uang Anda Tersisa : " + Database.uang + " Level Pendingin : " + Database.upgradePendingin);
        //Application.LoadLevel(1);
    }

	// Use this for initialization
	void Start () {
        btnBuy.GetComponent<SpriteRenderer>().sprite = normal;
        //Database.uang = 700;
        //Database.upgradePendingin = 0;

        if (Database.upgradePendingin == 0)
        {
            objectGambar.GetComponent<SpriteRenderer>().sprite = pendinginLV0;
        }
        else if (Database.upgradePendingin == 1)
        {
            objectGambar.GetComponent<SpriteRenderer>().sprite = pendinginLV1;
        }
        else if (Database.upgradePendingin == 2)
        {
            objectGambar.GetComponent<SpriteRenderer>().sprite = pendinginLV2;
        }
        else if (Database.upgradePendingin == 3)
        {
            objectGambar.GetComponent<SpriteRenderer>().sprite = pendinginLV3;
        }

        gameObject.AddComponent<AudioSource>();
        source.clip = sound;
        source.playOnAwake = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
