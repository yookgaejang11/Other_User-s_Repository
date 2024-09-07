using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameManager manager; //GameManager ����
    public float Speed;
    public float jumpPower;
    Rigidbody2D Rigid;
    Checker checker;
    Vector2 moveVec
    {
        get
        {
            return new Vector2(Input.GetAxis("Horizontal") * Speed, Rigid.velocity.y);//velocity = �ӷ� ���ͷ� �ӷ��� ���� ���� horizon = ����, �ڿ� rigid�� �߷¹������
        }
    }
    //����� ���� �����ϴ°�
    private void Awake()
    {
        Rigid = GetComponent<Rigidbody2D>();  //Rididbody2D��� ������Ʈ ��������
        checker = GetComponent<Checker>();
    }
    //fps(frame for second) �����Ӹ��� ����(���� ���� ���ϸ� ���� �ֱⰡ �ٸ�)
    //�������̸� �ٿ���
    private void FixedUpdate()
    {
        Rigid.velocity = moveVec; //deltatime = ���ɰ� ���� ���̴µ� FixedUpdate�� fixedDeltatime��
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && checker.isGround)
        {
            Rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);//ForceMode�� ���� ã��
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ending") //"Item" �±װ� ���� ������Ʈ�� ����� ���� �ƴ϶�  �÷��̾� �±׿� ���������
        {
            Debug.Log("������");
            manager.GameOver(); //���� �Ŵ����� GameOver �޼ҵ� ȣ��
        }
    }
}
