using UnityEngine;
using UnityEngine.AI;

public class GuardPatrol : MonoBehaviour
{
    public Transform[] patrolPoints;

    private NavMeshAgent agent;
    private int currentPointIndex = 0;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        ResumePatrol();
    }

    private void Update()
    {
        if (agent == null || patrolPoints == null || patrolPoints.Length == 0)
            return;

        if (!agent.pathPending && agent.remainingDistance < 0.2f)
        {
            currentPointIndex = (currentPointIndex + 1) % patrolPoints.Length;
            agent.SetDestination(patrolPoints[currentPointIndex].position);
        }
    }

    public void ResumePatrol()
    {
        if (agent == null)
            agent = GetComponent<NavMeshAgent>();

        if (agent != null && patrolPoints != null && patrolPoints.Length > 0)
        {
            agent.isStopped = false;
            agent.SetDestination(patrolPoints[currentPointIndex].position);
        }
    }
}