using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour{

    public float speed = 5;
    private Waypoint Wpoints;

    private int waypointIndex = 0;
    public float hp = 100;

    public void TakeDamage(float x){
        hp -= x;
    }
    public float GetHp(){
        return hp;
    }

    void Start(){
        
        Wpoints = GameObject.FindGameObjectWithTag("Waypoint").GetComponent<Waypoint>();
    }

    void Update(){

        transform.position = Vector2.MoveTowards(transform.position, Wpoints.waypoints[waypointIndex].position, speed * Time.deltaTime);

        if(Vector2.Distance(transform.position, Wpoints.waypoints[waypointIndex].position) < 0.1f){
            if(waypointIndex< Wpoints.waypoints.Length -1){
                waypointIndex++;
            }
            else{
                Destroy(gameObject);
            }
        }

        if(hp <= 0){
            Destroy(gameObject);
        }
    }
}
