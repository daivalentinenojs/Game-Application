using UnityEngine;
using System.Collections;

public class btnKembaliKePreDay : MonoBehaviour {

    public Sprite normal;
    public Sprite hover;
    public Sprite click;
    //public GameObject objectGambar;
    public GameObject btnBack;

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
        Application.LoadLevel(2);
    }

    void OnMouseExit()
    {
        btnBack.GetComponent<SpriteRenderer>().sprite = normal;
    }

	// Use this for initialization
	void Start () {
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
