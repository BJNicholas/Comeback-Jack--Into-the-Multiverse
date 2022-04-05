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

    public float respawnDelay;

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
            StartCoroutine(RespawnCoroutine());
        }
        else
        {
            print("GAME OVER");
            UI.instance.gameOverMenu.SetActive(true);
            Time.timeScale = 0;
            Camera.main.GetComponent<CameraController>().target = respawnPoint.transform;
        }
    }

    public IEnumerator RespawnCoroutine()
    {
        /*solution 1 = speed
        GameObject newPlayer = Instantiate(characterPrefab, respawnPoint.position, Quaternion.identity);
        Camera.main.GetComponent<CameraController>().target = newPlayer.transform;
        newPlayer.GetComponent<PlayerController>().speed = 0;

        yield return new WaitForSeconds(respawnDelay);

        newPlayer.GetComponent<PlayerController>().speed = 10;
        */
        GameObject newPlayer = Instantiate(characterPrefab, respawnPoint.position, Quaternion.identity);
        Camera.main.GetComponent<CameraController>().target = newPlayer.transform;
        newPlayer.GetComponent<PlayerController>().characterModel.GetComponent<Animator>().Play("Player-Respawn");
        newPlayer.GetComponent<PlayerController>().enabled = false;

        yield return new WaitForSeconds(respawnDelay);

        newPlayer.GetComponent<PlayerController>().enabled = true;
    }

    

}
