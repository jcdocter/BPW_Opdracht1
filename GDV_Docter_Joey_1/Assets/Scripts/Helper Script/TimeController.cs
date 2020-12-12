using System;
using UnityEngine;
using TMPro;

//made by Joey Docter
//timer
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
        // start timer on 5 minutes
        gameTimer.text = "5:00.00";
        timerOnGoing = true;
    }
    void Update()
    {
        TimeCounter(); 
    }

    void TimeCounter()
    {
        // countdown
        elapsedTime -= Time.deltaTime;
        timePlaying = TimeSpan.FromSeconds(elapsedTime);
        string timeText = timePlaying.ToString("m':'ss'.'ff");
        gameTimer.text = timeText;

        // reset game
        if (elapsedTime <= 0f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }

    // gain seconds if enemy is death
    public void AddTime(float addTime)
    {
        elapsedTime += addTime;
    }
}
