using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform player;
    public Vector3 playerP;
    public int boundary = 50;
    // Start is called before the first frame update
    void Start()
    {
        
        transform.position = player.position;
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 move = new Vector3(0,0,0);
        playerP = GetComponent<Camera>().WorldToScreenPoint(player.position);
        if(playerP.y < boundary) 
        {
            move.y = move.y + (playerP.y - boundary);
        }   
        if(playerP.y > (GetComponent<Camera>().pixelHeight - boundary)) 
        {
            move.y = move.y + (playerP.y - (GetComponent<Camera>().pixelHeight - boundary));
        }
        if(playerP.x < boundary)
        {
            move.x = move.x + (playerP.x - boundary);
        }
        if(playerP.x > (GetComponent<Camera>().pixelWidth - boundary)) 
        {
            move.x = move.x + (playerP.x - (GetComponent<Camera>().pixelWidth - boundary));
        }
        Vector3 cameraP = GetComponent<Camera>().WorldToScreenPoint(transform.position);
        cameraP = cameraP + move;
        transform.position = GetComponent<Camera>().ScreenToWorldPoint(cameraP);
    }
}