using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    int speed = 10;
    Vector3 velocity;
	// Use this for initialization
	void Start () {
        velocity = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {
        //Vector3 position = transform.position;

        //float horizontalMovement = Input.GetAxis("Horizontal");
        //float verticalMovement = Input.GetAxis("Vertical");

        //if(horizontalMovement != 0)
        //{
        //    transform.Translate(transform.right * horizontalMovement * speed * Time.deltaTime);
        //}

        //if(verticalMovement != 0)
        //{
        //    transform.Translate(transform.up * verticalMovement * speed * Time.deltaTime);
        //}

        //velocity = transform.position - position;
    }
}
