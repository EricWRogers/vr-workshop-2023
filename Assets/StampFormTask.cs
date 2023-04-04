using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StampFormTask : Task
{
    private StampForm stampForm;

    private void Start()
    {
        stampForm = FindObjectOfType<StampForm>();
        stampForm.stampedEvent.AddListener(ManageTask);
    }

    private void ManageTask()
    {
        if (currentAmount >= requiredAmount)
            CompleteTask(this);
            
    }
}
