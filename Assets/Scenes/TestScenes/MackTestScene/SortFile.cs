using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SortFile : Task
{
    private Drawer drawer;

    private void Start()
    {
        drawer = FindObjectOfType<Drawer>();
        drawer.filedEvent.AddListener(ManageTask);
    }

    private void ManageTask()
    {
        if (drawer.numFiled >= requiredAmount)
        {
            Debug.Log("Task Completed");
            CompleteTask(this);
        }
    }
}
