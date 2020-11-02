using UnityEngine;
using System.Collections;

public class btnHargaJualTambahJamuSinom : MonoBehaviour {

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

    public GameObject hargaJualRealJamuSinom;

    void OnMouseDown()
    {
        btnPlus.GetComponent<SpriteRenderer>().sprite = click;
        if (Database.hargaJualRealJamuSinom <= 95)
        {
            Database.hargaJualRealJamuSinom += 5;
        }

        
        print(Database.hargaJualRealJamuSinom);
        hargaJualRealJamuSinom.GetComponent<TextMesh>().text = Database.hargaJualRealJamuSinom.ToString();
    }

	// Use this for initialization
	void Start () {
        btnPlus.GetComponent<SpriteRenderer>().sprite = normal;
        hargaJualRealJamuSinom.GetComponent<TextMesh>().text = Database.hargaJualRealJamuSinom.ToString();

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
