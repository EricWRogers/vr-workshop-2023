using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostVignette : HallucinationEvent
{
    public GameObject vignetteObj;
    bool isOn = false;

    public override void PerformHallucinationEvent()
    {
        base.PerformHallucinationEvent();

        turnOn();

        FinishHallucinationEvent();
    }

    public void testVignette()
    {
        if (isOn == false)
        {
            turnOn();
        }
        else if (isOn == true)
        {
            turnOff();
        }
    }

    public void turnOn()
    {
        vignetteObj.SetActive(true);
        isOn = true;
    }

    public void turnOff()
    {
        vignetteObj.SetActive(false);
        isOn = false;
    }
}
