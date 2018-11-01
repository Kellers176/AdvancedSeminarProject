﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldHealth : MonoBehaviour {

	int currentHealth;
    BubbleEnemyAI parent;
	// Use this for initialization
	void Start () {
		currentHealth = 155;
        parent = gameObject.transform.parent.gameObject.GetComponent<BubbleEnemyAI>();
	}
	
	// Update is called once per frame
	void Update () {
		if(currentHealth <= 0)
		{
            parent.SetShieldActive(false);
			this.gameObject.SetActive(false);
        }
		Debug.Log(currentHealth);
	}

	private void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.tag != "Bubbles")
		{
			currentHealth -= 10;

		}
	}
	private void OnTriggerEnter2D(Collider2D col)
	{
		currentHealth -= 10;
	}
	

}