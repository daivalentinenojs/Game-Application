using UnityEngine;
using System.Collections;

public class btnHargaJualTambahCotoMakassar : MonoBehaviour {

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

    public GameObject hargaJualRealCotoMakassar;

    void OnMouseDown()
    {
        btnPlus.GetComponent<SpriteRenderer>().sprite = click;
        if (Database.hargaJualRealCotoMakassar <= 95)
        {
            Database.hargaJualRealCotoMakassar += 5;
        }
        print(Database.hargaJualRealCotoMakassar);
        hargaJualRealCotoMakassar.GetComponent<TextMesh>().text = Database.hargaJualRealCotoMakassar.ToString();
    }

	// Use this for initialization
	void Start () {
        btnPlus.GetComponent<SpriteRenderer>().sprite = normal;
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
