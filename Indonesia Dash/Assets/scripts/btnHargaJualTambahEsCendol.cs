using UnityEngine;
using System.Collections;

public class btnHargaJualTambahEsCendol : MonoBehaviour {

    public AudioClip sound;

    public GameObject btnPlus;
    public Sprite normal;
    public Sprite hover;
    public Sprite click;

    private AudioSource source { get { return GetComponent<AudioSource>(); } }

    void OnMouseEnter()
    {
        btnPlus.GetComponent<SpriteRenderer>().sprite = hover;
        source.PlayOneShot(sound);
    }

    void OnMouseExit()
    {
        btnPlus.GetComponent<SpriteRenderer>().sprite = normal;
    }

    public GameObject hargaJualRealEsCendol;

    void OnMouseDown()
    {
        btnPlus.GetComponent<SpriteRenderer>().sprite = click;
        if (Database.hargaJualRealEsCendol <= 95)
        {
            Database.hargaJualRealEsCendol += 5;
        }
        
        print(Database.hargaJualRealEsCendol);
        hargaJualRealEsCendol.GetComponent<TextMesh>().text = Database.hargaJualRealEsCendol.ToString();
    }

	// Use this for initialization
	void Start () {
        btnPlus.GetComponent<SpriteRenderer>().sprite = normal;
        hargaJualRealEsCendol.GetComponent<TextMesh>().text = Database.hargaJualRealEsCendol.ToString();

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
