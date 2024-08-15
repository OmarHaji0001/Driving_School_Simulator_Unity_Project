using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stoprewind : MonoBehaviour
{
    public static bool flag6;
    void Start()
    {

    }
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
    public static void set(bool o)
    {
        flag6 = o;
    }

}
