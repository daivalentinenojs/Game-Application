using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class EntranceManager : MonoBehaviour
{

    //public int spawned = 0;
    int[] randomMakanan = { -1, 1, 2, 3 };
    int[] randomMinuman = { -1, 1, 2, 3 };

    public DateTime startTime;
    public GameObject CustomerPrefab;
    public DateTime[] times;
    public int idx;
    public Database db;
    int waypointIndex;
    public int num;
    int maxRand;
    int nIdx;
    // Use this for initialization
    void Start()
    {
        print(randomMakanan.Length + "<--mkn | minum->" + randomMinuman.Length);
        if (!Database.beliResepCotoMakassar)
        {
            randomMakanan[1] = -1;
        }
        if (!Database.beliResepPecel)
        {
            randomMakanan[2] = -1;
        }
        if (!Database.beliResepRujak)
        {
            randomMakanan[3] = -1;
        }
        if (!Database.beliResepEsCendol)
        {
            randomMinuman[2] = -1;
        }
        if (!Database.beliResepEsDawet)
        {
            randomMinuman[1] = -1;
        }
        if (!Database.beliResepJamuSinom)
        {
            randomMinuman[3] = -1;
        }
        print(randomMakanan.Length + "<--mkn | minum->" + randomMinuman.Length);

        idx = 0;
        db = GameObject.Find("Controller").GetComponent<Database>();
        startTime = DateTime.Now;
        print("now is " + startTime);
        num = UnityEngine.Random.Range(Database.minPembeliDatang, Database.maxPembeliDatang);
        maxRand = Database.lamaRound / num - 1;
        Database.LapTotalPembeliDatang = num;
        print("total:" + num + " rand:" + maxRand);
        //maxRand = 1;
        //num = 100;
        times = new DateTime[num];
        nIdx = Database.jumlahMeja;
        for (int a = 0; a < Database.jumlahMeja; a++)
        {
            if (a == 0)
                times[a] = DateTime.Now;
            else
                times[a] = times[a - 1];
            int addition = UnityEngine.Random.Range(1, maxRand);
            times[a] = new DateTime(times[a].Add(new TimeSpan(0, 0, addition)).Ticks);
            print("GENERATED cust arrival time: " + times[a] + " (" + addition + ")");
        }
        print("available menus: ");
        for (int a = 0; a < randomMakanan.Length; a++)
            print(randomMakanan[a] + ")))" + randomMinuman[a]);
    }

    public void generateNewCust()
    {
        if (idx < num && nIdx < num)
        {
            int addition = UnityEngine.Random.Range(1, maxRand);
            times[nIdx] = DateTime.Now;
            times[nIdx] = new DateTime(times[nIdx].Ticks).Add(new TimeSpan(0, 0, addition));
            print("*GENERATED cust arrival time: " + times[idx] + " (" + addition + ")--" + DateTime.Now);
            nIdx++;
        }
        else
        {
            print("MAXED");
        }
    }
    float t1, t2, t3;
    int kemungkinanSemua()
    {
        t1 = (float)Database.hargaJualRealCotoMakassar / (float)Database.hargaJualCotoMakassar;

        t2 = (float)Database.hargaJualRealRujak / (float)Database.hargaJualRujak;

        t3 = (float)Database.hargaJualRealPecel / (float)Database.hargaJualPecel;

        t1 = t1 / (t1 + t2 + t3);
        t2 = t2 / (t1 + t2 + t3);
        t3 = t3 / (t1 + t2 + t3);

        float tx = UnityEngine.Random.Range(0f, 1.0f);
        if (tx <= t1)
            return 1;
        else if (tx <= t2)
            return 2;
        else
            return 3;

    }

    int kemungkinanSemuaMinum()
    {
        t2 = (float)Database.hargaJualRealEsCendol / (float)Database.hargaJualEsCendol;

        t1 = (float)Database.hargaJualRealEsDawet / (float)Database.hargaJualEsDawet;

        t3 = (float)Database.hargaJualJamuSinom / (float)Database.hargaJualJamuSinom;

        t1 = t1 / (t1 + t2 + t3);
        t2 = t2 / (t1 + t2 + t3);
        t3 = t3 / (t1 + t2 + t3);

        float tx = UnityEngine.Random.Range(0f, 1.0f);
        if (tx <= t1)
            return 1;
        else if (tx <= t2)
            return 2;
        else
            return 3;


    }

    public bool[] abisstoke = new bool[6];

    public bool cekStokWsAbisBlm()
    {
        abisstoke[0] = true;
        abisstoke[1] = true;
        abisstoke[2] = true;
        if ((Database.stokDagingSapi <= 0 || Database.stokBumbuHalus <= 0 || Database.stokMinyakGoreng <= 0))
        {
            abisstoke[0] = true;
        }

        if ((Database.stokNasi <= 0 || Database.stokBumbuPecel <= 0 || Database.stokSayuran <= 0))
        {
            abisstoke[1] = true;
        }

        if ((Database.stokLontong <= 0 || Database.stokSayuran <= 0 || Database.stokCingur <= 0))
        {
            abisstoke[2] = true;
        }

        if ((Database.stokAir <= 0 || Database.stokDawet <= 0 || Database.stokSanten <= 0))
        {
            abisstoke[3] = true;
        }

        if ((Database.stokAir <= 0 || Database.stokCendol <= 0 || Database.stokSirup <= 0))
        {
            abisstoke[4] = true;
        }

        if ((Database.stokAir <= 0 || Database.stokDaunAsamMuda <= 0 || Database.stokTemulawak <= 0))
        {
            abisstoke[5] = true;
        }
        bool[] reseps = new bool[6];
        reseps[0] = Database.beliResepCotoMakassar;
        reseps[1] = Database.beliResepPecel;
        reseps[2] = Database.beliResepRujak;
        reseps[3] = Database.beliResepEsDawet;
        reseps[4] = Database.beliResepEsCendol;
        reseps[5] = Database.beliResepJamuSinom;

        int stokabis = 0;
        int totalresep = 0;
        for (int a = 3; a < 6; a++)
        {
            if (reseps[a])
            {
                totalresep++;
                if (abisstoke[a])
                    stokabis++;
            }
        }
        print("resep:" + totalresep + "  abis:" + stokabis);
        if (stokabis == totalresep)
            return true;
        else
            return false;
    }


    GameObject spawnedCust;
    // Update is called once per frame
    void Update()
    {
        if (!Database.waktuAbis && !cekStokWsAbisBlm())
        {
            if (Database.orangDiMeja < Database.jumlahMeja)
            {
                if (idx < times.Length && DateTime.Now >= times[idx])
                {
                    spawnedCust = (GameObject)Instantiate(CustomerPrefab, gameObject.transform.position, Quaternion.identity);

                    if (UnityEngine.Random.Range(0, 100) < Database.kemungkinanGaBeliMakan)
                    {
                        spawnedCust.GetComponent<Customer>().makananID = -1;
                    }
                    else
                    {
                        spawnedCust.GetComponent<Customer>().makananID = kemungkinanSemua();
                    }
                    if (UnityEngine.Random.Range(0, 100) < Database.kemungkinanGaBeliMinum)
                    {
                        spawnedCust.GetComponent<Customer>().minumanID = kemungkinanSemuaMinum();
                    }
                    else
                    {
                        spawnedCust.GetComponent<Customer>().minumanID = kemungkinanSemuaMinum();
                    }
                    int minume = randomMinuman[kemungkinanSemuaMinum()];
                    int makane = randomMakanan[kemungkinanSemua()];
                    spawnedCust.GetComponent<Customer>().minumanID = minume;
                    spawnedCust.GetComponent<Customer>().makananID = makane;

                    spawnedCust.GetComponent<Customer>().idx = idx;
                    spawnedCust.GetComponent<Customer>().db = db;
                    spawnedCust.gameObject.name = "Customer-" + idx;
                    spawnedCust.GetComponent<Customer>().goToTableManager();
                    idx++;
                    Database.orangDiMeja++;
                    print("spawned cust " + idx + "(" + Database.orangDiMeja + "<>" + Database.jumlahMeja + ") next->" + times[idx] + " prev->" + times[idx - 1] + "makID: " + spawnedCust.GetComponent<Customer>().makananID + " minID: " + spawnedCust.GetComponent<Customer>().minumanID+ "makane: "+makane+"minume: "+minume);
                }
            }
            if (idx == num && GameObject.FindGameObjectWithTag("Customer") == null)
                Database.dayend = true;
        }
        //else
        //{
        //    for(int a=idx;a<times.Length;a++)
        //    {
        //        times[a] = DateTime.Now;
        //    }
        //}
    }



}
