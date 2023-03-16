using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{
    public Slider slider;

    public void SetMinEnergy(float energy)
    {
        slider.minValue = energy;
        slider.value = energy;
    }

    public void SetEnergy(float energy)
    {
        slider.value = energy;
    }
}
