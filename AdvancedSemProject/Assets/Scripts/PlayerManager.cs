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
    [SerializeField] GameObject deathV1, deathV2, deathV3;
    PlayerMovement mSpeed;
    bool notColliding = true;

	// Use this for initialization
	void Start () 
	{
		currentHealth = maxHealth;
        rend = GetComponent<Renderer>();
        rend.material.color = Color.white;
        mSpeed = this.GetComponent<PlayerMovement>();
    }
	
	// Update is called once per frame
	private void Update () 
	{
        checkHealth();
	}

    private void checkHealth()
    {

        if(currentHealth < 70 && currentHealth > 50)
        {
            //rend.material.color = Color.grey;
            deathV1.SetActive(true);
        }
        if(currentHealth < 50 && currentHealth > 20)
        {
            //rend.material.color = Color.yellow;
            deathV1.SetActive(false);
            deathV2.SetActive(true);
        }
        if(currentHealth < 20 && currentHealth > 1)
        {
            deathV2.SetActive(false);
            deathV3.SetActive(true);
        }
        if(currentHealth > 70)
        {
            deathV1.SetActive(false);
            deathV2.SetActive(false);
            deathV3.SetActive(false);
        }
        if (currentHealth <= 0)
        {
            Destroy(this.gameObject);
            SceneManager.LoadScene("Lose Screen");
        }
        if(notColliding)
            mSpeed.SetSpeed(15);
    }
	private void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.tag == "Enemy")
		{
			currentHealth -= 10;
		}
        
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyBullet")
        {
            currentHealth -= 10;
        }
        if(collision.gameObject.tag == "RocketExplosion")
        {
            currentHealth -= 20;
        }
        if (collision.gameObject.tag == "SpikeTrap")
        {
            Debug.Log("In spike trap");
            if(collision.gameObject.GetComponent<Animator>().GetBool("pain"))
            {
                Debug.Log("inPain");
                currentHealth -= 10;
                mSpeed.SetSpeed(10);
                notColliding = false;
            }
        }
        if(collision.gameObject.tag == "Health")
        {
            currentHealth = maxHealth;
            Destroy(collision.gameObject);
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "SpikeTrap")
        {
            Debug.Log("In spike trap");
            if (collision.gameObject.GetComponent<Animator>().GetBool("pain"))
            {
                mSpeed.SetSpeed(15);
                notColliding = true;
            }
        }
    }


    public float GetHealth()
    {
        return currentHealth;
    }
}
