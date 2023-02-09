using UnityEngine;
using UnityEngine.Events;


public class Stapler : MonoBehaviour
{
    [HideInInspector]

    public int numStapled = 0;
    [HideInInspector]

    public UnityEvent StapleEvent = new UnityEvent();
    private Staple_Task task;


    private void Start()
    {

        task = FindObjectOfType<Staple_Task>();
    }


    public void Staple_Task()
    {
        numStapled++;
        task.UpdateTask();
        StapleEvent.Invoke();
    }

}
