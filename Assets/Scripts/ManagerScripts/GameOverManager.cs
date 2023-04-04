using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SuperPupSystems.Helper;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public float waitTime = 3f;
    private Timer timer;

    private void Start()
    {
        timer = GetComponent<Timer>();

        timer.StartTimer(waitTime);
        timer.TimeOut.AddListener(Reload);
    }

    public void Reload()
    {
        SceneManager.LoadScene(0);
    }
}
