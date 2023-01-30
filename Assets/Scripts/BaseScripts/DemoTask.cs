using UnityEngine;
using UnityEngine.Events;

/*
 * This script should NEVER be used directly. 
 * I've left this here as an example of how you create a task and interface with my Task base class
 */

/// <summary>
/// This an example of a Shredder script that would be on a seperate shredder game object.
/// </summary>
public class Shredder : MonoBehaviour
{
    [HideInInspector]
    //[HideInInspector] is used when we want to have a variable with a public protection level without having it appear in the editor
    public int numShredded = 0;
    [HideInInspector]
    //Unity events are used to trigger certain functions that are listeners when the event is invoked
    public UnityEvent shreddedEvent = new UnityEvent();
    //This class needs a reference to the task it's involved with so it can call some events
    private ShredPaper task;

    //Start is a built in unity function that is called before the first frame of the game
    private void Start()
    {
        //This is one way to find a reference to the task since there should only be one version of the script in the scene
        task = FindObjectOfType<ShredPaper>();
    }

    /// <summary>
    /// Whenever a paper collides with the shredder, this function will be called to handle what comes next
    /// </summary>
    public void ShredPaper()
    {
        numShredded++;
        //You call this event whenever you update the amount of a task that has been completed. In this case since a paper has been shredded you increase this.
        task.UpdateTask();
        //This is how you invoke a Unity Event which will now call all functions that are listeners of this event.
        //The only listener of the shreddedEvent is on line 83 in the ShredPaper class
        shreddedEvent.Invoke();
    }
}

/// <summary>
/// This an example of a Paper script that would be on a seperate paper game object
/// </summary>
public class Paper : MonoBehaviour
{
    /// <summary>
    /// Built-in Unity function to detect collisions. In this case between the paper and the shredder.
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        //This will check if the object that the paper collides with is tagged as a shredder
        if (other.CompareTag("Shredder"))
        {
            //finds the Shredder script that is on the shredder game object the paper collided with
            //and tells it to shred the paper
            other.GetComponent<Shredder>().ShredPaper();
            //gameObject is a reference to the GameObject this script resides on.
            //We destroy it here to give the illusion that the paper was shredded.
            Destroy(gameObject);
        }
    }
}

/// <summary>
/// Demonstrative example of a task script you would create, which in this case is a task to shred x amount of paper.
/// Note that we inherit from Task instead of MonoBehaviour on line 72.
/// </summary>
public class ShredPaper : Task
{
    //This is to hold a reference to the shredder. Reference set on line 80
    private Shredder shredder;

    private void Start()
    {
        //There are multiple ways of finding objects in the scene but for this scenario FindObjectOfType is most performant.
        shredder = FindObjectOfType<Shredder>();
        //Because we have a reference to the shredder we can add a function in this class, ManageTask, as a listener of the shredded event.
        //Now whenever a paper collides with the shredder, the shredder will increment the amount of paper it has shredded and let this task script know that something has been shredded.
        shredder.shreddedEvent.AddListener(ManageTask);
    }

    /// <summary>
    /// Used to check if this task has been completed yet.
    /// While you could simply use the Update function for this, Unity events are much better as the code is not being run every frame, only exactly when you need it.
    /// </summary>
    private void ManageTask()
    {
        //simple check that will be made every time a paper is shredded. requiredAmount is inherited from Task
        if (shredder.numShredded >= requiredAmount)
        {
            //This function is not defined within the ShredPaper class but inside of the Task class which it inherits from.
            //No matter what task you are working on, it is INCREDIBLY important that you call this function whenever the completion criteria is met.
            //CompleteTask looks for a Task as an argument. You should generally always be passing in the class which calls CompleteTask which you can access with the 'this' keyword.
            CompleteTask(this);
        }
    }
}
