using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProjectileManager : MonoBehaviour
{
    public bool canShoot = false;
    //make more clear
    public Rigidbody2D[] myObject;
    private Rigidbody2D myObjectClone;
    private Rigidbody2D spawn;
    public Vector3 myDirection;
    public bool done;

    float time;

    float cooldown;

    int random;

    HUD myCountdown;

    // Use this for initialization
    void Start()
    {
        myDirection = Vector3.up;
        //switch to random element in array 
        myCountdown = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>();
        myObjectClone = myObject[0];
        done = true;
        cooldown = 0.2f;
    }

    // Update is called once per frame
    private void Update()
    {
        ChangeObject();
        MoveInput();
    }

    private void MoveInput()
    {
        time += Time.deltaTime;
        if (Input.GetKey(KeyCode.Space) && !(myCountdown.GetTimeLeft() <= 0) && time > cooldown)
        {
            SpawnObject();
            time = 0;
        }
    }

    private void SpawnObject()
    {
        spawn = (Rigidbody2D)Instantiate(myObjectClone, transform.position, transform.rotation);
    }

    private void ChangeObject()
    {
        random = Random.Range(0, myObject.Length);

        if (myCountdown.GetTimeLeft() <= 0 && done)
        {
            if (myObject[random] != myObjectClone)
            {
                myObjectClone = myObject[random];
            }
            else
            {
                //switch to list instead of a while loop
                while (myObject[random] == myObjectClone)
                {
                    random = Random.Range(0, myObject.Length);
                }
                myObjectClone = myObject[random];
            }


            if(myObject[random].tag == "Bullet")
            {
                cooldown = 0.2f;
            }
            if(myObject[random].tag == "Rocket")
            {
                cooldown = 0.7f;
            }
            done = false;
        }
       
    }


    public Vector3 GetDirection()
    {
        return myDirection;
    }


    public void SetCoolDownTime(float cool)
    {
        cooldown = cool;
    }

}
