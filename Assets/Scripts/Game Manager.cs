using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [SerializeField] private UnityEvent onGameStart;
    [SerializeField] private UnityEvent onFinishGame;
    [SerializeField] private UnityEvent onLoseGame;
    [SerializeField] private UnityEvent onShowGameOverScreen;
    [SerializeField] private UnityEvent<int> onShowTimer;
    [SerializeField] private UnityEvent onRespawnGame;

    [SerializeField] private float secondsToRestart = 3f;
    [SerializeField] private float finalSecondsToRestart = 5f;

    public float secondsToShowGameOverScreen = 3f;

    private int loseCount = 0;
    private bool gameEnded = false;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        secondsToRestart += secondsToShowGameOverScreen;
        finalSecondsToRestart += secondsToShowGameOverScreen;
    }

    private void Start()
    {
        if (gameEnded) return;
        onGameStart?.Invoke();
        secondsToRestart += secondsToShowGameOverScreen;
    }

    public void LoseGame()
    {
        if (gameEnded) return;

        loseCount++;
        onLoseGame?.Invoke();

        if (loseCount >= 3)
        {
            gameEnded = true;
            Invoke("EndGame", secondsToShowGameOverScreen);
        }
        else
        {
            Invoke("ShowGameOverScreen", secondsToShowGameOverScreen);
        }
    }

    public void ShowGameOverScreen()
    {
        if (gameEnded) return;
        onShowGameOverScreen?.Invoke();
        onShowTimer?.Invoke(3);
    }

    public void RespawnGame()
    {
        if (gameEnded) return;
        Invoke("RestartGame", secondsToRestart);
    }

    public void FinishGame()
    {
        if (gameEnded) return;
        onFinishGame?.Invoke();
        Invoke("Start", secondsToRestart);
        Invoke("RestartGame", finalSecondsToRestart);
    }

    private void RestartGame()
    {
        if (gameEnded) return;
        onRespawnGame?.Invoke();
    }

    private void EndGame()
    {
        onShowGameOverScreen?.Invoke();
        onShowTimer?.Invoke(0); // 0 para indicar que no hay más juego
        Debug.Log("Juego terminado después de 3 derrotas.");
        // Aquí puedes cargar una escena de fin de juego o mostrar un mensaje especial
    }
}

