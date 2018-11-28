using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour {

    [SerializeField] GameObject[] tutorialObjects;
    bool endDoor = false, enemyDoor = false, counter = false, wavesLeft = false, enemiesLeft = false,
        health = false, bubbleGun = false, flameThrower = false, bulletTutorial = false, rocketTutorial = false;
    float timer;
    

    int myType;

    // Use this for initialization
    void Start () {
        timer = 0.0f;
    }
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if(timer > 1)
        {
            Time.timeScale = 0.0f;
        }
	}
   
    public void Continue()
    {
        //tutorialObjects[9].SetActive(false);
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Main Menu");
    }

    public void showEndDoor()
    {
        tutorialObjects[0].SetActive(true);
        endDoor = true;
        Time.timeScale = 0.0f;
    }

    public void showEnemyDoor()
    {
        tutorialObjects[0].SetActive(false);
        enemyDoor = true;
        tutorialObjects[1].SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void showCounter()
    {
        tutorialObjects[1].SetActive(false);
        counter = true;
        tutorialObjects[2].SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void showWaves()
    {
        tutorialObjects[2].SetActive(false);
        wavesLeft = true;
        tutorialObjects[3].SetActive(true);
        Time.timeScale = 0.0f;
    }
    public void showEnemiesLeft()
    {
        tutorialObjects[3].SetActive(false);
        enemiesLeft = true;
        tutorialObjects[4].SetActive(true);
        Time.timeScale = 0.0f;
    }
    public void showHealth()
    {
        tutorialObjects[4].SetActive(false);
        health = true;
        tutorialObjects[5].SetActive(true);
        Time.timeScale = 0.0f;
    }
    public void showBubble()
    {
        tutorialObjects[5].SetActive(false);
        health = true;
        tutorialObjects[6].SetActive(true);
        Time.timeScale = 0.0f;
    }
    public void showFlameThrower()
    {
        tutorialObjects[6].SetActive(false);
        health = true;
        tutorialObjects[7].SetActive(true);
        Time.timeScale = 0.0f;
    }
    public void showBullet()
    {
        tutorialObjects[7].SetActive(false);
        health = true;
        tutorialObjects[8].SetActive(true);
        Time.timeScale = 0.0f;
    }
    public void showRocket()
    {
        tutorialObjects[8].SetActive(false);
        health = true;
        tutorialObjects[9].SetActive(true);
        Time.timeScale = 0.0f;
    }
}
