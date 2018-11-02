using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleEnemyAI : MonoBehaviour {

GameObject target;
    List<GameObject> closeEnemies = new List<GameObject>();
    EnemyManager mManager;
    private Renderer rend;
    bool ifDying;
    [SerializeField] int deecelerationFactor;
    
    Vector2 positionVector;
    Transform sitPoint;
    Transform cowerPoint;
    private GameObject spawn;
    public GameObject bullet;
	private GameObject shield;

    float moveSpeed = 2.0f;
    float impulseForce = 30.0f;
    int neighborCount;
    float safeDistance = 3f;
    int maxHealth = 100;
    int currentHealth;
    bool flee = false;
    float timeToSeek = 0.0f;
	float timeTillDeactive;
    int mRandom;
    float time;
    float cooldown;
	bool shieldIsActive;

    int numberOfAIBehaviors = 5;
    enum AIBehaviors {SEEK, ARRIVE, FLEE, MOVETOPOINT, COWER }
    AIBehaviors myBehavior;
    Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        target = GameObject.FindGameObjectWithTag("Player");
        sitPoint = GameObject.FindGameObjectWithTag("Sit").GetComponent<Transform>();
        cowerPoint = GameObject.FindGameObjectWithTag("Cower").GetComponent<Transform>();
		shield = this.gameObject.transform.GetChild(0).gameObject;
        mRandom = Random.Range(0, numberOfAIBehaviors);
        mManager = GameObject.FindGameObjectWithTag("EnemyManager").GetComponent<EnemyManager>();
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        rend = GetComponent<Renderer>();
		shieldIsActive = false;
        rend.material.color = Color.white;
		timeTillDeactive = 0.0f;
        deecelerationFactor = 10;
        ifDying = false;
        Wave();
    }

    public void SetShieldActive(bool myShield)
    {
        shieldIsActive = myShield;
    }
	
	// Update is called once per frame
	void Update () {
        DestroyObject();
        if (target != null && !ifDying)
        {
            ChangeColor();
            time += Time.deltaTime;
            timeToSeek += Time.deltaTime;
            switch (mRandom)
            {
                case (int)AIBehaviors.SEEK:
                    Seek();
                    break;
                case (int)AIBehaviors.ARRIVE:
                    Arrive();
                    break;
                case (int)AIBehaviors.FLEE:
                    Flee();
                    flee = true;
                    break;
                case (int)AIBehaviors.MOVETOPOINT:
                    MoveAway();
                    break;
                case (int)AIBehaviors.COWER:
                    Cower();
                    break;
                default:
                    break;
            }
            //Debug.Log(moveSpeed + "BUBBLE");
            //Debug.Log(maxHealth + "BUBBLE");
            Debug.Log(currentHealth);
            if (timeToSeek > 2.0 && flee)
            {
                flee = false;
                timeToSeek = 0.0f;
                Seek();
            }

            Seperation();
        }
    }

    void Wave()
    {
        int myCurrentWave = mManager.GetWaves();
        switch(myCurrentWave)
        {
            case 1: 
                cooldown = 1.5f;
                moveSpeed = 2.0f;
                maxHealth = 100;
                break;
            case 2:
                cooldown = 1.0f;
                moveSpeed = 2.5f;
                maxHealth = 120;
                break;
            case 3:
             cooldown = 0.7f;
                moveSpeed = 3.0f;
                maxHealth = 130;
                break;
            case 4:
                cooldown = 0.6f;
                moveSpeed = 3.5f;
                maxHealth = 140;
                break;
            default:
                moveSpeed = 1.5f;
                maxHealth = 100;
                break;
        }
    }

    void Seek()
    {
        Vector3 enemyDirection = target.transform.position - transform.position;
        enemyDirection.z = 0;
        enemyDirection.Normalize();
        enemyDirection *= moveSpeed * Time.deltaTime;
        
        transform.position += enemyDirection;
        rb.velocity *= enemyDirection * moveSpeed * Time.deltaTime;
    }

    void Flee()
    {
        Vector3 enemyDirection = transform.position - target.transform.position;
        enemyDirection.z = 0;

        if(enemyDirection.magnitude < safeDistance)
        {
            Vector3 moveVector = enemyDirection.normalized * moveSpeed * Time.deltaTime;
            transform.position += moveVector;
            rb.velocity *= moveVector * moveSpeed * Time.deltaTime;
        }
        else
        {
            Seek();
        }
    }

    void Arrive()
    {
        Vector3 enemyDirection = target.transform.position - transform.position;
        enemyDirection.z = 0;
        float distance = enemyDirection.magnitude;
        float deecelelrationFactor = distance / deecelerationFactor;
        float speed = moveSpeed * deecelelrationFactor;

        Vector3 moveVector = enemyDirection.normalized * Time.deltaTime * speed;
        transform.position += moveVector;
        rb.velocity *= moveVector * moveSpeed * Time.deltaTime;
        
    }

    void Cower()
    {
        Vector3 enemyDirection = cowerPoint.position - transform.position;
        enemyDirection.z = 0;
        float distance = enemyDirection.magnitude;
        rend.material.color = Color.blue;
        if (distance < 1)
        {
            //do nothing
        }
        else
        {
            float deecelelrationFactor = distance / deecelerationFactor;
            float speed = moveSpeed * deecelelrationFactor;

            Vector3 moveVector = enemyDirection.normalized * Time.deltaTime * speed;
            transform.position += moveVector;
            rb.velocity *= moveVector * moveSpeed * Time.deltaTime;
        }
    }

    void Shoot()
    {
        if(time > cooldown)
        {
            spawn = Instantiate(bullet, transform.position, Quaternion.identity);
            time = 0;
        }

    }
    void MoveAway()
    {
        Vector3 enemyDirection = sitPoint.position - transform.position;
        enemyDirection.z = 0;
        float distance = enemyDirection.magnitude;

        if (distance < 3)
        {
            //do nothing
        }
        else
        {
            float deecelelrationFactor = distance / deecelerationFactor;
            float speed = moveSpeed * deecelelrationFactor;

            Vector3 moveVector = enemyDirection.normalized * Time.deltaTime * speed;
            transform.position += moveVector;
            rb.velocity *= moveVector * moveSpeed * Time.deltaTime;
        }
        Shoot();
    }

    void Seperation()
    {
        neighborCount = 0;
        
        closeEnemies = mManager.getEnemyList();

        for (int k = 0; k < closeEnemies.Count; k++)
        {
            if(closeEnemies[k].gameObject != this.gameObject && closeEnemies[k] != null)
            {
                Vector2 direction = closeEnemies[k].transform.position - this.gameObject.transform.position;
                float distance = direction.magnitude;
                if (distance <= 1)
                {
                    float strength = Mathf.Min(20.0f / 1.0f, moveSpeed);
                    direction.Normalize();
                    rb.velocity += (-direction * strength);
                    
                    neighborCount++;
                }
            }
        }

        if (neighborCount == 0)
        {
            //do nothing
            rb.velocity = Vector3.zero;
        }
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
			if(collision.gameObject.tag == "Well")
			{
				Debug.Log("Colliding");
				Destroy(this.gameObject);
				Vector3 enemyDirection = collision.transform.position - target.transform.position;
				enemyDirection.z = 0;

				if(enemyDirection.magnitude < safeDistance)
				{
					Vector3 moveVector = enemyDirection.normalized * moveSpeed * Time.deltaTime;
					transform.position += moveVector;
					rb.velocity *= moveVector * moveSpeed * Time.deltaTime;
				}
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
