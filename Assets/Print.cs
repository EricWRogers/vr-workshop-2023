using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Print : MonoBehaviour
{
    [HideInInspector]
    public int numPrinted = 0;
    [HideInInspector]
    public UnityEvent printedEvent = new UnityEvent();
    private PrintCopy task;
    public Printer print;
    public Rigidbody rigidbody;
    public GameObject Document;
    public GameObject SpawnPoint;

    private void start()
    {
        task = FindObjectOfType<PrintCopy>();
    }

    public void Printcopy()
    {
        numPrinted++;
        task.UpdateTask();
        printedEvent.Invoke();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            MakeCopy();
        }

    }


    public void MakeCopy()
    {
        if (GameObject.Find("Document").GetComponent<Printer>().ReadyToCopy)
        {
            
            Instantiate(Document, /*new Vector3(0, 0, 0)*/GameObject.Find("SpawnPoint").transform.position, Quaternion.identity);
            Debug.Log("Making Copies");
            Printcopy();
        }
    }

  
    

    // Update is called once per frame
    void Update()
    {
        
    }
}

public class PrintCopy : Task
{
    private Print print;

    private void Start()
    {
        print = FindObjectOfType<Print>();
        print.printedEvent.AddListener(ManageTask);
    }

    private void ManageTask()
    {
        CompleteTask(this);
    }
}
