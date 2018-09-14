using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

	float maxHealth = 100;
	float currentHealth;

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

		if(currentHealth < 60)
        {
            rend.material.color = Color.yellow;
        }
        if (currentHealth < 40)
        {
            rend.material.color = Color.blue;
        }
        if (currentHealth <= 0)
        {
            Destroy(this.gameObject);
        }
		
	}
	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.tag == "Enemy")
		{
			currentHealth -= 10;
		}
	}
}
