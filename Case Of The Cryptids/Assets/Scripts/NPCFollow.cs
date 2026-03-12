using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class NPCFollow : MonoBehaviour
{
    public Transform player;
    public float followDistance = 1.5f;
    public float behindDistance = 2.5f;
    public float rotationSpeed = 8f;

    [Header("Throw Settings")]
    public GameObject rockPrefab;
    public Transform throwPoint;
    public float throwForce = 15f;
    public KeyCode throwKey = KeyCode.F;
    public float throwDelay = 0.5f;

    private NavMeshAgent agent;
    private Animator animator;
    private bool hasMetPlayer = false;
    private bool isThrowing = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        if (agent != null)
            agent.stoppingDistance = followDistance;
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

        if (!isThrowing)
        {
            Vector3 followTarget = player.position - player.forward * behindDistance;
            agent.SetDestination(followTarget);

            if (animator != null)
                animator.SetFloat("Speed", agent.velocity.magnitude);

            if (Vector3.Distance(transform.position, player.position) <= behindDistance + 1f)
            {
                Quaternion targetRotation = Quaternion.LookRotation(player.forward);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }

            if (Input.GetKeyDown(throwKey))
            {
                StartCoroutine(ThrowRoutine());
            }
        }
        else
        {
            agent.SetDestination(transform.position);

            if (animator != null)
                animator.SetFloat("Speed", 0f);
        }
    }

    private IEnumerator ThrowRoutine()
    {
        isThrowing = true;
         // Stop navigation movement
        agent.isStopped = true;
        agent.velocity = Vector3.zero;

        if (animator != null)
            animator.SetTrigger("Throw");

        yield return new WaitForSeconds(throwDelay);

        ThrowRock();

        yield return new WaitForSeconds(1f);
        // Resume movement
        agent.isStopped = false;

        isThrowing = false;
    }

    private void ThrowRock()
    {
        if (rockPrefab == null || throwPoint == null)
        {
            Debug.LogWarning("Rock prefab or throw point is missing.");
            return;
        }

        GameObject rock = Instantiate(rockPrefab, throwPoint.position, throwPoint.rotation);

        Rigidbody rb = rock.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(throwPoint.forward * throwForce, ForceMode.Impulse);
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