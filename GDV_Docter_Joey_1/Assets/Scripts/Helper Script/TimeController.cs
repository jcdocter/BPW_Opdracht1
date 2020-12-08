using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TimeController : MonoBehaviour
{
    public static TimeController instance;

    public TextMeshProUGUI gameTimer;
    private TimeSpan timePlaying;
    private bool timerOnGoing;

    private float elapsedTime = 300f;

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
            FindObjectOfType<GameManager>().EndGame();
        }
    }

    public void AddTime(float addTime)
    {
        elapsedTime += addTime;
    }
}
