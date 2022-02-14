using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform playerT;
    public IsVisible script;
    
    // Update is called once per frame
    void Update()
    {
        if(script.GetVisible() == false)
        {
            transform.position = playerT.position;
        }
    }
}
