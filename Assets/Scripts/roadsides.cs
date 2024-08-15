using UnityEngine;
using TMPro; 
using System.Collections; 
public class roadsides : MonoBehaviour
{
    public GameObject thePanel;
    private TextMeshProUGUI messageText;
    private void Start()
    {
        if (thePanel != null)
        {
            messageText = thePanel.GetComponentInChildren<TextMeshProUGUI>();
            thePanel.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            if (messageText != null)
            {
                messageText.text = "You're trying to climb a roadside";
                strikes.incStrike();
                thePanel.SetActive(true);
                StartCoroutine(HidePanelAfterDelay(3.0f));
            }
        }
    }
    IEnumerator HidePanelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); 
        thePanel.SetActive(false); 
    }
}