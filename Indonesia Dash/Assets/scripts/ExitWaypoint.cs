using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ExitWaypoint : MonoBehaviour {
     
    public List<GameObject> collidedCust;
	// Use this for initialization
	void Start () { 
        collidedCust = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public bool isCollided(GameObject cust)
    {
        if (collidedCust.Contains(cust))
            return true;
        else
            //TODO: tambah list sapa aj yang ketabrak,biar bisa punya flag sendiri2
            return false;
    }

    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.gameObject.tag == "Customer" || obj.gameObject.tag == "Pelayan")
        {
            collidedCust.Add(obj.gameObject);
        }
    }
    void OnTriggerExit2D(Collider2D obj)
    {
        if (obj.gameObject.tag == "Customer" || obj.gameObject.tag == "Pelayan")
        { 
            collidedCust.Remove(obj.gameObject);
        }
    }
}
