using UnityEngine;
using System.Collections;

public class backtoprepday : MonoBehaviour {

    public AudioClip sound;

    public GameObject btnMenu;
    public Sprite normal;
    public Sprite hover;
    public Sprite click;

    private AudioSource source { get { return GetComponent<AudioSource>(); } }

    void OnMouseEnter()
    {
        btnMenu.GetComponent<SpriteRenderer>().sprite = hover;
        source.PlayOneShot(sound);
        print("1");
    }

    void OnMouseExit()
    {
        print("3");
        btnMenu.GetComponent<SpriteRenderer>().sprite = normal;
    }

    void OnMouseDown()
    {
        print("2");
        btnMenu.GetComponent<SpriteRenderer>().sprite = click;
        Database.LapDapetTotalUang = 0;
        Database.LapTotalIncome = 0;
        Database.LapTotalMakananTerjual = new int[3];
        Database.LapTotalMinumanTerjual = new int[3];
        Database.LapTotalPembeliDatang = 0;
        Database.LapTotalPembeliGagalBeli = 0;
        Application.LoadLevel(2);
    }

	// Use this for initialization
	void Start () {
        btnMenu.GetComponent<SpriteRenderer>().sprite = normal;
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
