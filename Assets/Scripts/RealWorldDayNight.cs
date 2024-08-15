using UnityEngine;

public class RealWorldDayNight : MonoBehaviour
{
    public GameObject Sun;
    public float SunRiseTime = 8;
    public float SunSetTime = 20;

    private int CurrentHour;
    private float CurrentMinute;
    private Vector3 eulerRotation;
    private float TimeIntoDay;
    private float SolarDayLength;
    private float SolarNightLength;

    void Start()
    {
        
        eulerRotation = Sun.transform.rotation.eulerAngles;
    }

    private void FixedUpdate()
    {
        
        CurrentHour = System.DateTime.Now.Hour;
        CurrentMinute = System.DateTime.Now.Minute;

        SunTime(CurrentHour, CurrentMinute);
    }

    void SunTime(int Hour, float Minuet)
    {
        
        SolarDayLength = SunSetTime - SunRiseTime;
        SolarNightLength = 24 - SolarDayLength;

        TimeIntoDay = Hour + Minuet / 60;

        if (TimeIntoDay < SunRiseTime) 
        {
            Sun.transform.rotation = Quaternion.Euler(TimeIntoDay * 90 / SolarNightLength + 270, eulerRotation.y, eulerRotation.z);
        }
        else if(TimeIntoDay > SunSetTime) 
        {
            
            var SolarNightTime = TimeIntoDay - SunSetTime;

            Sun.transform.rotation = Quaternion.Euler(SolarNightTime * 90 / SolarNightLength + 180, eulerRotation.y, eulerRotation.z);
        }
        else 
        {
            
            var SolarDayTime = TimeIntoDay - SunRiseTime;

            
            Sun.transform.rotation = Quaternion.Euler(SolarDayTime * 180 / SolarDayLength, eulerRotation.y, eulerRotation.z);
        }
    }
}
