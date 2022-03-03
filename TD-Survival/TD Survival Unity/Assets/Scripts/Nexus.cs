using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nexus : MonoBehaviour
{
    //public Enemy enemy;
    public float NexusHP = 1000;
    private void Start()
    {
        Debug.Log(NexusHP);
    }
    public float GetNexusHP()
    {
        return NexusHP;
    }

    public void ReduceNexusHP(float R)
    {
        NexusHP -= R;
        Debug.Log(NexusHP);
    }

    private void Update()
    {

        if (NexusHP <= 0)
        {
            Destroy(gameObject);
            //Game beenden!!!
        }

    }

}
