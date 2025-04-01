using UnityEngine;
using UnityEngine.Events;

public class DeactivateInSeconds : MonoBehaviour
{
  [SerializeField]
  private float secondsToDesactivate = 5f;
  

    private void OnEnable()
    {
        Invoke("DesactivateObject", secondsToDesactivate);
    }

    private void DesactivateObject()
    {
        gameObject.SetActive(false);
    }
}
