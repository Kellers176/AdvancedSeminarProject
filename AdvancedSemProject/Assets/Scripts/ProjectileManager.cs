﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    public bool canShoot = false;
    public Rigidbody2D[] myObject;
    private Rigidbody2D myObjectClone;
    private Rigidbody2D spawn;
    public Vector3 myDirection;
    public bool done;

    int random;

    HUD myCountdown;

    // Use this for initialization
    void Start()
    {
        myDirection = Vector3.up;
        myCountdown = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>();
        myObjectClone = myObject[0];
        done = true;
    }

    // Update is called once per frame
    void Update()
    {
        random = Random.Range(0, myObject.Length);

        if (myCountdown.getTimeLeft() <= 0 && done)
        {
            if (myObject[random] != myObjectClone)
            {
                myObjectClone = myObject[random];
            }
            else
            {
                while (myObject[random] == myObjectClone)
                {
                    random = Random.Range(0, myObject.Length);
                }
                myObjectClone = myObject[random];
            }
            done = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && !(myCountdown.getTimeLeft() <= 0))
        {
            spawnObject();
        }
    }

    public void spawnObject()
    {

        spawn = (Rigidbody2D)Instantiate(myObjectClone, transform.position, transform.rotation);

    }

    public Vector3 getDirection()
    {
        return myDirection;
    }
}
