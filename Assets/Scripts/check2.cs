using System.Collections;
using TMPro;
using UnityEngine;
public class check2 : MonoBehaviour
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
                
                if (!(dotForward > 0))
                {
                     if(circletraffic2.isenterdd()==1){
                if (warningPanel != null)
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
            else
            {
             
                 if(circletraffic2.isenterdd()==1){
                
                if (warningPanel != null)
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
        }
          IEnumerator HidePanelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        warningPanel.SetActive(false);
    }

}
