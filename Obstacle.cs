using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    public int RotationSpeed;

    public GameObject obj;
    public bool FadeOut;
    public bool FadeIn = false;

    private int interpolationFramesCount = 320; // Number of frames to completely interpolate between the 2 positions
    public int collisionOffTime;
    private int collisionOffTimeCounter;
    private int elapsedFrames = 0;

    public bool isDead = false;

    private Color startingColor;
    private Color alphaZero;
    private Color interpolateColor;
    BoxCollider2D obstacle_Collider;


    void Awake()
    {
        obstacle_Collider = GetComponent<BoxCollider2D>();
        startingColor = alphaZero = obj.GetComponent<SpriteRenderer>().material.color;
        alphaZero.a = 0f;
        collisionOffTimeCounter = collisionOffTime;
    }

    void Update()
    {
        if (isDead == false)
        {

            if (RotationSpeed != 0)
            {
                Rotation();
            }

            if (FadeOut)
            {
                float interpolationRatio = (float)elapsedFrames / interpolationFramesCount;
                interpolateColor = Color.Lerp(startingColor, alphaZero, interpolationRatio);
                obj.GetComponent<SpriteRenderer>().material.color = interpolateColor;
                elapsedFrames++;

                //Debug.Log(interpolateColor);

                if (interpolateColor == alphaZero)
                {
                    collisionOffTimeCounter--;
                    obstacle_Collider.enabled = false;
                    if (collisionOffTimeCounter == 0)
                    {
                        obstacle_Collider.enabled = true;
                        FadeOut = false;
                        FadeIn = true;
                        elapsedFrames = 0;
                        collisionOffTimeCounter = collisionOffTime;
                        Debug.Log("turning collision back on");
                    }
                    //obstacle_Collider.enabled = true;
                }
            }

            if (FadeIn)
            {
                float interpolationRatio = (float)elapsedFrames / interpolationFramesCount;
                interpolateColor = Color.Lerp(alphaZero, startingColor, interpolationRatio);
                obj.GetComponent<SpriteRenderer>().material.color = interpolateColor;
                elapsedFrames++;

                if (interpolateColor == startingColor)
                {
                    FadeOut = true;
                    FadeIn = false;
                    elapsedFrames = 0;
                }
            }
        }

    }

    void Rotation()
    {
        transform.Rotate(Vector3.forward * Time.deltaTime * RotationSpeed);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isDead = true;
        }
    }
}
