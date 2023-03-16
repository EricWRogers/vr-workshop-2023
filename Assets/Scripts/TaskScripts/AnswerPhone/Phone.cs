using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SuperPupSystems.Helper;

public class Phone : MonoBehaviour
{
    [Tooltip("How long should the player have to hold the phone for it count as 1 completion of the task.")]
    public float timeToComplete = 5f;
    [Tooltip("The chance for a call to happen. The actual chance is this number - 100 so if it was 75, it would have a 25% chance to happen")]
    public float chanceForCall = 75f;
    public float timeBetweenRings = 1.5f;
    public int amountOfRings = 3;

    private AnswerPhoneTask task;
    private float currentTalkTime = 0f;
    private int ringCounter = 0;
    private bool isRinging = false;

    private void Start()
    {
        task = FindObjectOfType<AnswerPhoneTask>();
        DayManager.Instance.GetComponent<Timer>().TimeOut.AddListener(InvokeCall);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && isRinging == true)
        {
            CancelInvoke("Call");

            currentTalkTime += Time.deltaTime;

            if (currentTalkTime >= timeToComplete)
            {
                task.UpdateTask();
                if (task.currentAmount >= task.requiredAmount)
                {
                    task.CompleteTask(task);
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            currentTalkTime = 0f;
        }
    }

    void InvokeCall()
    {
        if (Random.Range(0f, 100f) > chanceForCall)
        {
            InvokeRepeating("Call", 0f, timeBetweenRings);
        }
    }

    private void Call()
    {
        if (ringCounter < amountOfRings)
        {
            //Play ringtone
            ringCounter++;
            isRinging = true;
        }
        else
        {
            CancelInvoke("Call");
            isRinging = false;
        }
    }
}
