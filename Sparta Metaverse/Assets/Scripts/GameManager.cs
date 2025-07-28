using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    static GameManager gameManager;

    public static GameManager Instance
    {
        get { return gameManager; }
    }

    private int currentScore = 0; //현재 점수 저장하는 변수
    private int highScore = 0; //최고 점수 저장하는 변수
    UIManager uiManager;

    public UIManager UIManager
    {
        get { return uiManager; }
    }
    private void Awake()
    {
        gameManager = this;
        uiManager = FindObjectOfType<UIManager>();

        highScore = PlayerPrefs.GetInt("HighScore", 0);
        //PlayerPrefs에서 최고점수 로드, 없으면 0으로 초기화
    }

    private void Start()
    {
        uiManager.UpdateScore(0); //초기 점수를 0으로 설정
        uiManager.UpdateHighScore(highScore); //초기 최고점수 표시
    }

    public void GameOver()
    {
        Debug.Log("Game Over"); 

        if(currentScore > highScore) //현재 점수가 최고 점수보다 높으면 업데이트
        {
            highScore = currentScore;
            PlayerPrefs.SetInt("HighScore", highScore); //최고 점수 저장
            PlayerPrefs.Save(); //저장된 데이터를 디스크에 반영
            
        }
        uiManager.UpdateHighScore(highScore); //UI에 새로운 최고 점수 반영
        uiManager.highScoreText.gameObject.SetActive(true);
        uiManager.SetRestart(); //재시작 UI 표시
    }

    public void RestartGame()
    {
        currentScore = 0; //재시작 시 점수 초기화
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //현재 씬을 다시 로드
    }

    public void AddScore(int score)
    {
        currentScore += score; //점수 증가
        uiManager.UpdateScore(currentScore); //UI에 점수 업데이트
        Debug.Log("Score: " + currentScore); //점수 로그 출력
    }

    public int GetHighScore()
    {
        return highScore; //최고 점수 반환
    }

    public void EndMiniGame(bool success, int finalScore)
    {
        Debug.Log(success ? "success!" : "fail!");

        if (finalScore > highScore) //점수 저장 및 UI 업데이트
        {
            highScore = finalScore;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
            uiManager.UpdateHighScore(highScore);
        }
 
    uiManager.UpdateScore(finalScore);
    // 예를 들어, 성공 여부에 따라 UI 다르게 처리 가능 (uiManager에 함수 있으면 호출)
    uiManager.ShowMiniGameResult(success);

    // 일정 시간 후 메인씬으로 돌아가기
    StartCoroutine(ReturnToMainMapAfterDelay(5f));
    }

    private IEnumerator ReturnToMainMapAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("SampleScene");  
    }
    public int GetCurrentScore()
    {
        return currentScore;
    }
}