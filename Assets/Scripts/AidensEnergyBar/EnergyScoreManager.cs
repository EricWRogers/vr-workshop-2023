using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyScoreManager : MonoBehaviour
{
    public static EnergyScoreManager instance;

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
