using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SuperPupSystems.Helper;

public class WaterSpray : HallucinationEvent
{

    public ParticleSystem waterSpray;
    public Transform waterLocation;
    public Transform playerLocation;
    public Timer waterTimer;
    public float waterTimeActive;
    public float maxDistance;
    public float boxDistance;
    public float boxSize;

    private Collider m_Collider;

    private bool m_hitDetect;
    private RaycastHit m_hit;
    private bool isWaterActive = false;

    
    public void Start()
    {
        m_Collider = GetComponent<Collider>();

    }

    public void Update()
    {   
        m_hitDetect = Physics.BoxCast(m_Collider.bounds.center, transform.localScale * boxSize, transform.forward, out m_hit, transform.rotation, boxSize);
        Debug.Log("Detect: " + m_hitDetect);
        if(m_hitDetect)
        {
            Debug.Log("Hit: " + m_hit.collider.name);
        }
    }

    public override void PerformHallucinationEvent()
    {
        base.PerformHallucinationEvent();
        m_hitDetect = Physics.BoxCast(m_Collider.bounds.center, transform.localScale * boxSize, transform.forward, out m_hit, transform.rotation, boxDistance);
        if(m_hitDetect)
        {
            Debug.Log("Hit: " + m_hit.collider.name);
        }
    }

    /*public void OnTriggerEnter(Collider other)
    {
        PerformHallucinationEvent();
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
*/

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        if(m_hitDetect)
        {
            Gizmos.DrawRay(transform.position, transform.forward * m_hit.distance);
            Gizmos.DrawWireCube(transform.position + transform.forward * boxDistance, transform.localScale * boxSize);
        }
        else
        {
            Gizmos.DrawRay(transform.position, transform.forward * boxDistance);
            Gizmos.DrawWireCube(transform.position + transform.forward * boxDistance, transform.localScale * boxSize);
        }
    }

    public void EndWater()
    {
        float dist = Vector3.Distance(waterLocation.position, playerLocation.position);
        if (dist > maxDistance)
        {
            FinishHallucinationEvent();
            waterSpray.gameObject.SetActive(false);
            isWaterActive = false;
        }
        else
        {
            waterTimer.StartTimer();
        }
    }
}
