using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Drawer : MonoBehaviour
{
    [HideInInspector]
    public UnityEvent filedEvent = new UnityEvent();

    private SortFile task;

    private void Start()
    {
        task = FindObjectOfType<SortFile>();
    }

    public void FilePaper()
    {
        task.UpdateTask();
        filedEvent.Invoke();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Paper"))
        {
            FilePaper();
        }
    }
}
