using UnityEngine;
using System.Collections;

public class btnHargaJualTambahNasiPecel : MonoBehaviour {

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

    public GameObject hargaJualRealNasiPecel;

    void OnMouseDown()
    {
        btnPlus.GetComponent<SpriteRenderer>().sprite = click;
        if (Database.hargaJualRealPecel <= 95)
        {
            Database.hargaJualRealPecel += 5;
        }

        
        print(Database.hargaJualRealPecel);
        hargaJualRealNasiPecel.GetComponent<TextMesh>().text = Database.hargaJualRealPecel.ToString();
    }

	// Use this for initialization
	void Start () {
        btnPlus.GetComponent<SpriteRenderer>().sprite = normal;
        hargaJualRealNasiPecel.GetComponent<TextMesh>().text = Database.hargaJualRealPecel.ToString();

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
