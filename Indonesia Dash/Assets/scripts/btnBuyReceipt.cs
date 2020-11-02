using UnityEngine;
using System.Collections;

public class btnBuyReceipt : MonoBehaviour {

    public Sprite normal;
    public Sprite hover;
    public Sprite click;
    public GameObject btnBack;
    public AudioClip sound;

    void OnMouseExit()
    {
        btnBack.GetComponent<SpriteRenderer>().sprite = normal;
    }

    private AudioSource source { get { return GetComponent<AudioSource>(); } }

    void OnMouseEnter()
    {
        btnBack.GetComponent<SpriteRenderer>().sprite = hover;
        source.PlayOneShot(sound);
    }
    void OnMouseDown()
    {
        btnBack.GetComponent<SpriteRenderer>().sprite = click;
        Application.LoadLevel(3);
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
