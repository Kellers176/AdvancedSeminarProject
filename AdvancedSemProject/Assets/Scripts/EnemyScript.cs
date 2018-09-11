using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

    int maxHealth = 50;
    int currentHealth;
    private Renderer rend;

	// Use this for initialization
	void Start () {
        currentHealth = maxHealth;
        rend = GetComponent<Renderer>();
        rend.material.color = Color.black;
    }
	
	// Update is called once per frame
	void Update () {

        if(currentHealth < 40)
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
       
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            currentHealth -= 10;
        }
    }
}
