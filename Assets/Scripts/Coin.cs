using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public SpriteRenderer sr;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" || collision.gameObject.tag == "Jill")
        {
            GameManager.instance.coinsCollected += 1;
            //play sound
            //Audio
            GetComponent<AudioSource>().Play();
            sr.enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
