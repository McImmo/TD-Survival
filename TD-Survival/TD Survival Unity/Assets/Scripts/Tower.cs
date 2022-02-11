using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
private float range;
public float damage = 4f;
public float timeBetweenShots = 2f; // in seconds
private float cooldown;
private Enemy currentTarget;

private void Start()
{
    cooldown = timeBetweenShots;
}

private void updateNearestEnemy()
{
    if(GameObject.FindGameObjectWithTag("Enemy") != null)
currentTarget = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>();
}

private void shoot(){
        if (currentTarget != null)
        {
            currentTarget.TakeDamage(damage);
        }
}


private void Update()
{
    updateNearestEnemy();
    cooldown -= Time.deltaTime;
    if(cooldown <= 0){
    shoot();
    cooldown = timeBetweenShots;
    Debug.Log(currentTarget.GetHp());
    }
}
}
