using UnityEngine;
using UnityEngine.Events;

public class Trash_Task : Task
{
    private Trash trash;

    private void Start()
    {
        trash = FindObjectOfType<Trash>();
        trash.TrashEvent.AddListener(ManageTask);
    }
    private void ManageTask()
    {
        if (trash.TrashBags >= requiredAmount)
        {
            CompleteTask(this);
            Debug.Log("At night");
        }
    }
}