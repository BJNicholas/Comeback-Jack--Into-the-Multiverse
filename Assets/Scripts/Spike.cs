using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    public enum directions
    {
        right,
        left,
        up,
        down
    }
    [Header("Settings")]
    public directions facing;
    Vector2 direction;
    public float speed;
    [Range(0.5f, 5f)] public float altTime;
    public Transform raycastOrigin;
    public Vector2 hitPoint;
    Vector2 originPoint;

    float count;
    private void Start()
    {
        originPoint = transform.position;
        hitPoint = originPoint;
        count = altTime;
        if (facing == directions.right)
        {
            direction = transform.right;
        }
        else if (facing == directions.left)
        {
            direction = -transform.right;
        }
        else if (facing == directions.up)
        {
            direction = transform.up;
        }
        else if (facing == directions.down)
        {
            direction = -transform.up;
        }
    }

    private void Update()
    {
        transform.position = Vector2.Lerp(transform.position, hitPoint, speed * Time.deltaTime);
        Debug.DrawLine(transform.position, hitPoint);
        count += 1 * Time.deltaTime;
        if (count >= altTime)
        {
            ChangeTarget();
        }
        if (count >= (altTime * 2))
        {
            count = 0;
            hitPoint = originPoint;
        }
    }
    public void ChangeTarget()
    {
        RaycastHit2D hit = Physics2D.Raycast(raycastOrigin.position, direction);
        if (hit.collider != null)
        {
            hitPoint = hit.point;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        hitPoint = transform.position;
        transform.position = hitPoint;
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerController>().Death();
        }
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
        }
    }

}
