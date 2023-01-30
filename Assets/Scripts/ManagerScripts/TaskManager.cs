using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;
using TMPro;
using System.Linq;

public class TaskManager : MonoBehaviour
{
    public List<Task> tasks = new List<Task>();
    public GameObject taskUIGroup;
    public GameObject standardTextPrefab;

    private List<GameObject> uiElements = new List<GameObject>();

    private void Start()
    {
        if (standardTextPrefab == null || taskUIGroup == null)
        {
            Debug.LogError("Could not find one or more essential GameObjects. Ensure that all public GameObjects are properly assigned in the inspector.");
        }

        tasks.AddRange(FindObjectsOfType<Task>());
        tasks.ForEach(task => AssignListeners(task));
        CreateUI(); 
    }

    private void AssignListeners(Task task)
    {
        task.onTaskUpdated.AddListener(UpdateUI);
        //task.onComplete.AddListener(HandleTaskCompletes);
    }

    private void CreateUI()
    {
        GameObject instance;
        for(int i = 0; i < tasks.Count; i++)
        {
            instance = Instantiate(standardTextPrefab);

            instance.GetComponent<TextMeshProUGUI>().SetText(tasks[i].taskName + " [" + tasks[i].currentAmount + "/" + tasks[i].requiredAmount + "]");
            instance.GetComponentInChildren<TaskDescriptionController>().descriptionBox.GetComponent<TextMeshProUGUI>().SetText(tasks[i].taskDescription);

            instance.transform.parent = taskUIGroup.transform;
            uiElements.Add(instance);
        }
    }

    private void UpdateUI()
    {
        for (int i = 0; i < tasks.Count; i++)
        {
            if (tasks[i].currentAmount > tasks[i].requiredAmount)
                continue;

            uiElements[i].GetComponent<TextMeshProUGUI>().SetText(tasks[i].taskName + " [" + tasks[i].currentAmount + "/" + tasks[i].requiredAmount + "]");

            uiElements[i].transform.parent = taskUIGroup.transform;
        }
    }

    public void HandleTaskCompletes()
    {
        Debug.Log("Completed");
    }
}
