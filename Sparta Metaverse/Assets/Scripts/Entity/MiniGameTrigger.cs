using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameTrigger : MonoBehaviour
{
    public GameObject popupUI; //안내 메시지 팝업
    public static bool isPlayerInTrigger = false; 
    //다른 스크립트에서 접근 가능한 static 변수

    private void OnTriggerEnter2D(Collider2D other)
    //플레이어가 이 트리거 오브젝트에 닿았을때 호출
    //OnTriggerEnter2D(Collider2D other) > 플레이어가 Trigger 안에 들어오면 자동으로 호출됨
    {
        if (other.CompareTag("Player")) //닿은 상대 태그가 (Player)
        {
            popupUI.SetActive(true); //팝업 표시
            //isPlayerInTrigger = true; //현재 트리거 안에 있다는 상태 저장
        }
    }

    private void OnTriggerExit2D(Collider2D other)
        //플레이어가 트리거를 나가면 호출
    {
        if(other.CompareTag("Player")) //닿은 상대 태그가 (Player)
        {
            popupUI.SetActive(false); //팝업 숨김
            //isPlayerInTrigger = false;
        }
    }
}
