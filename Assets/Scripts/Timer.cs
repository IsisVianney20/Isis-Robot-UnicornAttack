using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
   [SerializeField]
   private Text timeText;

   [SerializeField]
   private UnityEvent onSecondPassed;
   private int currentSeconds;

    public void StartTimer(int startSeconds)
    {
        currentSeconds = startSeconds;
        SetTimer();
    }

    private void SetTimer()
    {
        onSecondPassed?.Invoke();
        currentSeconds--;
        timeText.text = currentSeconds.ToString();
        if (currentSeconds > 0)
        {
            Invoke("SetTimer", 1f);
        }
    }
}
