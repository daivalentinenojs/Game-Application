using UnityEngine;
using System.Collections;

public class btnHargaJualTambahRujak : MonoBehaviour {

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

    public GameObject hargaJualRealRujak;

    void OnMouseDown()
    {
        btnPlus.GetComponent<SpriteRenderer>().sprite = click;
        if (Database.hargaJualRealRujak <= 95)
        {
            Database.hargaJualRealRujak += 5;
        }

        print(Database.hargaJualRealRujak);
        hargaJualRealRujak.GetComponent<TextMesh>().text = Database.hargaJualRealRujak.ToString();
    }

	// Use this for initialization
	void Start () {
        btnPlus.GetComponent<SpriteRenderer>().sprite = normal;
        hargaJualRealRujak.GetComponent<TextMesh>().text = Database.hargaJualRealRujak.ToString();

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
