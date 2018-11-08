using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level4 : MonoBehaviour
{

    [SerializeField] SceneManagerScript myScene;
    [SerializeField] LevelChanger myLevel;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (myScene.getDone() == true && collision.gameObject.tag == "Player")
        {
            myLevel.FadeToNextLevel(6);
            //SceneManager.LoadScene("WinScene");

        }
    }
}
