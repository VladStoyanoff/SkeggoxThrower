using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{

    [Header("Singleton")]
    static ScoreManager instance;

    [Header("Variables")]
    public int score;

    [Header("UI")]
    public TextMeshProUGUI scoreText;

    [Header("Scripts")]
    GameManager gameManager;
    PauseUI pauseUI;

    void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        pauseUI = FindObjectOfType<PauseUI>();
    }

    void Start()
    {
        ManageSingleton();
        if (gameManager.isGameActive)
        {
            UpdateScore(0);
        }
    }

    void Update()
    {
        if (gameManager.isGameActive && !pauseUI.isGamePaused)
        {
            scoreText.text = score.ToString("000000000");
        }
    }

    void ManageSingleton()
    {
        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
    }
}

