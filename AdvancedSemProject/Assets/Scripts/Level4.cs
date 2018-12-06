using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level4 : MonoBehaviour
{
    [SerializeField] LevelCheck LevelManager;
    [SerializeField] SceneManagerScript myScene;
    [SerializeField] LevelChanger myLevel;
    // Use this for initialization
    void Start()
    {
        LevelManager = GameObject.FindGameObjectWithTag("LevelCheck").GetComponent<LevelCheck>();
        LevelManager.SetLevel("Level 4");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (myScene.getDone() == true && collision.gameObject.tag == "Player")
        {
            Debug.Log("Im gettting hit");
            //myLevel.FadeToNextLevel(6);
            SceneManager.LoadScene("WinScene");

        }
    }
}
