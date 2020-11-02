using UnityEngine;
using System.Collections;

public class btnHargaJualKurangNasiPecel : MonoBehaviour {

    public AudioClip sound;

    public GameObject btnMinus;
    public Sprite normal;
    public Sprite hover;
    public Sprite click;

    private AudioSource source { get { return GetComponent<AudioSource>(); } }

    void OnMouseEnter()
    {
        btnMinus.GetComponent<SpriteRenderer>().sprite = hover;
        source.PlayOneShot(sound);
    }

    void OnMouseExit()
    {
        btnMinus.GetComponent<SpriteRenderer>().sprite = normal;
    }

    public GameObject hargaJualRealPecel;

    void OnMouseDown()
    {
        btnMinus.GetComponent<SpriteRenderer>().sprite = click;
        if (Database.hargaJualRealPecel >= 1)
        {
            Database.hargaJualRealPecel -= 5;
            print(Database.hargaJualRealPecel);
            hargaJualRealPecel.GetComponent<TextMesh>().text = Database.hargaJualRealPecel.ToString();
        }
    }

	// Use this for initialization
	void Start () {
        btnMinus.GetComponent<SpriteRenderer>().sprite = normal;
        hargaJualRealPecel.GetComponent<TextMesh>().text = Database.hargaJualRealPecel.ToString();

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
