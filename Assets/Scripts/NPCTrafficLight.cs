using UnityEngine;
using System.Collections.Generic;

public class npcintrafficlight : MonoBehaviour
{
    public List<Transform> nodes;
    private int currentNodeIndex = 0;
    private float speed = 1.0f;
    public Light light1;
    public Light light2;
    public float sensoresleanth = 3f;
    public Vector3 frontsensorepos = new Vector3(0f, 20f, 0f);
    private bool isMoving = true;
    private bool hasRotated = false;
    private bool isFirstVisit = true;

    void Start()
    {
        if (nodes.Count != 4)
        {
            Debug.LogError("Exactly four nodes required.");
        }
    }

    void Update()
    {
        if (nodes.Count == 4)
        {
            MoveTowardsTarget();
            senseores();
        }
    }

    private void MoveTowardsTarget()
    {
        if (!isMoving)
        {
            return;
        }
        Transform target = nodes[currentNodeIndex];
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target.position) < 0.1f)
        {
            if (!hasRotated && (currentNodeIndex != 0 || !isFirstVisit))
            {
                RotateAtNode();
                hasRotated = true;
            }
            CheckCrossings();
        }
    }

    private void RotateAtNode()
    {
        transform.Rotate(0, 90, 0);
    }

    void senseores()
    {
        RaycastHit hit;
        Vector3 sensorStartPos = transform.position + transform.forward * frontsensorepos.z + transform.up * frontsensorepos.y;
        if (Physics.Raycast(sensorStartPos, transform.forward, out hit, sensoresleanth))
        {
            if (hit.collider.CompareTag("CARS"))
            {
                isMoving = false;
            }
            else
            {
                isMoving = true;
            }
            Debug.DrawLine(sensorStartPos, hit.point);
        }
        else
        {
            isMoving = true;
        }
    }

    private void CheckCrossings()
    {
        bool canMove = true;
        switch (currentNodeIndex)
        {
            case 0:
            case 2:
                if (!light1.enabled)
                {
                    canMove = false;
                }
                break;
            case 3:
                if (!light2.enabled)
                {
                    canMove = false;
                }
                break;
        }
        if (canMove)
        {
            isMoving = true;
            ProceedToNextNode();
        }
        else
        {
            isMoving = false;
        }
    }

    private void ProceedToNextNode()
    {
        currentNodeIndex = (currentNodeIndex + 1) % nodes.Count;
        if (currentNodeIndex == 0) isFirstVisit = false;
        hasRotated = false;
    }
}