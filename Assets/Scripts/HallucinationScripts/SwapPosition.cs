using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapPosition : HallucinationEvent
{
    public GameObject object1;
    public GameObject object2;
    private Vector3 tempPos;

    public override void PerformHallucinationEvent()
    {
        base.PerformHallucinationEvent();

        tempPos = object1.transform.position;
        object1.transform.position = object2.transform.position;
        object2.transform.position = tempPos;

        FinishHallucinationEvent();
    }
}
