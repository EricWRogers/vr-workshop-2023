using UnityEngine;
using UnityEngine.Events;


public class Trash : MonoBehaviour
{
    [HideInInspector]

    public int TrashBags = 0;
    [HideInInspector]

    public UnityEvent TrashEvent = new UnityEvent();
    private Trash_Task task;


    private void Start()
    {

        task = FindObjectOfType<Trash_Task>();
    }


    public void Trash_Task()
    {
        TrashBags++;
        task.UpdateTask();
        TrashEvent.Invoke();
    }

}