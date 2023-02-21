using UnityEngine;
using UnityEngine.Events;


public class Pen : MonoBehaviour
{
    [HideInInspector]

    public int Documents = 0;
    [HideInInspector]

    public UnityEvent SignEvent = new UnityEvent();
    private Signing_Task task;


    private void Start()
    {

        task = FindObjectOfType<Signing>();
    }


    public void Signing_Task()
    {
        Documents++;
        task.UpdateTask();
        SignEvent.Invoke();
    }

}
