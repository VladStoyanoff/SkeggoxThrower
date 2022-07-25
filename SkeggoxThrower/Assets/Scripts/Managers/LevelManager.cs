using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [Header("Singleton")]
    static LevelManager instance;

    [Header("Booleans")]
    public bool isMultiplayer;
    public bool isEasy;
    public bool isMedium;
    public bool isHard;

    [Header("Difficulty Variables")]
    public int easyDifficulty = 1;
    public int mediumDifficulty = 3;
    public int hardDifficulty = 5;

    [Header("Scripts")]
    GameManager gameManager;

    void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void Start()
    {
        isMedium = true;
        ManageSingleton();
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

    public void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void MultiplayerBoolActivate()
    {
        isMultiplayer = true;
    }

    public void MultiplayerBoolDeactivate()
    {
        isMultiplayer = false;
    }

    public int GetEasyDifficultyVariable()
    {
        return easyDifficulty;
    }

    public int GetMediumDifficultyVariable()
    {
        return mediumDifficulty;
    }

    public int GetHardDifficultyVariable()
    {
        return hardDifficulty;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        SceneManager.LoadScene(2);
    }
}
