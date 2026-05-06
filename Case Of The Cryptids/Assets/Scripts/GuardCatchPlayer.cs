using UnityEngine;

public class GuardCatchPlayer : MonoBehaviour
{
    public Transform player;
    public float catchDistance = 1.0f;

    private bool hasCaughtPlayer = false;

    private void Update()
    {
        if (hasCaughtPlayer || player == null)
            return;

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= catchDistance)
        {
            CatchPlayer();
        }
    }

    private void CatchPlayer()
    {
        hasCaughtPlayer = true;

        Health playerHealth = player.GetComponentInParent<Health>();

        if (playerHealth != null)
        {
            Debug.Log(gameObject.name + " caught the player!");
            playerHealth.RestartTutorial();
        }
    }
}