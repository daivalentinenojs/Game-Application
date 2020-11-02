using UnityEngine;
using System.Collections;

public class btnStokKurangBumbuHalus : MonoBehaviour {

    public GameObject stokBumbuHalus;

    public AudioClip sound;
    public GameObject balonCost;
    public Sprite costNormal;
    public Sprite costLvl1;
    public GameObject btnMinus;
    public Sprite normal;
    public Sprite hover;
    public Sprite click;

    private AudioSource source { get { return GetComponent<AudioSource>(); } }

    void OnMouseEnter()
    {
        btnMinus.GetComponent<SpriteRenderer>().sprite = hover;
        balonCost.GetComponent<SpriteRenderer>().sprite = costLvl1;
        source.PlayOneShot(sound);
    }

    void OnMouseExit()
    {
        balonCost.GetComponent<SpriteRenderer>().sprite = costNormal; 
        btnMinus.GetComponent<SpriteRenderer>().sprite = normal;
    }

    void OnMouseDown()
    {
        btnMinus.GetComponent<SpriteRenderer>().sprite = click;
        if (Database.stokBumbuHalus >= 1)
        {
            Database.stokBumbuHalus -= 1;
            Database.uang += 2;
            print(Database.stokBumbuHalus);
            stokBumbuHalus.GetComponent<TextMesh>().text = Database.stokBumbuHalus.ToString();
        }
    }

	// Use this for initialization
	void Start () {
        btnMinus.GetComponent<SpriteRenderer>().sprite = normal;
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
