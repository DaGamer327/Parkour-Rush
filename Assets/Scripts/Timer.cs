using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 405;
    public bool timerIsRunning = false;
    public Text timeText;

    private void Start()
    {
        // Starts the timer automatically
        timerIsRunning = true;
    }

    void Update()
    {
        if (timerIsRunning)
        {
                timeRemaining += Time.deltaTime;
                DisplayTime(timeRemaining);
        
            if (timeRemaining > 480)
            {
                SceneManager.LoadScene(4);
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00} AM", minutes, seconds);
    }
}