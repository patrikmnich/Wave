using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{
    public GameObject GameOverPanel;
    public GameObject Score;
    private Canvas canvas;

    public TextMeshProUGUI currentScoreText;
    public TextMeshProUGUI bestScoreText;
    public TextMeshProUGUI bestScoreString;
    public TextMeshProUGUI scoreTextString;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI currencyText;


    int currentScore;
    private int currency;
    public double timeLeft;

    Player player;

    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }
    void Start()
    {
        currentScore = 0;
        //PlayerPrefs.SetInt("BestScore", 0); //ak chces vynulovat best skore pri kazdom spusteni
        bestScoreText.text = PlayerPrefs.GetInt("BestScore", 0).ToString();
        currency = PlayerPrefs.GetInt("Currency", 0);
        currencyText.text = "• " + PlayerPrefs.GetInt("Currency", 0).ToString();
        SetScore();
    }

    void FixedUpdate()
    {
        Timer();

        if (Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene("Menu");
    }

    public void CallGameOver()
    {
        StartCoroutine(GameOver());
        //StopTimer();
    }


    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(0.5f);
        canvas = Score.GetComponent<Canvas>();
        canvas.sortingOrder = 2;
        GameOverPanel.SetActive(true);
        yield break;
    }

    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }

    public void AddScore()
    {
        //TODO: nastavit aby bod pridavalo prejdenie prekazky, nie zbieranie bodu - pridanim timera bod pridava len cas
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
            timeLeft -= Time.fixedDeltaTime;
            timerText.text = timeLeft.ToString("F");
        }
        else if (timeLeft < 0)
        {
            timerText.text = "0.00";
        }
    }
     
    public void AddTime()
    {
        timeLeft += 3;
    }

    public void AddCurrency()
    {
        currency++;
        currencyText.text = "• " + currency.ToString();
        PlayerPrefs.SetInt("Currency", currency);
    }
}

