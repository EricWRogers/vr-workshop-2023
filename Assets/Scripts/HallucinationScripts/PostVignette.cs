using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostVignette : HallucinationEvent
{
    public GameObject floorParticle;
    // bool isOn = false;

    public override void PerformHallucinationEvent()
    {
        base.PerformHallucinationEvent();

        FloorChange();

        //FinishHallucinationEvent();
    }

    public void FloorChange()
    {
        if(floorParticle == false)
        {
            floorParticle.SetActive(true);
            //isOn = true;
            Debug.Log("Floor particle on");
        }
        else if(floorParticle == true)
        {
            floorParticle.SetActive(false);
            //isOn = false;
            Debug.Log("Floor particle off");
        }
        else
            Debug.Log("something is wrong " + floorParticle);
    }
}
