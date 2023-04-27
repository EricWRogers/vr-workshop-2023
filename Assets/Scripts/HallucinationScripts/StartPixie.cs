using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPixie : HallucinationEvent
{
    public GameObject pixie;
    public override void PerformHallucinationEvent()
    {
        //Always make sure this base call comes first.
        base.PerformHallucinationEvent();
        pixie.SetActive(true);
        
    }
}
