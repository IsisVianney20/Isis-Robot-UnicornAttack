using UnityEngine;
using UnityEngine.Events;

public class MainMenuScreens : MonoBehaviour
{
    [SerializeField]
    private UnityEvent OnStartGame;

    private void Start()
    {
        OnStartGame?.Invoke();
    }


    public void ShowScreen(GameObject screen)
    {
        screen.SetActive(true);

    }
    public void HideScreen(GameObject screen)
    {
        screen.SetActive(false);
    }
}
