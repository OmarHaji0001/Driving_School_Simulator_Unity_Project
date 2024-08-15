using UnityEngine;
using System.Collections;

public class rightside : MonoBehaviour
{
    public float onTime = 2f;
    public float offTime = 1f;
    public Material material1;
    public Material material2;
        public Material material3;

    public GameObject front;

    private static bool autoToggle = false;
    private static rightside instance;
    private Renderer rendererComponent;
        private Renderer rendererComponentfront;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            
            rendererComponent = GetComponent<Renderer>();
            rendererComponentfront=front.GetComponent<Renderer>();
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public static void SetAutoToggle(bool value)
{
    autoToggle = value;
    if (instance == null) return;

    if (autoToggle)
    {
        instance.StartCoroutine(instance.ToggleMaterial());
    }
    else
    {
        instance.StopAllCoroutines();
        instance.rendererComponent.material = instance.material1; 
               instance.rendererComponentfront.material=instance.material3;

    }
}


    public static bool get()
    {
        return autoToggle;
    }

    private IEnumerator ToggleMaterial()
    {
        while (autoToggle)
        {
            instance.rendererComponent.material = material2;
            rendererComponentfront.material=material2; 
            yield return new WaitForSeconds(onTime);
            instance.rendererComponent.material = material1;
             rendererComponentfront.material=material3; 
            yield return new WaitForSeconds(offTime);
        }
    }
}
