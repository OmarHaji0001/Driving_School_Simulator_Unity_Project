using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class strikes : MonoBehaviour
{
    static public TextMeshProUGUI strikeMsg = null;
    static public int counterOfStrikes = 0;
    static public Canvas canvas;

    void Start()
    {
        if (strikeMsg == null)
        {
            if (canvas == null)
            {
                canvas = FindObjectOfType<Canvas>();
            }
            TextMeshProUGUI[] allTexts = canvas.GetComponentsInChildren<TextMeshProUGUI>(true);
            foreach (TextMeshProUGUI txt in allTexts)
            {
                if (txt.text == "Strikes:0")
                {
                    strikeMsg = txt;
                }
            }
        }
    }
    static public void incStrike()
    {
        flagrevarse.setff(1);
        if (CarController2.getHantuliFlags() == 0)
        {
            counterOfStrikes++;
            if (strikeMsg == null)
            {
                if (canvas == null)
                {
                    canvas = FindObjectOfType<Canvas>();
                }
                TextMeshProUGUI[] allTexts = canvas.GetComponentsInChildren<TextMeshProUGUI>(true);
                foreach (TextMeshProUGUI txt in allTexts)
                {
                    if (txt.text == "Strikes:0")
                    {
                        strikeMsg = txt;
                        
                    }
                }
            }
            if (strikeMsg != null)
            {
                strikeMsg.text = "Strikes:" + counterOfStrikes;
                
            }
        }
    }
}