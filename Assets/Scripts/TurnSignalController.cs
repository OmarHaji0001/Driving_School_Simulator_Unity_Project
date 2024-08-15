using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
public class TurnSignalController : MonoBehaviour
{
    public GameObject warningPanel; 
    public GameObject leftTurnSignal;
    public GameObject rightTurnSignal;
    public float anglebefore;
    private Quaternion initialRotation;
    private bool flag1 = false;
    private bool flag2 = false;
    private bool flag4 = false;
    private bool flag5 = false;
    private bool flag6 = false;
    int r = 2;
    int l = 2;
    private Gamepad gamepad;
    private void Start()
    {
        initialRotation = transform.rotation;
        gamepad = Gamepad.current;
    }
    private void Update()
    {
      if (gamepad.dpad.left.wasReleasedThisFrame)
        {

            l = 1;
        }
        if (gamepad.buttonEast.wasReleasedThisFrame)
        {

            r = 1;
        }
        if (gamepad.dpad.left.isPressed && (l >= 1))
        {
            l = 0;
            if (rightside.get() == true)
            {
                rightside.SetAutoToggle(false);

            }
            if (leftside.get())
            {
                leftside.SetAutoToggle(false);
                flag4 = false;

            }
            else
            {
                flag4 = true;
                anglebefore = Mathf.Abs(transform.rotation.eulerAngles.y - initialRotation.eulerAngles.y);
                leftside.SetAutoToggle(true);
            }
        }
        if (gamepad.buttonEast.isPressed && r >= 1)
        {
            r = 0;
            if (leftside.get() == true)
            {
                leftside.SetAutoToggle(false);

            }
            if (rightside.get())
            {

                rightside.SetAutoToggle(false);
                flag4 = false;


            }
            else
            {
                anglebefore = Mathf.Abs(transform.rotation.eulerAngles.y - initialRotation.eulerAngles.y);
                flag4 = true;
                rightside.SetAutoToggle(true);
            }
        }

        
        if (crross1.get() == false)
        {
            flag6 = true;
        }
        if (circle.get() == true && flag5 == false)
        {
            anglebefore = Mathf.Abs(transform.rotation.eulerAngles.y - initialRotation.eulerAngles.y);
            flag1 = HasRotatedLeft();
            flag2 = HasRotatedRight();
            flag5 = true;


        }
        if (crross1.get() == true || (circle.get() == false && flag5 == true))
        {
            flag5 = false;
            

            if (flag6 == true && crross1.get() == true)
            {

                anglebefore = Mathf.Abs(transform.rotation.eulerAngles.y - initialRotation.eulerAngles.y);
                flag1 = HasRotatedLeft();
                flag2 = HasRotatedRight();
                flag6 = false;
            }
            
            if (HasRotatedLeft() && rightside.get())
            {
 
                warningPanel.SetActive(true);

                TextMeshProUGUI textComponent = warningPanel.GetComponentInChildren<TextMeshProUGUI>();
                if (textComponent != null)
                {
                    textComponent.text = "You turned the right indicator and then you went left";
                    strikes.incStrike();
                }
                StartCoroutine(HidePanelAfterDelay(5));

            }

           else  if (HasRotatedRight() && leftside.get())
            {

                warningPanel.SetActive(true);
                TextMeshProUGUI textComponent = warningPanel.GetComponentInChildren<TextMeshProUGUI>();
                if (textComponent != null)
                {
                    textComponent.text = "You turned the left indicator and then you went right";
                    strikes.incStrike();

                }
                StartCoroutine(HidePanelAfterDelay(5));

            }

            
           else  if ((HasRotatedLeft() != flag1 || HasRotatedRight() != flag2) && rightside.get() == false && leftside.get() == false)
            {

                warningPanel.SetActive(true);

                TextMeshProUGUI textComponent = warningPanel.GetComponentInChildren<TextMeshProUGUI>();
                if (textComponent != null)
                {
                    if ((HasRotatedLeft() != flag1))
                    {
                        textComponent.text = "You should turn on the left indicator";
                        strikes.incStrike();
                    }
                    else
                    {
                        textComponent.text = "You should turn on the right indicator";
                        strikes.incStrike();

                    }
                }
                StartCoroutine(HidePanelAfterDelay(5));
                if (crross1.get() == true)
                {
                    anglebefore = Mathf.Abs(transform.rotation.eulerAngles.y - initialRotation.eulerAngles.y);
                    flag1 = HasRotatedLeft();
                    flag2 = HasRotatedRight();
                }


            }
            if (HasRotatedRight() && rightside.get())
            {
                anglebefore = Mathf.Abs(transform.rotation.eulerAngles.y - initialRotation.eulerAngles.y);
                flag4 = false;
                rightside.SetAutoToggle(false);
                flag1 = HasRotatedLeft();
                flag2 = HasRotatedRight();
            }
            if (HasRotatedLeft() && leftside.get())
            {
                anglebefore = Mathf.Abs(transform.rotation.eulerAngles.y - initialRotation.eulerAngles.y);
                flag4 = false;
                flag1 = HasRotatedLeft();
                flag2 = HasRotatedRight();
                leftside.SetAutoToggle(false);

            }
        }
        if (flag5 == true && circle.get() == false)
        {
            leftside.SetAutoToggle(false);
            rightside.SetAutoToggle(false);

        }

    }

    private bool HasRotatedLeft()
    {
        bool f = false;
        float forback = 0;
        int check = 0;
        
        float angleDifference = Mathf.Abs(transform.rotation.eulerAngles.y - initialRotation.eulerAngles.y);
        if (anglebefore < 90)
        {
            forback = anglebefore;
            check = 1;
            anglebefore = 360;
        }
        float result = (angleDifference - anglebefore);

        if (angleDifference < anglebefore && (result <= -80 && result >= -92))
        {

            f = true;

        }
        if (crross1.get() == false)
        {
            if (angleDifference < anglebefore && (result <= -80 && result >= -199))
            {
                Debug.Log("kjbgjg");


                f = true;


            }
        }
        if (check == 1)
            anglebefore = forback;
        return f;
    }

    private bool HasRotatedRight()
    {
        float forback = 0;
        int check = 0;
        bool f = false;
        float angleDifference = Mathf.Abs(transform.rotation.eulerAngles.y - initialRotation.eulerAngles.y);
        if (anglebefore > 325)
        {
            forback = anglebefore;
            check = 1;
            anglebefore = 0;
        }
        float result = Mathf.Abs(angleDifference - anglebefore);
        if (angleDifference > anglebefore && ((result >= 80 && result <= 92)))
        {
            f = true;
        }
        if (crross1.get() == false)
        {
            if (angleDifference > anglebefore && (result >= 85 && result <= 120))
            {
                f = true;
            }
        }
        if (check == 1)
            anglebefore = forback;

        return f;
    }
    IEnumerator HidePanelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        warningPanel.SetActive(false);
    }
}