using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketBullet : MonoBehaviour {
    [SerializeField] float speed = 50f;
    [SerializeField] float rotatingSpeed = 200;
    [SerializeField] GameObject target;
    Vector3 toTransform;

    float lifetime;

    ProjectileManager manager;

    Rigidbody2D rb;

    Vector3 myTransform;

    CameraShake myShake;
    

    // Use this for initialization
    void Start()
    {
        //Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), GameObject.FindGameObjectWithTag("Well").GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), GameObject.FindGameObjectWithTag("Rocket").GetComponent<Collider2D>());
        manager = GameObject.FindGameObjectWithTag("SpawnManager").GetComponent<ProjectileManager>();
        myShake = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShake>();
        toTransform = manager.GetDirection();
        target = GameObject.FindGameObjectWithTag("Enemy");
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = manager.GetDirection() * speed;
        if(manager.GetDirection() == Vector3.left)
        {
            transform.Rotate(0, 0, 90);
        }
        if(manager.GetDirection() == Vector3.right)
        {
            transform.Rotate(0, 0, -90);
        }
        if (manager.GetDirection() == Vector3.up)
        {
            transform.Rotate(0, 0, 0);
        }
        if (manager.GetDirection() == Vector3.down)
        {
            transform.Rotate(0, 0, 180);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        lifetime += Time.deltaTime;
        //if(target != null)
        //{
        //    Vector2 pointToTarget = (Vector2)transform.position - (Vector2)target.transform.position;

        //    pointToTarget.Normalize();

        //    float value = Vector3.Cross(pointToTarget, transform.up).z;
        
        //    rb.angularVelocity = rotatingSpeed * value;

        //    rb.velocity = transform.up * speed;
        //}
        //else
        //{
        //   rb.velocity = manager.GetDirection() * speed;
        //}

        if(lifetime > 3.0)
        {
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        myShake.TriggerShake();
        Destroy(this.gameObject);
    }
}
