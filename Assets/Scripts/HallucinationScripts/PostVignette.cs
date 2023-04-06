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

        floorParticle.SetActive(true);
        //if(!floorParticle.activeSelf)
        //{
        //    floorParticle.SetActive(true);
        //    //isOn = true;
        //    Debug.Log("Floor particle on");
        //}
        //else if(floorParticle.activeSelf)
        //{
        //    floorParticle.SetActive(false);
        //    //isOn = false;
        //    Debug.Log("Floor particle off");
        //}
        //else
        //    Debug.Log("something is wrong " + floorParticle);
    }
}
