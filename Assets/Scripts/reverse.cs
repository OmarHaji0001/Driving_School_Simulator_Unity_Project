using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class CarController2 : MonoBehaviour
{
    public PrometeoCarController car;
    public GameObject ai1;
    public GameObject PanelControl;

    private Stack<Vector3> positions;
    private Stack<Quaternion> rotations;
    public float recordTime = 5.0f;
    private float timer;

    private Stack<Vector3> positionsai1;
    private Stack<Quaternion> rotationsai1;
    private Stack<int> currentnodeai1;
    private Stack<int> currentpathai1;
    public carungine ai;
    int thepath = 1;

    private Stack<Vector3> positionsbmw;
    private Stack<Quaternion> rotationsbmw;
    private Stack<int> currentnodebmw;
    private Stack<int> currentpathbmw;
    public carunginebmwai bmw;
    int thepathbmw = 1;

    private Stack<Vector3> positionsbmw2;
    private Stack<Quaternion> rotationsbmw2;
    private Stack<int> currentnodebmw2;
    private Stack<int> currentpathbmw2;
    public carunginebmwai2 bmw2;
    int thepathbmw2 = 1;

    private Stack<Vector3> positionscaymen;
    private Stack<Quaternion> rotationscaymen;
    private Stack<int> currentnodecaymen;
    private Stack<int> currentpathcaymen;
    public carunginecaymen caymen;
    int thepathcaymen = 1;

    private Stack<Vector3> positionscaymen2;
    private Stack<Quaternion> rotationscaymen2;
    private Stack<int> currentnodecaymen2;
    private Stack<int> currentpathcaymen2;
    public carunginecaymen2 caymen2;
    int thepathcaymen2 = 1;

    private bool flagcrros = false;
    private bool flagcircle = false;
    public GameObject thePanel;
    public GameObject thePanel2;
    private TextMeshProUGUI messageText;
    private TextMeshProUGUI messageText2;
    private int fff = 1;
    static int hantuliFlags = 0;
    void Start()
    {
        if (thePanel != null)
        {
            messageText = thePanel.GetComponentInChildren<TextMeshProUGUI>();
            thePanel.SetActive(false);
            messageText2 = thePanel2.GetComponentInChildren<TextMeshProUGUI>();
            thePanel2.SetActive(false);
        }
        positions = new Stack<Vector3>();
        rotations = new Stack<Quaternion>();

        positionsai1 = new Stack<Vector3>();
        rotationsai1 = new Stack<Quaternion>();
        currentnodeai1 = new Stack<int>();
        currentpathai1 = new Stack<int>();

        positionsbmw = new Stack<Vector3>();
        rotationsbmw = new Stack<Quaternion>();
        currentnodebmw = new Stack<int>();
        currentpathbmw = new Stack<int>();

        positionsbmw2 = new Stack<Vector3>();
        rotationsbmw2 = new Stack<Quaternion>();
        currentnodebmw2 = new Stack<int>();
        currentpathbmw2 = new Stack<int>();

        positionscaymen = new Stack<Vector3>();
        rotationscaymen = new Stack<Quaternion>();
        currentnodecaymen = new Stack<int>();
        currentpathcaymen = new Stack<int>();

        positionscaymen2 = new Stack<Vector3>();
        rotationscaymen2 = new Stack<Quaternion>();
        currentnodecaymen2 = new Stack<int>();
        currentpathcaymen2 = new Stack<int>();

    }

    void Update()
    {

        {
            //Pushing to the stacks
            positions.Push(transform.position);
            rotations.Push(transform.rotation);

            positionsai1.Push(ai1.transform.position);
            rotationsai1.Push(ai1.transform.rotation);
            currentnodeai1.Push(ai.currectNode);
            currentpathai1.Push(ai.pathcount);

            positionsbmw.Push(bmw.transform.position);
            rotationsbmw.Push(bmw.transform.rotation);
            currentnodebmw.Push(bmw.currectNode);
            currentpathbmw.Push(bmw.pathcount);

            positionsbmw2.Push(bmw2.transform.position);
            rotationsbmw2.Push(bmw2.transform.rotation);
            currentnodebmw2.Push(bmw2.currectNode);
            currentpathbmw2.Push(bmw2.pathcount);

            positionscaymen.Push(caymen.transform.position);
            rotationscaymen.Push(caymen.transform.rotation);
            currentnodecaymen.Push(caymen.currectNode);
            currentpathcaymen.Push(caymen.pathcount);

            positionscaymen2.Push(caymen2.transform.position);
            rotationscaymen2.Push(caymen2.transform.rotation);
            currentnodecaymen2.Push(caymen2.currectNode);
            currentpathcaymen2.Push(caymen2.pathcount);
        }

        if (flagrevarse.getff() == 1)
        {
            hantuliFlags = 1;
            PanelControl.SetActive(false);
            if (fff == 0 || messageText2.text == messageText.text)
            {
                fff = 1;
                thePanel2.SetActive(true);
                messageText2.text = messageText.text;

            }

            rightsideai1.SetAutoToggle(false);
            rightsideai1.SetAutoToggle(false);
            float absoluteCarSpeed = Mathf.Abs(car.carSpeed);
            StartCoroutine(breaking());
            StartCoroutine(ReverseMovement());

        }

    }

    IEnumerator breaking()
    {

        float maxDuration = 0.15f;
        float elapsed = 0f;
        while (elapsed < maxDuration)
        {
            yield return null;

            elapsed += Time.deltaTime;

        }
        flagrevarse.setff(0);
        GameObject objectToStop = GameObject.FindGameObjectWithTag("Car");
        if (objectToStop != null)
        {

            Rigidbody rb = objectToStop.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }
        }
    }
    IEnumerator ReverseMovement()
    {

        float maxDuration = 0.4f;
        float elapsed = 0f;
        int flagcircle2 = 0;
        while (elapsed < maxDuration && positions.Count > 0 && rotations.Count > 0 && flagcircle2 == 0)
        {
            if (pauseMenu.IsGamePaused())
            {
                yield return null;
                continue;
            }
            transform.position = positions.Pop();
            transform.rotation = rotations.Pop();
            ai1.transform.position = positionsai1.Pop();
            ai1.transform.rotation = rotationsai1.Pop();
            ai.currectNode = currentnodeai1.Pop();
            {
                ai.pathcount = currentpathai1.Pop();
            }
            bmw.transform.position = positionsbmw.Pop();
            bmw.transform.rotation = rotationsbmw.Pop();
            bmw.currectNode = currentnodebmw.Pop();

            bmw.pathcount = currentpathbmw.Pop();
            caymen.transform.position = positionscaymen.Pop();
            caymen.transform.rotation = rotationscaymen.Pop();
            caymen.currectNode = currentnodecaymen.Pop();

            caymen.pathcount = currentpathcaymen.Pop();

            bmw2.transform.position = positionsbmw2.Pop();
            bmw2.transform.rotation = rotationsbmw2.Pop();
            bmw2.currectNode = currentnodebmw2.Pop();

            bmw2.pathcount = currentpathbmw2.Pop();

            caymen2.transform.position = positionscaymen2.Pop();
            caymen2.transform.rotation = rotationscaymen2.Pop();
            caymen2.currectNode = currentnodecaymen2.Pop();

            caymen2.pathcount = currentpathcaymen2.Pop();

            yield return null;

            elapsed += Time.deltaTime;

        }
        while ((circle.get() == true) && positions.Count > 0 && rotations.Count > 0)
        {
            if (pauseMenu.IsGamePaused())
            {
                yield return null;
                continue;
            }
            flagcircle2 = 1;
            //Popping the stacks
            transform.position = positions.Pop();
            transform.rotation = rotations.Pop();

            ai1.transform.position = positionsai1.Pop();
            ai1.transform.rotation = rotationsai1.Pop();
            ai.currectNode = currentnodeai1.Pop();
            ai.pathcount = currentpathai1.Pop();


            bmw.transform.position = positionsbmw.Pop();
            bmw.transform.rotation = rotationsbmw.Pop();
            bmw.currectNode = currentnodebmw.Pop();

            bmw.pathcount = currentpathbmw.Pop();

            bmw2.transform.position = positionsbmw2.Pop();
            bmw2.transform.rotation = rotationsbmw2.Pop();
            bmw2.currectNode = currentnodebmw2.Pop();

            bmw2.pathcount = currentpathbmw2.Pop();

            caymen.transform.position = positionscaymen.Pop();
            caymen.transform.rotation = rotationscaymen.Pop();
            caymen.currectNode = currentnodecaymen.Pop();

            caymen.pathcount = currentpathcaymen.Pop();


            caymen2.transform.position = positionscaymen2.Pop();
            caymen2.transform.rotation = rotationscaymen2.Pop();
            caymen2.currectNode = currentnodecaymen2.Pop();

            caymen2.pathcount = currentpathcaymen2.Pop();

            yield return null;

            elapsed += Time.deltaTime;


        }
        while ((stoprewind.get() == true) && positions.Count > 0 && rotations.Count > 0)
        {


            if (pauseMenu.IsGamePaused())
            {
                yield return null;
                continue;
            }
            flagcircle2 = 1;
            transform.position = positions.Pop();
            transform.rotation = rotations.Pop();

            ai1.transform.position = positionsai1.Pop();
            ai1.transform.rotation = rotationsai1.Pop();
            ai.currectNode = currentnodeai1.Pop();

            ai.pathcount = currentpathai1.Pop();


            bmw.transform.position = positionsbmw.Pop();
            bmw.transform.rotation = rotationsbmw.Pop();
            bmw.currectNode = currentnodebmw.Pop();

            bmw.pathcount = currentpathbmw.Pop();

            bmw2.transform.position = positionsbmw2.Pop();
            bmw2.transform.rotation = rotationsbmw2.Pop();
            bmw2.currectNode = currentnodebmw2.Pop();

            bmw2.pathcount = currentpathbmw2.Pop();

            caymen.transform.position = positionscaymen.Pop();
            caymen.transform.rotation = rotationscaymen.Pop();
            caymen.currectNode = currentnodecaymen.Pop();

            caymen.pathcount = currentpathcaymen.Pop();


            caymen2.transform.position = positionscaymen2.Pop();
            caymen2.transform.rotation = rotationscaymen2.Pop();
            caymen2.currectNode = currentnodecaymen2.Pop();

            caymen2.pathcount = currentpathcaymen2.Pop();

            yield return null;

            elapsed += Time.deltaTime;


        }
        while (crross1.get() == true && positions.Count > 0 && rotations.Count > 0)
        {
            if (pauseMenu.IsGamePaused())
            {
                yield return null;
                continue;
            }
            flagcircle2 = 1;
            transform.position = positions.Pop();
            transform.rotation = rotations.Pop();
            ai1.transform.position = positionsai1.Pop();
            ai1.transform.rotation = rotationsai1.Pop();
            ai.currectNode = currentnodeai1.Pop();
            {
                ai.pathcount = currentpathai1.Pop();
            }
            bmw.transform.position = positionsbmw.Pop();
            bmw.transform.rotation = rotationsbmw.Pop();
            bmw.currectNode = currentnodebmw.Pop();

            bmw.pathcount = currentpathbmw.Pop();

            caymen.transform.position = positionscaymen.Pop();
            caymen.transform.rotation = rotationscaymen.Pop();
            caymen.currectNode = currentnodecaymen.Pop();

            caymen.pathcount = currentpathcaymen.Pop();


            caymen2.transform.position = positionscaymen2.Pop();
            caymen2.transform.rotation = rotationscaymen2.Pop();
            caymen2.currectNode = currentnodecaymen2.Pop();

            caymen2.pathcount = currentpathcaymen2.Pop();

            bmw2.transform.position = positionsbmw2.Pop();
            bmw2.transform.rotation = rotationsbmw2.Pop();
            bmw2.currectNode = currentnodebmw2.Pop();

            bmw2.pathcount = currentpathbmw2.Pop();

            yield return null;
            elapsed += Time.deltaTime;

        }

        ai.isbreaking = false;
        flagrevarse.setff(0);

        if (flagcrros == true)
        {
            flagcrros = false;

        }
        if (flagcircle == true)
        {
            flagcircle = false;

        }
        flagcircle2 = 0;
        messageText.text = "null";
        PanelControl.SetActive(true);
        thePanel.SetActive(false);

        if (fff == 1 && messageText2.text == messageText.text)
        {
            fff = 0;
        }
        hantuliFlags = 0;
    }
    public static int getHantuliFlags()
    {
        return hantuliFlags;
    }

}