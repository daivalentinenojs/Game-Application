using UnityEngine;
using System.Collections;

public class btnBuyStock : MonoBehaviour {
    public GameObject btnBack;
    public Sprite normal;
    public Sprite hover;
    public Sprite click;

    void OnMouseExit()
    {
        btnBack.GetComponent<SpriteRenderer>().sprite = normal;
    }

    public AudioClip sound;
    private AudioSource source { get { return GetComponent<AudioSource>(); } }

    void OnMouseEnter()
    {
        btnBack.GetComponent<SpriteRenderer>().sprite = hover;
        source.PlayOneShot(sound);
    }

    void OnMouseDown()
    {
        btnBack.GetComponent<SpriteRenderer>().sprite = click;
        Application.LoadLevel(10);
    }

	// Use this for initialization
	void Start () {
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
