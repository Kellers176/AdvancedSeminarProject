using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    // Use this for initialization

    public float speed;

    public GameObject spawner;
    Projectile myProjectile;

	void Start () {
        myProjectile = spawner.GetComponent<Projectile>();
	}
	
	// Update is called once per frame
	void Update () {

        if(Input.GetKey(KeyCode.W))
        {
            //up
           transform.Translate(Vector2.up * speed);
           if(transform.rotation != Quaternion.Euler(0,0,0))
            {
                myProjectile.myDirection = Vector3.up;
                transform.rotation = Quaternion.Euler(0,0,0);
            }
            
        }
        if (Input.GetKey(KeyCode.S))
        {
            //down
            transform.Translate(Vector2.up * speed);
            if(transform.rotation != Quaternion.Euler(0,0,180))
            {
                myProjectile.myDirection = Vector3.down;
                transform.rotation = Quaternion.Euler(0,0,180);
            }
            
        }
        if (Input.GetKey(KeyCode.A))
        {
            //left
            transform.Translate(Vector2.up * speed);
            if(transform.rotation != Quaternion.Euler(0,0,90))
            {
                myProjectile.myDirection = Vector3.left;
                transform.rotation = Quaternion.Euler(0,0,90);
            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            //right
            transform.Translate(Vector2.up * speed);
            if(transform.rotation != Quaternion.Euler(0,0,-90))
            {
                myProjectile.myDirection = Vector3.right;
                transform.rotation = Quaternion.Euler(0,0,-90);
            }
        }



    }
}
