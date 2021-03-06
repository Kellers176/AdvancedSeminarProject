﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour 
{

    int maxHealth = 100;
    int currentHealth;
    private Renderer rend;
    Rigidbody2D rb;

    [SerializeField] GameObject pointA;
    [SerializeField] GameObject pointB;

    [SerializeField] float speed = 20.0f;


    [SerializeField] int direction = 1;

    [SerializeField] Quaternion left = Quaternion.Euler(0, 0, 0);
    [SerializeField] Quaternion right = Quaternion.Euler(0, 180, 0);

	// Use this for initialization
	void Start () 
    {
        currentHealth = maxHealth;
        rend = GetComponent<Renderer>();
        rend.material.color = Color.white;

        rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	private void Update () 
    {

        if(currentHealth < 60)
        {
            rend.material.color = Color.yellow;
        }

        if (currentHealth < 30)
        {
            rend.material.color = Color.red;
        }

        if (currentHealth <= 0)
        {
            Destroy(this.gameObject);
        }
       
	}

    private void FixedUpdate()
    {
        if(rb.position.x >= pointB.transform.position.x && direction == 1)
        {
            direction = -direction;
            transform.rotation = right;
        }
        else if(rb.position.x < pointA.transform.position.x && direction == -1)
        {
            direction = -direction;
            transform.rotation = left;
        }

        transform.Translate(speed * Time.deltaTime, 0, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            currentHealth -= 10;
        }

        if (collision.gameObject.tag == "Rocket")
        {
            currentHealth -= 50;
        }
    }
}
