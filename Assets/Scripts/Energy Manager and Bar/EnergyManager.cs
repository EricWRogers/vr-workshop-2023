using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnergyManager : MonoBehaviour
{
    public static EnergyManager instance;
    private CoffeeCup coffeeCup;
    private BottleWater bottleWater;
    public UnityEvent gameOver;

    public bool hasWater { get { return waterBar.slider.value > 0.0f; } }
    public string sceneName;
    public float energyLeft = 0;
    public float hydrationLeft = 0;
    public float waterLossRate = 0.01f;
    public float energyLossRate = 0.01f;
    public EnergyBar energyBar;
    public EnergyBar waterBar;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }

    void Start()
    {
        //coffeeCup = GameObject.FindObjectOfType<CoffeeCup>();
        //coffeeCup.onDrink.AddListener(AddPoints);
        //bottleWater = GameObject.FindObjectOfType<BottleWater>();
        //bottleWater.onDrink.AddListener(AddHydration);
    }

    public void AddPoints(float amount)
    {
        energyLeft += amount;
        energyBar.slider.value = energyLeft;
    }

    public void AddHydration(float waterAmount)
    {
        hydrationLeft += waterAmount;
        waterBar.slider.value =+ hydrationLeft;
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

    public void TimeDown()
    {
        if(hasWater)
        {
           AddHydration(waterLossRate);
        }
        else
        {
            AddPoints(energyLossRate);
        }
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
