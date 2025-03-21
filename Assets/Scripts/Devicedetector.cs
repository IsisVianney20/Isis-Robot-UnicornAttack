using UnityEngine;
using UnityEngine.Events;

public class Devicedetector : MonoBehaviour
{
    private UnityEvent onDesktop;
    [SerializeField]
    private UnityEvent onMobile;

    private void Start()
    {
        if (Application.isMobilePlatform)
        {
            onMobile?.Invoke();
        }
        else
        {
            onDesktop?.Invoke();
        }
    }

}
