using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MiniGameResultUI : MonoBehaviour
{
    public GameObject popupUI;
    public TextMeshProUGUI resultText;
    public TextMeshProUGUI currentScoreText;
    public TextMeshProUGUI highScoreText;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            popupUI.SetActive(true);

            int score = ScoreManager.Instance.score;
            int high = ScoreManager.Instance.highScore;
            int success = PlayerPrefs.GetInt("MiniGameSuccess", 0); // ���� ���� ����� ��

            resultText.text = success == 1 ? "�̴ϰ��� ���: ����!" : "�̴ϰ��� ���: ����!";
            currentScoreText.text = $"���� ����: {score}";
            highScoreText.text = $"�ְ� ����: {high}";
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            popupUI.SetActive(false);
        }
    }
}
