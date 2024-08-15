using UnityEngine;

public class CarControlle22222r : MonoBehaviour
{
    private float horizontalInput, verticalInput;
    private float currentSteerAngle;
    private float currentBrakeForce;
    private bool isBraking;

    [Header("Performance Settings")]
    [SerializeField] private float motorForce = 1500f;
    [SerializeField] private float brakeForce = 3000f;
    [SerializeField] private float maxSteerAngle = 30f;
    [SerializeField] private float smoothAccelerationTime = 1.0f; 

    [Header("Wheel Colliders")]
    [SerializeField] private WheelCollider frontLeftWheelCollider;
    [SerializeField] private WheelCollider frontRightWheelCollider;
    [SerializeField] private WheelCollider rearLeftWheelCollider;
    [SerializeField] private WheelCollider rearRightWheelCollider;

    [Header("Wheel Transforms")]
    [SerializeField] private Transform frontLeftWheelTransform;
    [SerializeField] private Transform frontRightWheelTransform;
    [SerializeField] private Transform rearLeftWheelTransform;
    [SerializeField] private Transform rearRightWheelTransform;

    private float targetVelocity;
    private float currentVelocity;
    public float topspeed = 22f;

    private Rigidbody rb;

    private void FixedUpdate()
    {
        GetInput();
        HandleMotor();
        HandleSteering();
        UpdateWheels();
    }

    private void GetInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        isBraking = Input.GetKey(KeyCode.Space);
    }
    void Start()
{
            rb = GetComponent<Rigidbody>();

    SetupWheelFrictionCurve(frontLeftWheelCollider);
    SetupWheelFrictionCurve(frontRightWheelCollider);
    SetupWheelFrictionCurve(rearLeftWheelCollider);
    SetupWheelFrictionCurve(rearRightWheelCollider);
}
void SetupWheelFrictionCurve(WheelCollider collider)
{
    WheelFrictionCurve forwardFriction = collider.forwardFriction;
    forwardFriction.extremumSlip = 0.4f;
    forwardFriction.extremumValue = 1.0f;
    forwardFriction.asymptoteSlip = 0.8f;
    forwardFriction.asymptoteValue = 0.5f;
    forwardFriction.stiffness = 1.2f;
    collider.forwardFriction = forwardFriction;

    WheelFrictionCurve sidewaysFriction = collider.sidewaysFriction;
    sidewaysFriction.extremumSlip = 0.2f;
    sidewaysFriction.extremumValue = 1.25f;
    sidewaysFriction.asymptoteSlip = 0.5f;
    sidewaysFriction.asymptoteValue = 0.75f;
    sidewaysFriction.stiffness = 1.5f;
    collider.sidewaysFriction = sidewaysFriction;
}
private void HandleMotor()
{
    if(gear.thegear1()=='D'||gear.thegear1()=='R')
    {

    targetVelocity = verticalInput * motorForce;
if(gear.thegear1()=='R')
{
targetVelocity*=-1;
}
    bool movingForward = Mathf.Sign(targetVelocity) == Mathf.Sign(currentVelocity);
    currentVelocity = Mathf.Lerp(currentVelocity, targetVelocity, smoothAccelerationTime * Time.deltaTime);

    if (verticalInput<0.00f)
    {
        currentBrakeForce = brakeForce*verticalInput*-1;
        if ( currentVelocity > 0)
        {

            currentBrakeForce = brakeForce*verticalInput*-1;
        }
    }
    else
    {
        currentBrakeForce = 0f;
    }

    if( rb.velocity.magnitude < 8f)
    {
 frontLeftWheelCollider.motorTorque = currentVelocity;
    frontRightWheelCollider.motorTorque = currentVelocity;
    }
    else
    {
    frontLeftWheelCollider.motorTorque = 0;
    frontRightWheelCollider.motorTorque = 0;
      }
    }
    ApplyBraking();
}


    private void ApplyBraking()
    {
        frontLeftWheelCollider.brakeTorque = currentBrakeForce;
        frontRightWheelCollider.brakeTorque = currentBrakeForce;
        rearLeftWheelCollider.brakeTorque = currentBrakeForce;
        rearRightWheelCollider.brakeTorque = currentBrakeForce;
    }
    private float AdjustSteeringSensitivity(float input)
{
    return Mathf.Pow(input, 3);  
}

 private void HandleSteering()
{
    float adjustedInput = AdjustSteeringSensitivity(horizontalInput);
    currentSteerAngle = maxSteerAngle * adjustedInput;
    frontLeftWheelCollider.steerAngle = currentSteerAngle;
    frontRightWheelCollider.steerAngle = currentSteerAngle;
}


    private void UpdateWheels()
    {
        UpdateSingleWheel(frontLeftWheelCollider, frontLeftWheelTransform);
        UpdateSingleWheel(frontRightWheelCollider, frontRightWheelTransform);
        UpdateSingleWheel(rearRightWheelCollider, rearRightWheelTransform);
        UpdateSingleWheel(rearLeftWheelCollider, rearLeftWheelTransform);
    }

    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);
        wheelTransform.position = pos;
        wheelTransform.rotation = rot;
    }
}