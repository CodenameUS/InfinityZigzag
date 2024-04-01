using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platform;

    public Transform lastPlatform;
    Vector3 lastPosition;
    Vector3 newPos;

    bool stop;

    // Start is called before the first frame update
    void Start()
    {
        lastPosition = lastPlatform.position;

        StartCoroutine(SpawnPlatforms());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnPlatforms()
    {
        while(!stop)
        {
            GeneratePosition();

            //마지막 플랫폼블럭위치에 newPos만큼 새로운 플랫폼을 생성
            Instantiate(platform, newPos, Quaternion.identity);

            lastPosition = newPos;

            yield return new WaitForSeconds(0.1f);
        }
    }

    void GeneratePosition()
    {
        newPos = lastPosition;

        int rand = Random.Range(0, 2);

        if(rand>0)
        {
            newPos.x += 2.0f;
        }
        else
        {
            newPos.z += 2.0f;
        }
    }
}
