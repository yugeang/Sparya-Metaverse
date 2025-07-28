using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameTrigger : MonoBehaviour
{
    public GameObject popupUI; //�ȳ� �޽��� �˾�
    public static bool isPlayerInTrigger = false; 
    //�ٸ� ��ũ��Ʈ���� ���� ������ static ����

    private void OnTriggerEnter2D(Collider2D other)
    //�÷��̾ �� Ʈ���� ������Ʈ�� ������� ȣ��
    //OnTriggerEnter2D(Collider2D other) > �÷��̾ Trigger �ȿ� ������ �ڵ����� ȣ���
    {
        if (other.CompareTag("Player")) //���� ��� �±װ� (Player)
        {
            popupUI.SetActive(true); //�˾� ǥ��
            //isPlayerInTrigger = true; //���� Ʈ���� �ȿ� �ִٴ� ���� ����
        }
    }

    private void OnTriggerExit2D(Collider2D other)
        //�÷��̾ Ʈ���Ÿ� ������ ȣ��
    {
        if(other.CompareTag("Player")) //���� ��� �±װ� (Player)
        {
            popupUI.SetActive(false); //�˾� ����
            //isPlayerInTrigger = false;
        }
    }
}
