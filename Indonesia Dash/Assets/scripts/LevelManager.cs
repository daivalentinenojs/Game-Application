using UnityEngine;
using System.Collections;

[System.Serializable]
public class upgrades
{
    public GameObject objek;
    public bool enabled;
}

public class LevelManager : MonoBehaviour {

    public int minute;
    public int second;
    public GameObject ui;
    public upgrades[] upgrade; 
    public float endTime = 0.0f;
    public EntranceManager ent;
	// Use this for initialization
    void Start()
    {
        ent = GameObject.Find("entranceManager").GetComponent<EntranceManager>();
        Database.dayend = false;
        Database.waktuAbis = false;
        endTime = Time.time + Database.lamaRound;
        second = Database.lamaRound;
        minute = (second / 60);
        second = second % 60;
        ui = GameObject.Find("UI");
        if (Database.upgradeTanaman == 0)
            upgrade[0].enabled = false;
        else
        {
            string st = "";
            upgrade[0].enabled = true;
            if (Database.upgradeTanaman == 2)
                st = "lv2";
            else if (Database.upgradeTanaman==3)
                st = "lv3";
            if (st != "")
                upgrade[0].objek.GetComponent<Animator>().SetTrigger(st);
        }

        if (Database.upgradePigura == 0)
            upgrade[1].enabled = false;
        else
        {
            string st = "";
            upgrade[1].enabled = true;
            if (Database.upgradePigura == 2)
                st = "lv2";
            else if (Database.upgradePigura==3)
                st = "lv3";
            if (st != "")
                upgrade[1].objek.GetComponent<Animator>().SetTrigger(st);
        }

        if (Database.upgradeTV == 0)
            upgrade[2].enabled = false;
        else
        {
            string st = "";
            upgrade[2].enabled = true;
            if (Database.upgradeTV == 2)
                st = "lv2";
            else if (Database.upgradeTV == 3)
                st = "lv3";
            if (st != "")
                upgrade[2].objek.GetComponent<Animator>().SetTrigger(st);
        }


        if (Database.upgradeMusicPlayer == 0)
            upgrade[3].enabled = false;
        else
        {
            string st = "";
            upgrade[3].enabled = true;
            if (Database.upgradeMusicPlayer == 2)
                st = "lv2";
            else if (Database.upgradeMusicPlayer == 3)
                st = "lv3";
            if (st != "")
                upgrade[3].objek.GetComponent<Animator>().SetTrigger(st);
        }

        if (Database.upgradeTanaman == 0)
            upgrade[4].enabled = false;
        else
        {
            string st = "";
            upgrade[4].enabled = true;
            if (Database.upgradeTanaman == 2)
                st = "lv2";
            else if (Database.upgradeTanaman == 3)
                st = "lv3";
            if (st != "")
                upgrade[4].objek.GetComponent<Animator>().SetTrigger(st);
        }

        if (Database.upgradeBackground == 0)
            upgrade[5].enabled = true;
        else
        {
            string st = "";
            upgrade[5].enabled = true;
            if (Database.upgradeBackground == 1)
                st = "lv2";
            else if (Database.upgradeBackground == 2)
                st = "lv3";
            if (st != "")
                upgrade[5].objek.GetComponent<Animator>().SetTrigger(st);
        }


        if (Database.upgradeLantai == 0)
            upgrade[6].enabled = true;
        else
        {
            string st = "";
            upgrade[6].enabled = true;
            if (Database.upgradeLantai == 1)
                st = "lv2";
            else if (Database.upgradeLantai == 2)
                st = "lv3";
            if (st != "")
                upgrade[6].objek.GetComponent<Animator>().SetTrigger(st);
        }

        if (Database.hireSinden)
        {
            upgrade[7].enabled = true;
        }
        else
            upgrade[7].enabled = false;
        for(int a=0;a<upgrade.Length;a++)
        {
            if(upgrade[a].enabled)
            {
                upgrade[a].objek.GetComponent<SpriteRenderer>().enabled = true;
            }
            else
            {
                upgrade[a].objek.GetComponent<SpriteRenderer>().enabled = false;

            }
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (!Database.dayend)
        {
            float timeleft = endTime - Time.time;
            if (timeleft <= 0)
            {
                timeleft = 0;
                dayEnd();
            }

            second = (int)timeleft;
            minute = (second / 60);
            second = second % 60;
            ui.GetComponent<TextMesh>().text = "Sisa waktu:\n" + minute + ":" + second;
        }
        else
        {
            //ui.GetComponent<TextMesh>().text = "muncul day end report";
            print("end day-waktu habis");
        }
        if(ent.cekStokWsAbisBlm())
        {
            dayEnd();
            print("end day-stok abis");
            if(ent.num!=ent.idx && !udaitung)
            {
                udaitung = true;
                Database.LapTotalPembeliGagalBeli += ent.num - ent.idx;
                print("end day-stok abis & ada cust kabur");
            }
        }
        if(ent.idx>=ent.num)
        { 
            dayEnd();
            print("end day,generated>predicted");
        }
	}
    bool udaitung = false;
    public void dayEnd()
    {
        Database.waktuAbis = true; 
        if (GameObject.FindWithTag("Customer") == null)
        {
            Database.dayend = true;
            Database.stokAir = 0;
            Database.stokBumbuHalus = 0;
            Database.stokBumbuPecel = 0;
            Database.stokCendol = 0;
            Database.stokCingur = 0;
            Database.stokDagingSapi = 0;
            Database.stokDaunAsamMuda = 0;
            Database.stokDawet = 0;
            Database.stokLontong = 0;
            Database.stokMinyakGoreng = 0;
            Database.stokNasi = 0;
            Database.stokSanten = 0;
            Database.stokSayuran = 0;
            Database.stokSirup = 0;
            Database.stokTemulawak = 0;
            
            //ui.GetComponent<TextMesh>().text = "";
            Application.LoadLevel(11);
        }
    }
}
