using UnityEngine;
using UnityEngine.Events;

public class Dash : MonoBehaviour
{
    [SerializeField]
    private float duration = 1f;
    [SerializeField]
    private float inactiveDuration = 2f;
    [SerializeField]    
    private UnityEvent onDash;
    [SerializeField]
    private UnityEvent onDashEnd;


    private bool canDash = true;
    private bool isDashing;
    public bool IsDashing { get => isDashing; }
    private bool dashEnabled = true;

    [SerializeField]
    private UnityEvent AudioDash;

    public void SetDashEnabled(bool enabled)
    {
        dashEnabled = enabled;
    }
    public void DashAction()
    {
        if (!isDashing && canDash && dashEnabled)
        {
            canDash = false;
            onDash?.Invoke();
            isDashing = true;
            Invoke(nameof(StopDash), duration);
            AudioDash?.Invoke();
        }
    }

    private void StopDash()
    {
        onDashEnd?.Invoke();
        isDashing = false;
        Invoke(nameof(EnableDash), inactiveDuration);
        AudioDash?.Invoke();
    }

    private void EnableDash()
    {
        canDash = true;
    }
}
