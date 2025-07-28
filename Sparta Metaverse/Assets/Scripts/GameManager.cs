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

    private int currentScore = 0; //���� ���� �����ϴ� ����
    private int highScore = 0; //�ְ� ���� �����ϴ� ����
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
        //PlayerPrefs���� �ְ����� �ε�, ������ 0���� �ʱ�ȭ
    }

    private void Start()
    {
        uiManager.UpdateScore(0); //�ʱ� ������ 0���� ����
        uiManager.UpdateHighScore(highScore); //�ʱ� �ְ����� ǥ��
    }

    public void GameOver()
    {
        Debug.Log("Game Over"); 

        if(currentScore > highScore) //���� ������ �ְ� �������� ������ ������Ʈ
        {
            highScore = currentScore;
            PlayerPrefs.SetInt("HighScore", highScore); //�ְ� ���� ����
            PlayerPrefs.Save(); //����� �����͸� ��ũ�� �ݿ�
            
        }
        uiManager.UpdateHighScore(highScore); //UI�� ���ο� �ְ� ���� �ݿ�
        uiManager.highScoreText.gameObject.SetActive(true);
        uiManager.SetRestart(); //����� UI ǥ��
    }

    public void RestartGame()
    {
        currentScore = 0; //����� �� ���� �ʱ�ȭ
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //���� ���� �ٽ� �ε�
    }

    public void AddScore(int score)
    {
        currentScore += score; //���� ����
        uiManager.UpdateScore(currentScore); //UI�� ���� ������Ʈ
        Debug.Log("Score: " + currentScore); //���� �α� ���
    }

    public int GetHighScore()
    {
        return highScore; //�ְ� ���� ��ȯ
    }

    public void EndMiniGame(bool success, int finalScore)
    {
        Debug.Log(success ? "success!" : "fail!");

        if (finalScore > highScore) //���� ���� �� UI ������Ʈ
        {
            highScore = finalScore;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
            uiManager.UpdateHighScore(highScore);
        }
 
    uiManager.UpdateScore(finalScore);
    // ���� ���, ���� ���ο� ���� UI �ٸ��� ó�� ���� (uiManager�� �Լ� ������ ȣ��)
    uiManager.ShowMiniGameResult(success);

    // ���� �ð� �� ���ξ����� ���ư���
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