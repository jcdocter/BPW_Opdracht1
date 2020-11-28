using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TimeController : MonoBehaviour
{
    public static TimeController instance;

    public TextMeshProUGUI gameTimer;
    private TimeSpan timePlaying;
    private bool timerOnGoing;

    private float elapsedTime = 3f;

    void Awake()
    {
        instance = this;

    }
    void Start()
    {
        gameTimer.text = "5:00.00";
        timerOnGoing = true;
    }
    void Update()
    {
        TimeCounter(); 
    }

    void TimeCounter()
    {
        elapsedTime -= Time.deltaTime;
        timePlaying = TimeSpan.FromSeconds(elapsedTime);
        string timeText = timePlaying.ToString("m':'ss'.'ff");
        gameTimer.text = timeText;

        if (elapsedTime <= 0f)
        {
            GameOver();
        }
    }

    public void AddTime(float addTime)
    {
        elapsedTime += addTime;
    }

    void GameOver()
    {
        SceneManager.LoadScene(0);
    }
}
