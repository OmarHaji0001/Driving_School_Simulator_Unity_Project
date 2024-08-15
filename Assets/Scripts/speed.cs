using UnityEngine;
using TMPro; 
using System.Collections; 

public class speed : MonoBehaviour
{
    public float speeeed ; 
    public GameObject stopSignPanel; 
    private TextMeshProUGUI messageText; 
    public float maxspeed = 3f; 
    private bool isspeed = false;
    private GameObject banket;
    private Collider banketCollider;


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
            circlerparnt.set1(false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
         if (other.CompareTag("Car") )
        {
            speeeed = other.attachedRigidbody.velocity.magnitude*3.6f;
            speeeed*=1.6666667f;

        }
        if (isspeed == true && speeeed < maxspeed && other.CompareTag("Car"))
        {
            isspeed = false;
        }
        if (other.CompareTag("Car") && speeeed > maxspeed && isspeed != true)
        {
            isspeed = true;            
            if (messageText != null)
            {
                messageText.text = "You passed the speed limit";
                strikes.incStrike();
                stopSignPanel.SetActive(true);
                StartCoroutine(HidePanelAfterDelay(3.0f)); 
            }
        }

    }
    IEnumerator HidePanelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); 
        stopSignPanel.SetActive(false); 
    }
}