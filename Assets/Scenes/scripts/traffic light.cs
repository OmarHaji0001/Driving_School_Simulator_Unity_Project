using UnityEngine;
public class TrafficLightController : MonoBehaviour
{
    public Light yellowLight;
    public Light greenLight;
    public Light redLight;

    public float greenDuration = 10f; 
    public float yellowDuration = 3f; 
    public float redDuration = 5f; 

    public int initialLightIndex = 0; 
    public  int f1=0;
    private float timer; 
    void Start()
    {
        timer = 0f; 

        
        switch (initialLightIndex)
        {
            case 0:
                ActivateYellowLight();
                timer = yellowDuration;
                break;
            case 1:
                ActivateRedLight(); 
                timer = redDuration;
                break;
            case 2:
                ActivateGreenLight(); 
                timer = greenDuration;
                break;
            default:
                break;
        }
    }

    void Update()
    {
        
        timer -= Time.deltaTime;

        
        if (timer <= 0f)
        {
            if (yellowLight.enabled)
            {
                if(f1==1)
                {
ActivateRedLight();
                timer = redDuration;
                }
                else if(f1==0){
                ActivateGreenLight();
                timer = greenDuration;
                }
                else {
                ActivateRedLight();
                timer = redDuration;
                }
            }
            else if (greenLight.enabled)
            {
                f1=1;

                
                ActivateYellowLight();
                timer = yellowDuration;
                

            }
            else if (redLight.enabled)
            {
                f1=0;
                
                ActivateYellowLight();
                timer = yellowDuration;
            }
        }
    }

    void ActivateGreenLight()
    {
        greenLight.enabled = true;
        yellowLight.enabled = false;
        redLight.enabled = false;
    }

    void ActivateYellowLight()
    {
        greenLight.enabled = false;
        yellowLight.enabled = true;
        redLight.enabled = false;
    }

    void ActivateRedLight()
    {
        greenLight.enabled = false;
        yellowLight.enabled = false;
        redLight.enabled = true;
    }
}