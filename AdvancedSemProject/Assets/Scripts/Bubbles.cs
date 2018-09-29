using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubbles : MonoBehaviour {

    [SerializeField] float speed = 50f;
    GameObject spawn;
    Vector3 newPosition;
    ProjectileManager myProjectile;
    float[] SpreadRange = { 10, 8, 6, 4, 2, 0, -2, -4, -6, -8, -10 };

    // Use this for initialization
    void Start()
    {
        Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), GameObject.FindGameObjectWithTag("Bubbles").GetComponent<Collider2D>());
        myProjectile = GameObject.FindGameObjectWithTag("SpawnManager").GetComponent<ProjectileManager>();
        Movement();
    }

    // Update is called once per frame
    private void Update()
    {
        //this.transform.localScale *= Time.deltaTime;

        if(transform.localScale.x <= 2.0 && transform.localScale.x <= 2.0)
        {
            transform.localScale += new Vector3(0.05f, 0.05f, 0);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(this.gameObject);
    }

    private void Movement()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(myProjectile.getShootDirection().x * speed, myProjectile.getShootDirection().y * speed);
        float RandomRange = SpreadRange[Random.Range(0, SpreadRange.Length)];
        if (gameObject.transform.position == Vector3.right)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(speed, RandomRange));
        }
        if (gameObject.transform.position == Vector3.left)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-speed, RandomRange));
        }
        if (gameObject.transform.position == Vector3.up)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(RandomRange, speed));
        }
        if (gameObject.transform.position == Vector3.down)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(RandomRange, -speed));
        }
    }
}
