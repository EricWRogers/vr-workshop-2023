using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PhoneTask : MonoBehaviour
{
    [HideInInspector]
    public float secondsHeld = 0;
    [HideInInspector]
    public UnityEvent phoneEvent = new UnityEvent();

    public void phoneAnswered()
    {
        secondsHeld+=4;
        phoneEvent.Invoke();
    }

}

public class CallTimer: MonoBehaviour
{
    private void OnTriggerEvent(Collider other)
    {
        if (other.CompareTag("Player"))
        {

        }
    }
}

public class CallTask : Task
{
    public float requiredSecondsHeld = 4;

    private PhoneTask phone;

    private void Start()
    {
        //There are multiple ways of finding objects in the scene but for this scenario FindObjectOfType is most performant.
        phone = FindObjectOfType<PhoneTask>();
        //Because we have a reference to the shredder we can add a function in this class, ManageTask, as a listener of the shredded event.
        //Now whenever a paper collides with the shredder, the shredder will increment the amount of paper it has shredded and let this task script know that something has been shredded.
        phone.phoneEvent.AddListener(ManageTask);
    }

    private void ManageTask()
    {
        //simple check that will be made every time a paper is shredded.
        if (phone.secondsHeld == 4)
        {
            //This function is not defined within the ShredPaper class but inside of the Task class which it inherits from.
            //No matter what task you are working on, it is INCREDIBLY important that you call this function whenever the completion criteria is met.
            //CompleteTask looks for a Task as an argument. You should generally always be passing in the class which calls CompleteTask which you can access with the 'this' keyword.
            CompleteTask(this);
        }
    }
}
