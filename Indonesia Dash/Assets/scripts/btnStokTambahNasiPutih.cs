﻿using UnityEngine;
using System.Collections;

public class btnStokTambahNasiPutih : MonoBehaviour {

    public GameObject stokNasiPutih;

    public AudioClip sound;

    public GameObject btnPlus;
    public Sprite normal;
    public Sprite hover;
    public Sprite click;
    public GameObject balonCost;
    public Sprite costNormal;
    public Sprite costLvl1;
    public Sprite belumBeli;
    private AudioSource source { get { return GetComponent<AudioSource>(); } }

    void OnMouseEnter()
    {
        btnPlus.GetComponent<SpriteRenderer>().sprite = hover;
        source.PlayOneShot(sound);
        if (Database.upgradeResepPecel == 0)
        {
            balonCost.GetComponent<SpriteRenderer>().sprite = belumBeli;
        }
        else
        {
            balonCost.GetComponent<SpriteRenderer>().sprite = costLvl1;
        }
    }

    void OnMouseExit()
    {
        balonCost.GetComponent<SpriteRenderer>().sprite = costNormal; 
        btnPlus.GetComponent<SpriteRenderer>().sprite = normal;
    }

    void OnMouseDown()
    {
        btnPlus.GetComponent<SpriteRenderer>().sprite = click;
        if (Database.upgradeResepPecel > 0)
        {
            Database.stokNasi += 1;
            Database.uang -= 5;
            print(Database.stokNasi);
            stokNasiPutih.GetComponent<TextMesh>().text = Database.stokNasi.ToString();
        }
    }

	// Use this for initialization
	void Start () {
        btnPlus.GetComponent<SpriteRenderer>().sprite = normal;
        stokNasiPutih.GetComponent<TextMesh>().text = Database.stokNasi.ToString();

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
