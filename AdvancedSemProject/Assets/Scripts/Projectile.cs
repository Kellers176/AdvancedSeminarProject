using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	public Rigidbody2D myObject;
	public float speed = 100f;
    public Vector3 myDirection;

    // Use this for initialization
    void Start () {
        myDirection = Vector3.up;

    }
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space))
		{
			spawnObject();
		}
	}

	public void spawnObject()
	{
		Rigidbody2D myObjectClone = (Rigidbody2D) Instantiate(myObject, transform.position, transform.rotation);
		myObjectClone.AddForce(myDirection * speed);

	}
}
