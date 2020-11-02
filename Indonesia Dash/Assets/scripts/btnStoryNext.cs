using UnityEngine;
using System.Collections;

public class btnStoryNext : MonoBehaviour {
    public Sprite storyLV1;
    public Sprite storyLV2;
    public Sprite storyLV3;
    public GameObject objectGambar;
    public GameObject btnNext;
    public GameObject btnBack;

    public Sprite normal;
    public Sprite hover;
    public Sprite click;

    public AudioClip sound;

    private AudioSource source { get { return GetComponent<AudioSource>(); } }

    void OnMouseEnter()
    {
        btnNext.GetComponent<SpriteRenderer>().sprite = hover;
        source.PlayOneShot(sound);
    }

    void OnMouseExit()
    {
        btnNext.GetComponent<SpriteRenderer>().sprite = normal;
    }

    void OnMouseDown()
    {
        btnNext.GetComponent<SpriteRenderer>().sprite = click;
        if (Database.urutanTutorial == 1)
        {
            Database.urutanTutorial++;
            objectGambar.GetComponent<SpriteRenderer>().sprite = storyLV2;
            btnBack.GetComponent<Renderer>().enabled = true;
            btnNext.GetComponent<Renderer>().enabled = true;
            print("2");
        }
        else if (Database.urutanTutorial == 2)
        {
            Database.urutanTutorial++;
            objectGambar.GetComponent<SpriteRenderer>().sprite = storyLV3;
            btnBack.GetComponent<Renderer>().enabled = true;
            btnNext.GetComponent<Renderer>().enabled = false;
            print("3");
        }
    }

	// Use this for initialization
	void Start () {
        btnNext.GetComponent<SpriteRenderer>().sprite = normal;
        //Database.urutanTutorial = 1;
        objectGambar.GetComponent<SpriteRenderer>().sprite = storyLV1;
        btnBack.GetComponent<Renderer>().enabled = false;
        btnNext.GetComponent<Renderer>().enabled = true;

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
