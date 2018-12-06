using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateLevel : MonoBehaviour {

    TextMeshProUGUI myCurrentText;
    [SerializeField] LevelCheck myCheck;
    string toChange;

	// Use this for initialization
	void Start () {
        myCurrentText = this.GetComponent<TextMeshProUGUI>();
        myCheck = GameObject.FindGameObjectWithTag("LevelCheck").GetComponent<LevelCheck>();
        changeLevel();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void changeLevel()
    {
        toChange = myCheck.getLevel();
        myCurrentText.text = toChange;
    }
}
