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
    bool bautAb;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)) linksBtnDown = true;
        if(Input.GetMouseButtonUp(0)) linksBtnDown = false;
    }

    void FixedUpdate()
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

    //Überprüft ob point im collider c ist
    public static bool IsInside(Collider2D c, Vector3 point)
        {
            return c.OverlapPoint(point);
        }
}
