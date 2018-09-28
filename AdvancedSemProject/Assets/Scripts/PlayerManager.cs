using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour 
{

	float maxHealth = 5;
	public float currentHealth;

    Rigidbody2D rb;

	// Use this for initialization
	void Start () 
	{
		currentHealth = maxHealth;
	}
	
	// Update is called once per frame
	private void Update () 
	{
        checkHealth();
	}

    private void checkHealth()
    {
        if (currentHealth <= 0)
        {
            Destroy(this.gameObject);
            SceneManager.LoadScene("Lose Screen");
        }
    }
	private void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.tag == "Enemy")
		{
			currentHealth -= 1;
		}
	}
}
