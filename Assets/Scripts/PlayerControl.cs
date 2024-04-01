using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    public float moveSpeed;     //이동속도
    bool sideMoving = true;     //방향전환
    bool firstInput = true;     //첫클릭 확인용


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.gameStarted)
        {
            Move();
            CheckInput();
        }

        //플레이어 죽음
        if (transform.position.y <= -2)
        {
            GameManager.instance.GameOver();
        }
    }

    void Move()
    {
        //플레이어 이동
        transform.position -= transform.forward * moveSpeed * Time.deltaTime;
    }

    //게임준비(첫 클릭인지 확인하는함수)
    void CheckInput()
    {
        //첫 클릭이라면 무시
        if(firstInput)
        {
            firstInput = false;
            return;
        }

        //두번째 클릭부터 마우스클릭으로 방향전환
        if(Input.GetMouseButtonDown(0))
        {
            ChangeDirection();
        }
    }

    //플레이어 방향전환
    void ChangeDirection()
    {
        if(sideMoving)
        {
            sideMoving = false;

            transform.rotation = Quaternion.Euler(0, -90, 0);
        }
        else
        {
            sideMoving = true;
            transform.rotation = Quaternion.Euler(0, -180, 0);
        }
    }
}
