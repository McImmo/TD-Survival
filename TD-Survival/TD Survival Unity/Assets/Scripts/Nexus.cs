using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nexus : MonoBehaviour
{
    public Enemy enemy;
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

    /*public void IncreaseNexusHP(int I)
    {
        NexusHP += I;
    }*/

    private void Update()
    {
        /*if (NexusHP >= 1000)
        {
            NexusHP = 1000;
        }*/

        if (NexusHP <= 0)
        {
            Destroy(gameObject);
            //Game beenden!!!
        }

        /*if (NexusHP < 500)
        {
            IncreaseNexusHP (2f * Time.fixedDeltaTime)
        } */
    }

}
