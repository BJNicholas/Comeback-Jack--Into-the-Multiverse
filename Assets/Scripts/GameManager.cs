using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public float startingLives;
    public float livesLeft;

    public float coinsCollected;

    public GameObject characterPrefab;
    public GameObject deadCharacter;

    public GameObject characterModel; //jack
    public GameObject jillModel; //jill

    [Header("Level Details")]
    public Transform respawnPoint;


    private void Start()
    {
        instance = this;
        livesLeft = startingLives;
    }

    public void Respawn()
    {
        if(livesLeft > 0)
        {
            GameObject newPlayer = Instantiate(characterPrefab, respawnPoint.position, Quaternion.identity);

            //changing character
            if (jillModel.activeInHierarchy)
            {
                EnableJack();
            }
            else if (characterModel.activeInHierarchy)
            {
                EnableJill();
            }

            Camera.main.GetComponent<CameraController>().target = newPlayer.transform;
        }
        else
        {
            print("GAME OVER");
            UI.instance.gameOverMenu.SetActive(true);
            Time.timeScale = 0;
            Camera.main.GetComponent<CameraController>().target = respawnPoint.transform;
        }
    }

    public void EnableJill()
    {
        if (!jillModel.activeInHierarchy)
        {
            jillModel.SetActive(true);
            characterModel.SetActive(false);
        }

    }

    public void EnableJack()
    {
        if (!characterModel.activeInHierarchy)
        {
            characterModel.SetActive(true);
            jillModel.SetActive(false);
        }

    }

}
