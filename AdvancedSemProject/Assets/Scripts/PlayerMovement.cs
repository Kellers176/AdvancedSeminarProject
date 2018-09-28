using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    // Use this for initialization

    public float speed;
    Vector3 distance;
    float angle;

    Vector3 mousePosition;
    
    ProjectileManager myProjectile;

    Rigidbody2D rb;

    public Sprite[] playerSprites;


	void Start () {
        myProjectile = GameObject.FindGameObjectWithTag("SpawnManager").GetComponent<ProjectileManager>();
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	private void Update () 
    {
        MoveInput();
    }

    private void MoveInput()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        distance = mousePosition - this.transform.position;
        angle = Mathf.Atan2(distance.y, distance.x) * Mathf.Rad2Deg;
        Debug.Log(angle);
        if(angle < 135 && angle > 45)
        {
            //up
            this.GetComponent<SpriteRenderer>().sprite = playerSprites[1];
            Debug.Log("up");
        }
        else if(angle < 45 && angle > -45)
        {
            //right
            this.GetComponent<SpriteRenderer>().sprite = playerSprites[2];
             Debug.Log("right");
        }
        else if( angle < -45 && angle > -135)
        {
            //down
            this.GetComponent<SpriteRenderer>().sprite = playerSprites[0];
             Debug.Log("down");
        }
        else if (angle < -135 || angle > 135)
        {
            //left
            this.GetComponent<SpriteRenderer>().sprite = playerSprites[3];
             Debug.Log("left");
        }
        
        //get angle. so get 
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            MoveUp();
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            MoveDown();
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            MoveLeft();
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            MoveRight();
        }
    }

    void MoveLeft()
    {
        rb.velocity += Vector2.left * speed * Time.deltaTime;
        myProjectile.myDirection = Vector2.left;
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    void MoveRight()
    {
         rb.velocity += Vector2.right * speed* Time.deltaTime;
         myProjectile.myDirection = Vector2.right;
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    void MoveDown()
    {
        rb.velocity += Vector2.down * speed* Time.deltaTime;
        myProjectile.myDirection = Vector2.down;
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

     void MoveUp()
    {
        rb.velocity += Vector2.up * speed* Time.deltaTime;
        myProjectile.myDirection = Vector2.up;
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}
