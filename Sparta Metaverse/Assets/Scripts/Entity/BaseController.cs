using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BaseController : MonoBehaviour
{
    public Rigidbody2D _rigidbody; //�̵��� ���� ���� ������Ʈ

    [SerializeField] public SpriteRenderer characterRenderer; //�¿� ������ ���� ������

    protected Vector2 movementDirection = Vector2.zero; //���� �̵� ����
    public Vector2 MovementDirection { get { return movementDirection; } } 
    //get ���ο� movementDirection �ʵ� �� ��ȯ����

    protected Vector2 lookDirection = Vector2.right; //���� �ٶ󺸴� ����
    public Vector2 LookDirection { get { return lookDirection; } }

    protected AnimationHandler animationHandler; //�ִϸ��̼� ����� �ڵ鷯 Ŭ����

    protected virtual void Awake() //Awake�� ��ũ��Ʈ�� ����ɶ� ���� ���� ȣ���
    {
        _rigidbody = GetComponent<Rigidbody2D>(); 
        //���� ������Ʈ�� ���� Rigidbody2D ������Ʈ�� ã�Ƽ� _rigidbody ������ �Ҵ�

        animationHandler = GetComponent<AnimationHandler>();
        //AnimationHandler ��������
    }
    protected virtual void Start()
    {

    }

    protected virtual void Update() //�� ������ ȣ��
    {
        HandleAction(); //�ڽ� Ŭ�������� �Է� �� �ൿ ó�� ���
        Rotate(lookDirection); //���� �ٶ󺸴� �������� ĳ���� ȸ��
    }

    protected virtual void FixedUpdate() //���� ���� �ֱ⸶�� ȣ��
    {
        Movement(movementDirection); //Rigidbody2D ���� �̵� ó��
    }

    protected virtual void HandleAction() 
    {
        /*BaseController���� �⺻ ������ ����, PlayerController ���� �ڽ� Ŭ������
        Ű �Է�, ���콺 �Է��� �޾Ƽ� ���ϵ��� �ϱ� ���� �� �Լ��� �а���*/
        //�Է� ó�� �� �ൿ�� �ڽ� Ŭ������ �����ϵ��� �����
    }

    private void Movement(Vector2 direction) //Rigidbody2D �ӵ� �����ؼ� ĳ���͸� �����̰���
    {
        float speed = 5f; //�̵��ӵ�
        _rigidbody.velocity = direction * speed; //Rigidbody2D �ӵ� ����

        //animationHandler�� �����ϸ� �ִϸ��̼� ���� ������Ʈ
        if (animationHandler != null) 
        {
            animationHandler.Move(direction);
            //�̵� ���� �����ؼ� IsMove �ִϸ��̼� ����
        }
    }

    private void Rotate(Vector2 direction)
    {
        if (direction == Vector2.zero)
            return; //�ƹ� ���⵵ �� ���������� ȸ�� ����

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //Mathf.Atan2(y, x)�� ���� ���͸� ������ �ٲ���
        //flipX�� ĳ���Ͱ� ������ ���� �̹��� �����ؼ� ���� ���°�ó�� ����

        bool isLeft = Mathf.Abs(angle) > 90f; //������ 90�� ������ ���� ������
        characterRenderer.flipX = isLeft; //���� ���� ��������Ʈ �¿� ����
    }

}
