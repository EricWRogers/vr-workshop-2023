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
    public BoxCollider mainCollider;

    private AnswerPhoneTask task;
    private float currentTalkTime = 0f;
    private int ringCounter = 0;
    private bool isRinging = false;
    private AudioSource aSrc;
    private bool isTalking = false;
    private bool updated = false;
    private bool finished = false;

    AudioManagerX AMX;

    private void Start()
    {
        AMX = AudioManagerX.Instance;
        aSrc = GetComponent<AudioSource>();
        task = FindObjectOfType<AnswerPhoneTask>();
        // DayManager.Instance.GetComponent<Timer>().TimeOut.AddListener(InvokeCall);
        GetComponent<Timer>().TimeOut.AddListener(InvokeCall);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("PlayerMouth") && isRinging && !finished)
        {
            mainCollider.enabled = false;
            isTalking = true;
            CancelInvoke("Call");
            AMX.stop("Phone");
            ringCounter = 0;

            currentTalkTime += Time.deltaTime;

            if (currentTalkTime >= timeToComplete)
            {
                task.UpdateTask();
                AMX.play("Complete Sound");
                if (task.currentAmount >= task.requiredAmount)
                {
                    task.CompleteTask(task);
                    finished = true;
                }
                isRinging = false;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("PlayerMouth"))
        {
            currentTalkTime = 0f;
            isTalking = false;
            mainCollider.enabled = true;
        }
    }

    public void InvokeCall()
    {
        if (Random.Range(0f, 100f) >= chanceForCall && !isTalking && !finished)
        {
            InvokeRepeating("Call", 0f, timeBetweenRings);
        }
    }

    private void Call()
    {
        if (ringCounter < amountOfRings)
        {
            AMX.play("Phone");
            ringCounter++;
            isRinging = true;
        }
        else
        {
            CancelInvoke("Call");
            AMX.stop("Phone");
            isRinging = false;
            ringCounter = 0;
        }
    }
}
