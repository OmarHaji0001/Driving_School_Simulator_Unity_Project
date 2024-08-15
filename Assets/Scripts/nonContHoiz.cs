
using System.Collections;
using TMPro;
using UnityEngine;

public class nonContHoiz : MonoBehaviour
{
    public GameObject car;
    public GameObject box;
    public GameObject warningPanel;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            if (car.transform.eulerAngles.y > 135f)
            {
                if (car.transform.position.z > box.transform.position.z)
                {
                    if (leftside.get() == false)
                    {
                        warningPanel.SetActive(true);

                        TextMeshProUGUI textComponent = warningPanel.GetComponentInChildren<TextMeshProUGUI>();
                        if (textComponent != null)
                        {
                            textComponent.text = "Turn on left indicator";
                            strikes.incStrike();
                            flagrevarse.setff(1);

                        }
                        StartCoroutine(HidePanelAfterDelay(5));
                    }

                }

                else if (car.transform.position.z < box.transform.position.z)
                {

                    if (rightside.get() == false)
                    {
                        warningPanel.SetActive(true);

                        TextMeshProUGUI textComponent = warningPanel.GetComponentInChildren<TextMeshProUGUI>();
                        if (textComponent != null)
                        {
                            textComponent.text = "Turn on right indicator";
                            strikes.incStrike();
                            flagrevarse.setff(1);

                        }
                        StartCoroutine(HidePanelAfterDelay(5));
                    }

                }
            }
            else
            {

                if (car.transform.position.z < box.transform.position.z)
                {
                    if (leftside.get() == false)
                    {
                        warningPanel.SetActive(true);

                        TextMeshProUGUI textComponent = warningPanel.GetComponentInChildren<TextMeshProUGUI>();
                        if (textComponent != null)
                        {
                            textComponent.text = "Turn on left indicator";
                            strikes.incStrike();
                            flagrevarse.setff(1);

                        }
                        StartCoroutine(HidePanelAfterDelay(5));
                    }

                }

                else if (car.transform.position.z > box.transform.position.z)
                {

                    if (rightside.get() == false)
                    {
                        warningPanel.SetActive(true);

                        TextMeshProUGUI textComponent = warningPanel.GetComponentInChildren<TextMeshProUGUI>();
                        if (textComponent != null)
                        {
                            textComponent.text = "Turn on right indicator";
                            strikes.incStrike();
                            flagrevarse.setff(1);

                        }
                        StartCoroutine(HidePanelAfterDelay(5));
                    }

                }

            }


        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            leftside.SetAutoToggle(false);
            rightside.SetAutoToggle(false);

        }
    }
    IEnumerator HidePanelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        warningPanel.SetActive(false);
    }
}
