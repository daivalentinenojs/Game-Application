using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class pelayan : MonoBehaviour {

    public int idxMejaWaypoint;
    public int balikIndex;
    public Database db;
    public bool jalan;
    public bool balik;
    public bool busy;
    public List<GameObject> pelayanWaypoint=new List<GameObject>();
	// Use this for initialization
	void Start () {
        db = GameObject.Find("Controller").GetComponent<Database>();
        jalan = false;
        balik = false;
        foreach(GameObject a in db.pelayanWaypoints)
        {
            pelayanWaypoint.Add(a);
        }
        balikIndex = pelayanWaypoint.Count - 1;
	}
	
	// Update is called once per frame
	void Update () {
	    if(jalan)
        {
            moveToMeja();
        }
        if(balik)
        {
            balikKeMarkas();
        }
	}

    public void aktifkanPelayan(pesanan pesene)
    {
        print("going to meja-->" + idxMejaWaypoint);
        jalan = true;
        busy = true;
        pelayanWaypoint.Add(pesene.mejaID.tableObject);

        gameObject.GetComponent<Animator>().StopPlayback();
        gameObject.GetComponent<Animator>().Play("antarmakanan");
    }

    void moveToMeja()
    {
        if (pelayanWaypoint[idxMejaWaypoint].gameObject.GetComponent<ExitWaypoint>().isCollided(gameObject))
        {
            if (idxMejaWaypoint < pelayanWaypoint.Count - 1)
                idxMejaWaypoint++;
            else
            {
                print("cust lama end");
                balik = true;
                jalan = false;
                idxMejaWaypoint = 0;
                return;
            }
        }
        //float rotationAngle = Mathf.Atan2(db.exitWaypoints[exitWaypointIndex].gameObject.transform.position.y, db.exitWaypoints[exitWaypointIndex].gameObject.transform.position.x) * 180 / Mathf.PI;
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, pelayanWaypoint[idxMejaWaypoint].gameObject.transform.position, Database.kecepatanPelayan);
        //gameObject.transform.rotation = Quaternion.AngleAxis(rotationAngle, Vector3.forward);
    }

    void balikKeMarkas()
    {
        print("balik ke markas");
        gameObject.GetComponent<Animator>().StopPlayback();
        gameObject.GetComponent<Animator>().Play("balekmarkas");
        if (pelayanWaypoint[balikIndex].gameObject.GetComponent<ExitWaypoint>().isCollided(gameObject))
        {
            print("otw ke markas");
            if (balikIndex > 0)
                balikIndex--;
            else
            {
                print("wes balik ke markas");

                gameObject.GetComponent<Animator>().StopPlayback();
                gameObject.GetComponent<Animator>().Play("idle");
                balik = false;
                busy = false;
                balikIndex = pelayanWaypoint.Count - 1;
                    if (pelayanWaypoint[pelayanWaypoint.Count-1].gameObject.GetComponent<TableScript>() != null)
                        pelayanWaypoint.RemoveAt(pelayanWaypoint.Count - 1);
                
            }
        }
        //float rotationAngle = Mathf.Atan2(db.toTableManagerWaypoints[waypointIndex].gameObject.transform.position.y, db.toTableManagerWaypoints[waypointIndex].gameObject.transform.position.x) * 180 / Mathf.PI;
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, pelayanWaypoint[balikIndex].gameObject.transform.position, Database.kecepatanPelayan);
        //gameObject.transform.rotation = Quaternion.AngleAxis(rotationAngle, Vector3.forward);
    }
}
