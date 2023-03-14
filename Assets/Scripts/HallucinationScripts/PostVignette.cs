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

        vTurnOn();

        FinishHallucinationEvent();
    }

    public void testVignette()
    {
        if (isOn == false)
        {
            vTurnOn();
        }
        else if (isOn == true)
        {
            vTurnOff();
        }
    }

    public void vTurnOn()
    {
        vignetteObj.SetActive(true);
        isOn = true;
    }

    public void vTurnOff()
    {
        vignetteObj.SetActive(false);
        isOn = false;
    }
}
