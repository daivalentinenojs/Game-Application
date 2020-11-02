using UnityEngine;
using System.Collections;

public class totalMoney : MonoBehaviour {

    public GameObject totalUang;

	// Use this for initialization
	void Start () {
        totalUang.GetComponent<TextMesh>().text = string.Format("{0:N}",Database.uang);

	}
	
	// Update is called once per frame
	void Update () {
        totalUang.GetComponent<TextMesh>().text = "IDR " + Database.uang.ToString();
	}
}
