using System.Collections;
using TMPro;
using UnityEngine;
public class check1 : MonoBehaviour
{
     public GameObject warningPanel;
static int  isenterd=0;
    private void OnTriggerExit(Collider other)
        {
             if (other.CompareTag("Car")) 
        {
            Vector3 entryDirection = other.transform.position - transform.position;
            float dotForward = Vector3.Dot(entryDirection.normalized, transform.forward);
            float dotRight = Vector3.Dot(entryDirection.normalized, transform.right);

            if (Mathf.Abs(dotForward) > Mathf.Abs(dotRight))
            {
                
                if (!(dotForward < 0))
                {
 if(circletraffic.isenterdd()==1)
        {
             warningPanel.SetActive(true);

                    TextMeshProUGUI textComponent = warningPanel.GetComponentInChildren<TextMeshProUGUI>();
                    if (textComponent != null)
                    {
                        textComponent.text = "You entered the roundabout while there's a car on your left";
                        strikes.incStrike();
                    }
                    StartCoroutine(HidePanelAfterDelay(5)); 
        }                }
            }
            else
            {
                
                if (dotRight > 0)
                {
 if(circletraffic.isenterdd()==1)
        {
             warningPanel.SetActive(true);

                    TextMeshProUGUI textComponent = warningPanel.GetComponentInChildren<TextMeshProUGUI>();
                    if (textComponent != null)
                    {
                        textComponent.text = "You entered the roundabout while there's a car on your left";
                        strikes.incStrike();
                    }
                    StartCoroutine(HidePanelAfterDelay(5)); 
        }                }
                else
                {
                     if(circletraffic.isenterdd()==1)
        {
             warningPanel.SetActive(true);

                    TextMeshProUGUI textComponent = warningPanel.GetComponentInChildren<TextMeshProUGUI>();
                    if (textComponent != null)
                    {
                        textComponent.text = "You entered the roundabout while there's a car on your left";
                        strikes.incStrike();
                    }
                    StartCoroutine(HidePanelAfterDelay(5)); 
        }
                }
            }
        }
            isenterd=0;
        }
          IEnumerator HidePanelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        warningPanel.SetActive(false);
    }

}
