using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FloorParticles : HallucinationEvent
{
    public ParticleSystem floor;

    private void Start()
    {
        floor.Stop();
    }

    private bool isFloorOn = false;

    public override void PerformHallucinationEvent()
    {
        base.PerformHallucinationEvent();

        if (HallucinationEvent.isActive == true && isFloorOn == false)
        {
            TurnOnFloorParticles();
            Debug.Log("turn on " + HallucinationEvent.isActive);
        }
        else if(HallucinationEvent.isActive == false && isFloorOn == true)
        {
            TurnOffFloorParticles();
            Debug.Log("turn off " + HallucinationEvent.isActive);
        }
        else
        {
            Debug.Log("perhaps " + HallucinationEvent.isActive);
        }
        
        FinishHallucinationEvent();
    }

    public void TurnOnFloorParticles()
    {
        floor.Play();
        isFloorOn = true;
    }

    public void TurnOffFloorParticles()
    {
        floor.Stop();
        isFloorOn = false;
    }
}
