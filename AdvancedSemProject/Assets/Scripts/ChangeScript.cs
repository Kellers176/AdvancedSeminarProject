using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScript : MonoBehaviour {
    [SerializeField] SceneManagerScript myScene;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(myScene.getDone() == true && collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("WinScene");
        }
    }
}
