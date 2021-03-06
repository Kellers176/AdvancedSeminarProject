﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuSceneScript : MonoBehaviour 
{
    [SerializeField] AudioSource track1;

    int myType;

	// Use this for initialization
	void Start () 
	{
        //track1 = gameObject.GetComponent<AudioSource>();
        //Destroy(GameObject.Find("Music"));
    }
	
	// Update is called once per frame
	void Update () 
	{
		
	}
    public void LoadTutorial()
    {
        SceneManager.LoadScene("Tutorial");
        //myType = 3;
        //StartCoroutine(MainMenuSceneScript.FadeOut(track1, myType));
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene("Level1");
        //myType = 0;
       // StartCoroutine(MainMenuSceneScript.FadeOut(track1, myType));
    }
    public void Credits()
    {
        SceneManager.LoadScene("Credits");
        //myType = 1;
       // StartCoroutine(MainMenuSceneScript.FadeOut(track1, myType));
    }

    public void Quit()
    {
        Application.Quit();
        //myType = 2;
        //StartCoroutine(MainMenuSceneScript.FadeOut(track1, myType));
    }
    public static IEnumerator FadeOut(AudioSource audioSource, int type)
    {
        float startVolume = audioSource.volume;

        while(audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / 0.5f;
            yield return null;
        }
        audioSource.Stop();
        audioSource.volume = startVolume;
        switch(type)
        {
            case 0:
                SceneManager.LoadScene("Level1");
                break;
            case 1:
                SceneManager.LoadScene("Credits");
                break;
            case 2:
                Application.Quit();
                break;
            case 3:
                SceneManager.LoadScene("Tutorial");
                break;
            default:
                break;
        }
    }
}
