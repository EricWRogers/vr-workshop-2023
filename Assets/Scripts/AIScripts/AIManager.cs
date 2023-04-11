using UnityEngine;
using System.Collections.Generic;
using UnityEngine.AI;
using System.Linq;
using UnityEngine.Events;
using SuperPupSystems.Helper;

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

    private List<Vector3> occupiedPositions = new List<Vector3>();
    private NavMeshAgent agent;
    private Timer timer;
    private Destination currentDestination;
    private NavMeshAgent otherAgent;
    private bool canTalk = true;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        timer = GetComponent<Timer>();

        onPathComplete.AddListener(StartWaitTime);
        timer.TimeOut.AddListener(FinishTalk);
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
            Debug.Log("HIt");
            agent.isStopped = true;
            canTalk = false;
            timer.StartTimer(talkTime, false);

            otherAgent = other.GetComponent<NavMeshAgent>();
            otherAgent.isStopped = true;
            otherAgent.GetComponent<Timer>().StartTimer(otherAgent.GetComponent<AIManager>().talkTime);
        }
    }

    private Destination Move(Destination newPosition = null)
    {
        int index = Random.Range(0, destinations.Count);
        agent.SetDestination(destinations[index].destination.position);
        return destinations[index];
    }

    public void StartWaitTime()
    {
        StartCoroutine(Wait());
    }

    public void ResetTalk()
    {
        Debug.Log("Talk cooldown reset");
        timer.TimeOut.RemoveAllListeners();
        timer.TimeOut.AddListener(FinishTalk);
        canTalk = true;
    }

    public void FinishTalk()
    {
        Debug.Log("Finished Talking");
        agent.isStopped = false;
        otherAgent.isStopped = false;
        timer.TimeOut.RemoveAllListeners();
        timer.TimeOut.AddListener(ResetTalk);
        timer.StartTimer(talkCooldown, false);
    }

    System.Collections.IEnumerator Wait()
    {
        yield return new WaitForSeconds(currentDestination.waitTime);
        currentDestination = Move();
    }
}
