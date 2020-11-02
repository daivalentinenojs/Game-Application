using UnityEngine;
using System.Collections;

public class btnHargaJualKurangCotoMakassar : MonoBehaviour {

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

    public GameObject hargaJualRealCotoMakassar;

    void OnMouseDown()
    {
        btnMinus.GetComponent<SpriteRenderer>().sprite = click;
        if (Database.hargaJualRealCotoMakassar >= 1)
        {
            Database.hargaJualRealCotoMakassar -= 5;
            print(Database.hargaJualRealCotoMakassar);
            hargaJualRealCotoMakassar.GetComponent<TextMesh>().text = Database.hargaJualRealCotoMakassar.ToString();
        }
    }

	// Use this for initialization
	void Start () {
        btnMinus.GetComponent<SpriteRenderer>().sprite = normal;
        hargaJualRealCotoMakassar.GetComponent<TextMesh>().text = Database.hargaJualRealCotoMakassar.ToString();

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
