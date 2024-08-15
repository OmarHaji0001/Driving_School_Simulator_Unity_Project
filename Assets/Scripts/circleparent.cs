using UnityEngine;
using TMPro; 
using System.Collections; 
public class circlerparnt : MonoBehaviour
{
    private static bool iswrongdirction = false;
    private void Start() { }
    void Update() { }
    static public bool get1() { return iswrongdirction; }
    static public void set1(bool s)
    {
        iswrongdirction = s;
    }
}