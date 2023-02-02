using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class TaskDescriptionController : MonoBehaviour
{
    public GameObject descriptionBox;
    private bool isOn = false;
    private int newSiblingIndex = 0;

    public void ShowDescription()
    {
        if (isOn)
        {
            descriptionBox.transform.parent = gameObject.transform.parent.transform;
            newSiblingIndex = TaskManager.Instance.allUIElements.IndexOf(descriptionBox.transform.parent.gameObject) + 1;
            TaskManager.Instance.allUIElements.RemoveAt(newSiblingIndex);
            descriptionBox.SetActive(false);
            isOn = false;
            return;
        }

        newSiblingIndex = TaskManager.Instance.allUIElements.IndexOf(descriptionBox.transform.parent.gameObject) + 1;
        TaskManager.Instance.allUIElements.Insert(newSiblingIndex, descriptionBox);
        descriptionBox.transform.parent = GetComponentInParent<LayoutGroup>().transform;
        descriptionBox.transform.SetSiblingIndex(newSiblingIndex);
        descriptionBox.SetActive(true);
        isOn = true;
    }
}
