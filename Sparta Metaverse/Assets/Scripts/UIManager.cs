using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; //���� ���� ǥ��
    public TextMeshProUGUI restartText; //����� �ȳ� ǥ��
    public TextMeshProUGUI highScoreText; //�ְ� ���� ǥ��

    public void Start()
    {
        if (restartText == null)
        {
            Debug.LogError("restart text is null");
            // restartText�� ������ ���� �α� ���
        }

        if (scoreText == null)
        {
            Debug.LogError("scoreText is null");
            // scoreText�� ������ ���� �α� ���
            return;
        }

        if(highScoreText == null)
        {
            Debug.LogError("highScoreText is null");
            // highScoreText�� ������ ���� �α� ���
            return;
        }

        restartText.gameObject.SetActive(false); //�ʱ⿡�� ����� �ȳ� ����
        highScoreText.gameObject.SetActive(false); //�� �ְ� ���� ����
    }

    public void SetRestart()
    {
        restartText.gameObject.SetActive(true); //����� �ȳ� ǥ��
    }

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString(); //���� ���� UI�� ������Ʈ
    }

    public void UpdateHighScore(int score)
    {
        highScoreText.text = $"highest score: {score}"; //�ְ� ���� UI�� ������Ʈ
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