using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnergyManager : MonoBehaviour
{
    public static EnergyManager instance;
    private CoffeeCup coffeeCup;
    public UnityEvent gameOver;

    public string sceneName;
    public float energyLeft = 0;
    public EnergyBar energyBar;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }

    void Start()
    {
        coffeeCup = GameObject.FindObjectOfType<CoffeeCup>();
        coffeeCup.onDrink.AddListener(AddPoints);
    }

    public void AddPoints(float amount)
    {
        energyLeft += amount;
        energyBar.slider.value = energyLeft;
    }

    public Tier GetTier()
    {
        if (energyBar.slider.value <= 1 && energyBar.slider.value >= 0.67)
            return Tier.Low;
        if (energyBar.slider.value <= .66 && energyBar.slider.value >= .34)
            return Tier.Medium;
        if (energyBar.slider.value <= .34 && energyBar.slider.value >= .00)
            return Tier.High;
        return Tier.Low;
    }

    public void GameOver()
    {
        if(energyBar.slider.value == 0f)
        {
            //Debug.Log("Game Over");
            gameOver.Invoke();
        }
    }
}
