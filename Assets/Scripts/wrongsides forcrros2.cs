using UnityEngine;
using TMPro; 
using System.Collections; 

public class wrongsides2crros2 : MonoBehaviour
{
    public GameObject stopSignPanel;
    private TextMeshProUGUI messageText;
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
        if (other.CompareTag("Car") && other.attachedRigidbody.velocity.magnitude > 0)
        {
            Vector3 entryDirection = other.transform.position - transform.position;
            float dotRight = Vector3.Dot(entryDirection.normalized, transform.right);
            if (!(dotRight < 0))
            {
                
                if (messageText != null)
                {
                    messageText.text = "You're entering from the wrong side.";
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