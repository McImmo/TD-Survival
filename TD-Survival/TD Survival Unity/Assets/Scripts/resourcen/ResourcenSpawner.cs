using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcenSpawner : MonoBehaviour
{
    private float nextSpawnTime = 0;
    [SerializeField]
    private float spawnCooldown = 1;
    [SerializeField]
    private GameObject resourcePrefab;
    private int yMin = -53;
    private int yMax = 75;
    private int xMax = 100;
    private int xMin = -85;
    private bool abgebaut = false;

    private bool TimeToSpawn(){
        return Time.time >= nextSpawnTime;
    }

    private void Spawn(){
            if(abgebaut)
            {            
                nextSpawnTime = Time.time + spawnCooldown;
                Vector2 pos = new Vector2 (Random.Range (xMin, xMax), Random.Range (yMin, yMax));
                GameObject resource = Instantiate(resourcePrefab, pos, transform.rotation);
                abgebaut = false;
            }
    }
    void Update()
    {
                if(TimeToSpawn()){
            Spawn();
        }
    }

    public void SetAbgebaut(bool set)
    {
        abgebaut = set;
    }
}
