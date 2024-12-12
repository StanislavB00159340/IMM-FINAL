using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab; // The enemy prefab to spawn
    public Transform[] spawnMarkers; // Array of markers where enemies can spawn
    public float spawnInterval = 5f; // Time interval between spawns
    public int maxEnemies = 10; // Maximum number of enemies allowed on the map

    private int currentEnemyCount = 0; // Track the number of enemies currently on the map
    private float spawnTimer = 0f; // Timer to manage spawn intervals

    void Update()
    {
        // Increment the spawn timer
        spawnTimer += Time.deltaTime;

        // Check if it's time to spawn a new enemy
        if (spawnTimer >= spawnInterval && currentEnemyCount < maxEnemies)
        {
            SpawnEnemy();
            spawnTimer = 0f; // Reset the spawn timer
        }
    }

    void SpawnEnemy()
    {
        if (enemyPrefab == null || spawnMarkers.Length == 0)
        {
            Debug.LogWarning("Enemy prefab or spawn markers are not set!");
            return;
        }

        // Randomly select a spawn marker
        Transform selectedMarker = spawnMarkers[Random.Range(0, spawnMarkers.Length)];

        // Instantiate the enemy at the selected marker's position and rotation
        Instantiate(enemyPrefab, selectedMarker.position, selectedMarker.rotation);

        // Increment the current enemy count
        currentEnemyCount++;
    }

    // Call this method when an enemy is destroyed
    public void OnEnemyDestroyed()
    {
        currentEnemyCount--;
        if (currentEnemyCount < 0)
        {
            currentEnemyCount = 0; // Ensure enemy count doesn't go below zero
        }
    }
}
