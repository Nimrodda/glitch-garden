using UnityEngine;
using UnityEngine.UI;

public class LevelTimer : MonoBehaviour 
{
    private Text timeRemainingText;
    private Slider slider;
    private Timer timer;
    
    void Start() 
    {
        timeRemainingText = transform.Find("TimeRemaining").GetComponent<Text>();
        slider = transform.Find("Slider").GetComponent<Slider>();
        timer = GetComponent<Timer>();
        timer.Tick += (timeRemaining) => {
            slider.value = 1f / (float) timer.timerSeconds * timeRemaining;
            timeRemainingText.text = timeRemaining.ToString();
        };
        timer.Run();
    }
}
