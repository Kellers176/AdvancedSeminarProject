﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeToWin : MonoBehaviour {
    [SerializeField] SceneManagerScript myScene;
    [SerializeField] LevelChanger myLevel;
    [SerializeField] LevelCheck LevelManager;
    // Use this for initialization
    void Start () {
        LevelManager = GameObject.FindGameObjectWithTag("LevelCheck").GetComponent<LevelCheck>();
        LevelManager.SetLevel("Level 1");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(myScene.getDone() == true && collision.gameObject.tag == "Player")
        {
            Debug.Log("Hit");
            myLevel.FadeToNextLevel();
            //SceneManager.LoadScene("Level2");
        }
    }
}
