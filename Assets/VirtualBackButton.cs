using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualBackButton : VirtualButton
{
    public GameObject inboxWindow;
    public GameObject emailPage;

    public override void ClickBehavior()
    {
        base.ClickBehavior();

        inboxWindow.SetActive(true);

        emailPage.SetActive(false);
    }
}
