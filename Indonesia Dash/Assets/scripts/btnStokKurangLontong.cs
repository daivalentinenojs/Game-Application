using UnityEngine;
using System.Collections;

public class btnStokKurangLontong : MonoBehaviour {

    public GameObject stokLontong;

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
        if (Database.upgradeResepRujak == 0)
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
        if (Database.stokLontong >= 1 && Database.upgradeResepRujak > 0)
        {
            Database.stokLontong -= 1;
            Database.uang += 5;
            print(Database.stokLontong);
            stokLontong.GetComponent<TextMesh>().text = Database.stokLontong.ToString();
        }
    }

	// Use this for initialization
	void Start () {
        btnMinus.GetComponent<SpriteRenderer>().sprite = normal;
        stokLontong.GetComponent<TextMesh>().text = Database.stokLontong.ToString();

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
