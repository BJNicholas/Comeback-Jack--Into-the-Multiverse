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
    public GameObject jillPrefab;
    public GameObject deadCharacter;

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
            GameObject newJill = Instantiate(jillPrefab, respawnPoint.position, Quaternion.identity);
            newJill.SetActive(false);
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

    

}
