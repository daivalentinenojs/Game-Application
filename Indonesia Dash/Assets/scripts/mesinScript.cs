using UnityEngine;
using System.Collections;

public class mesinScript : MonoBehaviour {
    public int id;
	// Use this for initialization
    public GameObject db;
    public mesinManager mm;
    void Start () {
        db = GameObject.Find("Controller");
        mm = db.GetComponent<mesinManager>();
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {
        mm.pakeMesin(id);
        print("make mesin " + id);
        //TODO: kurangi stok bahan
    }
}
