using UnityEngine;
using System.Collections;

public class btnStokTambahSayuran : MonoBehaviour {

    public GameObject stokSayuran;

    public AudioClip sound;

    public GameObject btnPlus;
    public Sprite normal;
    public Sprite hover;
    public Sprite click;

    public GameObject balonCost;
    public Sprite costNormal;
    public Sprite costLvl1;
    public Sprite belumBeli;
    //public Sprite belumBeliPecel;
    //public Sprite belumBeliRujak;

    private AudioSource source { get { return GetComponent<AudioSource>(); } }

    void OnMouseEnter()
    {
        btnPlus.GetComponent<SpriteRenderer>().sprite = hover;
        source.PlayOneShot(sound);
        if (Database.upgradeResepRujak == 0 && Database.upgradeResepPecel == 0)
        {
            balonCost.GetComponent<SpriteRenderer>().sprite = belumBeli;
        }
        //else if (Database.upgradeResepRujak == 1 || Database.upgradeResepPecel == 0)
        //{
        //    balonCost.GetComponent<SpriteRenderer>().sprite = belumBeliPecel;
        //}
        //else if (Database.upgradeResepRujak == 0 || Database.upgradeResepPecel == 1)
        //{
        //    balonCost.GetComponent<SpriteRenderer>().sprite = belumBeliRujak;
        //}
        else
        {
            balonCost.GetComponent<SpriteRenderer>().sprite = costLvl1;
        }
    }

    void OnMouseExit()
    {
        balonCost.GetComponent<SpriteRenderer>().sprite = costNormal; 
        btnPlus.GetComponent<SpriteRenderer>().sprite = normal;
    }

    void OnMouseDown()
    {
        if (Database.upgradeResepRujak > 0 || Database.upgradeResepPecel > 0)
        {
            btnPlus.GetComponent<SpriteRenderer>().sprite = click;
            Database.stokSayuran += 1;
            Database.uang -= 3;
            print(Database.stokSayuran);
            stokSayuran.GetComponent<TextMesh>().text = Database.stokSayuran.ToString();
        }
    }

	// Use this for initialization
	void Start () {
        btnPlus.GetComponent<SpriteRenderer>().sprite = normal;
        stokSayuran.GetComponent<TextMesh>().text = Database.stokSayuran.ToString();

        gameObject.AddComponent<AudioSource>();
        source.clip = sound;
        source.playOnAwake = false;
	}

    void PlaySound()
    {
        source.PlayOneShot(sound);
    }

	// Update is called once per frame
	void Update () {
	
	}
}
