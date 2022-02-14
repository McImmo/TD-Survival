using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsVisible : MonoBehaviour
{
     Renderer m_Renderer;
     public bool visible = true;
     public Transform camera;
    // Use this for initialization
    void Start()
    {
        m_Renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_Renderer.isVisible)
        {
            visible = true;
        }
        else 
        {
            visible = false;
        }
    }

    public bool GetVisible()
    {
        return visible;
    }
}
