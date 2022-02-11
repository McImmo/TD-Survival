using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour{

    public float speed = 5;
    private Waypoint Wpoints;

    private int waypointIndex = 0;
    public int hp = 100;

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
