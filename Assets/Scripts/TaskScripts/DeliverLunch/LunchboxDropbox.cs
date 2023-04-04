using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LunchboxDropbox : MonoBehaviour
{
    private LunchboxTask task;

    void Start()
    {
        task = FindObjectOfType<LunchboxTask>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("LunchBox"))
        {
            task.UpdateTask();
            Debug.Log("LunchBox Added");
            if(task.currentAmount >= task.requiredAmount)
            {
                Debug.Log("LunchBox Done");
                task.CompleteTask(task);
                
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("LunchBox"))
        {
            task.UpdateTask(-1);
            Debug.Log("Lunch Removed");
        }
    }
}
