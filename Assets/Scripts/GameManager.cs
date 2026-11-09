using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text gameOverText;
    [SerializeField] float secondsCooldown;

    private int score;
    private bool canSpawnEnemy = true;
    private bool isGameOver = false;

    void Start()
    {
        score = 0;
        scoreText.text = "Score: " + score;
    }

    void FixedUpdate()
    {
        if (!isGameOver)
        {
            scoreText.text = "Score: " + score;

            if (canSpawnEnemy)
            {
                GameObject newEnemy = Instantiate(enemyPrefab);
                newEnemy.GetComponent<EnemyScript>().AssignManager(gameObject);
                newEnemy.transform.position = new Vector3(Random.Range(-7f, 7f), 11, 0);

                StartCoroutine(EnemySpawn());
            }
        }
    }

    IEnumerator EnemySpawn()
    {
        canSpawnEnemy = false;
        yield return new WaitForSeconds(secondsCooldown);
        canSpawnEnemy = true;
    }

    public void GameOver()
    {
        isGameOver = true;
        gameOverText.enabled = true;
    }

    public bool IsGameOver()
    {
        return isGameOver;
    }
}
