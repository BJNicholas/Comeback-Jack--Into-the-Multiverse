using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float chaseSpeed;


    private void FixedUpdate()
    {
        transform.position = Vector2.Lerp(transform.position, target.position, chaseSpeed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, transform.position.y, -10);
    }
}
