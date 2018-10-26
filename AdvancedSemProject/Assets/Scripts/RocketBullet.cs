using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketBullet : MonoBehaviour {
    [SerializeField] float speed = 50f;
    [SerializeField] float rotatingSpeed = 200;
    [SerializeField] GameObject target;
    Vector3 toTransform;
    [SerializeField] GameObject myExplosion;
    float lifetime;

    ProjectileManager manager;

    Rigidbody2D rb;

    Vector3 myTransform;

    CameraShake myShake;
    

    // Use this for initialization
    void Start()
    {
        Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), GameObject.FindGameObjectWithTag("Rocket").GetComponent<Collider2D>());
        manager = GameObject.FindGameObjectWithTag("SpawnManager").GetComponent<ProjectileManager>();
        myShake = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShake>();
        //myExplosion = GetComponent<GameObject>();
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
        if(lifetime > 3.0)
        {
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        myShake.TriggerShake();
        GameObject explosion = Instantiate(myExplosion, transform.position, Quaternion.identity) as GameObject;
        Destroy(explosion, 0.5f);
        this.gameObject.GetComponent<Renderer>().enabled = false;
        Destroy(this.gameObject, 0.5f);
    }
}
