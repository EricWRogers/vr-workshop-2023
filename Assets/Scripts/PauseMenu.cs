using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    public GameObject player;
    public Transform pauseSpawn;

    private Vector3 lastPos;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.JoystickButton6))
        {
            Debug.Log("test");
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        player.transform.position = lastPos;
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        lastPos = player.transform.position;
        player.transform.position = pauseSpawn.transform.position;
        //Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        Debug.Log("Loading Menu...");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
    }
}
