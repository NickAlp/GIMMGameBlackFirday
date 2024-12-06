using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText; 
    public float timeRemaining = 120f; 
    private bool isTimerRunning = true;
    private bool isPaused = false; 

    void Update()
    {
        if (!isPaused && isTimerRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                UpdateTimerDisplay(timeRemaining);
            }
            else
            {
                timeRemaining = 0;
                isTimerRunning = false;
                TimerFinished();
            }
        }
    }

    public void TogglePauseMenu(bool paused)
    {
        isPaused = paused;
        timerText.gameObject.SetActive(!paused); 
    }

    void UpdateTimerDisplay(float timeToDisplay)
    {
        timeToDisplay = Mathf.Max(0, timeToDisplay);
        int minutes = Mathf.FloorToInt(timeToDisplay / 60);
        int seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void TimerFinished()
    {
        Debug.Log("Timer has finished!");
    }
}
