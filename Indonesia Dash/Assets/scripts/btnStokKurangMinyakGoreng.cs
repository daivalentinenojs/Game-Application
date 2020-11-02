using UnityEngine;
using System.Collections;

public class btnStokKurangMinyakGoreng : MonoBehaviour {

    public GameObject stokMinyakGoreng;

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
        if (Database.stokMinyakGoreng >= 1)
        {
            Database.stokMinyakGoreng -= 1;
            Database.uang += 1;
            print(Database.stokMinyakGoreng);
            stokMinyakGoreng.GetComponent<TextMesh>().text = Database.stokMinyakGoreng.ToString();
        }
    }


	// Use this for initialization
	void Start () {
        btnMinus.GetComponent<SpriteRenderer>().sprite = normal;
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
