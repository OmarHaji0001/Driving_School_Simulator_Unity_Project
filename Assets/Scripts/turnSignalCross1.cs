using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class crross1 : MonoBehaviour
{
    public static bool flag6;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            flag6 = true;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            flag6 = false;
        }

    }
    public static bool get()
    {
        return flag6;
    }
} 