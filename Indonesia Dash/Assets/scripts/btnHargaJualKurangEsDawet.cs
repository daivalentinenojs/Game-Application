using UnityEngine;
using System.Collections;

public class btnHargaJualKurangEsDawet : MonoBehaviour {

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

    public GameObject hargaJualRealEsDawet;

    void OnMouseDown()
    {
        btnMinus.GetComponent<SpriteRenderer>().sprite = click;
        if (Database.hargaJualRealEsDawet >= 1)
        {
            Database.hargaJualRealEsDawet -= 5;
            print(Database.hargaJualRealEsDawet);
            hargaJualRealEsDawet.GetComponent<TextMesh>().text = Database.hargaJualRealEsDawet.ToString();
        }
    }

	// Use this for initialization
	void Start () {
        btnMinus.GetComponent<SpriteRenderer>().sprite = normal;
        hargaJualRealEsDawet.GetComponent<TextMesh>().text = Database.hargaJualRealEsDawet.ToString();

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
