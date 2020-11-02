using UnityEngine;
using System.Collections;

public class btnStokTambahMinyakGoreng : MonoBehaviour {

    public GameObject stokMinyakGoreng;

    public AudioClip sound;
    public GameObject balonCost;
    public Sprite costNormal;
    public Sprite costLvl1;
    public GameObject btnPlus;
    public Sprite normal;
    public Sprite hover;
    public Sprite click;

    private AudioSource source { get { return GetComponent<AudioSource>(); } }

    void OnMouseEnter()
    {
        balonCost.GetComponent<SpriteRenderer>().sprite = costLvl1;
        btnPlus.GetComponent<SpriteRenderer>().sprite = hover;
        source.PlayOneShot(sound);
    }

    void OnMouseExit()
    {
        balonCost.GetComponent<SpriteRenderer>().sprite = costNormal; 
        btnPlus.GetComponent<SpriteRenderer>().sprite = normal;
    }

    void OnMouseDown()
    {
        btnPlus.GetComponent<SpriteRenderer>().sprite = click;
        Database.stokMinyakGoreng += 1;
        Database.uang -= 1;
        print(Database.stokMinyakGoreng);
        stokMinyakGoreng.GetComponent<TextMesh>().text = Database.stokMinyakGoreng.ToString();
    }

	// Use this for initialization
	void Start () {
        btnPlus.GetComponent<SpriteRenderer>().sprite = normal;
        stokMinyakGoreng.GetComponent<TextMesh>().text = Database.stokMinyakGoreng.ToString();

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
