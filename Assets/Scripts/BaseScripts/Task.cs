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
    private TaskEvent onComplete = new TaskEvent();


    /// <summary>
    /// Call this function when the criteria for completing the given task is met.
    /// </summary>
    /// <param name="task">Pass in the Task that calls this function.</param>
    protected virtual void CompleteTask(Task task)
    {
        onComplete.Invoke(task);
        //task ui will listen for when an event is completed and update the ui accordingly with the given task
    }
}
