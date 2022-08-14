using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseUI : MonoBehaviour
{
    public bool isGamePaused;
    [SerializeField] GameObject pauseMenu;
    GameManager gameManager;

    void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && gameManager.isGameActive)
        {
            if (isGamePaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        isGamePaused = false;
    }

    void PauseGame()
    {
        pauseMenu.SetActive(true);
        isGamePaused = true;
    }

    public void QuitGame()
    {
        SceneManager.LoadScene(0);
    }
}
