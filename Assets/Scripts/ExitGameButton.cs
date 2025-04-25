using UnityEngine;

public class ExitGameButton : MonoBehaviour
{
        public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Saliendo...");
    }
}
