using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;
using TMPro;
using System.Linq;
using UnityEngine.UI;
public class TaskManager : MonoBehaviour
{
    public static TaskManager Instance;
    public List<Task> tasks = new List<Task>();
    public GameObject taskUIGroup;
    public GameObject standardTextPrefab;

    //[HideInInspector]
    public List<GameObject> taskUIElements = new List<GameObject>();
    public List<GameObject> allUIElements = new List<GameObject>();
    

    private void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        if (standardTextPrefab == null || taskUIGroup == null)
        {
            Debug.LogError("Could not find one or more essential GameObjects. Ensure that all public GameObjects fields are properly assigned in the inspector.");
        }

        tasks.AddRange(FindObjectsOfType<Task>());
        tasks.ForEach(task => AssignListeners(task));
        CreateUI(); 
    }

    private void AssignListeners(Task task)
    {
        task.onTaskUpdated.AddListener(UpdateUI);
        task.onComplete.AddListener(HandleTaskCompletes);
    }

    private void CreateUI()
    {
        GameObject textInstance;
        for(int i = 0; i < tasks.Count; i++)
        {
            textInstance = Instantiate(standardTextPrefab);

            textInstance.GetComponent<TextMeshProUGUI>().SetText(tasks[i].taskName + " [" + tasks[i].currentAmount + "/" + tasks[i].requiredAmount + "]");
            textInstance.GetComponentInChildren<TaskDescriptionController>().descriptionBox.GetComponent<TextMeshProUGUI>().SetText(tasks[i].taskDescription);

            textInstance.transform.parent = taskUIGroup.transform;
            taskUIElements.Add(textInstance);
        }

        foreach (GameObject element in taskUIElements)
        {
            if (!allUIElements.Contains(element))
            {
                allUIElements.Add(element);
            }
        }
    }

    private void UpdateUI()
    {
        for (int i = 0; i < tasks.Count; i++)
        {
            if (tasks[i].currentAmount > tasks[i].requiredAmount)
                continue;

            taskUIElements[i].GetComponent<TextMeshProUGUI>().SetText(tasks[i].taskName + " [" + tasks[i].currentAmount + "/" + tasks[i].requiredAmount + "]");
            tasks[i].currentText = tasks[i].taskName + " [" + tasks[i].currentAmount + "/" + tasks[i].requiredAmount + "]";
        }
    }

    public void HandleTaskCompletes(Task task)
    {
        List<GameObject> temp = taskUIElements.Where(text => text.GetComponent<TextMeshProUGUI>().text == task.currentText).ToList();

        temp[0].GetComponentInChildren<AnimateStrikethrough>().DoStrikeThrough();
    }
}
