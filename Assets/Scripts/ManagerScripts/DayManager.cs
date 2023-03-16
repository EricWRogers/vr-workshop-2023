using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
//public class Day
//{
//    [HideInInspector]
//    public Clock clock;
//    //public List<Task> tasks = new List<Task>();
//    public TaskManager taskManager;
//}

public class DayManager : MonoBehaviour
{
    public static DayManager Instance;
    private Clock clock;
    //public List<Day> days = new List<Day>();

    //private int dayIterator = 0;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Start()
    {
        clock = GetComponent<Clock>();
        clock.endOfDay.AddListener(LoadGameOver);
    }

    public void LoadGameOver()
    {
        if (clock.CURRENT_TIME == TIME_OF_DAY.FIVE)
        {
            //dayIterator++;
            SceneManager.LoadScene(1);
        }
    }

    public void EnergyMeterGameOver()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadWin()
    {
        SceneManager.LoadScene(SceneManager.GetSceneByName("Win").buildIndex);
    }
}
