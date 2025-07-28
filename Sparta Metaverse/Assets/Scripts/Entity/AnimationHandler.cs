using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    private static readonly int IsMoving = Animator.StringToHash("IsMove");
    //애니메이터 파라미터 이름을 해시로 변환하여 저장
    //IsMove 라는 파라미터를 빠르게 접근하기 위해 숫자로 바꿈

    private Animator animator; //Animator 컴포넌트를 저장할 변수
    //애니메이션을 실행시킬 유니티 컴포넌트

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        //자식 오브젝트에서 Animator 컴포넌트를 찾아서 변수로 할당
        //이 스크립트의 자식 오브젝트에서 Animator를 찾아옴
    }

    public void Move(Vector2 direction)
    {   //방향 벡터의 크기가 0.5보다 크면 이동 중이라 판단
        //방향이 0,0 이면 멈춰있는 상태
        //direction.magnitude > 방향 벡터의 크기
        bool isMoving = direction.magnitude > 0.5f;

        //Animator Controller 안에 있는 "IsMove" 파라미터 값을 true/false로 설정
        animator.SetBool(IsMoving, isMoving);
    }
}
