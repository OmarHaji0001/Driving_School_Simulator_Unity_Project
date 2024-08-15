using System.Collections;
using TMPro;
using UnityEngine;
public class TriggerDetector4 : MonoBehaviour
{
    public GameObject warningPanel;
    private int wayes =0;
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Car"))
        {

            Vector3 triggerPosition = transform.position;

            
            Vector3 carPosition = other.transform.position;

            
            if (carPosition.x > triggerPosition.x)
            {
               
wayes =2;
            }
            else
            {
               
wayes = 1;
            }
        }
            
    }
 
    private void OnTriggerExit(Collider other)
    {
        
        if (other.CompareTag("Car")&&linesparent.glock()==0)
        {
        {
            Vector3 triggerPosition = transform.position;
            Vector3 carPosition = other.transform.position;

            if(linesparent.get()==0)
            {
                Debug.Log(wayes);
            if (carPosition.x < triggerPosition.x&&wayes==1)
            {
                
                                linesparent.set1(0);

                linesparent.set(2);
               warningPanel.SetActive(true);
                    TextMeshProUGUI textComponent = warningPanel.GetComponentInChildren<TextMeshProUGUI>();
                    if (textComponent != null)
                    {
                        textComponent.text = "You crossed a continuous line";
                        strikes.incStrike();
                    }
                    
                    StartCoroutine(HidePanelAfterDelay(5)); 
            }
            else if(wayes==2)
            {
                
                                linesparent.set(1);
               warningPanel.SetActive(true);

                    
                    TextMeshProUGUI textComponent = warningPanel.GetComponentInChildren<TextMeshProUGUI>();
                    if (textComponent != null)
                    {
                        textComponent.text = "You crossed a continuous line";
                        strikes.incStrike();
                    }

                    
                    StartCoroutine(HidePanelAfterDelay(5)); 
            }
            
            }
            else {

                linesparent.set(0);
}

        }
        }
    }
    
     IEnumerator HidePanelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        warningPanel.SetActive(false);
    }
    
}
