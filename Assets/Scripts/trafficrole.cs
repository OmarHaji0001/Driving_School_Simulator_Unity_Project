using UnityEngine;
using TMPro; 
using System.Collections; 
public class trafficrole : MonoBehaviour
{
    public GameObject stopSignPanel; 
    private TextMeshProUGUI messageText; 
    public Light green;
    private Vector3 correctDirection = Vector3.forward;
    private bool flg = true;
    private void Start()
    {
        if (stopSignPanel != null)
        {
            messageText = stopSignPanel.GetComponentInChildren<TextMeshProUGUI>();
            stopSignPanel.SetActive(false); 
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            Vector3 carDirection = other.transform.forward;
            if (Vector3.Dot(carDirection, correctDirection) < 0) 
            {
                if (messageText != null)
                {
                    messageText.text = "This is one way road, you cannot enter here";
                    strikes.incStrike();
                    stopSignPanel.SetActive(true);
                    StartCoroutine(HidePanelAfterDelay(3.0f)); 
                }
                flg = false;
            }
            else if (other.CompareTag("Car") && green.enabled == false && flg)
            {                
                if (messageText != null)
                {
                    messageText.text = "The traffic light is not green!";
                    strikes.incStrike();
                    stopSignPanel.SetActive(true);
                    StartCoroutine(HidePanelAfterDelay(3.0f)); 
                }
            }
            flg = true;
        }
    }
    IEnumerator HidePanelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); 
        stopSignPanel.SetActive(false); 
    }
}