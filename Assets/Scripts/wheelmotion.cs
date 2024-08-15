using System.Collections;
using UnityEngine;
public class Carwheel : MonoBehaviour
{
    public WheelCollider targetwheel;
    private Vector3 wheelPosition = new Vector3();
    private Quaternion wheelRotation = new Quaternion();
    private void Update()
    {
        targetwheel.GetWorldPose(out wheelPosition, out wheelRotation);
        transform.position = wheelPosition;
        transform.rotation = wheelRotation;
    }
}