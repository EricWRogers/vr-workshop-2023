using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SuperPupSystems.Helper;

public class DoorScript : MonoBehaviour
{
    float distanceFromDoor;
    public GameObject doorOpen;
    public GameObject doorClose;
    private bool isDoorOpen = false;
    public float maxDistance;
    public float timeToDoorClose;
    public Transform doorLocation;
    public Transform playerLocation;
    public Timer doorTimer;
    public Animator doorAnimation;

    public void OnTriggerEnter(Collider other)
    {


        if (other.tag == "Player")
        {
            Debug.Log("trigger");
            Debug.Log("trigger" + isDoorOpen);
            if (isDoorOpen == false)
            {
                doorTimer.StartTimer(timeToDoorClose, doorTimer.AutoRestart);
                Debug.Log("trigger Here");
                Debug.Log("trigger2" + isDoorOpen);
                doorAnimation.SetTrigger("OnDoorOpen");
                isDoorOpen = true;
            }
        }

    }

    /* public void Update()
     {
         float dist = Vector3.Distance(doorLocation.position, playerLocation.position);
         if (dist > maxDistance)
         {
             Debug.Log("trigger What");
             Debug.Log("trigger" + isDoorOpen);
             doorOpen.SetActive(false);
             doorClose.SetActive(true);
             isDoorOpen = false;
         }
     }*/

    public void OpenDoor()
    {
        doorTimer.StartTimer(timeToDoorClose, doorTimer.AutoRestart);
        doorAnimation.SetTrigger("OnDoorOpen");
    }

    public void CloseDoor()
    {
        float dist = Vector3.Distance(doorLocation.position, playerLocation.position);
        if (dist > maxDistance)
        {
            doorAnimation.SetTrigger("OnDoorClose");
            isDoorOpen = false;
        }
        else
        {
            doorTimer.StartTimer();
        }


    }

}
