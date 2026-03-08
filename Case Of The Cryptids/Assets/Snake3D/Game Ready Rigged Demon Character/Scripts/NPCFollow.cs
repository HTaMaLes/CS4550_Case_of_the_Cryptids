using UnityEngine;
using UnityEngine.AI;

public class NPCFollow : MonoBehaviour
{
    public Transform player;
    public float followDistance = 2.5f;

    private NavMeshAgent agent;
    private Animator animator;
    private bool hasMetPlayer = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        if (agent != null)
        {
            agent.stoppingDistance = followDistance;
        }
    }

    void Update()
    {
        if (agent == null || player == null || !agent.isOnNavMesh)
            return;

        if (!hasMetPlayer)
        {
            if (animator != null)
                animator.SetFloat("Speed", 0f);

            return;
        }

        // Always keep updating the target destination
        agent.SetDestination(player.position);

        // Animate based on actual movement
        if (animator != null)
        {
            animator.SetFloat("Speed", agent.velocity.magnitude);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            hasMetPlayer = true;
        }
    }
}