using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapMovement : MonoBehaviour
{
    [SerializeField] private Transform main;
    // Update is called once per frame
    void Update()
    {
        transform.position = main.position;
    }
}
