using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	public Rigidbody2D myObject;
	public float speed = 100f;

	// Use this for initialization
	void Start () {
		
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
		myObjectClone.AddForce(Vector3.up * speed);

	}
}
