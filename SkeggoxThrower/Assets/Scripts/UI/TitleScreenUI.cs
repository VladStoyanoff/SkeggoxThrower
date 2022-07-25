using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class TitleScreenUI : MonoBehaviour
{
    [SerializeField] GameObject optionsPanel;
    [SerializeField] GameObject titleScreen;

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void OptionsMenu()
    {
        optionsPanel.SetActive(true);
        titleScreen.SetActive(false);
    }

    public void ExitOptionsMenu()
    {
        titleScreen.SetActive(true);
        optionsPanel.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

