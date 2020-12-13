using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuColor : MonoBehaviour
{
    float hueValue;

    void Start()
    {
        SetMenuColor();        
    }

    void SetMenuColor()
    {
        hueValue = Random.Range(0f, 1f);
        Camera.main.backgroundColor = Color.HSVToRGB(hueValue, 0.6f, 0.8f);
    }

}
