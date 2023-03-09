using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEvent : HallucinationEvent
{
    public override void PerformHallucinationEvent()
    {
        base.PerformHallucinationEvent();

        Debug.Log("Performing Event: " + hallucinationName);

        //FinishHallucinationEvent();
    }
}
