using UnityEngine;
using System.Collections;

public class btnStokTambahBumbuPecel : MonoBehaviour {

    public GameObject stokBumbuPecel;

    public AudioClip sound;

    public GameObject btnPlus;
    public Sprite normal;
    public Sprite hover;
    public Sprite click;

    public GameObject balonCost;
    public Sprite costNormal;
    public Sprite costLvl1;
    public Sprite belumBeli;

    private AudioSource source { get { return GetComponent<AudioSource>(); } }

    void OnMouseEnter()
    {
        btnPlus.GetComponent<SpriteRenderer>().sprite = hover;
        source.PlayOneShot(sound);
        if (Database.upgradeResepPecel == 0)
        {
            balonCost.GetComponent<SpriteRenderer>().sprite = belumBeli;
        }
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
        if (Database.upgradeResepPecel > 0)
        {
            btnPlus.GetComponent<SpriteRenderer>().sprite = click;
            Database.stokBumbuPecel += 1;
            Database.uang -= 3;
            print(Database.stokBumbuPecel);
            stokBumbuPecel.GetComponent<TextMesh>().text = Database.stokBumbuPecel.ToString();
        }
    }

	// Use this for initialization
	void Start () {
        btnPlus.GetComponent<SpriteRenderer>().sprite = normal;
        stokBumbuPecel.GetComponent<TextMesh>().text = Database.stokBumbuPecel.ToString();

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
