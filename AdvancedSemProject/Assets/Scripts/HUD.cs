using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour {


	public Sprite[] HeartSprites;

	public Image HeartUI;

	private PlayerManager myPlayer;

	// Use this for initialization
	void Start () {
		myPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
	}
	
	// Update is called once per frame
	void Update () {
		HeartUI.sprite = HeartSprites[(int)myPlayer.currentHealth];
	}
}
