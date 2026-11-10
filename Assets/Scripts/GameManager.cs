using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject bossPrefab;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text gameOverText;
    [SerializeField] private GameObject scoreGameObject;
    [SerializeField] private GameObject gameOverGameObject;
    [SerializeField] float secondsCooldown;

    private int score;
    private int enemiesHit = 0;
    private bool canSpawnEnemy = true;
    private bool bossActive = false;
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

            if (canSpawnEnemy && !bossActive)
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

    private void SpawnBoss()
    {
        GameObject newEnemy = Instantiate(bossPrefab);
        newEnemy.GetComponent<BossScript>().AssignManager(gameObject);
        newEnemy.transform.position = new Vector3(0, 10, 0);
    }

    public void HitEnemy()
    {
        score += 100;
        enemiesHit++;
        if (enemiesHit == 10)
        {
            enemiesHit = 0;
            bossActive = true;
            SpawnBoss();
        }
    }

    public void DestroyBoss()
    {
        score += 1000;
        bossActive = false;
    }

    public void GameOver()
    {
        isGameOver = true;
        gameOverText.text = "GAME OVER\n SCORE: " + score;
        Debug.Log("Game over");
        scoreGameObject.SetActive(false);
        gameOverGameObject.SetActive(true);
    }

    public bool IsGameOver()
    {
        return isGameOver;
    }
}
