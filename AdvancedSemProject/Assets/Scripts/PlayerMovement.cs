using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    // Use this for initialization

    public float speed;
    
    ProjectileManager myProjectile;

    public Sprite[] playerSprites;


	void Start () {
        myProjectile = GameObject.FindGameObjectWithTag("SpawnManager").GetComponent<ProjectileManager>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        moveInput();
    }

    void moveInput()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            moveUp();
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            moveDown();
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            moveLeft();
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            moveRight();
        }
    }

    void moveLeft()
    {
        transform.Translate(Vector2.left * speed);
        myProjectile.myDirection = Vector3.left;
        this.GetComponent<SpriteRenderer>().sprite = playerSprites[3];
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    void moveRight()
    {
        transform.Translate(Vector2.right * speed);
        myProjectile.myDirection = Vector3.right;
        this.GetComponent<SpriteRenderer>().sprite = playerSprites[2];
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    void moveDown()
    {
        transform.Translate(Vector2.down * speed);
        myProjectile.myDirection = Vector3.down;
        this.GetComponent<SpriteRenderer>().sprite = playerSprites[0];
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    void moveUp()
    {
        transform.Translate(Vector2.up * speed);
        myProjectile.myDirection = Vector3.up;
        this.GetComponent<SpriteRenderer>().sprite = playerSprites[1];
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}
