using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Nexus : MonoBehaviour
{
    public float NexusHP = 1000f;
    bool NexusZersoert = false;
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

        if (NexusHP <= 0 && NexusZersoert == false)
        {
            Destroy(gameObject);
            NexusZersoert = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

    }

}