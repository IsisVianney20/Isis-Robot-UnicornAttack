using System;
using UnityEngine;
using UnityEngine.Events;

public class PlayerCollision : MonoBehaviour
{
     [SerializeField]
    private UnityEvent onPlayerLose;
    private Dash dash;

    private void Start()
    {
        dash = GetComponent<Dash>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            if (dash.IsDashing)
            {
                Destroy(collision.gameObject);
            }
            else
            {
                onPlayerLose?.Invoke();
            }
        }
    }
    private void OggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("DeadZone"))
        {
            onPlayerLose?.Invoke();
        }
    }
}
