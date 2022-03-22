using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    [SerializeField] private GameObject mainMenuUI;
    [SerializeField] private GameObject tutorialUI;
    [SerializeField] private GameObject selectUI;

    private void Awake()
    {
        mainMenuUI.SetActive(true);
        tutorialUI.SetActive(false);
        selectUI.SetActive(false);
    }

    public void PlayGame()
    {
        mainMenuUI.SetActive(false);
        tutorialUI.SetActive(false);
        selectUI.SetActive(true);
    }

    public void Tutorial()
    {
        mainMenuUI.SetActive(false);
        tutorialUI.SetActive(true);
        selectUI.SetActive(false);
    }

    public void Back()
    {
        mainMenuUI.SetActive(true);
        tutorialUI.SetActive(false);
        selectUI.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Load1()
    {
        SceneManager.LoadScene(1);
    }
    public void Load2()
    {
        SceneManager.LoadScene(2);
    }
    public void Load3()
    {
        SceneManager.LoadScene(3);
    }
}
