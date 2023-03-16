using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Printer : MonoBehaviour
{
    public Transform spawnPoint;

    [HideInInspector]
    public GameObject documentToCopy;
    private PrintCopyTask task;
    [HideInInspector]
    public UnityEvent printedEvent = new UnityEvent();
    private PhysicsButton printButton;

    private void Start()
    {
        printButton = GetComponentInChildren<PhysicsButton>();
        task = FindObjectOfType<PrintCopyTask>();
        printButton.onPressed.AddListener(MakeCopy);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Paper"))
        {
            if (documentToCopy == other)
                return;

            documentToCopy = other.gameObject;
        }
    }

    public void MakeCopy()
    {
        if (documentToCopy != null)
        {
            Instantiate(documentToCopy, spawnPoint.position, Quaternion.identity);
            task.UpdateTask();
        }
    }
}
