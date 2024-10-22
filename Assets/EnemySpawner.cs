using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Assign your enemy prefab here in the Inspector
    public float spawnTime = 2f; // Time interval between enemy spawns
    public float spawnRangeX = 8f; // Horizontal spawn range
    public float spawnHeight = 10f; // Height from which enemies drop

    void Start()
    {
        InvokeRepeating("SpawnEnemy", spawnTime, spawnTime); // Call SpawnEnemy repeatedly
    }

    void SpawnEnemy()
    {
        // Choose a random spawn position above the player
        Vector3 spawnPosition = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), spawnHeight, 0);
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity); // Instantiate enemy at spawn position
    }
}
