using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnPointsManager : MonoBehaviour
{
    public static EnemySpawnPointsManager Instance;

    public GameObject[] SpawnPointsPrefabs;

    public int SpawnPointsCount = 4;
    public int SpawnPointsDistance = 100;

    private static List<Transform> SpawnPoints = new List<Transform>();
    private Transform player;

    public void Awake()
    {
        Instance = this;
    }

    public void Start()
    {
        player = Player.Instance.transform;
        SpawnPoints = new List<Transform>();
        GenerateSpawnPointsAround(player.position);
    }

    private void GenerateSpawnPointsAround(Vector3 centerPoint)
    {
        
    }   
}
