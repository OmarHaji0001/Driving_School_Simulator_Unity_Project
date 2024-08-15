using System.Collections;
using System.Net.Security;
using TMPro;
using UnityEngine;
public class TriggerDetector3 : MonoBehaviour
{
    public GameObject warningPanel;
    private int wayes =0;
    private void OnTriggerEnter(Collider other)
    {
 
        if (other.CompareTag("Car")&&linesparent.get1()==0)
        {
                 linesparent.set1(7);

              {
            Vector3 entryDirection = other.transform.position - transform.position;
            float dotForward = Vector3.Dot(entryDirection.normalized, transform.forward);
            float dotRight = Vector3.Dot(entryDirection.normalized, transform.right);

            if (Mathf.Abs(dotForward) > Mathf.Abs(dotRight))
            {
                
                if (dotForward > 0)
                {
                                                            wayes =1;


                }
                else
                {
                                        wayes =2;
                }
            }
            else
            {
                
                if (dotRight > 0)
                {
                    wayes =3;

                }
                else
                {
                                                            wayes =4;
                                                           
                }
            }
        }
              
            Vector3 triggerPosition = transform.position;
            Vector3 carPosition = other.transform.position;

    }
    }
 
    private void OnTriggerExit(Collider other)
    {
        
        if (other.CompareTag("Car")&&linesparent.glock()==0&&linesparent.get1()==7)
        {
        
        {
            Vector3 triggerPosition = transform.position;

            
            Vector3 carPosition = other.transform.position;

            if(linesparent.get()==0)
            {
                
            if (wayes==1)
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
            else if(wayes==2)
            {
                
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
            else if(wayes==3)
            {
                
       linesparent.set(3);
               warningPanel.SetActive(true);
                    
                    TextMeshProUGUI textComponent = warningPanel.GetComponentInChildren<TextMeshProUGUI>();
                    if (textComponent != null)
                    {
                        textComponent.text = "You crossed a continuous line";
                        strikes.incStrike();
                    }

                    
                    StartCoroutine(HidePanelAfterDelay(5)); 
            }
            else if(wayes==4)
            {
                
                linesparent.set(4);
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
            else if(wayes==linesparent.get())
            {
                     if (linesparent.get1()==7)
                     {                            
                        linesparent.set1(0);


                     }
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
