using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrintCopyTask : Task
{
    private Printer printer;

    private void Start()
    {
        printer = FindObjectOfType<Printer>();
        printer.printedEvent.AddListener(ManageTask);
    }

    private void ManageTask()
    {
        if (currentAmount >= requiredAmount)
            CompleteTask(this);
    }
}
