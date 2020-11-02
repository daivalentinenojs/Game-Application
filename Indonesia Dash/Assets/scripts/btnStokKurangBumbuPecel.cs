using UnityEngine;
using System.Collections;

public class btnStokKurangBumbuPecel : MonoBehaviour {

    public GameObject stokBumbuPecel;

    public AudioClip sound;

    public GameObject btnMinus;
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
        btnMinus.GetComponent<SpriteRenderer>().sprite = hover;
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
        btnMinus.GetComponent<SpriteRenderer>().sprite = normal;
    }

    void OnMouseDown()
    {
        btnMinus.GetComponent<SpriteRenderer>().sprite = click;
        if (Database.stokBumbuPecel >= 1 && Database.upgradeResepPecel > 0)
        {
            Database.stokBumbuPecel -= 1;
            Database.uang += 3;
            print(Database.stokBumbuPecel);
            stokBumbuPecel.GetComponent<TextMesh>().text = Database.stokBumbuPecel.ToString();
        }
    }

	// Use this for initialization
	void Start () {
        btnMinus.GetComponent<SpriteRenderer>().sprite = normal;
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
