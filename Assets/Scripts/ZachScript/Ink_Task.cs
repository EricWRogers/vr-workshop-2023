using UnityEngine;
using UnityEngine.Events;

public class Ink_Task : Task
{
    public void ManageTask()
    {
      CompleteTask(this);
      Debug.Log("Fin");
    }
}
