using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private int alleNTage = 1; //1 ist jeder Tag
    [SerializeField]
    private int ersterTag = 0; //in Tage, erster Tag = 0 usw.

    [SerializeField]
    private int letzterTag = 100; //in Tage, erster Tag = 0 usw.

    private float nextSpawnTime = 0;
    [SerializeField]
    private float spawnCooldown = 1;
    [SerializeField]
    private GameObject EnemyPrefab;
    [SerializeField] private DayNightCycle licht;

    private float time;

    private bool TimeToSpawn(){
        return Time.time >= nextSpawnTime;
    }

    private void Start()
    {
        time = licht.time + ersterTag*licht.cycleTime;
    }

    private void Spawn(){

        if(licht.GetIsNight && AktiverTag())
        {
            nextSpawnTime = Time.time + spawnCooldown;
            GameObject Enemy = Instantiate(EnemyPrefab, transform.position, transform.rotation);
        }

    }

    void Update()
    {
        time += Time.deltaTime;
        if(TimeToSpawn()){
        Spawn();
        }
    }

    private bool AktiverTag()
    {
        if(Time.time < ersterTag*licht.cycleTime) return false; //guckt ob der Erste Tag erreicht wurde
        LetzterTag();
            
        //guckt ob die angegebene Pause eingehalten wurde
        float mod = time % (alleNTage*licht.cycleTime);
        if(mod <= licht.cycleTime)
        {
        return true;
        }
        else
        {
        return false;
        }
    }

    private void LetzterTag()
    {
        if(Time.time > letzterTag*licht.cycleTime) Destroy(gameObject);
        /*am letzten Tag wird der Spawner zerstoert
        * Man kann also beispielsweise 5 Tage lang eine bestimmte Art Welle schicken und dann aufhoeren, weil ja der Spawner zerstoert ist.
        */
    }

}
