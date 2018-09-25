using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProjectileManager : MonoBehaviour
{
    public bool canShoot = false;
    public Rigidbody2D[] myObject;
    private Rigidbody2D myObjectClone;
    private Rigidbody2D spawn;
    public Vector3 myDirection;
    public bool done;

    float time;

    float cooldown;

    int maxBullets;
    int toReload;

    int random;

    HUD myCountdown;

    // Use this for initialization
    void Start()
    {
        myDirection = Vector3.up;
        myCountdown = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>();
        myObjectClone = myObject[0];
        done = true;
        cooldown = 0.5f;
        toReload = 5;
        maxBullets = toReload;
    }

    // Update is called once per frame
    void Update()
    {
        changeObject();
        
        time += Time.deltaTime;

        Reloading();
        if (Input.GetKeyDown(KeyCode.Space) && !(myCountdown.getTimeLeft() <= 0) && time > cooldown && !(toReload <= 0))
        {
            spawnObject();
            time = 0;
        }
    }

    void Reloading()
    {
        if(toReload <= 0 && Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("Reloading");
            //have a wait time
            toReload = maxBullets;
        }
    }

    public void spawnObject()
    {
        spawn = (Rigidbody2D)Instantiate(myObjectClone, transform.position, transform.rotation);
        toReload--;
    }

    public void changeObject()
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
    }

    public void setReload(int myreload)
    {
        maxBullets = myreload;
        toReload = myreload;
    }

    public Vector3 getDirection()
    {
        return myDirection;
    }
   

    public void setCoolDownTime(float cool)
    {
        cooldown = cool;
    }

}
