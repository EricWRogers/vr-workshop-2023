using UnityEngine;

public class VirtualOpenButton : VirtualButton
{
    public GameObject window;
    public GameObject taskbarGroup;
    public GameObject taskbarPrefab;

    public override void ClickBehavior()
    {
        base.ClickBehavior();

        window.SetActive(true);
        GameObject instance = Instantiate(taskbarPrefab, taskbarGroup.transform);
        instance.GetComponent<VirtualOpenCloseButton>().window = window;
        instance.GetComponentInChildren<AppStatusController>().window = window;
        window.GetComponentInChildren<VirtualMinimizeButton>().taskbarApp = instance;
    }
}
