using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Singleton")]
    GameManager instance;

    [Header("Booleans")]
    public bool isGameActive;

    [Header("Prefabs")]
    [SerializeField] GameObject playerOne;
    [SerializeField] GameObject playerTwo;

    [Header("Scripts")]
    PlayerController playerControllerScriptOne;
    PlayerController playerControllerScriptTwo;
    LevelManager levelManager;

    void Awake()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }
    void Start()
    {
        ManageSingleton();
        ManageMultiplayer();
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

    void ManageMultiplayer()
    {
        InitializePlayerOne();

        if (levelManager.isMultiplayer)
        {
           InitializePlayerTwo();
        }
    }

    void InitializePlayerOne()
    {
        playerOne.gameObject.SetActive(true);
        playerControllerScriptOne = GameObject.Find("PlayerOne").GetComponent<PlayerController>();
        StartCoroutine(playerControllerScriptOne.PlayIntro());
    }

    void InitializePlayerTwo()
    {
        playerTwo.gameObject.SetActive(true);
        playerControllerScriptTwo = GameObject.Find("PlayerTwo").GetComponent<PlayerController>();
        StartCoroutine(playerControllerScriptTwo.PlayIntro());
    }
}
