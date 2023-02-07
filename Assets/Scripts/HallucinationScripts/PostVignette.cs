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

        if (isActive == false)
        {
            vignetteObj.SetActive(true);
            isOn = true;
        }
        else if (isActive == true)
        {
            vignetteObj.SetActive(false);
            isOn = false;
        }

        FinishHallucinationEvent();
    }
}
