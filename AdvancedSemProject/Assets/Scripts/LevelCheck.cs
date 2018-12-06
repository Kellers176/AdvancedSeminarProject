using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCheck : MonoBehaviour {
    string myLevel;
	// Use this for initialization
	void Start () {
		
	}
    void Awake()
    {
        DontDestroyOnLoad(this);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public string getLevel()
    {
        //Debug.Log(myLevel);
        return myLevel;
    }

    public void SetLevel(string setLevel)
    {
       //Debug.Log("Setting Level");
        myLevel = setLevel;
    }
}
