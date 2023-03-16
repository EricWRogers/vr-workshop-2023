using UnityEngine;

public class VirtualOpenEmailButton : VirtualButton
{
    public GameObject emailContentPage;
    public GameObject inboxWindow;

    public override void ClickBehavior()
    {
        base.ClickBehavior();

        emailContentPage.SetActive(true);

        inboxWindow.SetActive(false);
    }
}
