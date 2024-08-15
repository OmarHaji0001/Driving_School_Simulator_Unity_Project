using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
public class UserBrake : MonoBehaviour
{
    public Material material1;
    public Material material2;
    private Renderer rendererComponent;
    private Gamepad gamepad;
    void Start()
    {
                gamepad = Gamepad.current;
        rendererComponent = GetComponent<Renderer>();
        rendererComponent.material = material2; 
    }

    void Update()
    {

        if ((gamepad.leftTrigger.isPressed)) 
        {
            rendererComponent.material = material1; 
        }
        else 
        {
            rendererComponent.material = material2; 
        }
    }
}