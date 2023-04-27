using UnityEngine;
using System.Collections.Generic;
using UnityEngine.AI;
using System.Linq;
using UnityEngine.Events;
using SuperPupSystems.Helper;

[System.Serializable]
public struct Destination
{
    public Transform destination;
    public float waitTime;
}

public class AIManager : MonoBehaviour
{
    public List<Destination> positions = new List<Destination>();
    public UnityEvent onPathComplete = new UnityEvent();


    private List<Vector3> occupiedPositions = new List<Vector3>();
    private NavMeshAgent agent;
    private bool setNewDestination = false;
    private Timer timer;
    private Destination? currentDestination;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        timer = GetComponent<Timer>();

        onPathComplete.AddListener(StartWaitTime);
        currentDestination = Move();
    }

    private void Update()
    {
        if (agent.isStopped && !setNewDestination)
        {
            setNewDestination = true;

            onPathComplete.Invoke();
            currentDestination = null;
        }
    }

    private Destination Move()
    {
        int index = Random.Range(0, positions.Count);
        agent.SetDestination(positions[index].destination.position);
        return positions[index];
    }

    public void StartWaitTime()
    {

    }

    public void SetPath()
    {
        agent.SetDestination(positions[Random.Range(0, positions.Count)].destination.position);
    }
}
