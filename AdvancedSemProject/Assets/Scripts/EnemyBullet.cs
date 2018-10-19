using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {

    [SerializeField] float speed = 10;
    Rigidbody2D rb;

    Transform target;
    Vector2 move;

    

    // Use this for initialization
    void Start()
    {
        //Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), GameObject.FindGameObjectWithTag("Well").GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), GameObject.FindGameObjectWithTag("Enemy").GetComponent<Collider2D>());
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        Movement();
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player" || col.tag == "Wall")
            Destroy(this.gameObject);
    }


    private void Movement()
    {
        move = (target.position - transform.position).normalized * speed;
        gameObject.GetComponent<Rigidbody2D>().velocity = move * speed;


    }
}
