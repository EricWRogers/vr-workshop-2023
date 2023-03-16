public class ShredPaperTask : Task
{
    public override void UpdateTask()
    {
        base.UpdateTask();

        if (currentAmount >= requiredAmount)
        {
            CompleteTask(this);
            SpawnFX(FindObjectOfType<PaperShredder>().transform.position);
        }
    }
}
