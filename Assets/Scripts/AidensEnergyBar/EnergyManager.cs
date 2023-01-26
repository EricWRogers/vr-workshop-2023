using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyManager : MonoBehaviour
{
    public static EnergyManager instance;

    public string sceneName;
    public int score = 0;
    public EnergyBar energyBar;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }

    public void AddPoints(int amount)
    {
        score += amount;
        energyBar.slider.value = score;
    }

    //public void GameOver()
    //{
    //    GameManager.instance.loadScene(sceneName);
    //}
}
