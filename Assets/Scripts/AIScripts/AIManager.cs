using UnityEngine;
using System.Collections.Generic;
using UnityEngine.AI;
using System.Linq;

public class AIManager : MonoBehaviour
{
    public List<NavMeshAgent> agents = new List<NavMeshAgent>();
    public List<Vector3> positions = new List<Vector3>();
    private List<Vector3> occupiedPositions = new List<Vector3>();

    public bool Move(NavMeshAgent agent, Vector3 position)
    {
        for (int i = 0; i < occupiedPositions.Count; i++)
        {
            if (Vector3.Distance(position, occupiedPositions[i]) < .5f)
            {
                return false;
            }
        }

        agent.SetDestination(position);

        return true;
    }

    private void Update()
    {
        foreach (NavMeshAgent agent in agents)
        {
            occupiedPositions.Add(agent.transform.position);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Move(GetComponent<NavMeshAgent>(), new Vector3(Random.Range(0, 10), Random.Range(0, 10), Random.Range(0, 10))))
            {
                Move(GetComponent<NavMeshAgent>(), new Vector3(Random.Range(0, 10), Random.Range(0, 10), Random.Range(0, 10)));
            }
        }
    }
}
