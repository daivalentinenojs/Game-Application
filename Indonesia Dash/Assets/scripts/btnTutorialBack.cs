using UnityEngine;
using System.Collections;

public class btnTutorialBack : MonoBehaviour {
    public Sprite tutorialLV1;
    public Sprite tutorialLV2;
    public Sprite tutorialLV3;
    public GameObject objectGambar;
    public GameObject btnBack;
    public GameObject btnNext;

    public Sprite normal;
    public Sprite hover;
    public Sprite click;
    //public GameObject objectGambar;

    //public int a;

    public AudioClip sound;

    private AudioSource source { get { return GetComponent<AudioSource>(); } }

    void OnMouseEnter()
    {
        btnBack.GetComponent<SpriteRenderer>().sprite = hover;
        source.PlayOneShot(sound);
    }

    void OnMouseExit()
    {
        btnBack.GetComponent<SpriteRenderer>().sprite = normal;
    }

    void OnMouseDown()
    {
        btnBack.GetComponent<SpriteRenderer>().sprite = click;
        if (Database.urutanTutorial == 2)
        {
            Database.urutanTutorial--;
            objectGambar.GetComponent<SpriteRenderer>().sprite = tutorialLV1;
            btnBack.GetComponent<Renderer>().enabled = false;
            btnNext.GetComponent<Renderer>().enabled = true;
            print("2");
        }
        else if (Database.urutanTutorial == 3)
        {
            Database.urutanTutorial--;
            objectGambar.GetComponent<SpriteRenderer>().sprite = tutorialLV2;
            btnBack.GetComponent<Renderer>().enabled = true;
            btnNext.GetComponent<Renderer>().enabled = true;
            print("3");
        }
    }

	// Use this for initialization
	void Start () {
        btnBack.GetComponent<SpriteRenderer>().sprite = normal;
        //a = Database.urutanTutorial;
        //Database.urutanTutorial = a;
        btnBack.GetComponent<SpriteRenderer>().sprite = normal;

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
