using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainSceneUIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;

    private int lastScore = -1;
    private int lastHighScore = -1;

    void Update()
    {
        if (ScoreManager.Instance == null)
            return;

        if (lastScore != ScoreManager.Instance.score)
        {
            lastScore = ScoreManager.Instance.score;
            scoreText.text = $"점수: {lastScore}";
        }

        if (lastHighScore != ScoreManager.Instance.highScore)
        {
            lastHighScore = ScoreManager.Instance.highScore;
            highScoreText.text = $"최고 점수: {lastHighScore}";
        }
    }
}
