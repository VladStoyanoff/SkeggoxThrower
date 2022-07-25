using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Collision : MonoBehaviour
{
    [Header("SFX & VFX")]
    [SerializeField] AudioClip crashSound;

    [Header("Scripts")]
    ScoreManager scoreManager;
    LevelManager levelManager;

    [Header("Game Objects")]
    [SerializeField] GameObject powerupIndicator;

    [Header("UI")]
    public Slider slider;

    [Header("Variables")]
    int scoreGained = 50;
    int scoreLost = -100;
    int PlayerHP = 3;

    [Header("Booleans")]
    public bool hasPowerUp;

    void Awake()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        levelManager = FindObjectOfType<LevelManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (gameObject.tag == "Player")
        {
            if (other.gameObject.tag == "Powerup")
            {
                Destroy(other.gameObject);
                PowerupCollision();
            }
            else if (other.gameObject.tag == "Enemy")
            {
                EnemyCollision();
            }
        }
        else if (gameObject.tag == "Axe")
        {
            if (other.gameObject.tag != "Enemy") return;
            Destroy(other.gameObject);
            ProjectileCollision();
        }
    }

    void PowerupCollision()
    {
        hasPowerUp = true;
        powerupIndicator.gameObject.SetActive(true);
        StartCoroutine(PowerupCountdownRoutine());
    }

    void EnemyCollision()
    {
        PlayCollisionClip();
        scoreManager.UpdateScore(scoreLost);
        PlayerHP--;
        slider.value = PlayerHP;
        if (PlayerHP < 1)
        {
            Destroy(gameObject);
            levelManager.GameOver();
        }
    }

    void ProjectileCollision()
    {
        scoreManager.UpdateScore(scoreGained);
        Destroy(gameObject);
    }

    void PlayCollisionClip()
    {
        Vector3 cameraPos = Camera.main.transform.position;
        AudioSource.PlayClipAtPoint(crashSound, cameraPos);
    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerUp = false;
        powerupIndicator.gameObject.SetActive(false);
    }
}