using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialMusicScript : MonoBehaviour {
    [SerializeField] AudioSource track1;
    int myType;

    // Use this for initialization
    void Start()
    {
        Destroy(GameObject.Find("Music"));
    }

    // Update is called once per frame
    void Update () {
		
	}
    public void MainMenu()
    {
        track1.Stop();
        SceneManager.LoadScene("Main Menu");
    }
}
