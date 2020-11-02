using UnityEngine;
using System.Collections;

public class btnHargaJualKurangJamuSinom : MonoBehaviour {

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

    public GameObject hargaJualRealJamuSinom;

    void OnMouseDown()
    {
        btnMinus.GetComponent<SpriteRenderer>().sprite = click;
        if (Database.hargaJualRealJamuSinom >= 1)
        {
            Database.hargaJualRealJamuSinom -= 5;
            print(Database.hargaJualRealJamuSinom);
            hargaJualRealJamuSinom.GetComponent<TextMesh>().text = Database.hargaJualRealJamuSinom.ToString();
        }
    }

	// Use this for initialization
	void Start () {
        btnMinus.GetComponent<SpriteRenderer>().sprite = normal;
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
