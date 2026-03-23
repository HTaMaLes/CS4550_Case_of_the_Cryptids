using UnityEngine;
using UnityEngine.AI;

public class GuardPatrol : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;

    private NavMeshAgent agent;
    private Transform currentTarget;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        currentTarget = pointA;
        agent.SetDestination(currentTarget.position);
    }

    private void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.2f)
        {
            if (currentTarget == pointA)
                currentTarget = pointB;
            else
                currentTarget = pointA;

            agent.SetDestination(currentTarget.position);
        }
    }
}
