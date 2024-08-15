using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class frontLightTime : MonoBehaviour
{
    public float nightStartHour = 20f; 
    public float nightEndHour = 6f;    
    public Light frontLight1;
    public Light frontLight2;
    
    void Update()
    {
        float currentHour = GetCurrentHour();

        if (currentHour >= nightStartHour || currentHour < nightEndHour)
        {
            TurnOnStreetLights();
        }
        else
        {
            TurnOffStreetLights();
        }
    }
    float GetCurrentHour()
    {
        return System.DateTime.Now.Hour;
    }

    void TurnOnStreetLights()
    {
        frontLight1.enabled = true;
        frontLight2.enabled = true;
    }

    void TurnOffStreetLights()
    {
        frontLight1.enabled = false;
        frontLight2.enabled = false;
    }
}
