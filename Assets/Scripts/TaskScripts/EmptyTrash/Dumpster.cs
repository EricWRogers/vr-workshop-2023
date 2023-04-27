using UnityEngine;
using UnityEngine.Events;

public class Dumpster : MonoBehaviour
{
    private Trash_Task task;
    AudioManagerX AMX;
    private void Start()
    {
        AMX = AudioManagerX.Instance;
        task = FindObjectOfType<Trash_Task>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trash"))
        {
            AMX.play("Trash Can Toss");
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

