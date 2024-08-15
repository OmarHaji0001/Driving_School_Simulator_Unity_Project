using UnityEngine;

public class caymenbreake2 : MonoBehaviour
{
    public Material material1;
    public Material material2;
    private Renderer rendererComponent;
    public carunginecaymen2 car;
    void Start()
    {
        rendererComponent = GetComponent<Renderer>();
        rendererComponent.material = material2; 
    }
    void Update()
    {
        if (car.isbreaking)
        {
            rendererComponent.material = material1; 
        }
        else
        {
            rendererComponent.material = material2; 
        }
    }
}
