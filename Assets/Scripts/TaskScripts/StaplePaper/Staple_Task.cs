using UnityEngine;
using UnityEngine.Events;

public class Staple_Task : Task
{
    private Stapler stapler;

    private void Start()
    {
        stapler = FindObjectOfType<Stapler>();
    }
    public override void UpdateTask()
    {
        base.UpdateTask();

        if (currentAmount >= requiredAmount)
        {
            CompleteTask(this);
            Debug.Log("Play effect");
            SpawnFX(stapler.transform.position);
        }
    }
}

