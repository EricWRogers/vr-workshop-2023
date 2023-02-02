using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualOpenCloseButton : VirtualButton
{
    public GameObject window;

    private bool isActive = true;

    private void Start()
    {
        window.GetComponentInChildren<VirtualCloseButton>().onClick.AddListener(DestroyThis);
    }

    public override void ClickBehavior()
    {
        base.ClickBehavior();

        if (!isActive)
        {
            isActive = true;
            window.SetActive(true);
            return;
        }

        window.SetActive(false);
        isActive = false;
    }

    public void DestroyThis()
    {
        Destroy(gameObject);
    }

    public void SetActiveStatus(bool value)
    {
        isActive = value;
    }
}
