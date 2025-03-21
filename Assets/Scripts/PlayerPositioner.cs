using UnityEngine;

public class PlayerPositioner : MonoBehaviour
{
    [SerializeField] 
    public Transform player;
    [SerializeField]
    private Transform startingPosition;

    public void SetPlayerPosition()
    {
        player.position = startingPosition.position;
    }
}
