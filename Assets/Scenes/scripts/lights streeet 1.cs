using UnityEngine;
public class StreetLightsManager : MonoBehaviour
{
    public Light[] streetLights;
    public float nightStartHour = 20f; 
    public float nightEndHour = 6f;    
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
        foreach (Light streetLight in streetLights)
        {
            streetLight.enabled = true;
        }
    }

    void TurnOffStreetLights()
    {
        foreach (Light streetLight in streetLights)
        {
            streetLight.enabled = false;
        }
    }
}
