using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketBullet : MonoBehaviour {
    public float speed = 50f;
    public float rotatingSpeed = 200;
    public GameObject target;

    Rigidbody2D rb;


    ProjectileManager myProjectile;

    // Use this for initialization
    void Start()
    {
        Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), GameObject.FindGameObjectWithTag("Bullet").GetComponent<Collider2D>());
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

            float value = Vector3.Cross(pointToTarget, transform.right).z;
        
            rb.angularVelocity = rotatingSpeed * value;

            rb.velocity = transform.right * speed;
        }
        else
        {
            rb.velocity = transform.right * speed;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(this.gameObject);
    }
}
