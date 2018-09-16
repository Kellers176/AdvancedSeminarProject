using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{


    public bool canShoot = false;



    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //work on player health, work on timer, work on weapon, work on fixing thsiss

        if (Input.GetKeyDown(KeyCode.Space))
        {
            canShoot = true;

        }
    }
}
