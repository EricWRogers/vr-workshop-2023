using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyManager : MonoBehaviour
{
    public static EnergyManager instance;

    public string sceneName;
    public float score = 0;
    public EnergyBar energyBar;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }

    public void AddPoints(float amount)
    {
        score += amount;
        energyBar.slider.value = score;
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
}
