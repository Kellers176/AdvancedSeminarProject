using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAIBehaviors : MonoBehaviour {

    GameObject target;
    EnemyManager mManager;
    float moveSpeed = 1.0f;
    float impulseForce = 10.0f;
    float rotateSpeed = 1.0f;

    float minimumDistance = 5.0f;
    float safeDistance = 60.0f;

    int maxHealth = 100;
    int currentHealth;
    bool flee = false;
    float timeToSeek = 0.0f;

    private Renderer rend;


    Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        target = GameObject.FindGameObjectWithTag("Player");
        mManager = GameObject.FindGameObjectWithTag("EnemyManager").GetComponent<EnemyManager>();
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        rend = GetComponent<Renderer>();
        rend.material.color = Color.white;
    }
	
	// Update is called once per frame
	void Update () {
        if(target != null)
        {
            ChangeColor();
            DestroyObject();
            
        }

        timeToSeek += Time.deltaTime;
        if(flee == false)
        {
            Seek();
        }
        else
        {
            Flee();
        }

        if(timeToSeek > 2.0)
        {
            flee = false;
            timeToSeek = 0.0f;
        }


    }

    void Seek()
    {
        Vector3 enemyDirection = target.transform.position - transform.position;
        enemyDirection.z = 0;

        
        Vector3 moving = enemyDirection.normalized * moveSpeed * Time.deltaTime;

        transform.position += moving;
        rb.velocity *= moving * moveSpeed * Time.deltaTime;
    }

    void Flee()
    {
        Vector3 enemyDirection = transform.position - target.transform.position;
        enemyDirection.z = 0;

        if(enemyDirection.magnitude < safeDistance)
        {
            Vector3 moveVector = enemyDirection.normalized * moveSpeed * Time.deltaTime;
            transform.position += moveVector;
            rb.velocity *= moveVector * moveSpeed * Time.deltaTime;
        }
    }

    void Arrive()
    {
        Vector3 enemyDirection = target.transform.position - transform.position;
        enemyDirection.z = 0;
        float distance = enemyDirection.magnitude;
        float deecelelrationFactor = distance / 5;
        float speed = moveSpeed * deecelelrationFactor;

        Vector3 moveVector = enemyDirection.normalized * Time.deltaTime * speed;
        transform.position += moveVector;
        rb.velocity *= moveVector * moveSpeed * Time.deltaTime;
        
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
        if(collision.gameObject.tag == "Bubbles")
        {
            Vector3 distance =  transform.position - collision.gameObject.transform.position;
            distance.Normalize();
            rb.AddForce(distance * impulseForce);
        }

        if(collision.gameObject.tag == "Player")
        {
            currentHealth -= 50;
            rb.velocity = Vector3.zero;
        }
        if(collision.gameObject.tag == "Well")
        {
            flee = true;
            //Destroy(this.gameObject);
        }
    }
}
