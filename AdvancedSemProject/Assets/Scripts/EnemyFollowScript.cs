using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowScript : MonoBehaviour {
    public Transform target;
    public float speed = 20.0f;

    int maxHealth = 100;
    int currentHealth;
    private Renderer rend;
    Rigidbody2D rb;

    // Use this for initialization
    void Start () {
        currentHealth = maxHealth;
        rend = GetComponent<Renderer>();
        rend.material.color = Color.white;
    }
	
	// Update is called once per frame
	void Update () {

        if (currentHealth < 40)
        {
            rend.material.color = Color.yellow;
        }
        if (currentHealth < 20)
        {
            rend.material.color = Color.red;
        }
        if (currentHealth <= 0)
        {
            Destroy(this.gameObject);
        }

        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
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
