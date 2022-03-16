using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            print("CheckPoint Reached");
            GameManager.instance.respawnPoint = gameObject.transform;
            //Audio
            GetComponent<AudioSource>().Play();
        }
    }
}
