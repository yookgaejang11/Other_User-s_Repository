using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameManager manager; //GameManager 선언
    public float Speed;
    public float jumpPower;
    Rigidbody2D Rigid;
    Checker checker;
    Vector2 moveVec
    {
        get
        {
            return new Vector2(Input.GetAxis("Horizontal") * Speed, Rigid.velocity.y);//velocity = 속력 벡터로 속력을 만든 다음 horizon = 수평, 뒤에 rigid는 중력받을라고
        }
    }
    //실행시 먼저 실행하는거
    private void Awake()
    {
        Rigid = GetComponent<Rigidbody2D>();  //Rididbody2D라는 컴포넌트 가져오기
        checker = GetComponent<Checker>();
    }
    //fps(frame for second) 프레임마다 실행(성능 차이 심하면 실행 주기가 다름)
    //성능차이를 줄여줌
    private void FixedUpdate()
    {
        Rigid.velocity = moveVec; //deltatime = 성능간 격차 줄이는데 FixedUpdate라 fixedDeltatime임
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && checker.isGround)
        {
            Rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);//ForceMode는 따로 찾기
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ending") //"Item" 태그가 붙은 오브젝트가 닿았을 때가 아니라  플레이어 태그에 닿았을때임
        {
            Debug.Log("감지함");
            manager.GameOver(); //게임 매니저의 GameOver 메소드 호출
        }
    }
}
