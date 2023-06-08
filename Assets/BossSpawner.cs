using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    public GameObject BossPrefab;
    public Transform[] SpawnPoints;
    
    float spawnDelay = 10f;

    public void Start()
    {
        StartCoroutine(SpawnBoss());
    }

    private IEnumerator SpawnBoss()
    {
        yield return new WaitForSeconds(spawnDelay);

        Instantiate(BossPrefab, SpawnPoints[0].position, SpawnPoints[0].rotation);
    }

}
