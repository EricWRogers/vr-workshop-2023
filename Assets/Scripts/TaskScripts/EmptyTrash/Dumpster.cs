using UnityEngine;
using UnityEngine.Events;

public class Dumpster : MonoBehaviour
{
    private Trash_Task task;

    private void Start()
    {
        task = FindObjectOfType<Trash_Task>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trash"))
        {
            task.UpdateTask();
            Destroy(other.gameObject);

            if (task.currentAmount >= task.requiredAmount)
            {
                task.CompleteTask(task);
                task.SpawnFX(transform.position);
            }
        }
    }
}

