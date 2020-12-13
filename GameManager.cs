using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{
    public GameObject GameOverPanel;
    public GameObject MainMenuPanel;

    public TextMeshProUGUI currentScoreText;
    public TextMeshProUGUI bestScoreText;
    public TextMeshProUGUI timerText;

    int currentScore;
    public double timeLeft;

    Player player;

    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Player>();

    }
    void Start()
    {
        currentScore = 0;
        //PlayerPrefs.SetInt("BestScore", 0); --ak chces vynulovat best skore pri kazdom spusteni
        bestScoreText.text = PlayerPrefs.GetInt("BestScore", 0).ToString();
        SetScore();
        //timeLeftText.text = timeLeft.ToString();
    }

    void Update()
    {
        Timer();
    }

    public void CallGameOver()
    {
        StartCoroutine(GameOver());
        //StopTimer();
    }


    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(0.5f);
        GameOverPanel.SetActive(true);
        yield break;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void AddScore()
    {
        currentScore++;

        if (currentScore > PlayerPrefs.GetInt("BestScore", 0))
        {
            PlayerPrefs.SetInt("BestScore", currentScore);
            bestScoreText.text = currentScore.ToString();
            Debug.Log("text:" + bestScoreText.text);
        }
        
        SetScore();
    }

    void SetScore()
    {
        currentScoreText.text = currentScore.ToString();
    }

    public void Timer()
    {
        if ((timeLeft > -1) && (player.isDead == false))
        {
            timeLeft -= Time.deltaTime;
            timerText.text = timeLeft.ToString("F");
        }
        else if (timeLeft < 0)
        {
            timerText.text = "0.00";
        }
    }
     
    public void AddTime()
    {
        timeLeft += 5;
    }
}

