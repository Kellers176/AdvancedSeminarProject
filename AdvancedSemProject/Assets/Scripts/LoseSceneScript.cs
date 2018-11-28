using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoseSceneScript : MonoBehaviour {

    [SerializeField] AudioSource track1;
    int myType;

    // Use this for initialization
    void Start () {
        Destroy(GameObject.Find("Music"));
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void MainMenu()
    {
        Debug.Log("Being hit");
        myType = 0;
        StartCoroutine(LoseSceneScript.FadeOut(track1, myType));
    }

    public void Credits()
    {
        myType = 1;
        StartCoroutine(LoseSceneScript.FadeOut(track1, myType));
    }

    public static IEnumerator FadeOut(AudioSource audioSource, int type)
    {
        float startVolume = audioSource.volume;
        Debug.Log("inside function");
        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / 0.5f;
            yield return null;
        }
        audioSource.Stop();
        audioSource.volume = startVolume;
        switch (type)
        {
            case 0:
                SceneManager.LoadScene("Main Menu");
                break;
            case 1:
                SceneManager.LoadScene("Credits");
                break;
            default:
                break;
        }
    }
}
