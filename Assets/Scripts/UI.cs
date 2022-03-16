using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public static UI instance;

    public GameObject pauseMenu;
    public GameObject levelCompleteMenu;
    public GameObject gameOverMenu;

    public Text livesLeft;
    public Text coinsCollected;

    [Header("Final Tally Variables")]
    public Text livesLost;
    public Text finalCoinsCollected;

    private void Start()
    {
        instance = this;

        pauseMenu.SetActive(false);
        levelCompleteMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        Time.timeScale = 1;
    }

    private void Update()
    {
        livesLeft.text = "X" + GameManager.instance.livesLeft.ToString("000");
        coinsCollected.text = "X" + GameManager.instance.coinsCollected.ToString("00");

        //final tally
        livesLost.text = "X" + (GameManager.instance.startingLives - GameManager.instance.livesLeft).ToString("000");
        finalCoinsCollected.text = "X" + GameManager.instance.coinsCollected.ToString("00");

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }


    public void Continue()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
    public void ReturnToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    public void Retry()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void NextLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
