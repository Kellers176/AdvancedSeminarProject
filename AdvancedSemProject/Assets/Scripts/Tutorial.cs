using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Tutorial : MonoBehaviour {
    // Use this for initialization
    [SerializeField] GameObject bubbleTutorial, bulletTutorial, rocketTutorial, flameTutorial;
    bool fire = false, bullet = false, bubble = false, rocket = false;
    float timer;
    bool can;
	void Start () {
        timer = 0.0f;
        can = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        
        //Time.timeScale = 0.0f;
        //Time.timescale = 0;
	}

    public void ShowRocketTutorial()
    {
        rocketTutorial.SetActive(true);
        rocket = true;
        Time.timeScale = 0.0f;
    }
    public void ShowBubbleTutorial()
    {
        bubbleTutorial.SetActive(true);
        bubble = true;
        Time.timeScale = 0.0f;
    }

    public void ShowBulletTutorial()
    {
        bulletTutorial.SetActive(true);
        bullet = true;
        Time.timeScale = 0.0f;
    }

    public void ShowFlameThrowerTutorial()
    {
        flameTutorial.SetActive(true);
        fire = true;
        Time.timeScale = 0.0f;
    }
    public void Continue()
    {
        Time.timeScale = 1;
        if(rocket)
        {
            rocketTutorial.SetActive(false);
            rocket = false;
        }
        else if(bullet)
        {
            bulletTutorial.SetActive(false);
            bullet = false;
        }
        else if(fire)
        {
            flameTutorial.SetActive(false);
            fire = false;
        }
        else if(bubble)
        {
            bubbleTutorial.SetActive(false);
            bubble = false;
        }
    }
    

}
