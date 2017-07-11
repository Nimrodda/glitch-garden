using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour 
{
    public int timerSeconds;
    public bool autoReset;

    public delegate void TickEvent(int timeRemaining);
    public delegate void FinishEvent();

    public event TickEvent Tick;
    public event FinishEvent Finish;

    public void Run() 
    {
        StartCoroutine(CountDown(timerSeconds));
    }
    
    private IEnumerator CountDown(int timeRemaining)
    {
        while (timeRemaining >= 0)
        {
            if (Tick != null)
            {
                Tick(timeRemaining);
            }
            yield return new WaitForSeconds(1f);
            timeRemaining--;
        }

        if (autoReset)
        {
            StartCoroutine(CountDown(timerSeconds));
        }

        if (Finish != null)
        {
            Finish();
        }
    }
}
