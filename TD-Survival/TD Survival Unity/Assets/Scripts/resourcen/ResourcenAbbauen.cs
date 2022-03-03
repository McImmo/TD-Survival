using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcenAbbauen : MonoBehaviour
{
    public Resourcen script;
    public Vector3 mouse;
    //public Collider2D collider;
    public Camera mainCamera;
    public bool linksBtnDown = false;
    public float damage = 50f;
    void Start()
    {
        Debug.Log(script);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)) linksBtnDown = true;
        if(Input.GetMouseButtonUp(0)) linksBtnDown = false;
    }

    void FixedUpdate()
    {
        if(linksBtnDown) //Wurde die maus gedrückt
        {
            mouse = mainCamera.ScreenToWorldPoint(Input.mousePosition); //Gibt die position der maus
            if(IsInside(GetComponent<Collider2D>(), mouse))
            {
                script.DMG(damage * Time.fixedDeltaTime); //Zieht leben von der resource ab
            }
        } 
    }

    //Überprüft ob point im collider c ist
    public static bool IsInside(Collider2D c, Vector3 point)
        {
            return c.OverlapPoint(point);
        }
}
