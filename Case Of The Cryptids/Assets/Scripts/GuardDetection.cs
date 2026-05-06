using UnityEngine;
using UnityEngine.AI;

public class GuardDetection : MonoBehaviour
{
    [Header("Player")]
    public Transform player;

    [Header("Chase Settings")]
    public float chaseStoppingDistance = 1.5f;

    private NavMeshAgent agent;
    private GuardPatrol patrolScript;
    private FieldOfView fieldOfView;
    private Health playerHealth;

    private bool isChasingPlayer = false;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        patrolScript = GetComponent<GuardPatrol>();
        fieldOfView = GetComponent<FieldOfView>();

        if (player != null)
        {
            playerHealth = player.GetComponent<Health>();
        }
    }

    private void Update()
    {
        if (player == null || agent == null || fieldOfView == null)
            return;

        if (fieldOfView.canSeePlayer)
        {
            ChasePlayer();
        }
        else
        {
            StopChasingPlayer();
        }
    }

    private void ChasePlayer()
    {
        isChasingPlayer = true;

        if (playerHealth != null)
        {
            playerHealth.SetDetected(true);
        }

        if (patrolScript != null)
        {
            patrolScript.enabled = false;
        }

        agent.isStopped = false;
        agent.stoppingDistance = chaseStoppingDistance;
        agent.SetDestination(player.position);

        Debug.Log(gameObject.name + " is chasing the player!");
    }

    private void StopChasingPlayer()
    {
        if (!isChasingPlayer)
            return;

        isChasingPlayer = false;

        if (playerHealth != null)
        {
            playerHealth.SetDetected(false);
        }

        agent.isStopped = false;
        agent.stoppingDistance = 0f;

        if (patrolScript != null)
        {
            patrolScript.enabled = true;
            patrolScript.ResumePatrol();
        }

        Debug.Log(gameObject.name + " stopped chasing the player.");
    }
}