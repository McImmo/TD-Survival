using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
[SerializeField]private float range = 20f;
[SerializeField]private float damage = 20f;
[SerializeField]private float timeBetweenShots = 1f; // in seconds
private float nextTimeToShoot;
public GameObject currentTarget;
public Transform pivot;
public Transform barrel;
public GameObject projectile;

private void Start()
{
   nextTimeToShoot = Time.time;
}

private void updateNearestEnemy()
{
    GameObject currentNearestEnemy = null;
    float distance = Mathf.Infinity;

    foreach(GameObject enemy in EnemiesInfo.enemies){
        if(enemy != null)
        {
        float _distance = (transform.position - enemy.transform.position).magnitude;

        if (_distance < distance){
            distance = _distance;
            currentNearestEnemy = enemy;

        }
        }
    }

    if (distance <= range){
        currentTarget = currentNearestEnemy;
    }
    else{
        currentTarget = null;
    }
}

private void shoot(){
        
    Enemy enemyScript = currentTarget.GetComponent<Enemy>();
    GameObject newProjectile = Instantiate(projectile, barrel.position, pivot.rotation);

    enemyScript.TakeDamage(damage);
        
}


private void Update()
{
    updateNearestEnemy();

    if(Time.time >= nextTimeToShoot){
        if (currentTarget != null){
            shoot();
            nextTimeToShoot = Time.time + timeBetweenShots;
        }
    }

}
}