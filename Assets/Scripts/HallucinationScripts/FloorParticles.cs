using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorParticles : HallucinationEvent
{
    public GameObject floorParts;
    public override void PerformHallucinationEvent()
    {
        base.PerformHallucinationEvent();

        floorParts.SetActive(true);

        FinishHallucinationEvent();
    }
}
