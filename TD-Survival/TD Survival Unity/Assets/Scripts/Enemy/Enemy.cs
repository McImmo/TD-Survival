using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour{

    public Nexus nexus;
    public float speed = 5;
    private Waypoint Wpoints;
    public Animator animator;

    private int waypointIndex = 0;
    public float hp = 100;
    private int DamageDealt = 100;

    public void TakeDamage(float x){
        hp -= x;
    }

    public float GetHp(){
        return hp;
    }

    private void Awake()
    {
        EnemiesInfo.enemies.Add(gameObject);
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
                die();
                nexus.ReduceNexusHP(DamageDealt);
            }
        }

        if(hp <= 0){
            die();
        }

        Vector3 movement = (Wpoints.waypoints[waypointIndex].position - transform.position );

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    private void die()
    {
        EnemiesInfo.enemies.Remove(gameObject);
        Destroy(gameObject);
    }

    private int getWaypointIndex(){
        return waypointIndex;
    }
}
