﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneManagerScript : MonoBehaviour {
    [SerializeField] EnemyManager myEnemyManager;
    [SerializeField] GameObject oldSprite;
    [SerializeField] GameObject particles;
    bool done = false;
    int finalWaveNum;
    // Use this for initialization
    private void Start () {
        finalWaveNum = 1;
        UpdateFinalWaveCount();
    }
	
	// Update is called once per frame
	private void Update ()
    {
        CheckEnemyCount();
       
    }

    private void CheckEnemyCount()
    {
        if(myEnemyManager.GetWaves() > finalWaveNum)
        {
            oldSprite.SetActive(false);
            particles.SetActive(true);
            done = true;
        }
        //Debug.Log(myEnemyManager.GetWaves());
        //Debug.Log(finalWaveNum);
    }

    public bool getDone()
    {
        return done;
    }

    public void UpdateFinalWaveCount()
    {
        finalWaveNum = myEnemyManager.getFinalWaveCount();
    }
}
