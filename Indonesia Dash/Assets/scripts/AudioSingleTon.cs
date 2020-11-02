using UnityEngine;
using System.Collections;

public class AudioSingleTon : MonoBehaviour {

    public static AudioSingleTon Instance;

    void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Audio Can Not More Than One");
        }
        else
        {
            Instance = this;
            GetComponent<AudioSource>().Play();
        }

        DontDestroyOnLoad(this.gameObject);


    }


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
