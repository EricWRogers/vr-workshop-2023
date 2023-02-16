using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropzone : MonoBehaviour
{
    private PenTask task;
    void Start()
    {
        task = FindObjectOfType<PenTask>();
    }

    private void OnTriggerEnter(Collider other){
        if(!other.CompareTag("Pen"))
            return;
        task.UpdateTask();

        if(task.currentAmount >= task.requiredAmount)
        {
            task.CompleteTask(task);
            task.SpawnFX(transform.position);
        }
    }
    private void OnTriggerExit(Collider other){
        if(!other.CompareTag("Pen"))
            return;
        task.UpdateTask(-1);
    }
}
