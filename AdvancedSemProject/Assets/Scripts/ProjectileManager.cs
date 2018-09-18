using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    public bool canShoot = false;
    public Rigidbody2D myObject;
    private Rigidbody2D myObjectClone;
    public Vector3 myDirection;



    // Use this for initialization
    void Start()
    {
        myDirection = Vector3.up;
    }

    // Update is called once per frame
    void Update()
    {
        //work on player health, work on timer, work on weapon, work on fixing thsiss

        if (Input.GetKeyDown(KeyCode.Space))
        {
            spawnObject();
        }
    }

    public void spawnObject()
    {
        myObjectClone = (Rigidbody2D)Instantiate(myObject, transform.position, transform.rotation);

    }

    public Vector3 getDirection()
    {
        return myDirection;
    }
}
