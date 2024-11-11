using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerUI : MonoBehaviour
{
    public Text timerText;
    public GameManager gameManager;

    private void Update()
    {
        timerText.text = gameManager.evacuationTime.ToString("F2") + "s";
    }
}
