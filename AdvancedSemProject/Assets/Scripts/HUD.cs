﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUD : MonoBehaviour {

    public TextMeshProUGUI countdown;

    public TextMeshProUGUI reload;

    public int timeLeft = 10;

	public Sprite[] HeartSprites;

	public Image HeartUI;

	private PlayerManager myPlayer;

    ProjectileManager mManager;

	// Use this for initialization
	void Start () {
        StartCoroutine("LoseTime");
		myPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
        mManager = GameObject.FindGameObjectWithTag("SpawnManager").GetComponent<ProjectileManager>();
        Time.timeScale = 1;
	}
	
	// Update is called once per frame
	void Update () {
		HeartUI.sprite = HeartSprites[(int)myPlayer.currentHealth];
        countdown.text = ("" + timeLeft);
        reload.text = ("" + mManager.getReloadCount());
        if(timeLeft < 11)
        {
            countdown.color = Color.green;
        }
        if(timeLeft < 6)
        {
            countdown.color = Color.yellow;
        }
        if(timeLeft < 3)
        {
            countdown.color = Color.red;
        }

        if(timeLeft < 0)
        {
            mManager.done = true;
            timeLeft = 10;
        }
	}

    IEnumerator LoseTime()
    {
        while(true)
        {
            yield return new WaitForSeconds(1);
            timeLeft--;

        }
    }

    public int getTimeLeft()
    {
        return timeLeft;
    }
}
