using UnityEngine;

public class astonebreake : MonoBehaviour
{
    public Material material1;
    public Material material2;
    private Renderer rendererComponent;
    public carungine car;
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
