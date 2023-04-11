using UnityEngine;
using System.Collections.Generic;
using UnityEngine.AI;
using System.Linq;
using UnityEngine.Events;
using OmnicatLabs.Managers;

[System.Serializable]
public class Destination
{
    public Transform destination;
    public float waitTime;
}

public class AIManager : MonoBehaviour
{
    public List<Destination> destinations = new List<Destination>();
    public UnityEvent onPathComplete = new UnityEvent();
    public float talkTime = 5f;
    public float talkCooldown = 7f;

    private NavMeshAgent agent;
    private Destination currentDestination;
    private NavMeshAgent otherAgent;
    private bool canTalk = true;

    private void Start()
    {
        if (FindObjectOfType<TimerManager>() == null)
        {
            Debug.LogError("Could not find Timer Manager. Make sure there is a Timer Manager somewhere in the scene");
        }

        agent = GetComponent<NavMeshAgent>();

        onPathComplete.AddListener(StartWaitTimer);
        currentDestination = Move();
    }

    private void Update()
    {
        if (agent.remainingDistance <= 0f && currentDestination != null)
        {
            onPathComplete.Invoke();
            currentDestination = null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Worker") && canTalk)
        {
            Debug.Log("Hit");
            otherAgent = other.GetComponent<NavMeshAgent>();
            otherAgent.GetComponent<AIManager>().canTalk = false;

            agent.isStopped = true;
            canTalk = false;

            otherAgent.isStopped = true;

            TimerManager.Instance.CreateTimer(talkTime, Resume);
        }
    }

    private Destination Move(Destination newPosition = null)
    {
        int index = Random.Range(0, destinations.Count);
        agent.SetDestination(destinations[index].destination.position);
        return destinations[index];
    }

    public void StartWaitTimer()
    {
        TimerManager.Instance.CreateTimer(talkTime, MoveNext);
    }

    public void MoveNext()
    {
        currentDestination = Move();
    }

    public void Resume()
    {
        agent.isStopped = false;
        otherAgent.isStopped = false;
        TimerManager.Instance.CreateTimer(talkCooldown, ResetCooldown);
    }

    public void ResetCooldown()
    {
        canTalk = true;
        otherAgent.GetComponent<AIManager>().canTalk = true;
    }
}
