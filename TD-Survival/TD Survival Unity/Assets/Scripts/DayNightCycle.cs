using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class DayNightCycle : MonoBehaviour
{
    [SerializeField] private Gradient lightColor;

    private int nights;
    public int Nights => nights;
    public float time = 0;
    public int cycleTime = 120;
    private bool isNight = false;
    public bool GetIsNight => isNight;

    void Update()
    {
        if(time > cycleTime)
        {
            time = 0;
            nights++;
        }
        
        if (Input.GetKeyDown(KeyCode.Return))
        {
            time = cycleTime * 0.45f;
        }

        if(((int)time >= cycleTime/2) && ((time < cycleTime*0.95f))) isNight = true;

        if(time > cycleTime*0.95f) isNight = false;
        
        time += Time.deltaTime;
        GetComponent<Light2D>().color = lightColor.Evaluate(time * 1/cycleTime);
    }

}
