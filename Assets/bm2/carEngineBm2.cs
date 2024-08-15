using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
public class carunginebmwai2 : MonoBehaviour
{
    public Transform path;
    public Transform path2;
    public Transform path3;
    public Transform pathc4;
    public Light greenlight1;
    public Light greenlight2;
    public Light greenlight3;

    public int pathcount = 1;
    private List<Transform> nodes;
    public int currectNode = 0;
    public float maxSteerAngle = 90f;
    public WheelCollider FL;
    public WheelCollider FR;
    public WheelCollider RL;
    public WheelCollider RR;
    public float maxmotortourage = 80f;
    public float maxmbraketourage = 150f;
    public float turnspeed = 5f;
    private float targetsteerangle = 0f;

    public float currentspeed;
    public float maxmimspeed = 100f;
    public Vector3 centerOfMass;
    public bool isbreaking = false;
    [Header("Sensores")]
    public float sensoresleanth = 3f;
    public Vector3 frontsensorepos = new Vector3(0f, 20f, 0f);
    public float sidesensoreposation = 0.3f;
    public float frontsensoreangle = 30f;
    //flags
    int flagforbreak = 0;
    private int ffff = -1;
    private int stop1 = 0;
    int chosenNumber = 2;
    private int stop2 = 0;
    private bool croosroad2 = false;
    private int circlef = 0;
    private int stopcars = 0;
    private int speedcars = 0;
    void Start()
    {
        GetComponent<Rigidbody>().centerOfMass = centerOfMass;
        if (pathcount == 2)
        {
            Transform[] pathTransforms = path2.GetComponentsInChildren<Transform>();
            nodes = new List<Transform>();
            for (int i = 0; i < pathTransforms.Length; i++)
            {
                if (pathTransforms[i] != path2.transform)
                {
                    nodes.Add(pathTransforms[i]);
                }
            }
        }
        else if (pathcount == 3)
        {
            Transform[] pathTransforms = path3.GetComponentsInChildren<Transform>();
            nodes = new List<Transform>();
            for (int i = 0; i < pathTransforms.Length; i++)
            {
                if (pathTransforms[i] != path3.transform)
                {
                    nodes.Add(pathTransforms[i]);

                }
            }

        }
        else if (pathcount == 1)
        {

            Transform[] pathTransforms = path.GetComponentsInChildren<Transform>();
            nodes = new List<Transform>();
            for (int i = 0; i < pathTransforms.Length; i++)
            {
                if (pathTransforms[i] != path.transform)
                {
                    nodes.Add(pathTransforms[i]);

                }
            }
        }
    }

    private void FixedUpdate()
    {
        nnnn();
        senseores();
        ApplySteer();
        Drive();
        checkwaypoindistance();
        breaking();
        if (currentspeed > maxmimspeed && stop1 == 0 && stop2 == 0)
        {
            speedcars = 1;
            isbreaking = true;
        }
        else if (speedcars == 1 && stop1 == 0 && stop2 == 0)
        {
            speedcars = 0;
            isbreaking = false;
        }

    }

    void nnnn()
    {
        if (ffff == currectNode)
        {
            GetComponent<Rigidbody>().centerOfMass = centerOfMass;
            if (pathcount == 2)
            {
                Transform[] pathTransforms = path2.GetComponentsInChildren<Transform>();
                nodes = new List<Transform>();
                for (int i = 0; i < pathTransforms.Length; i++)
                {
                    if (pathTransforms[i] != path2.transform)
                    {
                        nodes.Add(pathTransforms[i]);
                    }
                }
            }
            else if (pathcount == 3)
            {
                Transform[] pathTransforms = path3.GetComponentsInChildren<Transform>();
                nodes = new List<Transform>();
                for (int i = 0; i < pathTransforms.Length; i++)
                {
                    if (pathTransforms[i] != path3.transform)
                    {
                        nodes.Add(pathTransforms[i]);

                    }
                }

            }
            else if (pathcount == 1)
            {

                Transform[] pathTransforms = path.GetComponentsInChildren<Transform>();
                nodes = new List<Transform>();
                for (int i = 0; i < pathTransforms.Length; i++)
                {
                    if (pathTransforms[i] != path.transform)
                    {
                        nodes.Add(pathTransforms[i]);

                    }
                }
            }
        }
        else
        {
            ffff = currectNode;
            //  من تحت المفرق الاول
            //   تقاطع الايمن فوق الدوار للذهاب شمال

            if (currectNode == 65 && pathcount == 1)
            {//done2

                if (chosenNumber == 0)
                {
                    Transform[] pathTransforms = path3.GetComponentsInChildren<Transform>();
                    nodes = new List<Transform>();
                    for (int i = 0; i < pathTransforms.Length; i++)
                    {
                        if (pathTransforms[i] != path3.transform)
                        {
                            nodes.Add(pathTransforms[i]);

                        }
                    }
                    currectNode = 2;
                    pathcount = 3;
                }
            }
            if (currectNode == 60 && pathcount == 1)
            {
                chosenNumber = forchoosennumber();
                if (chosenNumber == 0)
                {
                    leftsidebmw2.SetAutoToggle(true);

                }
            }
            if (currectNode == 4 && pathcount == 3)
            {
                leftsidebmw2.SetAutoToggle(false);

            }
            // المفرق الاول من فوق
            //   تقاطع الايمن فوق الدوار للذهاب امام
            if (currectNode == 70 && pathcount == 3)
            {

                if (chosenNumber == 1)
                {
                    Transform[] pathTransforms = path2.GetComponentsInChildren<Transform>();
                    nodes = new List<Transform>();
                    for (int i = 0; i < pathTransforms.Length; i++)
                    {
                        if (pathTransforms[i] != path2.transform)
                        {
                            nodes.Add(pathTransforms[i]);

                        }
                    }
                    currectNode = 54;
                    pathcount = 2;
                }
            }
            if (currectNode == 67 && pathcount == 3)
            {
                chosenNumber = forchoosennumber();
                if (chosenNumber == 0)
                    rightsidebmw2.SetAutoToggle(true);
            }

            if (currectNode == 4 && pathcount == 3)
            {
                rightsidebmw2.SetAutoToggle(false);

            }
            //   تقاطع الايمن فوق الدوار للذهاب الامام
            if (currectNode == 48 && pathcount == 2)
            {
                if (chosenNumber == 0)
                {
                    Transform[] pathTransforms = path.GetComponentsInChildren<Transform>();
                    nodes = new List<Transform>();
                    for (int i = 0; i < pathTransforms.Length; i++)
                    {
                        if (pathTransforms[i] != path.transform)
                        {
                            nodes.Add(pathTransforms[i]);

                        }
                    }
                    currectNode = 66;
                    pathcount = 1;
                }

            }

            if (currectNode == 44 && pathcount == 2)
            {
                chosenNumber = forchoosennumber();
                if (chosenNumber == 0)
                {
                    leftsidebmw2.SetAutoToggle(true);
                }
                else
                {
                    rightsidebmw2.SetAutoToggle(true);
                }
            }
            if (currectNode == 54 && pathcount == 2)
            {
                stop2 = 0;

                rightsidebmw2.SetAutoToggle(false);

            }
            if (currectNode == 67 && pathcount == 1)
            {
                stop2 = 0;
                leftsidebmw2.SetAutoToggle(false);

            }
            // the seconed crros roads2
            //   تقاطع الاوسط فوق الدوار للذهاب شمال
            if (currectNode == 30 && pathcount == 2)
            {//done2
                stop1 = 0;
                if (chosenNumber == 0)
                {
                    Transform[] pathTransforms = path3.GetComponentsInChildren<Transform>();
                    nodes = new List<Transform>();
                    for (int i = 0; i < pathTransforms.Length; i++)
                    {
                        if (pathTransforms[i] != path3.transform)
                        {
                            nodes.Add(pathTransforms[i]);

                        }
                    }
                    currectNode = 20;
                    pathcount = 3;
                }
            }

            if (currectNode == 27 && pathcount == 2)
            {
                chosenNumber = forchoosennumber();
                if (chosenNumber == 0)
                {
                    leftsidebmw2.SetAutoToggle(true);

                }
                else
                {
                    rightsidebmw2.SetAutoToggle(true);

                }
            }
            if (currectNode == 37 && pathcount == 2)
            {
                rightsidebmw2.SetAutoToggle(false);
            }
            if (currectNode == 22 && pathcount == 3)
            {
                leftsidebmw2.SetAutoToggle(false);
            }
            //المفرق الثاني عشان ادخل للدوار
            if (currectNode == 19 && pathcount == 3)
            {
                if (chosenNumber == 0)
                {
                    Transform[] pathTransforms = path.GetComponentsInChildren<Transform>();
                    nodes = new List<Transform>();
                    for (int i = 0; i < pathTransforms.Length; i++)
                    {
                        if (pathTransforms[i] != path.transform)
                        {
                            nodes.Add(pathTransforms[i]);

                        }
                    }
                    currectNode = 163;
                    pathcount = 1;
                }
            }
            if (currectNode == 15 && pathcount == 3)
            {
                chosenNumber = forchoosennumber();
                if (chosenNumber == 0)
                    leftsidebmw2.SetAutoToggle(true);
            }
            if (currectNode == 164 && pathcount == 1)
            {
                leftsidebmw2.SetAutoToggle(false);

            }
            //   تقاطع الاوسط فوق الدوار للذهاب امام
            if (currectNode == 154 && pathcount == 1)
            {
                chosenNumber = forchoosennumber();
                if (chosenNumber == 1)
                {
                    Transform[] pathTransforms = path2.GetComponentsInChildren<Transform>();
                    nodes = new List<Transform>();
                    for (int i = 0; i < pathTransforms.Length; i++)
                    {
                        if (pathTransforms[i] != path2.transform)
                        {
                            nodes.Add(pathTransforms[i]);

                        }
                    }
                    currectNode = 32;
                    pathcount = 2;
                }
                else
                {
                    rightsidebmw2.SetAutoToggle(true);
                }
            }
            if (currectNode == 164 && pathcount == 1)
            {
                rightsidebmw2.SetAutoToggle(false);

            }
            //the end of  seconed crros roads2
            //the thired road croos
            if (currectNode == 195 && pathcount == 1)
            {

                if (chosenNumber == 1)
                {
                    leftsidebmw2.SetAutoToggle(true);

                    Transform[] pathTransforms = path3.GetComponentsInChildren<Transform>();
                    nodes = new List<Transform>();
                    for (int i = 0; i < pathTransforms.Length; i++)
                    {
                        if (pathTransforms[i] != path3.transform)
                        {
                            nodes.Add(pathTransforms[i]);

                        }
                    }
                    currectNode = 33;
                    pathcount = 3;
                }
                else
                {
                    rightsidebmw2.SetAutoToggle(true);
                    Transform[] pathTransforms = path.GetComponentsInChildren<Transform>();
                    nodes = new List<Transform>();
                    for (int i = 0; i < pathTransforms.Length; i++)
                    {
                        if (pathTransforms[i] != path.transform)
                        {
                            nodes.Add(pathTransforms[i]);

                        }
                    }
                    currectNode = 144;
                }
            }

            if (currectNode == 34 && pathcount == 3)
            {

                leftsidebmw2.SetAutoToggle(false);
            }
            if (currectNode == 146 && pathcount == 1)
            {
                rightsidebmw2.SetAutoToggle(false);
            }
            // the circle
            if (currectNode == 103 && pathcount == 2)//done2
            {
                circlef = 2;
                chosenNumber = forchoosennumbercircle();
                if (chosenNumber == 2)
                {
                    leftsidebmw2.SetAutoToggle(true);
                }
                else if (chosenNumber == 1)
                    rightsidebmw2.SetAutoToggle(true);
            }
            if (currectNode == 22 && pathcount == 1)
            {
                leftsidebmw2.SetAutoToggle(false);

            }
            if (currectNode == 105 && pathcount == 2)
            {

                Transform[] pathTransforms = path2.GetComponentsInChildren<Transform>();
                nodes = new List<Transform>();
                for (int i = 0; i < pathTransforms.Length; i++)
                {
                    if (pathTransforms[i] != path2.transform)
                    {
                        nodes.Add(pathTransforms[i]);

                    }
                }
                currectNode = 2;
                pathcount = 2;
            }
            if (pathcount == 2 && currectNode == 7)
            {
                leftsidebmw2.SetAutoToggle(false);
            }
            if (currectNode == 3 && pathcount == 2)
            {

                if ((chosenNumber == 0 || (chosenNumber == 2 && circlef == 2)) && circlef != 3)
                {

                    Transform[] pathTransforms = path.GetComponentsInChildren<Transform>();
                    nodes = new List<Transform>();
                    for (int i = 0; i < pathTransforms.Length; i++)
                    {
                        if (pathTransforms[i] != path.transform)
                        {
                            nodes.Add(pathTransforms[i]);

                        }
                    }
                    currectNode = 179;
                    pathcount = 1;
                }
            }
            if (currectNode == 175 && pathcount == 1)//done2
            {
                circlef = 3;
                chosenNumber = forchoosennumbercircle();
                if (chosenNumber == 2 || chosenNumber == 0)
                {
                    leftsidebmw2.SetAutoToggle(true);
                }
                else if (chosenNumber == 1)
                    rightsidebmw2.SetAutoToggle(true);
            }
            if (currectNode == 22 && pathcount == 1)
            {
                leftsidebmw2.SetAutoToggle(false);

            }

            if (currectNode == 181 && pathcount == 1)
            {
                if (chosenNumber == 2 || (chosenNumber == 0 && circlef == 3))
                {
                    Transform[] pathTransforms = pathc4.GetComponentsInChildren<Transform>();
                    nodes = new List<Transform>();
                    for (int i = 0; i < pathTransforms.Length; i++)
                    {
                        if (pathTransforms[i] != pathc4.transform)
                        {
                            nodes.Add(pathTransforms[i]);

                        }
                    }
                    currectNode = 0;
                    pathcount = 4;
                }

            }
            if (currectNode == 8 && pathcount == 4)
            {
                if (chosenNumber == 2 && circlef == 2 || chosenNumber == 2 && circlef == 3)
                {
                    Transform[] pathTransforms = path.GetComponentsInChildren<Transform>();
                    nodes = new List<Transform>();
                    for (int i = 0; i < pathTransforms.Length; i++)
                    {
                        if (pathTransforms[i] != path.transform)
                        {
                            nodes.Add(pathTransforms[i]);

                        }
                    }
                    currectNode = 17;
                    pathcount = 1;
                }
                else
                {
                    Transform[] pathTransforms = path2.GetComponentsInChildren<Transform>();
                    nodes = new List<Transform>();
                    for (int i = 0; i < pathTransforms.Length; i++)
                    {
                        if (pathTransforms[i] != path2.transform)
                        {
                            nodes.Add(pathTransforms[i]);

                        }
                    }
                    currectNode = 0;
                    pathcount = 2;
                }

            }



            // الدوار لفوق
            if (currectNode == 22 && pathcount == 1)
            {
                rightsidebmw2.SetAutoToggle(false);

            }
            if (currectNode == 183 && pathcount == 1)
            {
                leftsidebmw2.SetAutoToggle(false);
                rightsidebmw2.SetAutoToggle(false);
            }
            if (currectNode == 13 && pathcount == 1)
            {
                circlef = 1;

                chosenNumber = forchoosennumbercircle();
                if (chosenNumber == 0)
                    leftsidebmw2.SetAutoToggle(true);
                else if (chosenNumber == 1)
                    rightsidebmw2.SetAutoToggle(true);
            }
            if (currectNode == 17 && pathcount == 1)
            {
                if ((chosenNumber == 2 && circlef == 1) || chosenNumber == 0)
                {
                    Transform[] pathTransforms = path2.GetComponentsInChildren<Transform>();
                    nodes = new List<Transform>();
                    for (int i = 0; i < pathTransforms.Length; i++)
                    {
                        if (pathTransforms[i] != path2.transform)
                        {
                            nodes.Add(pathTransforms[i]);

                        }
                    }
                    currectNode = 0;
                    pathcount = 2;
                }

            }

        }
    }
     void senseores()
    {


        RaycastHit hit;
        Vector3 sensorStartPos = transform.position;
        sensorStartPos += transform.forward * frontsensorepos.z;
        sensorStartPos += transform.up * frontsensorepos.y;
        sensorStartPos += transform.right * sidesensoreposation;
        if (Physics.Raycast(sensorStartPos, transform.forward, out hit, sensoresleanth))
        {
 if (hit.collider.CompareTag("speed80"))
 {
maxmimspeed = 50f;
 }
 if (hit.collider.CompareTag("speed50"))
 {
maxmimspeed = 30f;
 }

            if (hit.collider.CompareTag("check2"))
      {
        Vector3 hitNormal = hit.normal;
        hitNormal = hit.transform.TransformDirection(hitNormal);
        
         if (Vector3.Angle(hitNormal, hit.transform.right) <= 45)
        {
          if (circletraffic2.isenterdd() == 1)
          {
            float dstop = (currentspeed * currentspeed) / (2 * (maxmbraketourage - maxmotortourage));

            if (-1 * (hit.point.x - sensorStartPos.x) <= dstop && currentspeed > 0)
            { isbreaking = true; }
          }
          else if (circletraffic2.isenterdd() == 0)
          {
              isbreaking = false;
          }
          Debug.DrawLine(sensorStartPos, hit.point);
        }
      }

            if (hit.collider.CompareTag("check3"))
            {
                Vector3 hitNormal = hit.normal;
                hitNormal = hit.transform.TransformDirection(hitNormal);
                if (Vector3.Angle(hitNormal, hit.transform.forward) <= 45)
                {
                    if (circletraffic3.isenterdd() == 1)
                    {
                        float dstop = (currentspeed * currentspeed) / (2 * (maxmbraketourage - maxmotortourage));
                        if (-1 * (hit.point.z - sensorStartPos.z) <= dstop && currentspeed > 0)
                        { isbreaking = true; }
                    }

                    else if (circletraffic3.isenterdd() == 0)
                    {
                            isbreaking = false;
                         
                    }
                    Debug.DrawLine(sensorStartPos, hit.point);



                }
            }

            if (hit.collider.CompareTag("light1"))
            {
                Vector3 hitNormal = hit.normal;
                hitNormal = hit.transform.TransformDirection(hitNormal);
             
                 if (Vector3.Angle(hitNormal, -hit.transform.forward) <= 45)
                {
                    if (greenlight1.enabled == false)
                    {
                        float dstop = (currentspeed * currentspeed) / (2 * (maxmbraketourage - maxmotortourage));
                        if (hit.point.z - sensorStartPos.z <= dstop && currentspeed > 0)
                        { isbreaking = true; }
                    }
                    else if (greenlight1.enabled == true)
                    {
                            isbreaking = false;
                    }
                    Debug.DrawLine(sensorStartPos, hit.point);

                }


            }
            //2
            if (hit.collider.CompareTag("light2"))
            {
                Vector3 hitNormal = hit.normal;
                hitNormal = hit.transform.TransformDirection(hitNormal);
               if (Vector3.Angle(hitNormal, hit.transform.right) <= 45)
                {
                    if (greenlight2.enabled == false)
                    {
                        float dstop = (currentspeed * currentspeed) / (2 * (maxmbraketourage - maxmotortourage));
                        if (-1 * (hit.point.x - sensorStartPos.x) <= dstop && currentspeed > 0)
                        { isbreaking = true; }
                    }
                    else if (greenlight2.enabled == true)
                    {
                            isbreaking = false;
                    }
                    Debug.DrawLine(sensorStartPos, hit.point);

                }

            }
            if (hit.collider.CompareTag("light3"))
            {
                Vector3 hitNormal = hit.normal;
                hitNormal = hit.transform.TransformDirection(hitNormal);
              if (Vector3.Angle(hitNormal, -hit.transform.right) <= 45)
                {

                    if (greenlight3.enabled == false)
                    {
                        float dstop = (currentspeed * currentspeed) / (2 * (maxmbraketourage - maxmotortourage));
                        if ((hit.point.x - sensorStartPos.x) <= dstop && currentspeed > 0)
                        { isbreaking = true; }
                    }
                    else if (greenlight3.enabled == true)
                    {
                            isbreaking = false;
                        
                    }
                    Debug.DrawLine(sensorStartPos, hit.point);
                }



            }
            // stops
            if (hit.collider.CompareTag("STOP2"))
            {

                Vector3 hitNormal = hit.normal;
                hitNormal = hit.transform.TransformDirection(hitNormal);
               if (Vector3.Angle(hitNormal, -hit.transform.right) <= 45)
                {
                    float d = (currentspeed * currentspeed) / (2 * (maxmbraketourage - maxmotortourage));
                    if (hit.point.x - sensorStartPos.x <= d && stop2 == 0)
                    {
                        stop2 = 1;
                        StartCoroutine(StopAtStopSign());
                    }
                    if (chosenNumber == 1)
                    {
                        if (aileftcross1.isenterdd() == 1 && croosroad2 == true)
                        {
                            float dstop = (currentspeed * currentspeed) / (2 * (maxmbraketourage - maxmotortourage));
                            if (hit.point.x - sensorStartPos.x <= dstop)
                            { isbreaking = true; }
                        }
                        else if (aileftcross1.isenterdd() == 0 && croosroad2 == true)
                        {
                            isbreaking = false;
                            croosroad2 = false;

                        }
                    }
                    else if (chosenNumber == 0)
                    {
                        if (aileftcross1.isenterdd() == 1 && croosroad2 == true && airightcross1.isenterdd() == 1)
                        {
                            float dstop = (currentspeed * currentspeed) / (2 * (maxmbraketourage - maxmotortourage));
                            if (hit.point.x - sensorStartPos.x <= dstop)
                            { isbreaking = true; }
                        }
                        else if (aileftcross1.isenterdd() == 0 && croosroad2 == true && airightcross1.isenterdd() == 0)
                        {
                            isbreaking = false;
                            croosroad2 = false;

                        }

                    }
                  
                    Debug.DrawLine(sensorStartPos, hit.point);
                }

            }



            if (hit.collider.CompareTag("STOP"))
            {
                Vector3 hitNormal = hit.normal;
                hitNormal = hit.transform.TransformDirection(hitNormal);
              if (Vector3.Angle(hitNormal, -hit.transform.forward) <= 45)
                {
                    float d = (currentspeed * currentspeed) / (2 * (maxmbraketourage - maxmotortourage));
                    if (hit.point.z - sensorStartPos.z <= d && stop1 == 0)
                    {
                        stop1 = 1;
                        StartCoroutine(StopAtStopSign());
                    }
                    if (chosenNumber == 1)
                    {
                        if (aileftcross2.isenterdd() == 1 && croosroad2 == true)
                        {
                            float dstop = (currentspeed * currentspeed) / (2 * (maxmbraketourage - maxmotortourage));
                            if (hit.point.z - sensorStartPos.z <= dstop && currentspeed > 0)
                            { isbreaking = true; }
                        }
                        else if (aileftcross2.isenterdd() == 0 && croosroad2 == true)
                        {
                            isbreaking = false;
                            croosroad2 = false;

                        }
                    }
                    else if (chosenNumber == 0)
                    {
                        if (aileftcross2.isenterdd() == 1 && croosroad2 == true && airightcross2.isenterdd() == 1)
                        {
                            float dstop = (currentspeed * currentspeed) / (2 * (maxmbraketourage - maxmotortourage));
                            if (hit.point.z - sensorStartPos.z <= dstop && currentspeed > 0)
                            { isbreaking = true; }
                        }
                        else if (aileftcross2.isenterdd() == 0 && croosroad2 == true && airightcross2.isenterdd() == 0)
                        {
                            isbreaking = false;
                            croosroad2 = false;

                        }

                    }
                    Debug.DrawLine(sensorStartPos, hit.point);
                }

            }

            else if (hit.collider.CompareTag("crros road1") && currectNode == 39 && pathcount == 2)
            {

                float d = (currentspeed * currentspeed) / (2 * (maxmbraketourage - maxmotortourage));
                if (hit.point.z - sensorStartPos.z <= d)
                {
                    isbreaking = true;
                }
                Debug.DrawLine(sensorStartPos, hit.point);
            }
            if (hit.collider.CompareTag("CARS"))
            {
             
                Vector3 hitNormal = hit.normal;
                hitNormal = hit.transform.TransformDirection(hitNormal);

                if (Mathf.Abs(hit.point.z - sensorStartPos.z) <= 4f && Mathf.Abs(hit.point.x - sensorStartPos.x) <= 4f)
                {
                    stopcars = 1;
                    isbreaking = true;
                }
                Debug.DrawLine(sensorStartPos, hit.point);
            }

            if (stopcars == 1 && hit.collider.CompareTag("CARS") == false)
            {
                stopcars = 0;
                isbreaking = false;
            }
        }
        else if (stopcars == 1)
        {
            isbreaking = false;
        }
             if (Physics.Raycast(sensorStartPos, Quaternion.AngleAxis(-frontsensoreangle, transform.up) * transform.forward, out hit, sensoresleanth)&&false)
        {
            Debug.DrawLine(sensorStartPos, hit.point);
       
            if (hit.collider.CompareTag("CARS")&&circle.get()==true)
            {
                if (Mathf.Abs(hit.point.z - sensorStartPos.z) <= 8f && Mathf.Abs(hit.point.x - sensorStartPos.x) <= 8f)
                {
                    //maxmimspeed = 20f;
                }

                Vector3 hitNormal = hit.normal;
                hitNormal = hit.transform.TransformDirection(hitNormal);

                if (Mathf.Abs(hit.point.z - sensorStartPos.z) <= 4f && Mathf.Abs(hit.point.x - sensorStartPos.x) <= 4f)
                {
                    stopcars = 1;
                    isbreaking = true;
                }
            }

            if (stopcars == 1 && hit.collider.CompareTag("CARS") == false)
            {
                
                stopcars = 0;
                isbreaking = false;
            }
        }

    }
    private void ApplySteer()
    {

        if (!(currectNode < 0 || currectNode >= nodes.Count))
        {
            Vector3 relativeVector = transform.InverseTransformPoint(nodes[currectNode].position);
            float newSteer = (relativeVector.x / relativeVector.magnitude) * maxSteerAngle;

            FL.steerAngle = newSteer;
            FR.steerAngle = newSteer;
        }
    }
    void Drive()
    {
        currentspeed = 2 * Mathf.PI * FL.radius * FL.rpm * 60 / 1000;
        if (currentspeed < maxmimspeed && !isbreaking)
        {
            FL.motorTorque = maxmotortourage;
            FR.motorTorque = maxmotortourage;

        }
        else
        {
            FL.motorTorque = 0;
            FR.motorTorque = 0;
        }


    }
    void checkwaypoindistance()
    {
        if (!(currectNode < 0 || currectNode >= nodes.Count))
        {
            if (Vector3.Distance(transform.position, nodes[currectNode].position) < 0.35f)
            {
                if (currectNode == (nodes.Count - 1))
                    currectNode = 0;
                else
                    currectNode++;
            }
        }
    }
    void breaking()
    {
        if (isbreaking)
        {
            RL.brakeTorque = maxmbraketourage;
            RR.brakeTorque = maxmbraketourage;

        }
        else
        {
            RL.brakeTorque = 0;
            RR.brakeTorque = 0;

        }
    }
    void LerptoSteerangle()
    {
        FR.steerAngle = Mathf.Lerp(FR.steerAngle, targetsteerangle, Time.deltaTime * turnspeed);
        FL.steerAngle = Mathf.Lerp(FL.steerAngle, targetsteerangle, Time.deltaTime * turnspeed);

    }
    private IEnumerator StopAtStopSign()
    {
        isbreaking = true;
        yield return new WaitForSeconds(5);
        croosroad2 = true;
    }
    public int forchoosennumber()
    {
        int a = 0;
        int b = 1;
        System.Random rand = new System.Random();
        int chosenNumber = rand.Next(a, b + 1);
        return chosenNumber;
    }
    public int forchoosennumbercircle()
    {
        int a = 0;
        int b = 2;
        System.Random rand = new System.Random();
        int chosenNumber = rand.Next(a, b + 1); 
        return chosenNumber;
    }
    public int noddes
    {

        get { return currectNode; }
    }

}