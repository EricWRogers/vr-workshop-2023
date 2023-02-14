using UnityEngine;
using UnityEngine.Events;

public class Staple_Task : Task
{
    private Stapler stapler;

    private void Start()
    {
        stapler = FindObjectOfType<Stapler>();
        stapler.StapleEvent.AddListener(ManageTask);
    }
    private void ManageTask()
    {
        if (stapler.numStapled >= requiredAmount)
        {
            CompleteTask(this);
            Debug.Log("Task Done");
        }
    }
}

