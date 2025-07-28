using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameInput : MonoBehaviour
{
    public string miniGameSceneName = "FlappyBirdScene"; //��ȯ�� �̴ϰ��� �� �̸�

    void Update()
    {
        //Input.GetKeyDown(KeyCode.Space) > �����̽��ٰ� ���� ������ �����ϴ� �ڵ�
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(CanEnterMiniGame())
            //�����̽��� �������� ()������ ���̸� EnterMiniGame() ����
            {
                EnterMiniGame();
            }
        }
    }

    private bool CanEnterMiniGame() //�÷��̾ �̴ϰ��� Ʈ���� �ȿ� �ִ��� Ȯ��
    {
        //Ʈ���� �ȿ� �������� true
        return MiniGameTrigger.isPlayerInTrigger;
        /*MiniGameTrigger Ŭ������ static ���� isPlayerInTrigger��
        true�� ���� �� ��ȯ�� ���*/
    }

    private void EnterMiniGame()
    {
        //�̴ϰ��� ������ ��ȯ
        SceneManager.LoadScene(miniGameSceneName);
        //miniGameSceneName�� ���� �̸��� ������ ��ȯ
    }
}
