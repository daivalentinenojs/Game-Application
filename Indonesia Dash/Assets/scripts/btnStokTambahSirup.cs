﻿using UnityEngine;
using System.Collections;

public class btnStokTambahSirup : MonoBehaviour {

    public GameObject stokSirup;

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
        if (Database.upgradeResepEsCendol == 0)
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
        if (Database.upgradeResepEsCendol > 0)
        {
            Database.stokSirup += 1;
            Database.uang -= 2;
            print(Database.stokSirup);
            stokSirup.GetComponent<TextMesh>().text = Database.stokSirup.ToString();
        }
    }

	// Use this for initialization
	void Start () {
        btnPlus.GetComponent<SpriteRenderer>().sprite = normal;
        stokSirup.GetComponent<TextMesh>().text = Database.stokSirup.ToString();

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
