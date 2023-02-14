using UnityEngine;

public class VirtualOpenButton : VirtualButton
{
    public GameObject window;
    public GameObject taskbarGroup;
    public GameObject taskbarPrefab;
    private bool isLaunched = false;
    private GameObject taskbarApp;

    public override void ClickBehavior()
    {
        base.ClickBehavior();

        if (!isLaunched)
        {
            isLaunched = true;
            window.SetActive(true);
            taskbarApp = Instantiate(taskbarPrefab, taskbarGroup.transform);
            taskbarApp.GetComponent<VirtualOpenCloseButton>().window = window;
            taskbarApp.GetComponentInChildren<AppStatusController>().window = window;
            window.GetComponentInChildren<VirtualMinimizeButton>().taskbarApp = taskbarApp;
            return;
        }

        window.SetActive(true);
        taskbarApp.GetComponentInChildren<AppStatusController>().UpdateStatus(false);   //seems counterintuitive but it's just the way open/close button works
    }

    public void SetUnlaunched()
    {
        isLaunched = false;
    }
}
