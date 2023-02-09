using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PhonePickedUp : Task
{
    //[HideInInspector]
    public float secondsHeld = 0;
    //[HideInInspector]
    public bool phoneHeld = false;
    [HideInInspector]
    public UnityEvent phoneEvent = new UnityEvent();

    public void phoneAnswered()
    {
        phoneEvent.Invoke();
    }

    void Awake()
    {
        Debug.Log("hi");
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Phone Held");
        phoneHeld = true;
        while (other.CompareTag("Player")) && secondsHeld != 4
        {
            
            secondsHeld += Time.deltaTime;

            Debug.Log("Phone Held");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            phoneHeld = false;
            secondsHeld = 0;

            Debug.Log("Phone not held");
        }
    }

}

public class CallTimer : PhonePickedUp
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Phone Held");
        phoneHeld = true;
        while (other.CompareTag("Player"))
        {
            
            secondsHeld += Time.deltaTime;

            Debug.Log("Phone Held");
        }
    }


    private void OnTriggerExit(Collider other)
    { 
        phoneHeld = false;

        if (other.CompareTag("Player"))
        {
           
            secondsHeld = 0;

            Debug.Log("Phone not held");
        }
    }
}



public class CallTask : PhonePickedUp
{
    

    private PhonePickedUp phone;
    private PhonePickedUp Player;

    private void Start()
    {
       
        phone = FindObjectOfType<PhonePickedUp>();
        Player = FindObjectOfType<PhonePickedUp>();
       
        phone.phoneEvent.AddListener(ManageTask);
        Player.phoneEvent.AddListener(ManageTask);
    }

    private void ManageTask()
    {
 
        if (phone.secondsHeld == 4)
        {
            CompleteTask(this);

            Debug.Log("Phone Answered.");
        }
    }
}
