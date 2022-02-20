using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private float nextSpawnTime = 0;
    [SerializeField]
    private float spawnCooldown = 1;
    [SerializeField]
    private GameObject EnemyPrefab;

    private bool TimeToSpawn(){
        return Time.time >= nextSpawnTime;
    }

    private void Spawn(){
        nextSpawnTime = Time.time + spawnCooldown;
        GameObject Enemy= Instantiate(EnemyPrefab, transform.position, transform.rotation);
    }
    void Update()
    {
                if(TimeToSpawn()){
            Spawn();
        }
    }
}
