using UnityEngine;
using System.Collections;

public class LaporanAkhir : MonoBehaviour {

    public GameObject[] texts;

	// Use this for initialization
	void Start () {
        texts[0].GetComponent<TextMesh>().text = Database.LapDapetTotalUang+"";
        texts[1].GetComponent<TextMesh>().text = Database.LapTotalIncome + "";
        texts[2].GetComponent<TextMesh>().text = Database.namamakanan[0] + ": " + Database.LapTotalMakananTerjual[0] + "\n" +
            Database.namamakanan[1] + ": " + Database.LapTotalMakananTerjual[1] + "\n" +
            Database.namamakanan[2] + ": " + Database.LapTotalMakananTerjual[2] + "\n";
        texts[3].GetComponent<TextMesh>().text = Database.namaminuman[0] + ": " + Database.LapTotalMinumanTerjual[0] + "\n" +
            Database.namaminuman[1] + ": " + Database.LapTotalMinumanTerjual[1] + "\n" +
            Database.namaminuman[2] + ": " + Database.LapTotalMinumanTerjual[2] + "\n";
        texts[4].GetComponent<TextMesh>().text = Database.LapTotalPembeliDatang + "";
        texts[5].GetComponent<TextMesh>().text = Database.LapTotalPembeliGagalBeli + "";
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
