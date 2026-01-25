using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Enemy enemyPrefab;
    public Path path;

    public float spawnInterval = 1.5f;

    float spawnTimer;

    void Update()
    {
        if (enemyPrefab == null || path == null)
            return;

        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnInterval)
        {
            SpawnEnemy();
            spawnTimer = 0f;
        }
    }

    void SpawnEnemy()
    {
        Enemy enemy = Instantiate(enemyPrefab);
        enemy.path = path;
    }
}
