using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Drawer : MonoBehaviour
{
    [HideInInspector]
    public int numFiled = 0;

    [HideInInspector]
    public UnityEvent filedEvent = new UnityEvent();

    private SortFile task;

    private void Start()
    {
        task = FindObjectOfType<SortFile>();
    }

    public void FilePaper()
    {
        numFiled++;
        task.UpdateTask();
        filedEvent.Invoke();
    }
}
