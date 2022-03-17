using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcenAbbauen : MonoBehaviour
{
    public Resourcen script;
    Vector3 mouse;
    public Camera mainCamera;
    bool linksBtnDown = false;
    public float damage = 50f;
    public Object player;
    public PlayerMovement playerM;
    [SerializeField] private Transform playerT;
    [SerializeField] private float abbauRadius = 2;
    bool bautAb;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)) linksBtnDown = true;
        if(Input.GetMouseButtonUp(0)) linksBtnDown = false;
    }

    void FixedUpdate()
    {
        Debug.Log(Vector3.Distance(playerT.position,transform.position));
        if(Vector3.Distance(playerT.position,transform.position) < abbauRadius)
        {
            bautAb = playerM.GetBautAb();
            if(linksBtnDown) //Wurde die maus gedrückt
            {
                mouse = mainCamera.ScreenToWorldPoint(Input.mousePosition); //Gibt die position der maus
            
                if(IsInside(GetComponent<Collider2D>(), mouse))
                {
                    script.DMG(damage * Time.fixedDeltaTime); //Zieht leben von der resource ab
                    bautAb = true;
                }
            }
            else bautAb = false;
            playerM.SetBautAb(bautAb);
        }
    }

    //Überprüft ob point im collider c ist
    public static bool IsInside(Collider2D c, Vector3 point)
    {
        return c.OverlapPoint(point);
    }

    public bool IsPlayerClose()
    {
        Vector3 resource = transform.position;
        Vector3 player = playerT.position;
        bool isClose = false;
        float deltaX = resource.x - player.x;
        float deltaY = resource.y - player.y;
        //Debug.Log(transform.position);// + "  /  " + (resource.x - abbauRadius) + "  ||  " + (resource.y + abbauRadius) + "  /  " + (resource.y - abbauRadius));
        if((((int)deltaX)^2 + ((int)deltaY)^2) < ((int)abbauRadius^2)) isClose = true;
        return isClose;
    }
}