using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour 
{

	int maxHealth = 100;
    [SerializeField] int currentHealth;
    private Renderer rend;
    Rigidbody2D rb;

	// Use this for initialization
	void Start () 
	{
		currentHealth = maxHealth;
        rend = GetComponent<Renderer>();
        rend.material.color = Color.white;
    }
	
	// Update is called once per frame
	private void Update () 
	{
        checkHealth();
	}

    private void checkHealth()
    {
        switch (currentHealth)
        {
            case 40:
                rend.material.color = Color.grey;
                break;
            case 20:
                rend.material.color = Color.yellow;
                break;
            case 0:
                Destroy(this.gameObject);
                break;
            default:
                break;
        }
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
			currentHealth -= 20;
		}
	}

    public float GetHealth()
    {
        return currentHealth;
    }
}
