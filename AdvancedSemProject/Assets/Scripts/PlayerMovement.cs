using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    // Use this for initialization

    public float speed;

	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

        if(Input.GetKey(KeyCode.W))
        {
            //up
            transform.Translate(Vector2.up * speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            //down
            transform.Translate(Vector2.down * speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            //left
            transform.Translate(Vector2.left * speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            //right
            transform.Translate(Vector2.right * speed);
        }



    }
}
