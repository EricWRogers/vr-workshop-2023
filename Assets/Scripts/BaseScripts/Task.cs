using UnityEngine;
using UnityEngine.Events;
using Unity.XR.CoreUtils;

/*
 * **NEVER** directly make a change to this script.
 * If you think something might need to be added, let me (Ben Lawrence) know and I'll get with you and add it personally.
 */

/// <summary>
/// Custom Unity Event class to take in a Task as an argument.
/// </summary>
[System.Serializable]
public class TaskEvent : UnityEvent<Task> { }

public class Task : MonoBehaviour
{
    public string taskName;
    [TextArea]
    public string taskDescription;
    public int requiredAmount;
    public GameObject completeParticles;

    [HideInInspector]
    public TaskEvent onComplete = new TaskEvent();
    [HideInInspector]
    public UnityEvent onTaskUpdated = new UnityEvent();
    [HideInInspector]
    public int currentAmount = 0;
    [HideInInspector]
    public string currentText;

    private bool completed = false;
    private bool playedEffects = false;


    /// <summary>
    /// Call this function when the criteria for completing the given task is met.
    /// </summary>
    /// <param name="task">Pass in the Task that calls this function.</param>
    public virtual void CompleteTask(Task task)
    {
        if (completed)
            return;
        
        onComplete.Invoke(task);
        completed = true;
        //task ui will listen for when an event is completed and update the ui accordingly with the given task
        //Instantiate(completeParticles, FindObjectOfType<XROrigin>().transform.position, Quaternion.identity);
        FindObjectOfType<TaskManager>().tasks.Remove(task);
    }

    /// <summary>
    /// Call this function when you increment the amount of a task the player has done.
    /// </summary>
    public virtual void UpdateTask()
    {
        currentAmount++;    //increases the current amount of the task completed.
        onTaskUpdated.Invoke(); //invokes the event that the UI listens to.
    }
    
    /// <summary>
    /// Same functionality as the normal UpdateTask but with a custom amount to increment/decrement.
    /// </summary>
    /// <param name="amount">Amount to add or subtract from the current amount. Add a negative to subtract.</param>
    public virtual void UpdateTask(int amount)
    {
        currentAmount += amount;
        onTaskUpdated.Invoke();
    }

    public virtual void SpawnFX(Vector3 position, Quaternion rotation)
    {
        if (playedEffects)
            return;
        
        playedEffects = true;
        Instantiate(completeParticles, position, rotation);
    }

    public virtual void SpawnFX(Vector3 position)
    {
        if (playedEffects)
            return;
        
        playedEffects = true;
        
        Instantiate(completeParticles, position, Quaternion.identity);
    }
}
