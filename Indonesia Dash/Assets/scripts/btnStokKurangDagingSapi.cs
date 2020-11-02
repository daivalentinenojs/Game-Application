using UnityEngine;
using System.Collections;

public class btnStokKurangDagingSapi : MonoBehaviour {

    public GameObject stokDagingSapi;

    public AudioClip sound;
    public GameObject balonCost;
    public Sprite costNormal;
    public Sprite costLvl1;
    public GameObject btnMinus;
    public Sprite normal;
    public Sprite hover;
    public Sprite click;

    private AudioSource source { get { return GetComponent<AudioSource>(); } }

    void OnMouseEnter()
    {
        balonCost.GetComponent<SpriteRenderer>().sprite = costLvl1;
        btnMinus.GetComponent<SpriteRenderer>().sprite = hover;
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
        if (Database.stokDagingSapi >= 1)
        {
            Database.stokDagingSapi -= 1;
            Database.uang += 7;
            print(Database.stokDagingSapi);
            stokDagingSapi.GetComponent<TextMesh>().text = Database.stokDagingSapi.ToString();
        }
    }

	// Use this for initialization
	void Start () {
        btnMinus.GetComponent<SpriteRenderer>().sprite = normal;
        stokDagingSapi.GetComponent<TextMesh>().text = Database.stokDagingSapi.ToString();

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
