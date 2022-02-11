using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
private float range;
private float damage;
private float timeBetweenShots; // in seconds
private GameObject currentTarget;

private void Start()
{
    
}

private void updateNearestEnemy()
{

}

private void shoot(){
        if (currentTarget != null)
        {
            currentTarget.hp -= damage; 
        }
}


private void Update()
{
    shoot();
}
}
