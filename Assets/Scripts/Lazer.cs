using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazer : MonoBehaviour
{
    public enum directions
    {
        right,
        left,
        up,
        down
    }
    [Header("Settings")]
    public bool alternating = false;
    public directions facing;
    Vector2 direction;
    [Range(0.5f, 5f)]public float altTime;

    [Header("Details")]
    public Vector2 hitPoint;
    public LineRenderer lr;


    float count;
    private void Start()
    {
        count = altTime;
        if(facing == directions.right)
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
        if (alternating)
        {
            count += 1 * Time.deltaTime;
            if(count >= altTime)
            {
                FireLazer();
            }
            if(count >= (altTime * 2))
            {
                count = 0;
                lr.enabled = false;
                //Audio
                GetComponent<AudioSource>().Pause();
            }
        }
        else
        {
            FireLazer();
        }

    }

    public void FireLazer()
    {
        lr.enabled = true;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction);
        if(hit.collider != null)
        {
            hitPoint = hit.point;
            if(hit.collider.gameObject.tag == "Player")
            {
                hit.collider.gameObject.GetComponent<PlayerController>().Death();
            }

            lr.SetPosition(0, transform.position);
            lr.SetPosition(1, hitPoint);
            //Debug.DrawLine(transform.position, hitPoint);
        }
        //Audio
        GetComponent<AudioSource>().UnPause();
    }


}
