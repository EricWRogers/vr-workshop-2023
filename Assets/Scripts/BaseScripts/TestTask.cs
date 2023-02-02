using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTask : Task
{
    private bool doneOnce = false;

    private void Start()
    {
       
    }

    private void Update()
    {
        if (currentAmount >= requiredAmount && !doneOnce)
        {
            CompleteTask(this);
            doneOnce = true;
        }    
    }
}
