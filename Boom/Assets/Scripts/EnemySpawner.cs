using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Reference to the regular enemy prefab
    public GameObject teleportOnlyEnemyPrefab; // Reference to the teleportonly enemy prefab
    public int numberOfEnemiesToSpawn = 3; // Total number of enemies to spawn
    public float spawnInterval = 10f; // Time interval between spawns

    private float timer = 0f;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnEnemies();
            timer = 0f; // Reset the timer
        }
    }

    private void SpawnEnemies()
    {
        for (int i = 0; i < numberOfEnemiesToSpawn; i++)
        {
            Vector3 randomPosition = GetRandomSpawnPosition();
            // Decide whether to spawn a regular enemy or a teleport-only enemy
            GameObject enemyToSpawn = ChooseEnemyToSpawn();
            Instantiate(enemyToSpawn, randomPosition, Quaternion.identity);
        }
    }

    private GameObject ChooseEnemyToSpawn()
    {
        //30% chance to spawn a teleport-only enemy
        float chance = Random.Range(0f, 1f);
        if (chance <= 0.3f)
        {
            return teleportOnlyEnemyPrefab;
        }
        else
        {
            return enemyPrefab;
        }
    }

    private Vector3 GetRandomSpawnPosition()
    {
        float spawnX = Random.Range(-10f, 10f); 
        float spawnY = Random.Range(-10f, 10f);
        return new Vector3(spawnX, spawnY, 0f);
    }
}
