using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowScript : MonoBehaviour {
    public Transform target;
    public float speed = 20.0f;

    int maxHealth = 100;
    int currentHealth;
    private Renderer rend;

    // Use this for initialization
    void Start () {
        currentHealth = maxHealth;
        rend = GetComponent<Renderer>();
        rend.material.color = Color.white;
    }
	
	// Update is called once per frame
	void Update () {
        if(target != null)
        {
            changeColor();
            destroyObject();
            move();
        }
    }
    void move()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }

    void destroyObject()
    {
        if (currentHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    void changeColor()
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
