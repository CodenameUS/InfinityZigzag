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
    public bool gameStarted;        //������ ���۵ƴ��� Ȯ���� ����

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
            //���콺 Ŭ���� ���� ������
            if(Input.GetMouseButtonDown(0))
            {
                GameStart();
            }
        }
        startAnim();
    }

    //���� ����
    public void GameStart()
    {
        gameStarted = true;
        //���ӽ����ϸ� ����ȭ�� �����
        MainUI.SetActive(false);

        //���ӽ����ϸ� platformSpawner ����
        platformSpawner.SetActive(true);

        //���ӽ����ϸ� ���ھ�̱�
        gameUI.SetActive(true);
        StartCoroutine(UpdateScore());
    }


    //���� ����
    public void GameOver()
    {
        //���ӿ����� platformSpawner ���� ����
        platformSpawner.SetActive(false);

        //����ȭ����߱�
        Time.timeScale = 0;

        Retry.SetActive(true);
        if (Input.GetKeyDown(KeyCode.R))
        {
            ReloadGame();
        }
    }

    //���������
    void ReloadGame()
    {
        Retry.SetActive(false);
        Time.timeScale = 1;
        SceneManager.LoadScene("InfiniteZigzag");
    }

    IEnumerator UpdateScore()
    {
        //1�ʿ� 1���� ���� ����
        while(true)
        {
            yield return new WaitForSeconds(1.0f);
            score++;

            scoreText.text = score.ToString();
        }
    }

    //�����̴� �ִϸ��̼�
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
