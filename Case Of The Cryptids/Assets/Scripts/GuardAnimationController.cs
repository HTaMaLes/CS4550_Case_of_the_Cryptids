using UnityEngine;
using UnityEngine.AI;

public class GuardAnimationController : MonoBehaviour
{
    private Animator animator;
    private NavMeshAgent agent;

    private void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (animator != null && agent != null)
        {
            float speed = agent.velocity.magnitude;
            animator.SetFloat("Speed", speed);
        }
    }
}