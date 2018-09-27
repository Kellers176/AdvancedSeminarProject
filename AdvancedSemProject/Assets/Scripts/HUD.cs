﻿using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
        changeTimeColor();
        showReload();
        resetTime();
    }
    void showReload()
    {
        if (mManager.getReloadCount() == 0)
        {
            reload.text = "Press R!";
        }
        else
        {
            reload.text = ("" + mManager.getReloadCount());
        }

    }

    void changeTimeColor()
    {
        switch (timeLeft)
        {
            case 10:
                countdown.color = Color.green;
                break;
            case 6:
                countdown.color = Color.yellow;
                break;
            case 3:
                countdown.color = Color.red;
                break;
            default:
                break;

        }
    }

    void resetTime()
    {
        if (timeLeft < 0)
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
