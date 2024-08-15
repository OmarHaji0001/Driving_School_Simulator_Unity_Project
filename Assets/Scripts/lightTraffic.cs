using UnityEngine;
using TMPro; 
using System.Collections; 
public class trafficrole2light : MonoBehaviour
{
    public GameObject stopSignPanel; 
    private TextMeshProUGUI messageText; 
    public Light green;
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
            Vector3 entryDirection = other.transform.position - transform.position;
            float dotRight = Vector3.Dot(entryDirection.normalized, transform.right);

            if (!(dotRight < 0))
            {
                if (messageText != null && green.enabled == false)
                {
                    messageText.text = "The traffic light is not green!";
                    strikes.incStrike();
                    stopSignPanel.SetActive(true);
                    StartCoroutine(HidePanelAfterDelay(3.0f)); 
                }
            }
        }
    }
    IEnumerator HidePanelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); 
        stopSignPanel.SetActive(false); 
    }
}