using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SuperPupSystems.Helper;
using TMPro;
using UnityEngine.Events;

public enum TIME_OF_DAY
{
    NINE,
    TEN,
    ELEVEN,
    TWELVE,
    ONE,
    TWO,
    THREE,
    FOUR,
    FIVE
}
public class Clock : MonoBehaviour
{
    public Timer clockTimer;
    public TIME_OF_DAY CURRENT_TIME;
    public float blackoutScale;
    public TMP_Text timeText;

    private int clockTimeTracker = 0;
    private int minutes = 60;
    private string timeOfDay = "";
    [HideInInspector]
    public UnityEvent endOfDay = new UnityEvent();

    void Start()
    {
        clockTimer.StartTimer(minutes, clockTimer.AutoRestart);
        CURRENT_TIME = TIME_OF_DAY.NINE;
        timeText.text = "9:00 AM";
        
    }

    void Update()
    {
        TimeTracker();
        DisplayTime();
    }

    public void HourBump()
    {
        clockTimeTracker++;
    }


    public void TimeTracker()
    {
        switch(clockTimeTracker)
        {
            case 0:
                CURRENT_TIME = TIME_OF_DAY.NINE;
                timeOfDay = "AM";
                //Debug.Log("It is 9 AM");
                break;
            case 1:
                CURRENT_TIME = TIME_OF_DAY.TEN;
                timeOfDay = "AM";
                //Debug.Log("It is 10 AM");
                break;
            case 2:
                CURRENT_TIME = TIME_OF_DAY.ELEVEN;
                timeOfDay = "AM";
                //Debug.Log("It is 11 AM");
                break;
            case 3:
                CURRENT_TIME = TIME_OF_DAY.TWELVE;
                timeOfDay = "PM";
                //Debug.Log("It is 12 PM");
                break;
            case 4:
                CURRENT_TIME = TIME_OF_DAY.ONE;
                timeOfDay = "PM";
                //Debug.Log("It is 1 PM");
                break;
            case 5:
                CURRENT_TIME = TIME_OF_DAY.TWO;
                timeOfDay = "PM";
                //Debug.Log("It is 2 PM");
                break;
            case 6:
                CURRENT_TIME = TIME_OF_DAY.THREE;
                timeOfDay = "PM";
                //Debug.Log("It is 3 PM");
                break;
            case 7:
                CURRENT_TIME = TIME_OF_DAY.FOUR;
                timeOfDay = "PM";
                //Debug.Log("It is 4 PM");
                break;
            case 8:
                CURRENT_TIME = TIME_OF_DAY.FIVE;
                timeOfDay = "PM";
                //Debug.Log("It is 5 PM");
                endOfDay.Invoke();
                clockTimer.StopTimer();

                break;
        }
        
    }

    public void DisplayTime()
    {
        string timeString = "";
        switch(CURRENT_TIME)
        {
            case TIME_OF_DAY.NINE:
                timeString = "9:";
                break;
            case TIME_OF_DAY.TEN:
                timeString = "10:";
                break;
            case TIME_OF_DAY.ELEVEN:
                timeString = "11:";
                break;
            case TIME_OF_DAY.TWELVE:
                timeString = "12:";
                break;
            case TIME_OF_DAY.ONE:
                timeString = "1:";
                break;
            case TIME_OF_DAY.TWO:
                timeString = "2:";
                break;
            case TIME_OF_DAY.THREE: 
                timeString = "3:";
                break;
            case TIME_OF_DAY.FOUR:
                timeString = "4:";
                break;
            case TIME_OF_DAY.FIVE:
                timeString = "5:";
                minutes = 0;
                break;

        }
        if(minutes - clockTimer.TimeLeft < 10)
        {
            timeString += "0";
        }
        timeString += (int)(minutes - clockTimer.TimeLeft) + " " + timeOfDay;
        timeText.text = timeString;
    }

    public void Blackout(Tier _energyTier)
    {
        if(_energyTier == Tier.High)
        {
            clockTimer.timeScale = blackoutScale;
        }
    }
}
