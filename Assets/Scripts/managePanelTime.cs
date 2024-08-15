using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
public class managePanelTime : MonoBehaviour
{
    public GameObject thePanel;
    public GameObject thePanel2;
    private TextMeshProUGUI messageText;
    private TextMeshProUGUI messageText2;
    private int fff = 0;
    
    void Start()
    {
        if (thePanel != null)
        {
            messageText = thePanel.GetComponentInChildren<TextMeshProUGUI>();
            thePanel.SetActive(false);
            messageText2 = thePanel2.GetComponentInChildren<TextMeshProUGUI>();
            thePanel2.SetActive(false);
        }
    }

    
    void Update()
    {
        if (flagrevarse.getff() == 1 && fff == 0 && CarController2.getHantuliFlags() == 1)
        {
            fff = 1;
            messageText2.text = messageText.text;
            thePanel2.SetActive(true);
            StartCoroutine(HidePanelAfterDelay(5.0f));


        }
        else if (flagrevarse.getff() == 0 && CarController2.getHantuliFlags() == 0)
        {
            fff = 0;
        }
    }
    IEnumerator HidePanelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); 
        thePanel2.SetActive(false); 
    }
}
