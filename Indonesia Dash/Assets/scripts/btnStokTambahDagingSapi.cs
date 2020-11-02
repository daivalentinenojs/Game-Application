using UnityEngine;
using System.Collections;

public class btnStokTambahDagingSapi : MonoBehaviour {

    public GameObject stokDagingSapi;

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
        balonCost.GetComponent<SpriteRenderer>().sprite = costLvl1;
        btnPlus.GetComponent<SpriteRenderer>().sprite = hover;
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
        Database.stokDagingSapi += 1;
        Database.uang -= 7;
        print(Database.stokDagingSapi);
        stokDagingSapi.GetComponent<TextMesh>().text = Database.stokDagingSapi.ToString();
    }

	// Use this for initialization
	void Start () {
        btnPlus.GetComponent<SpriteRenderer>().sprite = normal;
        stokDagingSapi.GetComponent<TextMesh>().text = Database.stokDagingSapi.ToString();

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
