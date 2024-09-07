using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    Text timeT; //TimeText 컴포넌트를 담아둘 변수
    float time = 0; //플레이 타임
    
    public Text ClearText; //클리어 텍스트 UI
    public Button RetryButton; //재시작 버튼 UI

    bool isGameOver = false; //게임이 끝났음을 판단할 변수

    void Start()
    {
        
        timeT = GameObject.Find("TimeText").GetComponent<Text>();
        //하이어라키에 있는 오브젝트 중 TimeText라는 이름의 오브젝트를 찾고, 그 오브젝트에 있는 Text 컴포넌트를 timeT변수에 담아줌. 참조

        //UI요소 비활성화
        ClearText.gameObject.SetActive(false);
        RetryButton.gameObject.SetActive(false);

        //버튼 클릭 시 RestartGame 메소드 호출
        RetryButton.onClick.AddListener(RestartGame);
    }

    void Update()
    {
        if (isGameOver) return; //게임이 끝났다면 Update함수를 빠져나감

        time += Time.deltaTime; //플레이 타임 증가
        timeT.text = "TIME\n" + SetTime((int)time); //텍스트로 시간 표현
    }

    string SetTime(int time) //00:00 포맷으로 시간 표현해줄 함수
    {
        string min = (time / 60).ToString(); //분

        if (int.Parse(min) < 10) min = "0" + min; //10분 아래면 0을 붙혀줌

        string sec = (time % 60).ToString(); //초

        if (int.Parse(sec) < 10) sec = "0" + sec; //10초 아래면 0을 붙혀줌

        return min + ":" + sec;
    }

    public void GameOver()
    {
        
        //게임 오버 시 UI 활성화
        ClearText.gameObject.SetActive(true);
        RetryButton.gameObject.SetActive(true);

        //게임 오버 상태로 설정
        Time.timeScale = 0; //게임 시간을 멈춤
    }

    private void RestartGame()
    {
        //게임 재시작
        Time.timeScale = 1; //게임 시간 재개
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //현재 씬 다시 로드
    }
}
