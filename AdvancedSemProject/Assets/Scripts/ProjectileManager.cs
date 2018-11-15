using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProjectileManager : MonoBehaviour
{
    [SerializeField] bool canShoot = false;
    //[SerializeField] Tutorial myTutorial;
    //make more clear
    //[SerializeField] Rigidbody2D[] myBulletType;
    [SerializeField] List<Rigidbody2D> myBulletType = new List<Rigidbody2D>();
    List<Rigidbody2D> myBulletTypeDeleted = new List<Rigidbody2D>();
    private Rigidbody2D myBullet;
    private Rigidbody2D spawn;
    bool firstRocket, firstBullet, firstBubble, firstFlamethrower;
    Vector3 oldDirection;
    [SerializeField] Vector3 myDirection;
    int activeGun;
    bool canShow;
    int notDone = 0;
    bool done;

    float speed = 10f;

    float time;

    float cooldown;
    
    int random;
    int count;
    float showTimer;

    HUD myCountdown;
    [SerializeField] TextMeshProUGUI[] CurrentType;
    Vector3 shootDirection;

    // Use this for initialization
    void Start()
    {
        myDirection = Vector3.up;
        //switch to random element in array 
        myCountdown = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>();
        myBullet = myBulletType[Random.Range(0, myBulletType.Count)];
        oldDirection = myDirection;
        CheckCooldown();
        count = 0;
        canShow = true;
        done = true;
    }

    // Update is called once per frame
    private void Update()
    {
        ChangeObject();
        MoveInput();
        if(canShow)
        {
            showTimer += Time.deltaTime;
            CurrentType[activeGun].enabled = true;
            //Debug.Log(showTimer);
            if(showTimer > 3.0)
            {
                showTimer = 0;
                CurrentType[activeGun].enabled = false;
                canShow = false;
            }
        }
    }

    private void CheckCooldown()
    {
       
            if (myBullet.tag == "Bullet")
            {
                canShow = true;
                activeGun = 0;
                cooldown = 0.2f;
                //GetTutorial
                firstBullet = true;
                if (notDone < 4)
                {
                    CheckTutorial();
                    notDone++;
                }
            }
            else if (myBullet.tag == "Rocket")
            {
                canShow = true;
                activeGun = 1;
                cooldown = 1.0f;
                //GetTutorial
                firstRocket = true;
                if (notDone < 4)
                {
                    CheckTutorial();
                    notDone++;
                }
        }
            else if (myBullet.tag == "Bubbles")
            {
                canShow = true;
                activeGun = 2;
                cooldown = 0.4f;
                //GetTutorial
                firstBubble = true;
                if (notDone < 4)
                {
                    CheckTutorial();
                    notDone++;
                }
        }
            else if (myBullet.tag == "FlameThrower")
            {
                canShow = true;
                activeGun = 3;
                cooldown = 0.1f;
                //GetTutorial
                firstFlamethrower = true;
                if (notDone < 4)
                {
                    CheckTutorial();
                    notDone++;
                }
        }
        
        
    }
    public void CheckTutorial()
    {
        //if (myTutorial != null)
        //{
        //    if (firstFlamethrower)
        //    {
        //        //Tutorial
        //        myTutorial.ShowFlameThrowerTutorial();
        //        firstFlamethrower = false;
        //    }
        //    else if (firstBubble)
        //    {
        //        //tutorial
        //        myTutorial.ShowBubbleTutorial();
        //        firstBubble = false;
        //    }
        //    else if (firstBullet)
        //    {
        //        //tutorial
        //        myTutorial.ShowBulletTutorial();
        //        firstBullet = false;
        //    }
        //    else if (firstRocket)
        //    {
        //        //tutorial
        //        myTutorial.ShowRocketTutorial();
        //        firstRocket = false;
        //    }
        //}
    }
    

    private void MoveInput()
    {
      
        time += Time.deltaTime;
        if (Input.GetMouseButton(0) && !(myCountdown.GetTimeLeft() <= 0) && time > cooldown)
        {
            //Debug.Log(time);
            SpawnObject();
            time = 0;
        }
    }

    private void SpawnObject()
    {
            shootDirection.z = 0.0f;
            shootDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            shootDirection = shootDirection - transform.position;
            oldDirection = myDirection;
            spawn = (Rigidbody2D)Instantiate(myBullet, transform.position, Quaternion.Euler(new Vector3(0,0,0))) as Rigidbody2D;

    }

    public Vector3 getShootDirection()
    {
        return shootDirection;
    }

    private void ChangeObject()
    {
        //fix this shit
        if (myCountdown.GetTimeLeft() <= 0 && done)
        {
            //checks to see if list is empty
            if (myBulletType.Count <= 1)
            {
                //moves all deleted bullets back to original list
                for(int i = 0; i < myBulletTypeDeleted.Count; i++)
                {
                    myBulletType.Add(myBulletTypeDeleted[i]);
                    myBulletTypeDeleted.RemoveAt(i);
                    i--;
                }
            }
            else
            {
                myBulletTypeDeleted.Add(myBullet);
                myBulletType.Remove(myBullet);
            }
            random = Random.Range(0, myBulletType.Count);
            myBullet = myBulletType[random];
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
        return oldDirection;
    }


    public void SetDone(bool mybool)
    {
        done = mybool;
    }

}
