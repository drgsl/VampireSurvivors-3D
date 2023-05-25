using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance;


    public List <EnemyData> enemyTypes;
    public List <Enemy> spawnedEnemies;
    public List <Transform> spawnPoints;

    public float spawnRadius = 1f;

    private void Awake()
    {
        Instance = this;

        foreach (Transform child in transform)
        {
            spawnPoints.Add(child);
        }
    }

    public static void SpawnEnemy()
    {
        int randomIndex = Random.Range(0, Instance.enemyTypes.Count);
        int randomSpawnPoint = Random.Range(0, Instance.spawnPoints.Count);

        float randomX = Random.Range(-Instance.spawnRadius, Instance.spawnRadius);
        float randomZ = Random.Range(-Instance.spawnRadius, Instance.spawnRadius);

        Vector3 randomPosition = new Vector3(randomX, 0, randomZ)
         + Instance.spawnPoints[randomSpawnPoint].position;
        
        GameObject enemy = Instantiate(Instance.enemyTypes[randomIndex].Prefab, 
        randomPosition, 
        Quaternion.identity, parent: Instance.spawnPoints[randomSpawnPoint]);
        
        Instance.spawnedEnemies.Add(enemy.GetComponent<Enemy>());
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
