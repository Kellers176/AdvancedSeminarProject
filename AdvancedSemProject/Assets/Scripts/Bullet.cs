using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float speed = 50f;
    public float[] SpreadRange = { 10, 8, 6, 4, 2, 0, -2, -4, -6, -8, -10 };


    ProjectileManager myProjectile;

    // Use this for initialization
    void Start () {
		Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>());
        myProjectile = GameObject.FindGameObjectWithTag("SpawnManager").GetComponent<ProjectileManager>();
        float RandomRange = SpreadRange[Random.Range(0, SpreadRange.Length)];
        gameObject.GetComponent<Rigidbody2D>().velocity = myProjectile.getDirection() * speed;
        if (myProjectile.getDirection() == Vector3.right)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(speed, RandomRange));
        }
        if (myProjectile.getDirection() == Vector3.left)
        {

            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-speed, RandomRange));
        }
        if (myProjectile.getDirection() == Vector3.up)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(RandomRange, speed));
        }
        if (myProjectile.getDirection() == Vector3.down)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(RandomRange, -speed));
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnCollisionEnter2D(Collision2D col)
    { 
        Destroy(this.gameObject);
    }
}
