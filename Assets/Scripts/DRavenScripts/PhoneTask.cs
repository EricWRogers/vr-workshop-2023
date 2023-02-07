using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PhoneTask : Task
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

}

public class CallTimer : PhoneTask
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Phone Held");

        if (other.CompareTag("Player"))
        {
            phoneHeld = true;
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



public class CallTask : PhoneTask
{
    

    private PhoneTask phone;
    private PhoneTask Player;

    private void Start()
    {
       
        phone = FindObjectOfType<PhoneTask>();
        Player = FindObjectOfType<PhoneTask>();
       
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
