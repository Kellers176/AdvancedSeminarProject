﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketBullet : MonoBehaviour {
    [SerializeField] float speed = 50f;
    [SerializeField] float rotatingSpeed = 200;
    [SerializeField] GameObject target;
    Vector3 toTransform;

    ProjectileManager manager;

    Rigidbody2D rb;

    Vector3 myTransform;
    

    // Use this for initialization
    void Start()
    {
        Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), GameObject.FindGameObjectWithTag("Rocket").GetComponent<Collider2D>());
        manager = GameObject.FindGameObjectWithTag("SpawnManager").GetComponent<ProjectileManager>();
        toTransform = manager.GetDirection();
        target = GameObject.FindGameObjectWithTag("Enemy");
       
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(target != null)
        {
            Vector2 pointToTarget = (Vector2)transform.position - (Vector2)target.transform.position;

            pointToTarget.Normalize();

            float value = Vector3.Cross(pointToTarget, transform.up).z;
        
            rb.angularVelocity = rotatingSpeed * value;

            rb.velocity = transform.up * speed;
        }
        else
        {
           rb.velocity = transform.up * speed;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(this.gameObject);
    }
}
