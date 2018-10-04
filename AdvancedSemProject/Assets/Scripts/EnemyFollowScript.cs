using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowScript : MonoBehaviour 
{
    Transform target;
    [SerializeField] float speed = 20.0f;
    EnemyManager mManager;

    int maxHealth = 100;
    int currentHealth;
    private Renderer rend;
    Rigidbody2D rb;
    bool collidingIntoWall;

    // Use this for initialization
    void Start () 
    {
        rb = GetComponent<Rigidbody2D>();
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        currentHealth = maxHealth;
        rend = GetComponent<Renderer>();
        rend.material.color = Color.white;
        collidingIntoWall = false;
        mManager = GameObject.FindGameObjectWithTag("EnemyManager").GetComponent<EnemyManager>();
    }
	
	// Update is called once per frame
	void Update () 
    {
        if(target != null)
        {
            ChangeColor();
            DestroyObject();
            Move();
        }
    }

    private void Move()
    {
        if(!collidingIntoWall)
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        else
            rb.velocity = transform.up * speed * Time.deltaTime;
    }

    private void DestroyObject()
    {
        if (currentHealth <= 0)
        {
            mManager.SubtractEnemyCount();
            Destroy(this.gameObject);
        }
    }

    private void ChangeColor()
    {
        switch (currentHealth)
        {
            case 40:
                rend.material.color = Color.yellow;
                break;
            case 20:
                rend.material.color = Color.red;
                break;
            case 0:
                Destroy(this.gameObject);
                break;
            default:
                break;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            currentHealth -= 10;
        }
        if (collision.gameObject.tag == "Rocket")
        {
            currentHealth -= 50;
        }
    }

    void OnCollisionEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Wall")
        {
            collidingIntoWall = true;
            //transform.position = transfom.up
        }
    }
}
