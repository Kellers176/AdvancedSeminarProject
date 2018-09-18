using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    public bool canShoot = false;
    public Rigidbody2D myObject;
    private Rigidbody2D myObjectClone;
    public float speed = 100f;
    public Vector3 myDirection;
    float[] SpreadRange = { 10, 8, 6, 4, 2, 0, -2, -4, -6, -8, -10 };



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
