using UnityEngine;
using System.Collections;

public class btnExit : MonoBehaviour {

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
    }

    void OnMouseExit()
    {
        btnMenu.GetComponent<SpriteRenderer>().sprite = normal;
    }

	// Use this for initialization
	void Start () {
        btnMenu.GetComponent<SpriteRenderer>().sprite = normal;
        gameObject.AddComponent<AudioSource>();
        source.clip = sound;
        source.playOnAwake = false;
	}

    void OnMouseDown()
    {
        btnMenu.GetComponent<SpriteRenderer>().sprite = click;
        Application.Quit();
    }

    void PlaySound()
    {
        source.PlayOneShot(sound);
    }

	// Update is called once per frame
	void Update () {
	
	}
}
