using UnityEngine;
using System.Collections;

public class btnStokKurangSayuran : MonoBehaviour {

    public GameObject stokSayuran;

    public AudioClip sound;

    public GameObject btnMinus;
    public Sprite normal;
    public Sprite hover;
    public Sprite click;

    public GameObject balonCost;
    public Sprite costNormal;
    public Sprite costLvl1;
    public Sprite belumBeli;
    //public Sprite belumBeliPecel;
    //public Sprite belumBeliRujak;

    private AudioSource source { get { return GetComponent<AudioSource>(); } }

    void OnMouseEnter()
    {
        btnMinus.GetComponent<SpriteRenderer>().sprite = hover;
        source.PlayOneShot(sound);
        if (Database.upgradeResepRujak == 0 && Database.upgradeResepPecel == 0) 
        {
            balonCost.GetComponent<SpriteRenderer>().sprite = belumBeli;
        }
        //else if (Database.upgradeResepRujak == 1 || Database.upgradeResepPecel == 0)
        //{
        //    balonCost.GetComponent<SpriteRenderer>().sprite = belumBeliPecel;
        //}
        //else if (Database.upgradeResepRujak == 0 || Database.upgradeResepPecel == 1)
        //{
        //    balonCost.GetComponent<SpriteRenderer>().sprite = belumBeliRujak;
        //}
        else
        {
            balonCost.GetComponent<SpriteRenderer>().sprite = costLvl1;
        }
    }

    void OnMouseExit()
    {
        btnMinus.GetComponent<SpriteRenderer>().sprite = normal;
        balonCost.GetComponent<SpriteRenderer>().sprite = costNormal; 
    }

    void OnMouseDown()
    {
        btnMinus.GetComponent<SpriteRenderer>().sprite = click;
        if ((Database.stokSayuran >= 1 && Database.upgradeResepRujak > 0) || (Database.stokSayuran >= 1 && Database.upgradeResepPecel > 0))
        {
            Database.stokSayuran -= 1;
            Database.uang += 3;
            print(Database.stokSayuran);
            stokSayuran.GetComponent<TextMesh>().text = Database.stokSayuran.ToString();
        }
    }

	// Use this for initialization
	void Start () {
        btnMinus.GetComponent<SpriteRenderer>().sprite = normal;
        stokSayuran.GetComponent<TextMesh>().text = Database.stokSayuran.ToString();

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
