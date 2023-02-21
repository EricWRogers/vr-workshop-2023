using UnityEngine;
using UnityEngine.Events;

public class Signing : Task
{
    private Signing signing;

    private void Start()
    {
        signing = FindObjectOfType<Pen>();
        signing.SignEvent.AddListener(ManageTask);
    }
    private void ManageTask()
    {
        if (Pen.Documents >= requiredAmount)
        {
            CompleteTask(this);
            Debug.Log("Task Done");
        }
    }
}
