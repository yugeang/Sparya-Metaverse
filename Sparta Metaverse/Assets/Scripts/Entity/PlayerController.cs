using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : BaseController //BaseController�� ����ϰ� �����
{
    private Camera camera; //ī�޶󿡼� ���콺 ��ġ �����ö� ����� ����
    
    protected override void Start()
    {
        base.Start(); //BaseController�� Start() ���� ����
        //�θ� Ŭ������ �ʱ�ȭ ������ ���� ����

        camera = Camera.main; //���� ī�޶� ���� ����
        //Main Camera �±װ� ���� ī�޶� �����ͼ� ������
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
