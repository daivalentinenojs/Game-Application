using UnityEngine;
using System.Collections;

public class btnStokKurangAirPutih : MonoBehaviour {

    public GameObject stokAirPutih;

    public AudioClip sound;

    public GameObject btnMinus;
    public Sprite normal;
    public Sprite hover;
    public Sprite click;

    public GameObject balonCost;
    public Sprite costNormal;
    public Sprite costLvl1;

    private AudioSource source { get { return GetComponent<AudioSource>(); } }

    void OnMouseEnter()
    {
        btnMinus.GetComponent<SpriteRenderer>().sprite = hover;
        balonCost.GetComponent<SpriteRenderer>().sprite = costLvl1;
        source.PlayOneShot(sound);
    }

    void OnMouseExit()
    {
        balonCost.GetComponent<SpriteRenderer>().sprite = costNormal; 
        btnMinus.GetComponent<SpriteRenderer>().sprite = normal;
    }

    void OnMouseDown()
    {
        btnMinus.GetComponent<SpriteRenderer>().sprite = click;
        if (Database.stokAir >= 1)
        {
            Database.stokAir -= 1;
            Database.uang += 1;
            print(Database.stokAir);
            stokAirPutih.GetComponent<TextMesh>().text = Database.stokAir.ToString();
        }
    }

	// Use this for initialization
	void Start () {
        btnMinus.GetComponent<SpriteRenderer>().sprite = normal;
        stokAirPutih.GetComponent<TextMesh>().text = Database.stokAir.ToString();

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
