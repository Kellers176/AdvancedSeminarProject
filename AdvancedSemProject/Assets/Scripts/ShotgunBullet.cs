using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunBullet : MonoBehaviour {

    public float speed = 50f;
    public float rotatingSpeed = 200;
    public GameObject target;

    Rigidbody2D rb;


    ProjectileManager myProjectile;

    // Use this for initialization
    void Start () {
        Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>());
        target = GameObject.FindGameObjectWithTag("Enemy");

        rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector2 pointToTarget = (Vector2)transform.position - (Vector2)target.transform.position;

        pointToTarget.Normalize();

        float value = Vector3.Cross(pointToTarget, transform.right).z;

        //if(value > 0)
        //{
        //    rb.angularVelocity = rotatingSpeed;
        //}
        //else if(value < 0)
        //{
        //    rb.angularVelocity = -rotatingSpeed;
        //}
        //else
        //{
        //    rb.angularVelocity = 0;
        //}

        rb.angularVelocity = rotatingSpeed * value;

        rb.velocity = transform.right * speed;
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(this.gameObject);
    }
}
