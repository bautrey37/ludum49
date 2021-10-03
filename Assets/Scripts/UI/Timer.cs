
using TMPro;
using UnityEngine;

using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public static Timer Instance;
    public TextMeshProUGUI timeText;
    public float timeRemaining = 360;
    private bool timerIsRunning = false;

    private void Start()
    {
        timerIsRunning = true;
        float minutes = Mathf.FloorToInt(timeRemaining / 60);
        float seconds = Mathf.FloorToInt(timeRemaining % 60);

    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;
                Events.EndLevel(false);
            }
            DisplayTime(timeRemaining);
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

}
