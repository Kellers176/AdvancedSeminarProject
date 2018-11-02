using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour {

	public Animator anim;
	private int levelToLoad;

	void Start()
	{
		AnimationEvent ae = new AnimationEvent();
		ae.messageOptions = SendMessageOptions.DontRequireReceiver;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void FadeToLevel (int levelName)
	{
		levelToLoad = levelName;
		anim.SetTrigger("FadeOut");
	}

	void OnFadeComplete()
	{
		SceneManager.LoadScene(levelToLoad);
	}

	public void FadeToNextLevel()
	{
		FadeToLevel(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void FadeToNextLevel(int myLevel)
	{
		FadeToLevel(myLevel);
	}

}
