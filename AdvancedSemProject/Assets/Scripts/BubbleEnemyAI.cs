using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleEnemyAI : MonoBehaviour {
    
    List<GameObject> closeEnemies = new List<GameObject>();
    EnemyManager mManager;
    private Renderer rend;
    [SerializeField] GameObject explosion;
    Vector2 positionVector;
    Transform sitPoint;
    Transform cowerPoint;
    private GameObject spawn;
    bool canSubtract;
    float moveSpeed = 2.0f;
    float impulseForce = 100.0f;
    int neighborCount;
    float safeDistance = 3f;
    int maxHealth = 100;
    int currentHealth;
    bool flee = false;
    float timeToSeek = 0.0f;
    int mRandom;
    float time;
    float cooldown;
    float timeTillDeactive;
    bool ifDying;
    private GameObject shield;
	bool shieldIsActive;

    int numberOfAIBehaviors = 5;
    enum AIBehaviors {SEEK, ARRIVE, FLEE, MOVETOPOINT, COWER }
    AIBehaviors myBehavior;
    Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		shield = this.gameObject.transform.GetChild(0).gameObject;
        mRandom = Random.Range(0, numberOfAIBehaviors);
        mManager = GameObject.FindGameObjectWithTag("EnemyManager").GetComponent<EnemyManager>();
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        rend = GetComponent<Renderer>();
		shieldIsActive = false;
        rend.material.color = Color.white;
		timeTillDeactive = 0.0f;
        ifDying = false;
        canSubtract = true;
    }

    public void SetShieldActive(bool myShield)
    {
        shieldIsActive = myShield;
    }
	
	// Update is called once per frame
	void Update () {
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
		if(!shieldIsActive)
		{
			if(collision.tag == "FlameThrower")
			{
				currentHealth -= 10;
			}

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
		if(!shieldIsActive)
		{
			if (collision.gameObject.tag == "Bullet")
			{
				currentHealth -= 10;
			}
			if (collision.gameObject.tag == "Rocket")
			{
				currentHealth -= 50;
			}
			if(collision.gameObject.tag == "Player")
			{
				currentHealth -= 50;
				rb.velocity = Vector3.zero;
			}
            if(collision.gameObject.tag == "DeathWall")
            {
                currentHealth = 0;
            }
            
        }
        if(collision.gameObject.tag == "Bubbles")
        {
			shield.SetActive(true);
			shieldIsActive = true;
        }

    }
}
