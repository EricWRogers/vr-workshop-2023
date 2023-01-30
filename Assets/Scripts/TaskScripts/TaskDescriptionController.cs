using UnityEngine;
using TMPro;

public class TaskDescriptionController : MonoBehaviour
{
    public GameObject descriptionBox;
    private bool isOn = false;

    public void ShowDescription()
    {
        if (isOn)
        {
            descriptionBox.SetActive(false);
            isOn = false;
            return;
        }

        descriptionBox.SetActive(true);
        isOn = true;
    }
}
