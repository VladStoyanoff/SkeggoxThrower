using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyUI : MonoBehaviour
{
    [Header("Interactables & Scripts")]
    LevelManager levelManager;

    void Awake()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }

    public void EasyDifficulty()
    {
        levelManager.isEasy = true;
        levelManager.isMedium = levelManager.isHard = false;
        
    }

    public void MediumDifficulty()
    {
        levelManager.isEasy = levelManager.isHard = false;
        levelManager.isMedium = true;
        
    }

    public void HardDifficulty()
    {
        levelManager.isEasy = levelManager.isMedium = false;
        levelManager.isHard = true;
    }
}
