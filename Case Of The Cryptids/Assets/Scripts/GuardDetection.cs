using UnityEngine;
using UnityEngine.AI;

public class GuardDetection : MonoBehaviour
{
    [Header("Detection Settings")]
    public float detectionRange = 5f;
    public float detectionAngle = 45f;
    public Transform player;

    private NavMeshAgent agent;
    private GuardPatrol patrolScript;

    private bool isDetectingPlayer = false;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        patrolScript = GetComponent<GuardPatrol>();
    }

    private void Update()
{
    if (player == null) return;

    Vector3 directionToPlayer = player.position - transform.position;
    float distanceToPlayer = directionToPlayer.magnitude;

    bool playerInRange = distanceToPlayer <= detectionRange;

    float angleToPlayer = Vector3.Angle(transform.forward, directionToPlayer.normalized);
    bool playerInAngle = angleToPlayer <= detectionAngle;

    PlayerStealth playerStealth = player.GetComponent<PlayerStealth>();
    bool playerVisible = playerStealth != null && !playerStealth.isHidden;

    if (playerInRange && playerInAngle && playerVisible)
    {
        DetectPlayer();
    }
    else
    {
        LosePlayer();
    }
}

    private void DetectPlayer()
{
    if (isDetectingPlayer) return;

    isDetectingPlayer = true;

    if (agent != null)
    {
        agent.isStopped = true;
    }

    Vector3 lookDirection = player.position - transform.position;
    lookDirection.y = 0f;

    if (lookDirection != Vector3.zero)
    {
        transform.rotation = Quaternion.LookRotation(lookDirection);
    }

    Debug.Log(gameObject.name + " detected the player!");
}

private void LosePlayer()
{
    if (!isDetectingPlayer) return;

    isDetectingPlayer = false;

    if (agent != null)
    {
        agent.isStopped = false;
    }

    Debug.Log(gameObject.name + " lost the player.");
}

}