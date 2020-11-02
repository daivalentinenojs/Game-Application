using UnityEngine;
using System.Collections;

public class debugging : MonoBehaviour {

    Database db; 
	// Use this for initialization
	void Start () {
        db = gameObject.GetComponent<Database>();
	   // g.tableObject.GetComponent<TableScript>().transform.position
        //tmp = ((GameObject)(Instantiate(cust, g.tableObject.GetComponent<TableScript>().transform.position, new Quaternion())));
        
        //g.tableObject.GetComponent<TableScript>().custBaru.custObject = tmp;
        
	}
	
	// Update is called once per frame
	void Update () {
        
	}
     

    void OnMouseDown()
    {
        GameObject.Find("tableManager").GetComponent<TableManager>().updateStok();
       // GameObject.Find("entranceManager").GetComponent<EntranceManager>().debug1();
    }
}
