using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualReplyButton : VirtualButton
{
    public GameObject replyWindow;
    public GameObject emailPage;

    public override void ClickBehavior()
    {
        base.ClickBehavior();

        replyWindow.SetActive(true);

        emailPage.SetActive(false);
    }
}
