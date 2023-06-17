using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Timer : MonoBehaviour
{
      public float totalTime = 60f;
    public TextMeshProUGUI timerText;

    private float timeLeft;

    [SerializeField] private WinLoseLevel winLoseLevel;

    private void Start()
    {
        timeLeft = totalTime;
    }

    private void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0f)
        {
            timeLeft = 0f;
            // Do something here when the timer reaches 0

            winLoseLevel.loseGame();
        }

        // Convert the remaining time to minutes and seconds
        int minutes = Mathf.FloorToInt(timeLeft / 60f);
        int seconds = Mathf.FloorToInt(timeLeft % 60f);

        // Update the text of the TextMeshProUGUI component
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }


    //disable all the script of the enemy
    
}
