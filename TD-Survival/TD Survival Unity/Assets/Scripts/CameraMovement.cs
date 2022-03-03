using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform player;
    public Vector3 playerP;
    public float boundary = 0.45f;
    float height;
    float width;
    
    // Start is called before the first frame update
    void Start()
    {
        
        transform.position = player.position;
        width = GetComponent<Camera>().pixelWidth * boundary;
        height = GetComponent<Camera>().pixelHeight * boundary;
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 move = new Vector3(0,0,0);
        playerP = GetComponent<Camera>().WorldToScreenPoint(player.position);
        if(playerP.y < height) 
        {
            move.y = move.y + (playerP.y - height);
        }   
        if(playerP.y > (GetComponent<Camera>().pixelHeight - height)) 
        {
            move.y = move.y + (playerP.y - (GetComponent<Camera>().pixelHeight - height));
        }
        if(playerP.x < width)
        {
            move.x = move.x + (playerP.x - width);
        }
        if(playerP.x > GetComponent<Camera>().pixelWidth - width)
        {
            move.x = move.x + (playerP.x - (GetComponent<Camera>().pixelWidth - width));
        }
        Vector3 cameraP = GetComponent<Camera>().WorldToScreenPoint(transform.position);
        cameraP = cameraP + move;
        transform.position = GetComponent<Camera>().ScreenToWorldPoint(cameraP);
        
    }
}
