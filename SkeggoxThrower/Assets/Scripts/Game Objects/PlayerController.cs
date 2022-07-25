using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Variables

    [Header("Inputs")]
    float horizontalInputOne;
    float horizontalInputTwo;

    [Header("Prefabs")]
    [SerializeField] GameObject playerOne;
    [SerializeField] GameObject playerTwo;
    public GameObject projectilePrefab;

    [Header("Game Objects")]
    [SerializeField] GameObject enemySpawner;
    [SerializeField] GameObject groundEnvironment;

    [Header("Variables")]
    [SerializeField] float speed;
    float xRange = 17f;
    float lerpSpeed = 5;

    [Header("Scripts")]
    LevelManager levelManager;
    GameManager gameManager;
    Collision targetOne;
    Collision targetTwo;


    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
        gameManager = FindObjectOfType<GameManager>();
        targetOne = GameObject.Find("PlayerOne").GetComponent<Collision>();
        targetTwo = GameObject.Find("PlayerTwo").GetComponent<Collision>();
    }

    void Update()
    {
        RestrictMovement();
        PlayerMovement();
        LaunchProjectile();
    }

    void RestrictMovement()
    {
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
    }

    void PlayerMovement()
    {
        horizontalInputOne = Input.GetAxis("HorizontalOne");
        playerOne.transform.Translate(Vector3.right * speed * Time.deltaTime * horizontalInputOne);

        if (levelManager.isMultiplayer)
        {
            horizontalInputTwo = Input.GetAxis("HorizontalTwo");
            playerTwo.transform.Translate(Vector3.right * speed * Time.deltaTime * horizontalInputTwo);
        }
    }

    void LaunchProjectile()
    {
        if (gameObject.name == "PlayerOne" && targetOne.hasPowerUp)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(projectilePrefab, transform.position + new Vector3(0, 1, 0), transform.rotation);
            }
        }
        else if (gameObject.name == "PlayerTwo" && targetTwo.hasPowerUp)
        {
            if (Input.GetKeyDown(KeyCode.RightControl))
            {
                Instantiate(projectilePrefab, transform.position + new Vector3(0, 1, 0), transform.rotation);
            }
        }
    }

    public IEnumerator PlayIntro()
    {
        Vector3 startPos = transform.position;
        Vector3 endPos = startPos + new Vector3(0, 0, 5);
        float journeyLength = Vector3.Distance(startPos, endPos);
        float startTime = Time.time;

        float distanceCovered = (Time.time - startTime) * lerpSpeed;
        float fractionOfJourney = distanceCovered / journeyLength;

        while (fractionOfJourney < 1)
        {
            distanceCovered = (Time.time - startTime) * lerpSpeed;
            fractionOfJourney = distanceCovered / journeyLength;
            transform.position = Vector3.Lerp(startPos, endPos, fractionOfJourney);
            yield return null;
        }
        gameManager.isGameActive = true;
        groundEnvironment.GetComponent<MoveForward>().enabled = true;
        enemySpawner.SetActive(true);
    }
}
