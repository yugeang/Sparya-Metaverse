using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameInput : MonoBehaviour
{
    public string miniGameSceneName = "FlappyBirdScene"; //전환할 미니게임 씬 이름

    void Update()
    {
        //Input.GetKeyDown(KeyCode.Space) > 스페이스바가 눌린 순간을 감지하는 코드
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(CanEnterMiniGame())
            //스페이스바 눌렀을때 ()조건이 참이면 EnterMiniGame() 실행
            {
                EnterMiniGame();
            }
        }
    }

    private bool CanEnterMiniGame() //플레이어가 미니게임 트리거 안에 있는지 확인
    {
        //트리거 안에 있을때만 true
        return MiniGameTrigger.isPlayerInTrigger;
        /*MiniGameTrigger 클래스의 static 변수 isPlayerInTrigger가
        true일 때만 씬 전환을 허용*/
    }

    private void EnterMiniGame()
    {
        //미니게임 씬으로 전환
        SceneManager.LoadScene(miniGameSceneName);
        //miniGameSceneName에 적힌 이름의 씬으로 전환
    }
}
