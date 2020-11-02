using UnityEngine;
using System.Collections;

public class btnStoryBack : MonoBehaviour {
    public Sprite storyLV1;
    public Sprite storyLV2;
    public Sprite storyLV3;
    public GameObject objectGambar;
    public GameObject btnNext;
    public GameObject btnBack;
    //public int a;

    public Sprite normal;
    public Sprite hover;
    public Sprite click;

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
            objectGambar.GetComponent<SpriteRenderer>().sprite = storyLV1;
            btnBack.GetComponent<Renderer>().enabled = false;
            btnNext.GetComponent<Renderer>().enabled = true;
            print("2");
        }
        else if (Database.urutanTutorial == 3)
        {
            Database.urutanTutorial--;
            objectGambar.GetComponent<SpriteRenderer>().sprite = storyLV2;
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
