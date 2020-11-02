using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[System.Serializable]
public class Table
{
    public GameObject tableObject;
    public bool full;
    public DateTime leaveTime;
    public DateTime enterTime;
    public bool busy;
    public DateTime length;
}


public class TableManager : MonoBehaviour
{

    public Table[] tables;
    public GameObject bubble;
    public GameObject bubble2;
    public Sprite sebal;
    public Sprite angry;
    public Sprite broke;
    public Sprite[] makanans;
    public Sprite[] minums;
    public GameObject[] stoks;
    //public Queue<Customer> q;
    public List<Customer> q;
    public Customer dilayani;
    public bool udhMinum;
    public bool nungguPesen;
    public bool diaDiDepanKasir;
    public bool pesenanAbis;
    public DateTime jamPesen;
    public GameObject uangui;
    public GameObject[] txtMakanan;
    Animator anim;
    public float startTime;
    public float leaveTime;
    public float angryTime;
    float timeleft;
    float timeleft2;
    float timeleft3;
    TimeSpan lamaBuatMakanan;
    //public GameObject maunyacust;
    GameObject custYangLiat2;
    pelayanManager pelayanManager1;
    Database db;
    bool moving = false;
    bool walkOut = false;
    Table spot;
    // Use this for initialization
    void Start()
    {
        updateStok();
        Database.jumlahMeja = tables.Length;
        db = GameObject.Find("Controller").GetComponent<Database>();
        //maunyacust = GameObject.Find("maunyaCust");
        pelayanManager1 = GameObject.Find("Controller").GetComponent<pelayanManager>();
        string lvMeja = "";
        if (Database.upgradeMeja == 0)
            lvMeja = "level1";
        else if (Database.upgradeMeja == 1)
            lvMeja = "level2";
        else if (Database.upgradeMeja == 2)
            lvMeja = "level3";
        for (int a = 0; a < tables.Length; a++)
            tables[a].tableObject.gameObject.GetComponent<Animator>().SetBool(lvMeja, true);
    }

    // Update is called once per frame
    void Update()
    {

        if (dilayani != null)
        {
            goToMeja();
        }

        if (q.Count != 0)
        {
            //tarik cust bentuk barisan
            for (int a = 0; a < q.Count; a++)
            {
                if (a == 0)
                {
                    if (Vector3.Distance(q[a].gameObject.transform.position, gameObject.transform.position) > 0.23f)
                    {
                        q[a].gameObject.transform.position = Vector3.MoveTowards(q[a].gameObject.transform.position, gameObject.transform.position, Database.kecepatanJalanCust);
                    }
                    else
                    {
                        q[a].gameObject.GetComponent<Animator>().SetBool("didepankasir", true);
                    }
                }
                else
                {
                    if (Vector3.Distance(q[a].gameObject.transform.position, q[a - 1].gameObject.transform.position) > 0.64f)
                    {
                        q[a].gameObject.transform.position = Vector3.MoveTowards(q[a].gameObject.transform.position, q[a - 1].gameObject.transform.position, Database.kecepatanJalanCust);

                    }
                    else
                    {
                        if (!q[a].gameObject.GetComponent<Animator>().GetBool("didepankasir"))
                            q[a].gameObject.GetComponent<Animator>().SetBool("antri", true);
                    }
                }

                //anim = q[a].gameObject.GetComponent<Animator>();
                //anim.Play("cust1jalanketablemanager");
                //anim.SetBool("jalanketablemanager", true);
            }
        }

        if (nungguPesen)
        {
            if (jamPesen <= DateTime.Now)
            {
                if (false)
                {
                    //print("makan tok->");
                    //makantok = false;
                    //diaDiDepanKasir = false;
                    
                    //if (q[0].bubble2 != null)
                    //    Destroy(q[0].bubble2);

                    //if (q[0].bubble != null)
                    //    Destroy(q[0].bubble);
                    //q[0].gameObject.GetComponent<Animator>().SetBool("jalankemeja", true);
                    //if (q.Count > 1)
                    //    q[1].gameObject.GetComponent<Animator>().SetBool("abisantri", true);
                    ////q.RemoveAt(0);
                    //nungguPesen = false;
                    //udhMinum = true;
                }
                else
                {
                    if (q[0].GetComponent<Customer>().bubble == null)
                    {
                        bubble.GetComponent<SpriteRenderer>().sprite = broke;
                        q[0].GetComponent<Customer>().bubble = (GameObject)Instantiate(bubble,
                            new Vector3(q[0].transform.position.x + 0.57f, q[0].transform.position.y + 0.72f, q[0].transform.position.z),
                            bubble.transform.rotation);
                    }
                    else
                    {
                        q[0].bubble.gameObject.GetComponent<SpriteRenderer>().sprite = broke;
                    }
                    if (q[0].bubble2 != null)
                        Destroy(q[0].bubble2);
                    q[0].gameObject.GetComponent<Animator>().SetBool("jalankemeja", true);
                    if (q.Count > 1)
                        q[1].gameObject.GetComponent<Animator>().SetBool("abisantri", true);
                    custYangLiat2.GetComponent<Customer>().walkOut = true;
                    q.RemoveAt(0);
                    Database.LapTotalPembeliGagalBeli++;
                    Database.orangDiMeja--;
                    db.entranceManager.GetComponent<EntranceManager>().generateNewCust();
                    print("odm-=-=-=->" + Database.orangDiMeja);
                    nungguPesen = false;
                    walkOut = false;
                }
                //maunyacust.GetComponent<TextMesh>().text = "";
            }
        }
        if (udhMinum)
        {
            //maunyacust.GetComponent<TextMesh>().text = "";
            if (q.Count > 1)
                q[1].gameObject.GetComponent<Animator>().SetBool("abisantri", true);
            dilayani = q[0];
            q.RemoveAt(0);
            udhMinum = false;
            print("udh minum");
        }
        if (diaDiDepanKasir)
        {
            timeleft = startTime - Time.time;
            if (timeleft <= 0)
            {
                timeleft = 0;
                if (q[0].bubble == null)
                {
                    bubble.GetComponent<SpriteRenderer>().sprite = sebal;
                    q[0].bubble = (GameObject)Instantiate(bubble,
                        new Vector3(q[0].transform.position.x + 0.57f, q[0].transform.position.y + 0.72f, q[0].transform.position.z),
                        bubble.transform.rotation);
                }
                else
                {
                    q[0].bubble.gameObject.GetComponent<SpriteRenderer>().sprite = sebal;
                }
                timeleft2 = leaveTime - Time.time;
                if (timeleft2 <= 0)
                {
                    timeleft2 = 0;
                    timeleft3 = angryTime - Time.time;
                    q[0].bubble.GetComponent<SpriteRenderer>().sprite = angry;
                    if (timeleft3 <= 0)
                    {
                        if (q[0].bubble2 != null)
                            Destroy(q[0].bubble2);
                        q[0].gameObject.GetComponent<Animator>().SetBool("jalankemeja", true);
                        if (q.Count > 1)
                            q[1].gameObject.GetComponent<Animator>().SetBool("abisantri", true);
                        q[0].GetComponent<Customer>().walkOut = true;
                        q.RemoveAt(0);
                        Database.LapTotalPembeliGagalBeli++;
                        diaDiDepanKasir = false;
                        Database.orangDiMeja--;
                        db.entranceManager.GetComponent<EntranceManager>().generateNewCust();
                        print("kelamaan (wo)" + Database.orangDiMeja);
                        nungguPesen = false;
                        //maunyacust.GetComponent<TextMesh>().text = "";
                        timeleft3 = 0;
                    }
                }
            }
        }
    }

    public bool udahDilayaniMinum(int idMinumanDikasi)
    {
        if (diaDiDepanKasir)
        {
            if (idMinumanDikasi == q[0].minumanID)
            {
                if (q[0].makananID == 1)
                {
                    Database.stokDagingSapi -= Database.jumlahResepSatuCotoMakassarDagingSapi;
                    Database.stokBumbuHalus -= Database.jumlahResepDuaCotoMakassarBumbuHalus;
                    Database.stokMinyakGoreng -= Database.jumlahResepTigaCotoMakassarMinyakGoreng;
                    Database.LapTotalMakananTerjual[0]++;
                    txtMakanan[0].GetComponent<TextMesh>().text = Database.LapTotalMakananTerjual[0] + "";
                    Database.LapDapetTotalUang += Database.hargaJualRealCotoMakassar;
                    Database.LapTotalIncome+=Database.hargaJualRealCotoMakassar+Database.HRGBahanDagingSapi+ Database.HRGBahanBumbuHalus+Database.HRGBahanMinyakGoreng ;//-Database.
                    Database.uang += Database.hargaJualRealCotoMakassar;
                }
                if (q[0].makananID == 2)
                {
                    Database.stokNasi -= Database.jumlahResepSatuPecelNasi;
                    Database.stokBumbuPecel -= Database.jumlahResepDuaPecelBumbuPecel;
                    Database.stokSayuran -= Database.jumlahResepTigaPecelSayuran;
                    Database.LapTotalMakananTerjual[1]++;
                    txtMakanan[1].GetComponent<TextMesh>().text = Database.LapTotalMakananTerjual[1] + "";
                    Database.LapDapetTotalUang += Database.hargaJualRealPecel;
                    Database.uang += Database.hargaJualRealPecel;
                    Database.LapTotalIncome += Database.hargaJualRealPecel + Database.HRGBahanNasi + Database.HRGBahanBumbuPecel + Database.HRGBahanSayuran;//-Database.
                }
                if (q[0].makananID == 3)
                {
                    Database.stokNasi -= Database.jumlahResepSatuRujakLontong;
                    Database.stokSayuran -= Database.jumlahResepDuaRujakSayuran;
                    Database.stokCingur -= Database.jumlahResepTigaRujakCingur;
                    Database.LapTotalMakananTerjual[2]++;
                    txtMakanan[2].GetComponent<TextMesh>().text = Database.LapTotalMakananTerjual[2] + "";
                    Database.LapDapetTotalUang += Database.hargaJualRealRujak;
                    Database.uang += Database.hargaJualRealRujak;
                    Database.LapTotalIncome += Database.hargaJualRealRujak + Database.HRGBahanLontong + Database.HRGBahanSayuran + Database.HRGBahanCingur;//-Database.
                }

                uangui.GetComponent<TextMesh>().text = "Total Money\n IDR "+Database.uang + "";
                updateStok();
                //...dst
                q[0].gameObject.GetComponent<Animator>().SetBool("jalankemeja", true);
                if (q[0].bubble != null)
                    Destroy(q[0].bubble);
                if (q[0].bubble2 != null)
                    Destroy(q[0].bubble2);
                udhMinum = true;
                diaDiDepanKasir = false;
                return true;
            }
            else
                return false;
        }
        return false;
    }

    public void goToMeja()
    {
        for (int a = 0; a < tables.Length; a++)
        {
            if (!tables[a].tableObject.GetComponent<TableScript>().stats.full)
                spot = tables[a];
        }
        spot.tableObject.GetComponent<TableScript>().custBaru = dilayani;
        dilayani.gameObject.GetComponent<SpriteRenderer>().sprite = db.jalanKeMeja;
        pelayanManager1.newOrder(lamaBuatMakanan, spot);
        dilayani = null;
    }


    public void updateStok()
    {
        int[] stoc = new int[18];
        stoc[0] = Database.stokDagingSapi;//makanan ID1 
        stoc[1] = Database.stokBumbuHalus;
        stoc[2] = Database.stokMinyakGoreng;

        stoc[3] = Database.stokNasi;//makananID2
        stoc[4] = Database.stokBumbuPecel;
        stoc[5] = Database.stokSayuran;

        stoc[6] = Database.stokLontong;//makananID3
        stoc[7] = Database.stokSayuran;
        stoc[8] = Database.stokCingur;

        stoc[9] = Database.stokAir;//minuman ID1
        stoc[10] = Database.stokDawet;
        stoc[11] = Database.stokSanten;

        stoc[12] = Database.stokAir;//minuman ID2
        stoc[13] = Database.stokCendol;
        stoc[14] = Database.stokSirup;

        stoc[15] = Database.stokAir;//minuman ID3
        stoc[16] = Database.stokDaunAsamMuda;
        stoc[17] = Database.stokTemulawak;
        
        for(int a=0;a<stoks.Length;a++)
        {
            if (stoc[a] < 0)
                stoc[a] = 0;
            stoks[a].gameObject.GetComponent<TextMesh>().text = stoc[a]+"";
        }
    }

    void OnTriggerEnter2D(Collider2D obj)
    {
        print("TableManager collided with " + obj.gameObject.name);
        if (obj.gameObject.tag == "Customer")
        {
            if (obj.gameObject == q[0].gameObject)
            {
                anim = obj.gameObject.GetComponent<Animator>();
                anim.SetBool("didepankasir", true);
                // obj.gameObject.GetComponent<SpriteRenderer>().sprite = db.sedangDilayani;
                //TODO: nambah probabilitas cust pergi,gak ke meja
               // walkOut = (UnityEngine.Random.Range(0, 100) <= Database.kemungkinanGaBeliMakan);
                walkOut = false;
                if(q[0].makananID==1)
                {
                    bubble2.GetComponent<SpriteRenderer>().sprite = makanans[0];
                    if ((Database.stokDagingSapi <= 0 || Database.stokBumbuHalus <= 0 || Database.stokMinyakGoreng <= 0))
                    {
                        walkOut = true;
                        print("makanan 1 abis");
                    }
                }
                if (q[0].makananID ==2)
                {
                    bubble2.GetComponent<SpriteRenderer>().sprite = makanans[1];
                    if ((Database.stokNasi <= 0 || Database.stokBumbuPecel <= 0 || Database.stokSayuran <= 0))
                    {
                        walkOut = true;
                        print("makanan 2 abis");
                    }
                }
                if (q[0].makananID == 3)
                {
                    bubble2.GetComponent<SpriteRenderer>().sprite = makanans[2];
                    if ((Database.stokLontong <= 0 || Database.stokSayuran <= 0 || Database.stokCingur <= 0))
                    {
                        walkOut = true;
                        print("makanan 3 abis");
                    }
                }
                if (q[0].minumanID == 1)
                {
                    bubble.GetComponent<SpriteRenderer>().sprite = minums[0];
                    if ((Database.stokAir <= 0 || Database.stokDawet <= 0 || Database.stokSanten <= 0))
                    {
                       // walkOut = true;
                        print("minum 1 abis");
                    }
                }

                if (q[0].minumanID == 2)
                {
                    bubble.GetComponent<SpriteRenderer>().sprite = minums[1];
                    if ((Database.stokAir <= 0 || Database.stokCendol <= 0 || Database.stokSirup <= 0))
                    {
                       // walkOut = true;
                        print("minum 2 abis");
                    }
                }

                if (q[0].minumanID == 3)
                {
                    bubble.GetComponent<SpriteRenderer>().sprite = minums[2];
                    if ((Database.stokAir <= 0 || Database.stokDaunAsamMuda <= 0 || Database.stokTemulawak <= 0))
                    {
                       // walkOut = true;
                        print("minum 3 abis");
                    }
                }
                q[0].bubble = (GameObject)Instantiate(bubble,
                       new Vector3(q[0].transform.position.x + 0.57f, q[0].transform.position.y + 0.72f, q[0].transform.position.z),
                       bubble.transform.rotation);
                if(q[0].makananID!=-1   )
                q[0].bubble2 = (GameObject)Instantiate(bubble2,
                      new Vector3(q[0].transform.position.x + 1.15f, q[0].transform.position.y + 0.58f, q[0].transform.position.z),
                      bubble2.transform.rotation);
                print("abis stok:" + walkOut);
                if (walkOut || (q[0].makananID == -1 && q[0].minumanID == -1) || (q[0].minumanID==-1))
                {
                    nungguPesen = true;
                    int rnd = UnityEngine.Random.Range(1, 3);
                    jamPesen = DateTime.Now.AddSeconds(rnd);
                    //print(jamPesen + "-->" + rnd);
                    custYangLiat2 = obj.gameObject;
                    //maunyacust.GetComponent<TextMesh>().text = "Hmm..pesen apa ya";
                }
                else
                {
                    bool makan = false;
                    bool minum = false;
                    string pesane = "";
                    if (q[0].makananID != -1)
                    {
                        makan = true;
                        pesane = "Pesan " + Database.namamakanan[q[0].makananID - 1];
                        lamaBuatMakanan = Database.lamaBuatArray[q[0].makananID - 1];
                    }
                    if (q[0].minumanID != -1)
                    {
                        minum = true;
                        if (makan)
                            pesane += "\ndan " + Database.namaminuman[q[0].minumanID - 1];
                        else
                        {
                            pesane = "Pesan " + Database.namaminuman[q[0].minumanID - 1];
                            lamaBuatMakanan = new TimeSpan(24, 0, 0);
                        }

                    }
                    if (makan || minum)
                    {
                        diaDiDepanKasir = true;
                        //maunyacust.GetComponent<TextMesh>().text = pesane;
                       // print("pesane: "+pesane);
                        startTime = Time.time + 5f;
                        leaveTime = Time.time + 10f;
                        angryTime = Time.time + 13f;
                    }

                    //TODO: tambah action kalo abis -> delay 1s(pesenanAbis) -> walk out 
                }
                if (dilayani != null)
                    print("done serving cust id: " + dilayani.gameObject.GetComponent<Customer>().idx + " sisa: " + q.Count);
            }
        }
    }
   // bool makantok = false;
    void OnTriggerExit2D(Collider2D obj)
    {
        //if (obj.gameObject.tag == "Customer")
        //{
        //    if (obj.gameObject == q.Peek())
        //    {

        //    }
        //}
    }
}