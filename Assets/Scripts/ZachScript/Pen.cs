using UnityEngine;
using UnityEngine.Events;

public class Pen : MonoBehaviour
{
    [HideInInspector]

    public int Doc = 0;
    [HideInInspector]

    public UnityEvent SignEvent = new UnityEvent();
    private Signature_Task task;


    private void Start()
    {

        task = FindObjectOfType<Signature_Task>();
    }


    public void Signature_Task()
    {
        Doc++;
        task.UpdateTask();
        SignEvent.Invoke();
    }
}