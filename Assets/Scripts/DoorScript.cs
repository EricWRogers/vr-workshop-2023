using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    float distanceFromDoor;
    public GameObject doorOpen;
    public GameObject doorClose;
    private bool isDoorOpen = false;
    public float maxDistance;
    public Transform doorLocation;
    public Transform playerLocation;

    public void OnTriggerEnter(Collider other)
    {
        

        if (other.tag == "Player")
        {
            Debug.Log("trigger");
            Debug.Log("trigger" + isDoorOpen);
            if (isDoorOpen == false)
            {
                Debug.Log("trigger Here");
                Debug.Log("trigger" + isDoorOpen);
                doorOpen.SetActive(true);
                doorClose.SetActive(false);
                isDoorOpen = true;
            }
        }

    }

    public void Update()
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
    }

    public void OpenDoor()
    {
        doorOpen.SetActive(true);
        doorClose.SetActive(false);
    }

    public void CloseDoor()
    {
        float dist = Vector3.Distance(doorLocation.position, playerLocation.position);
        if (dist > maxDistance)
        {
            doorOpen.SetActive(false);
            doorClose.SetActive(true);
        }
    }

}
