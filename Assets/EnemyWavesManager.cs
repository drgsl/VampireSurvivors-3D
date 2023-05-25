using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWavesManager : MonoBehaviour
{
    public float spawnDelay = 1f;

    public int startingEnemiesCount = 5;
    public int enemiesPerWave = 5;
    public int waveDuration = 10;

    private void Start()
    {
        StartCoroutine(StartWaves());
    }

    private IEnumerator StartWaves()
    {
        for (int i = 0; i < startingEnemiesCount; i++)
        {
            EnemyManager.SpawnEnemy();
            yield return new WaitForSeconds(spawnDelay);
        }

        while (true)
        {
            yield return new WaitForSeconds(waveDuration);

            for (int i = 0; i < enemiesPerWave; i++)
            {
                EnemyManager.SpawnEnemy();
                yield return new WaitForSeconds(spawnDelay);
            }
        }
    }
}
