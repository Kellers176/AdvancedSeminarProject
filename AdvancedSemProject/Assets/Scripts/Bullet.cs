﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour 
{

    [SerializeField] float speed = 50f;
    float[] SpreadRange = { 10, 8, 6, 4, 2, 0, -2, -4, -6, -8, -10 };


    ProjectileManager myProjectile;

    // Use this for initialization
    void Start ()
    {
		Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>());
        myProjectile = GameObject.FindGameObjectWithTag("SpawnManager").GetComponent<ProjectileManager>();
        Movement();
    }
	
	// Update is called once per frame
	private void Update ()
    {
	}

    private void OnCollisionEnter2D(Collision2D col)
    { 
        Destroy(this.gameObject);
    }

    private void Movement()
    {

        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(myProjectile.getShootDirection().x * speed, myProjectile.getShootDirection().y * speed);
        
        
    }
}
