using UnityEngine;

public class VirtualMinimizeButton : VirtualButton
{
    private GameObject window;
    [HideInInspector]
    public GameObject taskbarApp;

    private void Start()
    {
        window = transform.parent.gameObject;
    }

    public override void ClickBehavior()
    {
        base.ClickBehavior();
        taskbarApp.GetComponentInChildren<VirtualOpenCloseButton>().SetActiveStatus(false);
        window.SetActive(false);
    }
}
