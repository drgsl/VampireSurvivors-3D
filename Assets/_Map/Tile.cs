using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public Vector3 size;

    public void Awake(){
        size = GetComponent<Renderer>().bounds.size;
    }

    public bool Contains(Vector3 position)
    {
        Vector3 min = transform.position - size / 2;
        Vector3 max = transform.position + size / 2;
        return position.x >= min.x && 
                position.x <= max.x && 
                position.z >= min.z && 
                position.z <= max.z;
    }
    public void MoveTo(Vector3 position){
        transform.position = position;
    }

    public void OnCollisionEnter(Collision other){
        if(other.gameObject.CompareTag("Player")){
            MapManager.updateTilePositions(this);

            // EnemySpawnPointsManager.updateSpawnPositions(this.transform);
        }
    }
}
