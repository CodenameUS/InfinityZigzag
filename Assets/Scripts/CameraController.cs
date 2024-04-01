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
        //게임오버되기전까지만 따라가게
        if (target.position.y >= 0)
        {
            Follow();
        }
    }

    //플레이어 따라 움직임
    void Follow()
    {
        //현재 카메라 포지션
        Vector3 currentPos = transform.position;

        //현재 타겟 자동차
        Vector3 targetPos = target.position - distance;

        transform.position = Vector3.Lerp(currentPos, targetPos, smoothValu * Time.deltaTime);
    }
}
