using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Drawer : MonoBehaviour
{
    private SortFile task;

    private void Start()
    {
        task = FindObjectOfType<SortFile>();
    }

    public void FilePaper()
    {
        task.UpdateTask();
        if (task.currentAmount >= task.requiredAmount)
        {
            task.CompleteTask(task);
            task.SpawnFX(transform.position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Paper"))
        {
            FilePaper();
        }
    }
}
