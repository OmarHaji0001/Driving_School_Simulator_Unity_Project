using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class Speedometer : MonoBehaviour
{
    public Rigidbody target;
    public float maxSpeed = 0.0f; 
    public float minSpeedArrowAngle;
    public float maxSpeedArrowAngle;
    public Text speedLabel; 
    public RectTransform arrow; 

    private float speed = 0.0f;
    private void Update()
    {
        speed = target.velocity.magnitude * 3.6f;
        speed*=1.6666667f;

        if (speedLabel != null)
            speedLabel.text = ((int)speed) + " km/h";
        if (arrow != null)
            arrow.localEulerAngles =
                new Vector3(0, 0, Mathf.Lerp(minSpeedArrowAngle, maxSpeedArrowAngle, speed / maxSpeed));
    }
}