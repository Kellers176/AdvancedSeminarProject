﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldHealth : MonoBehaviour {
    //need to fix this
	int currentHealth;
    BubbleEnemyAI parent;
    private Renderer rend;
    // Use this for initialization
    void Start () {
		currentHealth = 155;
        rend = GetComponent<Renderer>();
        parent = gameObject.transform.parent.gameObject.GetComponent<BubbleEnemyAI>();
        rend.material.color = Color.white;
    }
	
	// Update is called once per frame
	void Update () {
		if(currentHealth <= 0)
		{
            parent.SetShieldActive(false);
			this.gameObject.SetActive(false);
        }
        if(currentHealth < 100 && currentHealth >= 50)
        {
            Debug.Log("YELLOw");
            rend.material.color = Color.yellow;
        }
        else if(currentHealth < 50)
        {
            Debug.Log("RED");
            rend.material.color = Color.grey;
        }
        //Debug.Log(currentHealth);
	}

	private void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.tag != "Bubbles" || col.gameObject.tag != "Wall")
		{
			currentHealth -= 10;
		}
	}
	private void OnTriggerEnter2D(Collider2D col)
	{
        if (col.gameObject.tag != "SpikeTrap")
		    currentHealth -= 10;
	}
	

}
