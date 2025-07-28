using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : BaseController //BaseController를 상속하게 만들기
{
    private Camera camera; //카메라에서 마우스 위치 가져올때 사용할 변수
    
    protected override void Start()
    {
        base.Start(); //BaseController의 Start() 먼저 실행
        //부모 클래스의 초기화 내용을 먼저 실행

        camera = Camera.main; //메인 카메라 참조 저장
        //Main Camera 태그가 붙은 카메라를 가져와서 저장함
    }

    protected override void HandleAction()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        movementDirection = new Vector2(horizontal, vertical).normalized;

        Vector2 mousePosition = Input.mousePosition;
        Vector2 worldPos = camera.ScreenToWorldPoint(mousePosition);

        lookDirection = (worldPos - (Vector2)transform.position);

        if(lookDirection.magnitude < 0.1f)
        {
            lookDirection = Vector2.zero;
        }
        else
        {
            lookDirection = lookDirection.normalized;
        }
    }
}
