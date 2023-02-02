using UnityEngine;
using UnityEngine.Events;

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

    [HideInInspector]
    public TaskEvent onComplete = new TaskEvent();
    [HideInInspector]
    public UnityEvent onTaskUpdated = new UnityEvent();
    [HideInInspector]
    public int currentAmount = 0;
    [HideInInspector]
    public string currentText;


    /// <summary>
    /// Call this function when the criteria for completing the given task is met.
    /// </summary>
    /// <param name="task">Pass in the Task that calls this function.</param>
    public virtual void CompleteTask(Task task)
    {
        onComplete.Invoke(task);
        //task ui will listen for when an event is completed and update the ui accordingly with the given task
    }

    /// <summary>
    /// Call this function when you increment the amount of a task the player has done.
    /// </summary>
    public virtual void UpdateTask()
    {
        currentAmount++;    //increases the current amount of the task completed.
        onTaskUpdated.Invoke(); //invokes the event that the UI listens to.
    }
}
