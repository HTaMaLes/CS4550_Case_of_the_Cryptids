using UnityEngine;
using UnityEngine.AI;

public class AgentFootsteps : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip footstepClip;

    public float walkStepInterval = 0.5f;
    public float minSpeed = 0.1f;

    private NavMeshAgent agent;
    private float stepTimer;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        if (audioSource == null)
            audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (agent == null || audioSource == null || footstepClip == null)
            return;

        if (agent.velocity.magnitude > minSpeed)
        {
            stepTimer += Time.deltaTime;

            if (stepTimer >= walkStepInterval)
            {
                audioSource.PlayOneShot(footstepClip);
                stepTimer = 0f;
            }
        }
        else
        {
            stepTimer = 0f;
        }
    }
}