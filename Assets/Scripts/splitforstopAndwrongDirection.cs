using UnityEngine;
using TMPro; 
using System.Collections; 

public class StopSignDetection40 : MonoBehaviour
{
    private bool hasStopped = false;
    public GameObject stopSignPanel;
    private TextMeshProUGUI messageText;
    private int flg = 0;
    private int noot = 1;
    private float stopTime = 0; 

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
            float dotForward = Vector3.Dot(entryDirection.normalized, transform.forward);
            float dotRight = Vector3.Dot(entryDirection.normalized, transform.right);
            if (Mathf.Abs(dotForward) > Mathf.Abs(dotRight))
            {
                
                if (dotForward > 0)
                {
                    //front
                    flg = 1;
                }
                else
                {
                    //back
                    flg = 1;
                }
            }
            else
            {
                
                if (dotRight > 0)
                {
                    //right
                    flg = 1;
                }
                else
                //left
                {
                    flg = 2;
                }
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Car") && other.attachedRigidbody.velocity.magnitude <= 0.5f && flg == 1) 
        {
            hasStopped = true;
            stopTime += Time.deltaTime; 
            if (stopTime >= 5) 
            {
                noot = 0;
            }
        }
    }

    private int CheckCarDirectionAndTraffic()
    {
        bool goingLeft = leftside.get();
        bool goingRight = rightside.get();

        if ((goingLeft && aileftcross2.isenterdd() == 0 && airightcross2.isenterdd() == 0) ||
         (goingRight && aileftcross2.isenterdd() == 0) || (goingLeft == false && goingRight == false && aileftcross2.isenterdd() == 0 && airightcross2.isenterdd() == 0))
        {
            return 1;
        }
        else if (goingLeft == false && goingRight == false)
        {
            return 2;
        }
        else
        {
            return 0;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (flg == 1)
        {
            if (other.CompareTag("Car") && !hasStopped && flg == 1)
            {
                if (messageText != null)
                {
                    stopTime = 0;
                    messageText.text = "You didn't stop at the stop sign";
                    strikes.incStrike();
                    stopSignPanel.SetActive(true);
                    StartCoroutine(HidePanelAfterDelay(3.0f)); 
                }
            }
            else if (other.CompareTag("Car") && noot == 1)
            {
                stopTime = 0;
                messageText.text = "You didn't stop for 5 seconds to see the traffic";
                strikes.incStrike();
                stopSignPanel.SetActive(true);
                StartCoroutine(HidePanelAfterDelay(3.0f)); 
            }
            else if (CheckCarDirectionAndTraffic() == 0 && other.CompareTag("Car"))
            {
                stopTime = 0;
                messageText.text = "There is a traffic ahead of you, you should give every singe car a priority.";
                strikes.incStrike();
                stopSignPanel.SetActive(true);
                StartCoroutine(HidePanelAfterDelay(3.0f)); 
            }
            else if (CheckCarDirectionAndTraffic() == 2 && other.CompareTag("Car"))
            {
                stopTime = 0;
                messageText.text = "You didn't give an indicator for your direction";
                strikes.incStrike();
                stopSignPanel.SetActive(true);
                StartCoroutine(HidePanelAfterDelay(3.0f)); 
            }
            else if (other.CompareTag("Car"))
            {
                stopTime = 0;
                noot = 1;
            }
        }
    }

    IEnumerator HidePanelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); 
        stopSignPanel.SetActive(false); 
    }
}