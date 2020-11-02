using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;


[System.Serializable]
public class mesin
{
    public GameObject objekMesin;
    public bool enabled;
    public TimeSpan lama;
    public int sediaMinumanID;
}


public class mesinManager : MonoBehaviour
{

    public mesin[] alat;
    public TableManager tm;
    public Database db;
    public GameObject kasir;
    public GameObject bubble;
    public GameObject uangui;
    public GameObject[] txtMinuman;
    float endbuble;
    // Use this for initialization
    void Start()
    {

        for (int a = 0; a < alat.Length; a++)
        {
            alat[a].objekMesin.GetComponent<mesinScript>().id = a;
        }
        alat[0].sediaMinumanID = 1;
        alat[1].sediaMinumanID = 2;
        alat[2].sediaMinumanID = 3;
        db = GameObject.Find("Controller").GetComponent<Database>();
        tm = db.tableManager.GetComponent<TableManager>();

        uangui.GetComponent<TextMesh>().text = "Total Money:\n IDR " + Database.uang + "";
    }

    // Update is called once per frame
    void Update()
    {
        float timeleft = endbuble - Time.time;
        if (timeleft <= 0)
            bubble.GetComponent<SpriteRenderer>().enabled = false;
    }

    public void pakeMesin(int id)
    {
        if (alat[id].sediaMinumanID == 1)
        {
            Database.stokAir -= Database.jumlahResepSatuEsDawetAir;
            Database.stokDawet -= Database.jumlahResepDuaEsDawetDawet;
            Database.stokSanten -= Database.jumlahResepTigaEsDawetSanten;
        }
        if (alat[id].sediaMinumanID == 2)
        {
            Database.stokAir -= Database.jumlahResepSatuEsCendolAir;
            Database.stokCendol -= Database.jumlahResepDuaEsCendolCendol;
            Database.stokSirup -= Database.jumlahResepTigaEsCendolSirup;
        }
        if (alat[id].sediaMinumanID == 3)
        {
            Database.stokAir -= Database.jumlahResepSatuJamuSinomAir;
            Database.stokDaunAsamMuda -= Database.jumlahResepDuaJamuSinomDaunAsamMuda;
            Database.stokTemulawak -= Database.jumlahResepTigaJamuSinomTemulawak;
        }
        print("kurangi stok minuman id:" + id);
        tm.updateStok();
        if (tm.udahDilayaniMinum(alat[id].sediaMinumanID))
        {
            Database.LapTotalMinumanTerjual[id]++;
            txtMinuman[0].GetComponent<TextMesh>().text = Database.LapTotalMinumanTerjual[0] + "";
            txtMinuman[1].GetComponent<TextMesh>().text = Database.LapTotalMinumanTerjual[1] + "";
            txtMinuman[2].GetComponent<TextMesh>().text = Database.LapTotalMinumanTerjual[2] + "";
            if (alat[id].sediaMinumanID == 1)
            {
                Database.LapDapetTotalUang += Database.hargaJualRealEsDawet;
                Database.uang += Database.hargaJualRealEsDawet;
                Database.LapTotalIncome += Database.hargaJualRealEsDawet + Database.HRGBahanAirPutih + Database.HRGBahanDawet + Database.HRGBahanSanten;
            }
            if (alat[id].sediaMinumanID == 2)
            {
                Database.LapDapetTotalUang += Database.hargaJualRealEsCendol;
                Database.uang += Database.hargaJualRealEsCendol;
                Database.LapTotalIncome += Database.hargaJualRealEsCendol + Database.HRGBahanAirPutih + Database.HRGBahanCendol + Database.HRGBahanSirup;
            }
            if (alat[id].sediaMinumanID == 3)
            {
                Database.LapDapetTotalUang += Database.hargaJualRealJamuSinom;
                Database.uang += Database.hargaJualRealJamuSinom;
                Database.LapTotalIncome += Database.hargaJualRealJamuSinom + Database.HRGBahanAirPutih + Database.HRGBahanDaunAsamMuda + Database.HRGBahanTemulawak;
            }
            print("bener pencete");
            uangui.GetComponent<TextMesh>().text = "Total Money\n IDR "+ Database.uang+"";
        }
        else
        {
            endbuble = Time.time + 3;
            bubble.GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}
