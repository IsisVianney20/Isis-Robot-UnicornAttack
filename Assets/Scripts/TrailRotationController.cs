using UnityEngine;

public class TrailRotationController : MonoBehaviour
{
    public Vector3 trailRotation = Vector3.zero; // Rotación deseada para el Trail Renderer
    private TrailRenderer trail;
    private GameObject trailHolder; // Objeto auxiliar para manipular la rotación

    void Start()
    {
       
        trail = GetComponent<TrailRenderer>();

       
        trailHolder = new GameObject("TrailHolder");
        trailHolder.transform.SetParent(transform); 
        trailHolder.transform.localPosition = Vector3.zero; 
        trailHolder.transform.localRotation = Quaternion.Euler(trailRotation); 
        
        trail.transform.SetParent(trailHolder.transform);
    }

    void Update()
    {
        // Mantener la posición del Trail Holder con el objeto principal
        trailHolder.transform.position = transform.position;
    }
}
