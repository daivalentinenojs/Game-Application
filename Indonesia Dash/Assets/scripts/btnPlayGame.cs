using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System.Collections;

public class btnPlayGame : MonoBehaviour {

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

    void OnMouseDown()
    {
        btnMenu.GetComponent<SpriteRenderer>().sprite = click;
        //source.PlayOneShot(sound);
        Application.LoadLevel(2);
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
