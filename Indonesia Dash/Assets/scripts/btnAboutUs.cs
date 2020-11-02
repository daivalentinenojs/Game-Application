using UnityEngine;
using System.Collections;

public class btnAboutUs : MonoBehaviour {

    public AudioClip sound;

    public GameObject btnMenu;
    public Sprite normal;
    public Sprite hover;
    public Sprite click;

    private AudioSource source { get { return GetComponent<AudioSource>(); } }

    void OnMouseEnter()
    {
        btnMenu.GetComponent<SpriteRenderer>().sprite = hover;
        source.PlayOneShot(sound);
        print("1");
    }

    void OnMouseExit()
    {
        print("3");
        btnMenu.GetComponent<SpriteRenderer>().sprite = normal;
    }

    void OnMouseDown()
    {
        print("2");
        btnMenu.GetComponent<SpriteRenderer>().sprite = click;
        Application.LoadLevel(7);
    }

	// Use this for initialization
	void Start () {
        btnMenu.GetComponent<SpriteRenderer>().sprite = normal;
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
