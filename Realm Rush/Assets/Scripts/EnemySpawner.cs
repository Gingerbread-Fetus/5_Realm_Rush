using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float secondsBetweenSpawns = 3f;
    [SerializeField] EnemyMovement enemyPrefab;
    [SerializeField] Text playerScoreText;
    [SerializeField] int scorePerSpawn = 10;
    [SerializeField] AudioClip spawnedEnemySFX;

    int playerScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RepeatedlySpawnEnemies());
        playerScoreText.text = playerScore.ToString();
    }

    IEnumerator RepeatedlySpawnEnemies()
    {
        while (true) //Do forever
        {
            AddScore();
            GetComponent<AudioSource>().PlayOneShot(spawnedEnemySFX);
            var newEnemy = Instantiate(enemyPrefab, this.transform.position, Quaternion.identity);
            newEnemy.transform.parent = transform;
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }

    private void AddScore()
    {
        playerScore += scorePerSpawn;
        playerScoreText.text = playerScore.ToString();
    }
}
