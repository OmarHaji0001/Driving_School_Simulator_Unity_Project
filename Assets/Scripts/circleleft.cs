using UnityEngine;
using TMPro;
using System.Collections; 
public class circler : MonoBehaviour
{
    public GameObject warningPanel; 
    private Vector3 correctDirection = Vector3.forward; 

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Car"))
        {
            Vector3 carDirection = other.transform.forward;
            if (Vector3.Dot(carDirection, correctDirection) > 0 && !circlerparnt.get1()) 
            {
                circlerparnt.set1(true);
                if (warningPanel != null)
                {
                    warningPanel.SetActive(true);
                    TextMeshProUGUI textComponent = warningPanel.GetComponentInChildren<TextMeshProUGUI>();
                    if (textComponent != null)
                    {
                        textComponent.text = "You entered the roundabout in the wrong direction";
                        strikes.incStrike();
                    }
                    StartCoroutine(HidePanelAfterDelay(5)); 
                }
            }
        }
    }

    IEnumerator HidePanelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        warningPanel.SetActive(false);
    }
    private void Start()
    {
        
        if (warningPanel != null)
        {
            warningPanel.SetActive(false);
        }
    }
}