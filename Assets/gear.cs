using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
public class gear : MonoBehaviour
{
    public GameObject stopSignPanel;
    public float sensoresleanth = 3f;
    public Vector3 frontsensorepos = new Vector3(0f, 20f, 0f);
    public GameObject gears;
    public float frontsensoreangle = 30f;
    public GameObject cam1;
    public GameObject cam2;
    private TextMeshProUGUI messageText2;
    private TextMeshProUGUI messageText;
    private Gamepad gamepad;
    public static char thegear = 'p';
    int p = 0;
    int r = 2, l = 2;
    bool flag = true;
    public static char thegear1()
    {
        return thegear;
    }

    void Start()
    {
        gamepad = Gamepad.current;
        if (gears != null)
        {
            messageText = gears.GetComponentInChildren<TextMeshProUGUI>();
        }
        if (stopSignPanel != null)
        {

            messageText2 = stopSignPanel.GetComponentInChildren<TextMeshProUGUI>();
            stopSignPanel.SetActive(false);
        }

    }
    void senseores()
    {
        int n = 0;
        RaycastHit hit;
        Vector3 sensorStartPos = transform.position + transform.forward * frontsensorepos.z + transform.up * frontsensorepos.y;
        if (Physics.Raycast(sensorStartPos, transform.forward, out hit, sensoresleanth))
        {
            if (hit.collider.CompareTag("Banket"))
            {
                if (Mathf.Abs(hit.point.z - sensorStartPos.z) <= 4f && Mathf.Abs(hit.point.x - sensorStartPos.x) <= 4f)
                {
                    n++;

                }
            }
            else if (hit.collider.CompareTag("Ban2"))
            {
                if (messageText2 != null)
                {
                    messageText2.text = "You can't park here; is not a parking area";
                    strikes.incStrike();
                    stopSignPanel.SetActive(true);
                    StartCoroutine(HidePanelAfterDelay(5.0f));
                }

            }

            Debug.DrawLine(sensorStartPos, hit.point);
        }


        if (Physics.Raycast(sensorStartPos, Quaternion.AngleAxis(frontsensoreangle, transform.up) * transform.forward, out hit, sensoresleanth))
        {
            if (hit.collider.CompareTag("Banket"))
            {
                if (!(Mathf.Abs(hit.point.z - sensorStartPos.z) <= 1.023f && Mathf.Abs(hit.point.x - sensorStartPos.x) <= 1.023f))
                {
                    n++;


                }
            }
            else if (hit.collider.CompareTag("Ban2"))
            {
                if (messageText2 != null)
                {

                    messageText2.text = "You can't park here; is not a parking area";
                    strikes.incStrike();
                    stopSignPanel.SetActive(true);
                    StartCoroutine(HidePanelAfterDelay(5.0f));

                }

            }
        }
        if (n != 0)
        {
            if (messageText2 != null)
            {

                messageText2.text = "The distance between the car and the road-side is more than 40cm";
                strikes.incStrike();
                stopSignPanel.SetActive(true);
                StartCoroutine(HidePanelAfterDelay(5.0f));

            }


        }
        flag = false;


    }

    void Update()
    {
        if (thegear == 'P' && flag == true)
        {
            senseores();

        }
        else if (thegear != 'P')
        {
            flag = true;
        }
        if (thegear == 'R')
        {
            cam2.SetActive(true);
            cam1.SetActive(false);
        }
        else
        {
            cam2.SetActive(false);
            cam1.SetActive(true);
        }



        if (messageText != null)
        {
            messageText.text = thegear + "";
        }
        if (gamepad.leftShoulder.wasReleasedThisFrame)
        {

            l = 1;
        }
        if (gamepad.rightShoulder.wasReleasedThisFrame)
        {

            r = 1;
        }

        if (gamepad.leftShoulder.isPressed && gamepad.leftTrigger.isPressed && l >= 1)
        {

            l = 0;
            if (p == 0)
            {


                thegear = 'R';
                p++;
            }
            else if (p == 1)
            {
                thegear = 'N';
                p++;
            }
            else if (p == 2)
            {
                thegear = 'D';
                p++;
            }

        }
        if (gamepad.rightShoulder.isPressed && gamepad.leftTrigger.isPressed && r >= 1)
        {
            r = 0;

            if (p == 1)
            {
                thegear = 'P';
                p--;
            }
            else if (p == 2)
            {
                thegear = 'R';
                p--;
            }
            else if (p == 3)
            {
                thegear = 'N';
                p--;
            }

        }


    }

    IEnumerator HidePanelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        stopSignPanel.SetActive(false);
    }
}