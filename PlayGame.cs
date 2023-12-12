using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    float hueValue;


    void Start()
    {
        SetMenuColor();
    }

    void Update()
    {

    }

    void SetMenuColor()
    {
        hueValue = Random.Range(0f, 1f);
        Camera.main.backgroundColor = Color.HSVToRGB(hueValue, 0.6f, 0.8f);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void OpenShop()
    {
        SceneManager.LoadScene("Shop");
    }

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
