using UnityEngine;
using System.Collections;

public class btnStokTambahDawet : MonoBehaviour {

    public GameObject stokDawet;

    public AudioClip sound;

    public GameObject btnPlus;
    public Sprite normal;
    public Sprite hover;
    public Sprite click;
    public GameObject balonCost;
    public Sprite costNormal;
    public Sprite costLvl1;
    private AudioSource source { get { return GetComponent<AudioSource>(); } }

    void OnMouseEnter()
    {
        btnPlus.GetComponent<SpriteRenderer>().sprite = hover;
        balonCost.GetComponent<SpriteRenderer>().sprite = costLvl1;
        source.PlayOneShot(sound);
    }

    void OnMouseExit()
    {
        balonCost.GetComponent<SpriteRenderer>().sprite = costNormal; 
        btnPlus.GetComponent<SpriteRenderer>().sprite = normal;
    }

    void OnMouseDown()
    {
        btnPlus.GetComponent<SpriteRenderer>().sprite = click;
        Database.stokDawet += 1;
        Database.uang -= 1;
        print(Database.stokDawet);
        stokDawet.GetComponent<TextMesh>().text = Database.stokDawet.ToString();
    }

	// Use this for initialization
	void Start () {
        btnPlus.GetComponent<SpriteRenderer>().sprite = normal;
        stokDawet.GetComponent<TextMesh>().text = Database.stokDawet.ToString();

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
