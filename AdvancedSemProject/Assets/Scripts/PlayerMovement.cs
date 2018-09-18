using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    // Use this for initialization

    public float speed;
    
    ProjectileManager myProjectile;


	void Start () {
        myProjectile = GameObject.FindGameObjectWithTag("SpawnManager").GetComponent<ProjectileManager>();
	}
	
	// Update is called once per frame
	void Update () 
    {


        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            //up
            transform.Translate(Vector2.up * speed);
            myProjectile.myDirection = Vector3.up;
            transform.rotation = Quaternion.Euler(0,0,0);
            
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            //down
            transform.Translate(Vector2.down * speed);
            myProjectile.myDirection = Vector3.down;
            transform.rotation = Quaternion.Euler(0,0,0);
            
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            //left
            transform.Translate(Vector2.left * speed);
            myProjectile.myDirection = Vector3.left;
            transform.rotation = Quaternion.Euler(0,0,0);
        }
        if (Input.GetKey(KeyCode.D)|| Input.GetKey(KeyCode.RightArrow))
        {
            //right
            transform.Translate(Vector2.right * speed);
            myProjectile.myDirection = Vector3.right;
            transform.rotation = Quaternion.Euler(0,0,0);
        }
    }
}
