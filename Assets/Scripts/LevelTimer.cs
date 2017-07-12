using UnityEngine;
using UnityEngine.UI;
using System;

public class LevelTimer : MonoBehaviour 
{
    private Text timeRemainingText;
    private Slider slider;
    private Timer timer;
    private Text winText;

    void Start() 
    {
        timeRemainingText = transform.Find("TimeRemaining").GetComponent<Text>();
        winText = transform.Find("Win Text").GetComponent<Text>();
        slider = transform.Find("Slider").GetComponent<Slider>();
        timer = GetComponent<Timer>();
        timer.Tick += (timeRemaining) => {
            slider.value = 1f / (float) timer.timerSeconds * timeRemaining;
            timeRemainingText.text = timeRemaining.ToString();
        };
        timer.Finish += () => {
            winText.enabled = true;
            Time.timeScale = 0;
        };
        timer.Run();
    }
}
