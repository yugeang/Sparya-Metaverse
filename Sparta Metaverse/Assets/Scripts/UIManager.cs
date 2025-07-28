using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; //현재 점수 표시
    public TextMeshProUGUI restartText; //재시작 안내 표시
    public TextMeshProUGUI highScoreText; //최고 점수 표시

    public void Start()
    {
        if (restartText == null)
        {
            Debug.LogError("restart text is null");
            // restartText가 없으면 오류 로그 출력
        }

        if (scoreText == null)
        {
            Debug.LogError("scoreText is null");
            // scoreText가 없으면 오류 로그 출력
            return;
        }

        if(highScoreText == null)
        {
            Debug.LogError("highScoreText is null");
            // highScoreText가 없으면 오류 로그 출력
            return;
        }

        restartText.gameObject.SetActive(false); //초기에는 재시작 안내 숨김
        highScoreText.gameObject.SetActive(false); //★ 최고 점수 숨김
    }

    public void SetRestart()
    {
        restartText.gameObject.SetActive(true); //재시작 안내 표시
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString(); //현재 점수 UI에 업데이트
    }

    public void UpdateHighScore(int score)
    {
        highScoreText.text = $"highest score: {score}"; //최고 점수 UI에 업데이트
    }
    public void ShowMiniGameResult(bool success)
    {
        if (restartText != null)
        {
            if (success)
                restartText.text = "success!";
            else
                restartText.text = "fail!\nClick To Restart";

            restartText.gameObject.SetActive(true);
        }
        if (highScoreText != null)
        {
            highScoreText.gameObject.SetActive(true);
        }
    }
}