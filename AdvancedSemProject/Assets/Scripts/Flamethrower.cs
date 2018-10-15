using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flamethrower : MonoBehaviour {
    [SerializeField] float speed;
    GameObject spawn;
    Vector3 newPosition;
    ProjectileManager myProjectile;
    float[] SpreadRange = { 10, 8, 6, 4, 2, 0, -2, -4, -6, -8, -10 };
    float lifetime = 0.0f;
    private Renderer rend;
    // Use this for initialization
    void Start()
    {
        Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>());
        Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), GameObject.FindGameObjectWithTag("FlameThrower").GetComponent<Collider2D>());
        //Physics2D.IgnoreCollision(gameObject.GetComponent<Collider2D>(), GameObject.FindGameObjectWithTag("Well").GetComponent<Collider2D>());
        myProjectile = GameObject.FindGameObjectWithTag("SpawnManager").GetComponent<ProjectileManager>();
        rend = GetComponent<Renderer>();
        rend.material.color = Color.white;
        Movement();
    }

    // Update is called once per frame
    private void Update()
    {
        //this.transform.localScale *= Time.deltaTime;

        if (transform.localScale.x <= 5.0 && transform.localScale.x <= 5.0)
        {
            transform.localScale += new Vector3(0.1f, 0.1f, 0);
        }
        lifetime += Time.deltaTime;
        ChangeColor();
        if (lifetime > 1.0)
        {
            Destroy(this.gameObject);
        }
    }

    private void ChangeColor()
    {
        if (lifetime > 0.01f)
        {
            rend.material.color = Color.blue;
        }
        if (lifetime > 0.1f)
        {
            rend.material.color = Color.yellow;
        }
        if (lifetime > 0.5f)
        {
            rend.material.color = Color.red;
        }
        if (lifetime > 0.8f)
        {
            rend.material.color = Color.gray;
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(this.gameObject);
    }

    private void Movement()
    {
        Vector2 direction = new Vector2(myProjectile.getShootDirection().x, myProjectile.getShootDirection().y);
        direction.Normalize();
        gameObject.GetComponent<Rigidbody2D>().velocity = direction * speed;
        float RandomRange = SpreadRange[Random.Range(0, SpreadRange.Length)];
        if (gameObject.transform.position == Vector3.right)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(speed, RandomRange));
        }
        if (gameObject.transform.position == Vector3.left)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-speed, RandomRange));
        }
        if (gameObject.transform.position == Vector3.up)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(RandomRange, speed));
        }
        if (gameObject.transform.position == Vector3.down)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(RandomRange, -speed));
        }
    }
}
