using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flagrevarse : MonoBehaviour
{
    static int f = 0;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Carai") && f == 0)
        {
            f = 1;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Carai"))
        {
            f = 0;
        }
    }
    static public int getff()
    {
        return f;
    }
    static public void setff(int s)
    {
        f = s;
    }
}