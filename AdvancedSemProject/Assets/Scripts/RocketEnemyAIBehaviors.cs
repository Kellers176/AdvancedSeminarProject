using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketEnemyAIBehaviors : MonoBehaviour {
    
    EnemyManager mManager;
    private Renderer rend;
    bool ifDying;
    [SerializeField] GameObject explosion;
    private GameObject spawn;

    float impulseForce = 200.0f;
    bool canSubtract;
    float moveSpeed = 2.0f;
    int maxHealth = 100;
    int currentHealth;
    bool flee = false;

    Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {
        mManager = GameObject.FindGameObjectWithTag("EnemyManager").GetComponent<EnemyManager>();
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        rend = GetComponent<Renderer>();
        rend.material.color = Color.white;
        ifDying = false;
        canSubtract = true;
    }

    // Update is called once per frame
    void Update()
    {
        DestroyObject();
    }

    private void DestroyObject()
    {
        if (currentHealth <= 0 && canSubtract)
        {
            GameObject myExplosion = Instantiate(explosion, transform.position, Quaternion.identity) as GameObject;
            Destroy(myExplosion, 1.0f);
            this.gameObject.GetComponent<Renderer>().enabled = false;
            mManager.SubtractEnemyCount();
            Destroy(this.gameObject, 1.0f);
            canSubtract = false;
        }
    }
    public void SetHealth(int myHealth)
    {
        maxHealth = myHealth;
    }

    int GetHealth()
    {
        return currentHealth;
    }

    public void SetSpeed(float mySpeed)
    {
        moveSpeed = mySpeed;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "FlameThrower")
        {
            currentHealth -= 10;
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
            //explode
            GameObject myExplosion = Instantiate(explosion, transform.position, Quaternion.identity) as GameObject;
            Destroy(myExplosion, 1.0f);
            this.gameObject.GetComponent<Renderer>().enabled = false;
            this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            mManager.SubtractEnemyCount();
            Destroy(this.gameObject, 1.0f);
        }
        if (collision.gameObject.tag == "Bubbles")
        {
            Vector3 distance = transform.position - collision.gameObject.transform.position;
            distance.Normalize();
            rb.AddForce(distance * impulseForce * Time.deltaTime);
        }
        if (collision.gameObject.tag == "Player")
        {
            currentHealth -= 20;
            rb.velocity = Vector3.zero;
        }
        if (collision.gameObject.tag == "DeathWall")
        {
            currentHealth = 0;
        }
    }
}
