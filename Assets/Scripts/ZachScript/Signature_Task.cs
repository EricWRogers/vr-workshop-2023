using UnityEngine;
using UnityEngine.Events;

public class Signature_Task : Task
{
    private Pen pen;
    private void Start()
    {
        //pen = FindObjectOfType<Pen>();
        //pen.SignEvent.AddListener(ManageTask);
    }
    private void ManageTask()
    {
        /*if (pen.Doc >= requiredAmount)
        {
            CompleteTask(this);
            Debug.Log("All done");
        }*/
    }
}
