using UnityEngine;
using System.Collections;

public class btnHargaJualKurangEsCendol : MonoBehaviour {

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

    public GameObject hargaJualRealEsCendol;

    void OnMouseDown()
    {
        btnMinus.GetComponent<SpriteRenderer>().sprite = click;
        if (Database.hargaJualRealEsCendol >= 1)
        {
            Database.hargaJualRealEsCendol -= 5;
            print(Database.hargaJualRealEsCendol);
            hargaJualRealEsCendol.GetComponent<TextMesh>().text = Database.hargaJualRealEsCendol.ToString();
        }
    }

	// Use this for initialization
	void Start () {
        btnMinus.GetComponent<SpriteRenderer>().sprite = normal;
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
