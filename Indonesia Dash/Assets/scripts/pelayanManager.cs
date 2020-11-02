using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
[System.Serializable]
public class pesanan
{
    public DateTime waktuKeluar;
    public Table mejaID;
}

public class pelayanManager : MonoBehaviour {

    List<pesanan> qOrder = new List<pesanan>();
    GameObject pelayane;
	// Use this for initialization
	void Start () {
        pelayane = GameObject.Find("pelayan");
	}
	
	// Update is called once per frame
	void Update () {
        if(qOrder.Count!=0)
	    if(qOrder[0].waktuKeluar<=DateTime.Now)
        {
            if(!pelayane.GetComponent<pelayan>().busy)
            { 
                pelayane.GetComponent<pelayan>().aktifkanPelayan(qOrder[0]);
                qOrder.RemoveAt(0);
            }
        }
	}

    public void newOrder(TimeSpan lama,Table yangBeli)
    {
        if (lama != new TimeSpan(24, 0, 0))
        {
            pesanan t = new pesanan();
            t.mejaID = yangBeli;
            t.waktuKeluar = DateTime.Now.Add(lama);
            qOrder.Add(t);
        }
    }

}
