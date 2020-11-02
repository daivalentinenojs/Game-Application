using UnityEngine;
using System.Collections;

public class textGUI : MonoBehaviour {

    public string textFieldString = "Text Field";
    public string textAreaString = "Text Area";

    void OnGUI()
    {
        textFieldString = GUI.TextField(new Rect(10, 10, 200, 20), textFieldString, 25);
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
