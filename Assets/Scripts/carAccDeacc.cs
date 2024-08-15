using UnityEngine;

public class CarAudioManager : MonoBehaviour
{
    public AudioSource engineSource;
    public float lowPitch = 1.0f;
    public float highPitch = 2.5f;
    public float maxSpeed = 20.0f;
    private Rigidbody carRigidbody;
    private void Start()
    {
        carRigidbody = GetComponent<Rigidbody>();
        if (carRigidbody == null)
        {
            Debug.LogError("Rigidbody component missing!");
        }

        if (engineSource == null)
        {
            Debug.LogError("Engine AudioSource not assigned!");
        }
        else
        {
            engineSource.loop = true;
            engineSource.Play();
        }
    }
    private void Update()
    {
        if (engineSource != null)
        {
            float speed = carRigidbody.velocity.magnitude;
            float speedRatio = Mathf.Clamp(speed / maxSpeed, 0, 1);
            float pitch = Mathf.Lerp(lowPitch, highPitch, speedRatio);
            engineSource.pitch = Mathf.Lerp(engineSource.pitch, pitch, Time.deltaTime * 0.5f);
        }
    }
}
