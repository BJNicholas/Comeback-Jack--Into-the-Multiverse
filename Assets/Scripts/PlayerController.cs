using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject characterModel;


    public float speed;
    public float jumpHeight;
    public bool grounded = false;

    Vector2 inputs;
    Rigidbody2D rb;
    int layerMaskID;

    private void Start()
    {
        layerMaskID = LayerMask.GetMask("Ground");
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        inputs.x = Input.GetAxis("Horizontal");
        inputs.y = Input.GetAxis("Jump");

        //sprite rotation check
        if (inputs.x != 0)
        {
            //right
            if (inputs.x > 0)
            {
                characterModel.transform.localScale = new Vector3(1, 1, 1);
            }
            //left
            if (inputs.x < 0)
            {
                characterModel.transform.localScale = new Vector3(-1, 1, 1);
            }

            if (grounded)
            {
                //animation
                characterModel.GetComponent<Animator>().Play("Player-Run");
            }
        }
        else
        {
            if (grounded)
            {
                //animation
                characterModel.GetComponent<Animator>().Play("Player-Idle");
            }
        }

        //ground check + jumping
        if (grounded && inputs.y > 0)
        {
            grounded = false;
            rb.AddForce(Vector2.up * inputs.y * (jumpHeight * 100));

            //animation
            characterModel.GetComponent<Animator>().Play("Player-Jump");
            //Audio
            GetComponent<AudioSource>().Play();
        }
        if(grounded == false)
        {
            //animation
            characterModel.GetComponent<Animator>().Play("Player-Jump");

            Invoke("SecondaryGroundCheck", 0.1f);
        }

    }

    public void SecondaryGroundCheck()
    {
        if(grounded == false)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.6f, layerMaskID);
            Debug.DrawRay(transform.position, Vector2.down, Color.red);
            if (hit.collider != null)
            {
                float distance = Vector2.Distance(hit.point, gameObject.transform.position);
                if (distance <= 0.6f && hit.collider.gameObject.tag == "Mid")
                {
                    grounded = true;
                    print("RAY CASTED");
                }

            }
        }
    }

    private void FixedUpdate()
    {
        transform.position += new Vector3(inputs.x * speed * Time.deltaTime, 0, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Mid")
        {
            grounded = true;
        }
    }

    public void Death()
    {
        GameObject body = Instantiate(GameManager.instance.deadCharacter, transform.position, Quaternion.identity);
        GameManager.instance.livesLeft -= 1;
        GameManager.instance.Respawn();
        Destroy(gameObject);
        SavedAudio.instance.FindEffetsObjects();
    }
}
