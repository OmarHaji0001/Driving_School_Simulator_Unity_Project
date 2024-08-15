using UnityEngine;
using System.Collections.Generic;

public class NPCCross1 : MonoBehaviour
{
    public List<Transform> nodes;
    public List<GameObject> crossZones;
    private int currentNodeIndex = 0;
    private float speed = 1.0f;
    private bool isFirstVisit = true;
    private bool hasRotated = false;
    public float sensoresleanth = 3f;
    public Vector3 frontsensorepos = new Vector3(0f, 20f, 0f);
    private bool isMoving = true;

    void Start()
    {
    }
    void Update()
    {
        if (nodes.Count == 4 && crossZones.Count == 4)
        {
            MoveTowardsTarget();
            senseores();
        }
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
            if (!hasRotated)
            {
                RotateAtNode();
                hasRotated = true;
            }

            if (currentNodeIndex == 1)
            {
                ProceedToNextNode();
            }
            else
            {
                CheckCrossings();
            }
        }
    }

    private void RotateAtNode()
    {
        if (!(isFirstVisit && currentNodeIndex == 0))
        {
            transform.Rotate(0, 90, 0);
        }
    }

    private void CheckCrossings()
    {
        bool canMove = true;
        List<GameObject> relevantZones = new List<GameObject>();
        switch (currentNodeIndex)
        {
            case 0:
                relevantZones.Add(crossZones[0]);
                relevantZones.Add(crossZones[1]);
                break;
            case 2:
                relevantZones.AddRange(crossZones.GetRange(0, 3));
                break;
            case 3:
                relevantZones.Add(crossZones[3]);
                break;
        }
        foreach (var zone in relevantZones)
        {
            Collider zoneCollider = zone.GetComponent<Collider>();
            Vector3 center = zoneCollider.bounds.center;
            Vector3 halfExtents = zoneCollider.bounds.extents;
            Collider[] hitColliders = Physics.OverlapBox(center, halfExtents, Quaternion.identity);
            foreach (Collider hitCollider in hitColliders)
            {
                if (hitCollider.CompareTag("CARS"))
                {
                    canMove = false;
                    break;
                }
            }

            if (!canMove)
            {
                return;
            }
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
        isFirstVisit = false;
        hasRotated = false;
    }
}