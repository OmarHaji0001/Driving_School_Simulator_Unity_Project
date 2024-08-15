using System.Collections;
using TMPro;
using UnityEngine;
public class circletraffic : MonoBehaviour
{
    int isthere = 0;
    static int isenterd = 0;
    void Start()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Carai") || other.CompareTag("Car"))
        {
            isenterd = 1;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Carai") || other.CompareTag("Car"))
        {
            isenterd = 1;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Carai") || other.CompareTag("Car"))
        {
            isenterd = 0;
        }
    }


    void Update()
    {

    }

    public static int isenterdd()
    {

        return isenterd;
    }
}