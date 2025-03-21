using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreGameOver : MonoBehaviour
{
   [SerializeField]
   private List <Text> scoreTexts;
   [SerializeField]         
    private Text FinalScoreText;
    private int scoreIndex = 0;

    public void SetScore(int score)
    {
        scoreTexts[scoreIndex].text = score.ToString();
        scoreIndex++;
    }
    public void SetFinalScore(int score)
    {
        FinalScoreText.text = score.ToString();
    }

    public void Restart()
    {
        scoreIndex = 0;
        FinalScoreText.text = "0";
        foreach (var scoreText in scoreTexts)
        {
            scoreText.text = "0";
        }
    }
}
