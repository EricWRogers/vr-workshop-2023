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
    private float minValue = 0.0f;
    private float maxValue = 1.0f;
    public float energyLeft = 0.0f;
    public float hydrationLeft = 0.0f; // { get; set { Mathf.Clamp(value, 0, 1); } }
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
        coffeeCup = FindObjectOfType<CoffeeCup>();
        coffeeCup.onDrink.AddListener(AddPoints);
        bottleWater = FindObjectOfType<BottleWater>();
        bottleWater.onDrink.AddListener(AddHydration);
    }

    public void AddPoints(float amount)
    {
        energyLeft += amount;
        energyLeft = Mathf.Clamp(energyLeft, minValue, maxValue);
        energyBar.slider.value = energyLeft;
    }

    public void AddHydration(float waterAmount)
    {
        hydrationLeft += waterAmount;
        hydrationLeft = Mathf.Clamp(hydrationLeft, minValue, maxValue);
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
        if(energyBar.slider.value <= 0f)
        {
            //Debug.Log("Game Over");
            gameOver.Invoke();
        }
    }
}
