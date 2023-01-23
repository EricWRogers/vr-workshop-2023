using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SuperPupSystems.Helper;
using TMPro;

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
    public int hourSpeed;
    public TMP_Text timeText;

    private int clockTimeTracker = 0;
    private int minutes = 0;

    void Start()
    {
        clockTimer.StartTimer(hourSpeed, clockTimer.AutoRestart);
        Debug.Log("Test: " + clockTimer.TimeLeft);
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
                Debug.Log("It is 9 AM");
                break;
            case 1:
                CURRENT_TIME = TIME_OF_DAY.TEN;
                Debug.Log("It is 10 AM");
                break;
            case 2:
                CURRENT_TIME = TIME_OF_DAY.ELEVEN;
                Debug.Log("It is 11 AM");
                break;
            case 3:
                CURRENT_TIME = TIME_OF_DAY.TWELVE;
                Debug.Log("It is 12 PM");
                break;
            case 4:
                CURRENT_TIME = TIME_OF_DAY.ONE;
                Debug.Log("It is 1 PM");
                break;
            case 5:
                CURRENT_TIME = TIME_OF_DAY.TWO;
                Debug.Log("It is 2 PM");
                break;
            case 6:
                CURRENT_TIME = TIME_OF_DAY.THREE;
                Debug.Log("It is 3 PM");
                break;
            case 7:
                CURRENT_TIME = TIME_OF_DAY.FOUR;
                Debug.Log("It is 4 PM");
                break;
            case 8:
                CURRENT_TIME = TIME_OF_DAY.FIVE;
                Debug.Log("It is 5 PM");
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
                break;

        }
        if(hourSpeed - clockTimer.TimeLeft < 10)
        {
            timeString += "0";
        }
        timeString += (int)(hourSpeed - clockTimer.TimeLeft);
        timeText.text = timeString;
    }
}
