using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Bounds")]
    float spawnRangeX = 14.5f;
    float spawnRangeY = 0;
    float spawnRangeZ = 10;

    [Header("Variables")]
    public float spawnRate;

    [Header("Enemies")]
    public GameObject[] targets;

    [Header("Scripts")]
    LevelManager levelManager;
    GameManager gameManager;

    void Awake()
    {
        levelManager = FindObjectOfType<LevelManager>();
        gameManager = FindObjectOfType<GameManager>();
    }

    void Start()
    {
       StartCoroutine(SpawnEnemy());
       if (levelManager.isEasy)
        {
            spawnRate /= levelManager.GetEasyDifficultyVariable();
        }
       else if (levelManager.isMedium)
        {
            spawnRate /= levelManager.GetMediumDifficultyVariable();
        }
       else
        {
            spawnRate /= levelManager.GetHardDifficultyVariable();
        }
    }

    IEnumerator SpawnEnemy()
    {
        while (gameManager.isGameActive)
        {
            int index = Random.Range(0, targets.Length);

            Instantiate(targets[index], 
                        new Vector3(Random.Range(-spawnRangeX, spawnRangeX), spawnRangeY, spawnRangeZ),
                        Quaternion.Euler(0, 180, 0));
            yield return new WaitForSeconds(spawnRate);
        }
    }
}
