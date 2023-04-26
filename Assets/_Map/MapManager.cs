using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public static MapManager Instance;

    [Tooltip("Works better with odd numbers")]
    public Vector3 mapSize;
    public GameObject[] TilePrefabs;


    private static List<Tile> Tiles = new List<Tile>();
    private Transform player;

    public void Awake()
    {
        Instance = this;
    }

    public void Start()
    {
        player = Player.Instance.transform;
        GenerateMapAround(player.position);
    }

    public static void updateTilePositions(Tile PlayerTile)
    {
        foreach (Tile otherTile in Tiles)
        {
            if(otherTile == PlayerTile)
            {
                continue;
            }
            if(Vector3.Distance(otherTile.transform.position, PlayerTile.transform.position) > Instance.mapSize.x / 2f * otherTile.size.x
            || Vector3.Distance(otherTile.transform.position, PlayerTile.transform.position) > Instance.mapSize.z / 2f * otherTile.size.z)
            {
                Vector3 NewPosition = GetEmptyPositionAround(PlayerTile); 
                otherTile.MoveTo(NewPosition);
            }
        }
    }

    private static Vector3 GetEmptyPositionAround(Tile tile)
    {
        for(int x = (int)-Instance.mapSize.x / 2; x <= (int) Instance.mapSize.x / 2; x++)
        {
            for(int z = (int)Instance.mapSize.z / 2; z >= (int) -Instance.mapSize.z / 2; z--)
            {
                Vector3 position = new Vector3(x * tile.size.x, 0, z * tile.size.z) + tile.transform.position;
                bool isPositionEmpty = true;
                foreach(Tile otherTile in Tiles)
                {
                    if(otherTile.Contains(position))
                    {
                        isPositionEmpty = false;
                        break;
                    }
                }
                if(isPositionEmpty)
                {
                    return position;
                }
            }
        }
        return Vector3.zero;
    }

    private void GenerateMapAround(Vector3 centerPoint)
    {
        for(int x = (int)-mapSize.x / 2; x <= (int) mapSize.x / 2; x++)
        {
            for(int z = (int)mapSize.z / 2; z >= (int) -mapSize.z / 2; z--)
            {
                int randomIndex = Random.Range(0, TilePrefabs.Length);
                GameObject randomTile = TilePrefabs[randomIndex];
                GameObject tileGO = Instantiate(randomTile, parent:transform);
                tileGO.name = "Tile " + x + " " + z;
                // change tile's mesh renderer color to a random color
                Color randomColor = Random.ColorHSV();
                Renderer tileRenderer = tileGO.GetComponent<Renderer>();
                tileRenderer.material.color = randomColor;


                Tile tile = tileGO.GetComponent<Tile>();
                Vector3 tilePosition = new Vector3(x * tile.size.x, 0, z * tile.size.z) + centerPoint;
                tile.MoveTo(tilePosition);
                Tiles.Add(tile);
            }
        }
    }
}
