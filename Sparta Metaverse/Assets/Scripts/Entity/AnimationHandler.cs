using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : MonoBehaviour
{
    private static readonly int IsMoving = Animator.StringToHash("IsMove");
    //�ִϸ����� �Ķ���� �̸��� �ؽ÷� ��ȯ�Ͽ� ����
    //IsMove ��� �Ķ���͸� ������ �����ϱ� ���� ���ڷ� �ٲ�

    private Animator animator; //Animator ������Ʈ�� ������ ����
    //�ִϸ��̼��� �����ų ����Ƽ ������Ʈ

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        //�ڽ� ������Ʈ���� Animator ������Ʈ�� ã�Ƽ� ������ �Ҵ�
        //�� ��ũ��Ʈ�� �ڽ� ������Ʈ���� Animator�� ã�ƿ�
    }

    public void Move(Vector2 direction)
    {   //���� ������ ũ�Ⱑ 0.5���� ũ�� �̵� ���̶� �Ǵ�
        //������ 0,0 �̸� �����ִ� ����
        //direction.magnitude > ���� ������ ũ��
        bool isMoving = direction.magnitude > 0.5f;

        //Animator Controller �ȿ� �ִ� "IsMove" �Ķ���� ���� true/false�� ����
        animator.SetBool(IsMoving, isMoving);
    }
}
