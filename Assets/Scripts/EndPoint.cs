using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPoint : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Jill") CompleteLevel();
    }

    public void CompleteLevel()
    {
        //Audio
        GetComponent<AudioSource>().Play();
        UI.instance.levelCompleteMenu.SetActive(true);
        Time.timeScale = 0;
    }
}
