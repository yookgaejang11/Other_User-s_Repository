using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    public GameManager manager; //GameManager ����
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) //"Item" �±װ� ���� ������Ʈ�� ����� ���� �ƴ϶�  �÷��̾� �±׿� ���������
        {
            Debug.Log("������");
            manager.GameOver(); //���� �Ŵ����� GameOver �޼ҵ� ȣ��
        }
    }
}
