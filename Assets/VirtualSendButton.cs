using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualSendButton : VirtualButton
{
    public GameObject inboxScreen;
    public GameObject emailScreen;
    public GameObject email;

    private SendEmailsTask task;

    private void Start()
    {
        task = FindObjectOfType<SendEmailsTask>();
    }

    public override void ClickBehavior()
    {
        base.ClickBehavior();

        inboxScreen.SetActive(true);

        emailScreen.SetActive(false);

        Destroy(email);

        task.UpdateTask();

        if (task.currentAmount >= task.requiredAmount)
        {
            task.CompleteTask(task);
        }
    }
}
