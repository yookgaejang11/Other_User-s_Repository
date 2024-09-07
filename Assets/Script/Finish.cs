using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    public GameManager manager; //GameManager 선언
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) //"Item" 태그가 붙은 오브젝트가 닿았을 때가 아니라  플레이어 태그에 닿았을때임
        {
            Debug.Log("감지함");
            manager.GameOver(); //게임 매니저의 GameOver 메소드 호출
        }
    }
}
