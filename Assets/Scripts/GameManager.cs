using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject platformSpawner;
    public GameObject Retry;
    public GameObject gameUI;
    public GameObject MainUI;

    public Text scoreText;
    public Text mainText;
    public bool gameStarted;        //게임이 시작됐는지 확인할 변수

    int score = 0;
    float time;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != null)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!gameStarted)
        {
            //마우스 클릭시 차가 움직임
            if(Input.GetMouseButtonDown(0))
            {
                GameStart();
            }
        }
        startAnim();
    }

    //게임 시작
    public void GameStart()
    {
        gameStarted = true;
        //게임시작하면 메인화면 숨기기
        MainUI.SetActive(false);

        //게임시작하면 platformSpawner 동작
        platformSpawner.SetActive(true);

        //게임시작하면 스코어보이기
        gameUI.SetActive(true);
        StartCoroutine(UpdateScore());
    }


    //게임 오버
    public void GameOver()
    {
        //게임오버시 platformSpawner 동작 멈춤
        platformSpawner.SetActive(false);

        //게임화면멈추기
        Time.timeScale = 0;

        Retry.SetActive(true);
        if (Input.GetKeyDown(KeyCode.R))
        {
            ReloadGame();
        }
    }

    //게임재시작
    void ReloadGame()
    {
        Retry.SetActive(false);
        Time.timeScale = 1;
        SceneManager.LoadScene("InfiniteZigzag");
    }

    IEnumerator UpdateScore()
    {
        //1초에 1점씩 점수 오름
        while(true)
        {
            yield return new WaitForSeconds(1.0f);
            score++;

            scoreText.text = score.ToString();
        }
    }

    //깜빡이는 애니메이션
    public void startAnim()
    {
        if (time < 0.5f)
        {
            mainText.color = new Color(1, 1, 1, 1 - time);
        }
        else
        {
            mainText.color = new Color(1, 1, 1, time);
            if (time > 1f)
            {
                time = 0;
            }
        }

        time += Time.deltaTime;
    }
}
