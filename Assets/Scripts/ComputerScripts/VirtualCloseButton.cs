using UnityEngine;

public class VirtualCloseButton : VirtualButton
{
    private GameObject window;

    private void Start()
    {
        window = transform.parent.gameObject;
    }

    public override void ClickBehavior()
    {
        base.ClickBehavior();

        window.SetActive(false);
    }
}
