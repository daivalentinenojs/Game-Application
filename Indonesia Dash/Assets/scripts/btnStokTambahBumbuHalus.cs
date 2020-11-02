using UnityEngine;
using System.Collections;

public class btnStokTambahBumbuHalus : MonoBehaviour {

    public GameObject stokBumbuHalus;

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
        Database.stokBumbuHalus += 1;
        Database.uang -= 2;
        print(Database.stokBumbuHalus);
        stokBumbuHalus.GetComponent<TextMesh>().text = Database.stokBumbuHalus.ToString();
    }

	// Use this for initialization
	void Start () {
        btnPlus.GetComponent<SpriteRenderer>().sprite = normal;
        stokBumbuHalus.GetComponent<TextMesh>().text = Database.stokBumbuHalus.ToString();

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
