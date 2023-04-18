using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SuperPupSystems.Helper;

public class WaterSpray : MonoBehaviour
{

    public ParticleSystem waterSpray;
    public Transform waterLocation;
    public Transform playerLocation;
    public Timer waterTimer;
    public float waterTimeActive;
    public float maxDistance;

    private bool isWaterActive = false;

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if(isWaterActive == false)
            {
                waterSpray.gameObject.SetActive(true);
                isWaterActive = true;
                waterTimer.StartTimer(waterTimeActive, waterTimer.AutoRestart);
            }
                
        }
    }

    public void EndWater()
    {
        float dist = Vector3.Distance(waterLocation.position, playerLocation.position);
        if (dist > maxDistance)
        {
            waterSpray.gameObject.SetActive(false);
            isWaterActive = false;
        }
        else
        {
            waterTimer.StartTimer();
        }
    }
}
