using UnityEngine;
using System.Collections;
using System;

public class TableScript : MonoBehaviour {

    public Table stats;
    public Customer custBaru;
    public Customer custLama;
    Database db;
    bool moveToExit;
    bool custDatang;
    float movingSpeed = Database.kecepatanJalanCust;
	// Use this for initialization
	void Start () {
        db = GameObject.Find("Controller").GetComponent<Database>();
        stats.leaveTime = new DateTime();
        stats.enterTime = new DateTime();
        stats.tableObject = gameObject;
        stats.busy = false; 
        //print(stats.tableObject.transform.position.x + " " + stats.tableObject.transform.position.y + " " + stats.tableObject.transform.position.z);
        //print(gameObject.name);
	}
	
	// Update is called once per frame
	void Update () {
	    if(custBaru!=null)
        {
            custDatang = true;
            custLama = custBaru;
            custBaru = null;
            stats.full = true;
            print("cust baru!");

        }
        if(custDatang)
        {
            //float rotationAngle = Mathf.Atan2(stats.tableObject.transform.position.y, stats.tableObject.transform.position.x) * 180 / Mathf.PI;
            custLama.gameObject.transform.position = Vector3.MoveTowards(custLama.gameObject.transform.position, stats.tableObject.transform.position, movingSpeed);
            //custLama.custObject.transform.rotation = new Quaternion(stats.tableObject.transform.position.x, stats.tableObject.transform.position.y, stats.tableObject.transform.position.z, stats.tableObject.transform.rotation.w);
            //custLama.gameObject.transform.rotation = Quaternion.AngleAxis(rotationAngle, Vector3.forward);

        }
        if(stats.busy && stats.leaveTime<=DateTime.Now)
        {

            gameObject.GetComponent<Animator>().SetTrigger("wesmakan");
            stats.full = false;
            custLama.served = true; 
            stats.leaveTime = new DateTime();
            stats.busy = false;
            moveToExit = true;
            print("cust "+ custLama.name+" is going to exit");
            Database.orangDiMeja--;
            db.entranceManager.GetComponent<EntranceManager>().generateNewCust();
            
        }
        if(moveToExit)
        {
            moveToExit = false;
            custLama.GetComponent<Animator>().SetBool("dimeja", false);
            custLama.gameObject.GetComponent<Animator>().StopPlayback();
            custLama.GetComponent<Animator>().SetBool("exit", true);
            custLama.GetComponent<Customer>().goingToExit = true;
            custLama = null;
        }
        
	}
     

    void OnTriggerEnter2D(Collider2D obj)
    {
   //     if(obj.gameObject.GetComponent<Customer>()!=null)
         //   print("got " + obj.name + " expected " + custLama.gameObject.name + " is served? " + obj.gameObject.GetComponent<Customer>().served);

        if(obj.gameObject.name==custLama.name && !obj.gameObject.GetComponent<Customer>().served)
        {
            obj.gameObject.GetComponent<Animator>().StopPlayback();
            obj.gameObject.GetComponent<Animator>().Play("dimeja");
            gameObject.GetComponent<Animator>().SetTrigger("nunggumakan");
            custDatang = false;
            if (obj.gameObject.GetComponent<Customer>().makananID == -1)
            { 
                gameObject.GetComponent<Animator>().SetTrigger("lagimakan");
                stats.enterTime = DateTime.Now;
                TimeSpan tmpw = Database.lamaMinumArray[custLama.minumanID - 1];
                DateTime tmps = DateTime.Now.Add(tmpw);
                stats.leaveTime = tmps;
                stats.busy = true;
                print("[MinumOnly] collided! exit time >>" + stats.leaveTime + "(" + tmpw.TotalSeconds.ToString() + ")");
            }
            else
            { 
                //obj.gameObject.GetComponent<Animator>().SetBool("dimeja", true);
                gameObject.GetComponent<Animator>().SetTrigger("nunggumakan");
                print("waiting for pelayan");
            }
        }
        else if(obj.gameObject.tag=="Pelayan")
        { 
            gameObject.GetComponent<Animator>().SetTrigger("lagimakan");
            stats.enterTime = DateTime.Now;
            TimeSpan tmpw = Database.lamaMakanArray[custLama.makananID - 1] + new TimeSpan(0, 0, ((int)Database.lamaMinumArray[custLama.minumanID - 1].TotalSeconds / 2));
            DateTime tmps = DateTime.Now.Add(tmpw);
            stats.leaveTime = tmps;
            stats.busy = true;
            print("[Makan+Minum] collided! exit time >>" + stats.leaveTime + "(" + tmpw.TotalSeconds.ToString() + ")");
        }
    }

}
