using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarckSpawner : MonoBehaviour
{
    private float nextSpawnTime = 0;
    [SerializeField]
    private float spawnCooldown = 1;
    [SerializeField]
    private GameObject karckPrefab;

    private bool TimeToSpawn(){
        return Time.time >= nextSpawnTime;
    }

    private void Spawn(){
        nextSpawnTime = Time.time + spawnCooldown;
        GameObject Karck = Instantiate(karckPrefab, transform.position, transform.rotation);
    }
    void Update()
    {
                if(TimeToSpawn()){
            Spawn();
        }
    }
}
