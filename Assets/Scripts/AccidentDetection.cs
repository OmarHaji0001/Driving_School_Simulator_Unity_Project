using UnityEngine;
using TMPro;
using System.Collections;
public class AccidentDetection : MonoBehaviour
{
    public GameObject accidentNotificationPanel; 
    private TextMeshProUGUI accidentText; 
    private void Start()
    {
         if (accidentNotificationPanel != null)
        {
            accidentNotificationPanel.SetActive(false);
            
            accidentText = accidentNotificationPanel.GetComponentInChildren<TextMeshProUGUI>();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "accident" || collision.gameObject.tag == "Carai")
        {
            
            if (accidentNotificationPanel != null && accidentText != null)
            {
                accidentText.text = "You made an accident, be careful!";
                strikes.incStrike();
                accidentNotificationPanel.SetActive(true);
                StartCoroutine(HidePanelAfterDelay(5)); 
            }
        }
    }
    IEnumerator HidePanelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        accidentNotificationPanel.SetActive(false);
    }
}