using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public Vector3 direction;
    public GameObject rayOrigin;
    public GameObject sprite;

    private void Start()
    {
        direction = Vector3.right;
    }


    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(rayOrigin.transform.position, direction);
        if (hit.collider != null)
        {
            float distance = Vector2.Distance(hit.point, gameObject.transform.position);
            if (distance <= 1 && hit.collider.gameObject.tag != "Player") 
            {
                Flip();
            }

        }
        transform.position += direction * speed * Time.deltaTime;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerController>().Death();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GetComponent<AudioSource>().Play();

            sprite.GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<Rigidbody2D>().gravityScale = 0;
        }
    }

    void Flip()
    {
        direction = -direction;
        transform.localScale = new Vector3(-transform.localScale.x, 1, 1);
    }
}
