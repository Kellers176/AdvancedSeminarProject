using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAIBehaviors : MonoBehaviour {

    GameObject target;
    EnemyManager mManager;
    float moveSpeed = 1.0f;
    float rotateSpeed = 1.0f;

    float minimumDistance = 5.0f;
    float safeDistance = 60.0f;

    int maxHealth = 100;
    int currentHealth;
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
            Seek();
        }

    }

    void Seek()
    {
        Vector3 enemyDirection = target.transform.position - transform.position;
        enemyDirection.z = 0;

        
        Vector3 moving = enemyDirection.normalized * moveSpeed * Time.deltaTime;

        transform.position += moving;
        rb.velocity = moving * moveSpeed * Time.deltaTime;
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
}
