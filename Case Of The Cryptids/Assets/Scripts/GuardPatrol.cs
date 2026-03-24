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
        if (patrolPoints != null && patrolPoints.Length > 0)
        {
            agent.SetDestination(patrolPoints[currentPointIndex].position);
        }
    }

    private void Update()
    {
        if (patrolPoints == null || patrolPoints.Length == 0)
            return;
            
        if (!agent.pathPending && agent.remainingDistance < 0.2f)
        {
            currentPointIndex = (currentPointIndex + 1) % patrolPoints.Length;
            agent.SetDestination(patrolPoints[currentPointIndex].position);
        }
    }
}
