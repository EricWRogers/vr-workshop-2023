using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StampForm : MonoBehaviour
{
    public Transform spawnPoint;
    private bool Approved = false;
    private bool Denied = false;
    public Rigidbody rigidbody;
    public GameObject ApprovedMark;
    public GameObject DeniedMark;
    public GameObject Form;
    public bool info;
    public bool Ruined = false;
    public bool ReadyToSubmit = false;
    int randomNumber;
    [HideInInspector]
    public UnityEvent stampedEvent = new UnityEvent();
    private StampFormTask task;

    // Start is called before the first frame update
    void Start()
    {
        task = FindObjectOfType<StampFormTask>();

        rigidbody = GetComponent<Rigidbody>();

        randomNumber = Random.Range(1, 3);

        if (randomNumber == 1)
        {
            info = false;
            //FalseInfo.SetActive(true);
        }
        else
        {
            info = true;
            //TrueInfo.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("ApproveStamp"))
        {
            if (Denied == false && Approved == false)
            {
                ApprovedMark.SetActive(true);
                

                if(info == false)
                {
                    Ruined = true;
                    Instantiate(Form, spawnPoint.position, Quaternion.identity);
                }
                else
                {
                    ReadyToSubmit = true;
                    task.UpdateTask();

                    if (task.currentAmount >= task.requiredAmount)
                    {
                        task.CompleteTask(task);
                        task.SpawnFX(transform.position);
                    }
                }
            }
        }

        if (collision.CompareTag("DenyStamp"))
        {
            if (Denied == false && Approved == false)
            {
                DeniedMark.SetActive(true);
                

                if (info == true)
                {
                    Ruined = true;
                    Instantiate(Form, spawnPoint.position, Quaternion.identity);
                }
                else
                {
                    ReadyToSubmit = true;
                    task.UpdateTask();

                    if (task.currentAmount >= task.requiredAmount)
                    {
                        task.CompleteTask(task);
                        task.SpawnFX(transform.position);
                    }
                }
            }
            
        }
    }
}
