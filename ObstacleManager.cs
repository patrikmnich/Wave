using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{

    public GameObject PlayerObj;
    public GameObject[] ObstaclesArr;


    int obstacleCount;

    int playerDistanceIndex = -1;
    int obstacleIndex = 0;
    int distanceToNext = 40;

    void Start()
    {
        obstacleCount = ObstaclesArr.Length;
        InstantiaceObstacle();
    }

    void Update()
    {
        int PlayerDistance = (int)(PlayerObj.transform.position.y / (distanceToNext));

        if (playerDistanceIndex != PlayerDistance)
        {
            InstantiaceObstacle();
            playerDistanceIndex = PlayerDistance;
        }
    }

    public void InstantiaceObstacle()
    {
        int RandomInt = Random.Range(0, obstacleCount);
        GameObject newObstacle = Instantiate(ObstaclesArr[RandomInt], new Vector3(0, obstacleIndex * distanceToNext), Quaternion.identity);
        Debug.Log("spawned obstacle" + ObstaclesArr[RandomInt]);
        newObstacle.transform.SetParent(transform);
        obstacleIndex++;

    }

}
