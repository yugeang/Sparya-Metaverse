using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BaseController : MonoBehaviour
{
    public Rigidbody2D _rigidbody; //이동을 위한 물리 컴포넌트

    [SerializeField] public SpriteRenderer characterRenderer; //좌우 반전을 위한 렌더러

    protected Vector2 movementDirection = Vector2.zero; //현재 이동 방향
    public Vector2 MovementDirection { get { return movementDirection; } } 
    //get 내부에 movementDirection 필드 값 반환해줌

    protected Vector2 lookDirection = Vector2.right; //현재 바라보는 방향
    public Vector2 LookDirection { get { return lookDirection; } }

    protected AnimationHandler animationHandler; //애니메이션 제어용 핸들러 클래스

    protected virtual void Awake() //Awake는 스크립트가 실행될때 가장 먼저 호출됨
    {
        _rigidbody = GetComponent<Rigidbody2D>(); 
        //게임 오브젝트에 붙은 Rigidbody2D 컴포넌트를 찾아서 _rigidbody 변수에 할당

        animationHandler = GetComponent<AnimationHandler>();
        //AnimationHandler 가져오기
    }
    protected virtual void Start()
    {

    }

    protected virtual void Update() //매 프레임 호출
    {
        HandleAction(); //자식 클래스에서 입력 등 행동 처리 담당
        Rotate(lookDirection); //현재 바라보는 방향으로 캐릭터 회전
    }

    protected virtual void FixedUpdate() //물리 연산 주기마다 호출
    {
        Movement(movementDirection); //Rigidbody2D 물리 이동 처리
    }

    protected virtual void HandleAction() 
    {
        /*BaseController에서 기본 동작이 없음, PlayerController 같은 자식 클래스가
        키 입력, 마우스 입력을 받아서 정하도록 하기 위해 빈 함수로 둔거임*/
        //입력 처리 등 행동을 자식 클래스가 구현하도록 비워둠
    }

    private void Movement(Vector2 direction) //Rigidbody2D 속도 지정해서 캐릭터를 움직이게함
    {
        float speed = 5f; //이동속도
        _rigidbody.velocity = direction * speed; //Rigidbody2D 속도 설정

        //animationHandler가 존재하면 애니메이션 상태 업데이트
        if (animationHandler != null) 
        {
            animationHandler.Move(direction);
            //이동 방향 전달해서 IsMove 애니메이션 제어
        }
    }

    private void Rotate(Vector2 direction)
    {
        if (direction == Vector2.zero)
            return; //아무 방향도 안 보고있으면 회전 안함

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //Mathf.Atan2(y, x)는 방향 벡터를 각도로 바꿔줌
        //flipX로 캐릭터가 왼쪽을 보면 이미지 반전해서 왼쪽 보는것처럼 해줌

        bool isLeft = Mathf.Abs(angle) > 90f; //각도가 90도 넘으면 왼쪽 보는중
        characterRenderer.flipX = isLeft; //왼쪽 보면 스프라이트 좌우 반전
    }

}
