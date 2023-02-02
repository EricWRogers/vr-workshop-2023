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

    private void Update()
    {
        //Debug.Log(isActive);
    }

    public override void ClickBehavior()
    {
        base.ClickBehavior();

        Debug.Log(isActive);

        if (!isActive)
        {
            Debug.Log("IN THE INACTIVE SECTION");
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
