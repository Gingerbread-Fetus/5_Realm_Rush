using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float secondsBetweenSpawns = 3f;
    [SerializeField] EnemyMovement enemyPrefab;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RepeatedlySpawnEnemies());
    }

    IEnumerator RepeatedlySpawnEnemies()
    {
        while (true) //Do forever
        {
            Instantiate(enemyPrefab, this.transform);
            yield return new WaitForSeconds(secondsBetweenSpawns); 
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
