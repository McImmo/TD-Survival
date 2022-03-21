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
    [SerializeField] private int anfangsMenge;

    private void Start()
    {
        for(int i = 0; i < anfangsMenge; i++)
        {
            Spawn(130,-110,95,-73);
        }
    }

    private bool TimeToSpawn(){
        return Time.time >= nextSpawnTime;
    }

    private void Spawn(int xMa, int xMi, int yMa, int yMi){          
        nextSpawnTime = Time.time + spawnCooldown;
        Vector2 pos = new Vector2 (Random.Range (xMi, xMa), Random.Range (yMi, yMa));
        GameObject resource = Instantiate(resourcePrefab, pos, transform.rotation);
        abgebaut = false;
    }
    void Update()
    {
        if(TimeToSpawn() && abgebaut){
            Spawn(xMax, xMin, yMax, yMin);
        }
    }

    public void SetAbgebaut(bool set)
    {
        abgebaut = set;
    }
}
