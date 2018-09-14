using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	public Rigidbody2D myObject;
	public float speed = 100f;
    public Vector3 myDirection;
    public float[] SpreadRange;


    // Use this for initialization
    void Start () {
        myDirection = Vector3.up;
    }
	
	// Update is called once per frame
	void Update () {
            //work on player health, work on timer, work on weapon, work on fixing thsiss
        
		if(Input.GetKeyDown(KeyCode.Space))
		{
			spawnObject();
		}
	}

	public void spawnObject()
	{
		Rigidbody2D myObjectClone = (Rigidbody2D) Instantiate(myObject, transform.position, transform.rotation);
        float RandomRange = SpreadRange[Random.Range(0, SpreadRange.Length)];
        if (myDirection == Vector3.right)
        {
            myObjectClone.AddForce(new Vector2(speed, RandomRange));
        }
        if(myDirection == Vector3.left)
        {
           
            myObjectClone.AddForce(new Vector2(-speed, RandomRange));
        }
        if(myDirection == Vector3.up)
        {
            myObjectClone.AddForce(new Vector2(RandomRange, speed));
        }
        if(myDirection == Vector3.down)
        {
            myObjectClone.AddForce(new Vector2(RandomRange, -speed));
        }
	}
}
