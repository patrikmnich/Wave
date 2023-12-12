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
    int distanceToNext = 1400;

    Player player;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        obstacleCount = ObstaclesArr.Length;
        InstantiaceObstacle();
    }

    void Update()
    {
        if (player.isDead == false)
        {
            int PlayerDistance = (int)(PlayerObj.transform.position.y / (distanceToNext));

        if (playerDistanceIndex != PlayerDistance)
        {
            InstantiaceObstacle();
            playerDistanceIndex = PlayerDistance;
        }
        }
    }

    public void InstantiaceObstacle()
    {
        //TODO: nastavit generovanie prekazok podla toho kolko ma hrac bodov
        int RandomInt = Random.Range(0, obstacleCount);
        GameObject newObstacle = Instantiate(ObstaclesArr[RandomInt], new Vector3(0, obstacleIndex * distanceToNext), Quaternion.identity);
        Debug.Log("spawned obstacle" + ObstaclesArr[RandomInt]);
        newObstacle.transform.SetParent(transform);
        obstacleIndex++;

    }

}
