using UnityEngine;
using System.Collections;

public class Customer : MonoBehaviour {


    //public GameObject custObject;
    public int makananID;
    public int minumanID;
    public bool served;
    public int idx;
    public GameObject bubble;
    public GameObject bubble2;
    public Database db;
    public bool ordered;
    public bool goingToTableManager;
    public bool goingToExit;
    public bool walkOut;
    public int waypointIndex;
    int exitWaypointIndex;
    int walkOutWaypointIndex;
    float movingSpeed;
	// Use this for initialization
	void Start () {
        ordered = false;
        served = false;
        waypointIndex = 0;
        walkOutWaypointIndex = 1;
        movingSpeed = Database.kecepatanJalanCust;
	}
	
	// Update is called once per frame
    void Update()
    {

        if (goingToTableManager)
        {
            //print("gtt");
            moveToTableManager();
        }
        if (goingToExit)
        {
            //print("gte");
            moveToExit();
        }
        if (walkOut)
        {
            //print("wo");
            //goWalkOut();
            moveToExit();
        }
        if(bubble!=null)
        {
            bubble.transform.position = new Vector3(gameObject.transform.position.x+0.57f, gameObject.transform.position.y + 0.72f, gameObject.transform.position.z);
        }
        if (bubble2 != null)
        {
            bubble2.transform.position = new Vector3(gameObject.transform.position.x + 1.15f, gameObject.transform.position.y + 0.58f, gameObject.transform.position.z);
        }
	}


    public void goToTableManager()
    {
        
        print("Cust " + idx + " is going to table manager through " + waypointIndex);
        this.goingToTableManager = true;
        
        //custLama.custObject.transform.rotation = Quaternion.LookRotation(db.exitWaypoints[exitWaypointIndex].gameObject.transform.position);

    } 

    public void goToExit()
    {
        this.goingToExit = true;
    }

    void moveToTableManager()
    {
        if (db.toTableManagerWaypoints[waypointIndex].gameObject.GetComponent<ExitWaypoint>().isCollided(gameObject))
        {
            print("cust "+idx+" collided with waypoint to table manager");
            if (waypointIndex < db.toTableManagerWaypoints.Length - 1)
                waypointIndex++;
            else
            {
                print("Cust " + idx + " arrived at table manager"); 
                goingToTableManager = false;
                db.tableManager.GetComponent<TableManager>().q.Add(this);
                return;
            }
        }
        //float rotationAngle = Mathf.Atan2(db.toTableManagerWaypoints[waypointIndex].gameObject.transform.position.y, db.toTableManagerWaypoints[waypointIndex].gameObject.transform.position.x) * 180 / Mathf.PI;
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, db.toTableManagerWaypoints[waypointIndex].gameObject.transform.position, movingSpeed);
        //gameObject.transform.rotation = Quaternion.AngleAxis(rotationAngle, Vector3.forward);
    }

    void moveToExit()
    {
        print("going to exit-->" + exitWaypointIndex);
        if (db.exitWaypoints[exitWaypointIndex].gameObject.GetComponent<ExitWaypoint>().isCollided(gameObject))
        {
            //TODO: tambah waypoints buat tiap meja (mungkin butuh-PLAN B)
            if (exitWaypointIndex < db.exitWaypoints.Length - 1)
                exitWaypointIndex++;
            else
            { 
                print("cust lama end");
                Destroy(bubble);
                Destroy(bubble2);
                Destroy(gameObject);
                return;
            }
        }
        //float rotationAngle = Mathf.Atan2(db.exitWaypoints[exitWaypointIndex].gameObject.transform.position.y, db.exitWaypoints[exitWaypointIndex].gameObject.transform.position.x) * 180 / Mathf.PI;
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, db.exitWaypoints[exitWaypointIndex].gameObject.transform.position, movingSpeed);
        //gameObject.transform.rotation = Quaternion.AngleAxis(rotationAngle, Vector3.forward);
    }

    public void goWalkOut()
    {
        if (db.toTableManagerWaypoints[walkOutWaypointIndex].gameObject.GetComponent<ExitWaypoint>().isCollided(gameObject))
        {
            print("cust " + idx + " is walking out");
            if (walkOutWaypointIndex > 0)
                walkOutWaypointIndex--;
            else
            {
                print("Cust " + idx + " walked out");
                Destroy(gameObject);
                return;
            }
        }
        //float rotationAngle = Mathf.Atan2(db.toTableManagerWaypoints[waypointIndex].gameObject.transform.position.y, db.toTableManagerWaypoints[waypointIndex].gameObject.transform.position.x) * 180 / Mathf.PI;
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, db.toTableManagerWaypoints[walkOutWaypointIndex].gameObject.transform.position, movingSpeed);
        //gameObject.transform.rotation = Quaternion.AngleAxis(rotationAngle, Vector3.forward);
    }
}
