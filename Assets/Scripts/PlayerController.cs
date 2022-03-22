using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject characterModel; //jack
    public GameObject character2Model; //jill

    public Transform activePos;
    public Transform inactivePos;

    public float speed;
    public float jumpHeight;
    public bool grounded = false;

    Vector2 inputs;
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        inputs.x = Input.GetAxis("Horizontal");
        inputs.y = Input.GetAxis("Jump");

        //sprite rotation check
        if(inputs.x != 0)
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
                characterModel.GetComponent<Animator>().Play("Jill-Run");
            }
        }
        else
        {
            if (grounded)
            {
                //animation
                characterModel.GetComponent<Animator>().Play("Player-Idle");
                characterModel.GetComponent<Animator>().Play("Jill-Idle");
            }
        }

        //ground check + jumping
        if (grounded && inputs.y > 0)
        {
            grounded = false;
            rb.AddForce(Vector2.up * inputs.y * (jumpHeight * 100));

            //animation
            characterModel.GetComponent<Animator>().Play("Player-Jump");
            characterModel.GetComponent<Animator>().Play("Jill-Jump");
            //Audio
            GetComponent<AudioSource>().Play();
        }
        if(grounded == false)
        {
            //animation
            characterModel.GetComponent<Animator>().Play("Player-Jump");
            characterModel.GetComponent<Animator>().Play("Jill-Jump");
        }

        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Return))
        {
            //changing character
            if (character2Model.activeInHierarchy == true)
            {

                EnableJack();
            }
            else if (characterModel.activeInHierarchy == true)
            {

                EnableJill();
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
    }

    public void EnableJill()
    {           
        if (!character2Model.activeInHierarchy)
        {
            characterModel.SetActive(false);
            character2Model.SetActive(true);

            character2Model.transform.position = activePos.position;
        }

    }

    public void EnableJack()
    {
        if (!characterModel.activeInHierarchy)
        {
            //transform.GetChild(1).gameObject.SetActive(false);
            //transform.GetChild(0).gameObject.SetActive(true);

            characterModel.SetActive(true);
            character2Model.SetActive(false);

            characterModel.transform.position = inactivePos.position;
        }
       

    }
}
