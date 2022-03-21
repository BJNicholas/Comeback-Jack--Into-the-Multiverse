using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    [SerializeField] private GameObject mainMenuUI;
    [SerializeField] private GameObject tutorialUI;

    private void Awake()
    {
        mainMenuUI.SetActive(true);
        tutorialUI.SetActive(false);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Tutorial()
    {
        mainMenuUI.SetActive(false);
        tutorialUI.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
