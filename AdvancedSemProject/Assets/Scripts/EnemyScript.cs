using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

    int maxHealth = 5;
    int currentHealth;
    private Renderer rend;
    Rigidbody2D rb;

    public GameObject pointA;
    public GameObject pointB;
    
    public float speed = 20.0f;
    

    public int direction = 1;

    public Quaternion left = Quaternion.Euler(0, 0, 0);
    public Quaternion right = Quaternion.Euler(0, 180, 0);

	// Use this for initialization
	void Start () {
        currentHealth = maxHealth;
        rend = GetComponent<Renderer>();
        rend.material.color = Color.white;

        rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {

        if(currentHealth < 4)
        {
            rend.material.color = Color.yellow;
        }
        if (currentHealth < 3)
        {
            rend.material.color = Color.red;
        }
        if (currentHealth <= 0)
        {
            Destroy(this.gameObject);
        }
       
	}

    private void FixedUpdate()
    {
        if(rb.position.x >= pointB.transform.position.x && direction == 1)
        {
            direction = -direction;
            transform.rotation = right;
        }
        else if(rb.position.x < pointA.transform.position.x && direction == -1)
        {
            direction = -direction;
            transform.rotation = left;
        }

        transform.Translate(speed * Time.deltaTime, 0, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            currentHealth -= 1;
        }
    }
}
