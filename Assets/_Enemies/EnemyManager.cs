using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance;


    public List <EnemyData> enemyTypes;
    public List <Enemy> spawnedEnemies;
    public List <Transform> spawnPoints;

    public float spawnDelay = 1f;
    public float spawnRadius = 1f;
    public int maxEnemies = 10;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (spawnedEnemies.Count < maxEnemies)
        {
            int randomIndex = Random.Range(0, enemyTypes.Count);
            int randomSpawnPoint = Random.Range(0, spawnPoints.Count);

            float randomX = Random.Range(-spawnRadius, spawnRadius);
            float randomZ = Random.Range(-spawnRadius, spawnRadius);

            Vector3 randomPosition = new Vector3(randomX, 0, randomZ) + spawnPoints[randomSpawnPoint].position;

            GameObject enemy = Instantiate(enemyTypes[randomIndex].Prefab, 
            randomPosition, 
            Quaternion.identity, parent: spawnPoints[randomSpawnPoint]);
            
            spawnedEnemies.Add(enemy.GetComponent<Enemy>());
            yield return new WaitForSeconds(spawnDelay);
        }
    }

    public static void RestartEnemy(Enemy enemy)
    {
        int randomSpawnPoint = Random.Range(0, Instance.spawnPoints.Count);

        float randomX = Random.Range(-Instance.spawnRadius, Instance.spawnRadius);
        float randomZ = Random.Range(-Instance.spawnRadius, Instance.spawnRadius);

        Vector3 randomPosition = new Vector3(randomX, 0, randomZ) + Instance.spawnPoints[randomSpawnPoint].position;

        enemy.transform.position = randomPosition;
        enemy.Health = enemy.data.MaxHealth;
    }
}
