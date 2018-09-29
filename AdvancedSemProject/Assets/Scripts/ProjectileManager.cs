using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProjectileManager : MonoBehaviour
{
    [SerializeField] bool canShoot = false;
    //make more clear
    [SerializeField] Rigidbody2D[] myBulletType;
    private Rigidbody2D myBullet;
    private Rigidbody2D spawn;
    [SerializeField] Vector3 myDirection;
    bool done;

    float speed = 10f;

    float time;

    float cooldown;

    int random;

    HUD myCountdown;

    Vector3 shootDirection;

    // Use this for initialization
    void Start()
    {
        myDirection = Vector3.up;
        //switch to random element in array 
        myCountdown = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>();
        myBullet = myBulletType[Random.Range(0, myBulletType.Length)];
        done = true;
        CheckCooldown();
    }

    // Update is called once per frame
    private void Update()
    {
        ChangeObject();
        MoveInput();
    }

    private void CheckCooldown()
    {
        if (myBulletType[random].tag == "Bullet")
        {
            cooldown = 0.2f;
        }
        if (myBulletType[random].tag == "Rocket")
        {
            cooldown = 1.0f;
        }
        if (myBulletType[random].tag == "Bubbles")
        {
            cooldown = 0.4f;
        }
    }

    private void MoveInput()
    {
        time += Time.deltaTime;
        if (Input.GetMouseButton(0) && !(myCountdown.GetTimeLeft() <= 0) && time > cooldown)
        {
            Debug.Log(time);
            SpawnObject();
            time = 0;
        }
    }

    private void SpawnObject()
    {
        shootDirection.z = 0.0f;
        shootDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        shootDirection = shootDirection - transform.position;
        spawn = (Rigidbody2D)Instantiate(myBullet, transform.position, Quaternion.Euler(new Vector3(0,0,0))) as Rigidbody2D;
    }

    public Vector3 getShootDirection()
    {
        return shootDirection;
    }

    private void ChangeObject()
    {
        random = Random.Range(0, myBulletType.Length);

        if (myCountdown.GetTimeLeft() <= 0 && done)
        {
            if (myBulletType[random] != myBullet)
            {
                myBullet = myBulletType[random];
            }
            else
            {
                //switch to list instead of a while loop
                while (myBulletType[random] == myBullet)
                {
                    random = Random.Range(0, myBulletType.Length);
                }
                myBullet = myBulletType[random];
            }


            CheckCooldown();
            done = false;
        }
       
    }

    public void SetDirection(Vector3 direction)
    {
        myDirection = direction;
    }

    public Vector3 GetDirection()
    {
        return myDirection;
    }


    public void SetDone(bool mybool)
    {
        done = mybool;
    }

}
