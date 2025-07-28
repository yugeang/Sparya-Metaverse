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
            int success = PlayerPrefs.GetInt("MiniGameSuccess", 0); // 성공 여부 저장된 값

            resultText.text = success == 1 ? "미니게임 결과: 성공!" : "미니게임 결과: 실패!";
            currentScoreText.text = $"현재 점수: {score}";
            highScoreText.text = $"최고 점수: {high}";
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
