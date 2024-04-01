using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float smoothValu;

    Vector3 distance;
    // Start is called before the first frame update
    void Start()
    {
        distance = target.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //���ӿ����Ǳ��������� ���󰡰�
        if (target.position.y >= 0)
        {
            Follow();
        }
    }

    //�÷��̾� ���� ������
    void Follow()
    {
        //���� ī�޶� ������
        Vector3 currentPos = transform.position;

        //���� Ÿ�� �ڵ���
        Vector3 targetPos = target.position - distance;

        transform.position = Vector3.Lerp(currentPos, targetPos, smoothValu * Time.deltaTime);
    }
}
