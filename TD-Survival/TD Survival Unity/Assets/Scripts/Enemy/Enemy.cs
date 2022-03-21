using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour{
    public float speed = 5;
    private Waypoint Wpoints;
    public Animator animator;

    private int waypointIndex = 0;
    public float hp = 100;
    private int schaden = 10;



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
    private void Start(){
        
        //vergleicht die seine Distanz zu den ersten Waypoints der 4 Pfade. Er deklariert "Wpoints" als den Pfad dessen Startpunkt ma naechsten ist
        Transform Start1 = GameObject.FindGameObjectWithTag("Waypoint").GetComponent<Waypoint>().waypoints[0];
        Transform Start2 = GameObject.FindGameObjectWithTag("Waypoint2").GetComponent<Waypoint>().waypoints[0];
        Transform Start3 = GameObject.FindGameObjectWithTag("Waypoint3").GetComponent<Waypoint>().waypoints[0];
        Transform Start4 = GameObject.FindGameObjectWithTag("Waypoint4").GetComponent<Waypoint>().waypoints[0];
        Transform[] paths = {Start1, Start2, Start3, Start4};

        int index = 0;
        float d = Mathf.Infinity;
        //findet den am wenigsten entfernten Start
        for (int i = 0; i < paths.Length; i++)
        {
            float mag = Vector2.Distance(transform.position, paths[i].position);
            if(mag < d)
            {
                index = i+1;
                d = mag;
            }
        }
        if(index == 1)
        {
            Wpoints = GameObject.FindGameObjectWithTag("Waypoint").GetComponent<Waypoint>();
        }
        if(index == 2)
        {
            Wpoints = GameObject.FindGameObjectWithTag("Waypoint2").GetComponent<Waypoint>();
        }
        if(index == 3)
        {
            Wpoints = GameObject.FindGameObjectWithTag("Waypoint3").GetComponent<Waypoint>();
        }
        if(index == 4)
        {
            Wpoints = GameObject.FindGameObjectWithTag("Waypoint4").GetComponent<Waypoint>();
        }
    }

    void Update(){

        transform.position = Vector2.MoveTowards(transform.position, Wpoints.waypoints[waypointIndex].position, speed * Time.deltaTime);

        if(Vector2.Distance(transform.position, Wpoints.waypoints[waypointIndex].position) < 0.1f){
            if(waypointIndex< Wpoints.waypoints.Length -1){
                waypointIndex++;
            }
            else{
                die();
                FindObjectOfType<Nexus>().ReduceNexusHP(schaden);
            }
        }

        if(hp <= 0){
            die();
        }

        Vector3 movement = (Wpoints.waypoints[waypointIndex].position - transform.position );

        if(animator != null)
        {
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("Speed", movement.sqrMagnitude);
        }
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
