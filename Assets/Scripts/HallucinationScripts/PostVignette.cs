using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostVignette : HallucinationEvent
{
    public GameObject vignetteObj;

    public override void PerformHallucinationEvent()
    {
        base.PerformHallucinationEvent();

        if (vignetteObj == false)
        {
            vignetteObj.SetActive(true);
        }
        else if (vignetteObj == true)
        {
            vignetteObj.SetActive(false);
        }
        
    }
}
