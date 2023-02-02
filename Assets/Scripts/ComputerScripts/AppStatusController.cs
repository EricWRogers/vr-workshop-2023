using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppStatusController : MonoBehaviour
{
    private Image statusBar;
    private bool isActive = true;
    [HideInInspector]
    public GameObject window;

    private void Start()
    {
        statusBar = GetComponent<Image>();

        window.GetComponentInChildren<VirtualMinimizeButton>().onClick.AddListener(AdjustStatus);
    }
    

    public void AdjustStatus()
    {
        if (!isActive)
        {
            isActive = true;
            statusBar.rectTransform.sizeDelta = new Vector2(35.15f, statusBar.rectTransform.sizeDelta.y);
            return;
        }

        statusBar.rectTransform.sizeDelta = new Vector2(20f, statusBar.rectTransform.sizeDelta.y);
        isActive = false;
    }
}
