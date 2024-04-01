using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    public float moveSpeed;     //�̵��ӵ�
    bool sideMoving = true;     //������ȯ
    bool firstInput = true;     //ùŬ�� Ȯ�ο�


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

        //�÷��̾� ����
        if (transform.position.y <= -2)
        {
            GameManager.instance.GameOver();
        }
    }

    void Move()
    {
        //�÷��̾� �̵�
        transform.position -= transform.forward * moveSpeed * Time.deltaTime;
    }

    //�����غ�(ù Ŭ������ Ȯ���ϴ��Լ�)
    void CheckInput()
    {
        //ù Ŭ���̶�� ����
        if(firstInput)
        {
            firstInput = false;
            return;
        }

        //�ι�° Ŭ������ ���콺Ŭ������ ������ȯ
        if(Input.GetMouseButtonDown(0))
        {
            ChangeDirection();
        }
    }

    //�÷��̾� ������ȯ
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
