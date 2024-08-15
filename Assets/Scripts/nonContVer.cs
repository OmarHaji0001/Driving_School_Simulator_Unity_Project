using System.Collections;
using TMPro;
using UnityEngine;
public class nonContVer : MonoBehaviour
{
    public GameObject car;
    public GameObject box;
    public GameObject warningPanel;

    void Start()
    { }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            if (car.transform.rotation.y <= 0.43f)
            {
                if (car.transform.position.x > box.transform.position.x)
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

                else if (car.transform.position.x < box.transform.position.x)
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

                if (car.transform.position.x < box.transform.position.x)
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

                else if (car.transform.position.x > box.transform.position.x)
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