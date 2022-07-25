using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class GameOverUI : MonoBehaviour
{
    ScoreManager scoreManager;
    [SerializeField] TextMeshProUGUI scoreText;

    void Awake()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    void Start()
    {
        if (scoreManager.score <= 0)
        {
            scoreText.text = "You scored a value that's not even worth mentioning...";
        }
        else
        {
            scoreText.text = "You scored: " + scoreManager.score;
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
