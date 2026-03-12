using UnityEngine;

public class RockProjectile : MonoBehaviour
{
    public float destroyDelay = 3f;   // time after hitting ground
    private bool hasHitGround = false;

    void OnCollisionEnter(Collision collision)
    {
        if (!hasHitGround)
        {
            hasHitGround = true;

            // Start countdown to destroy
            Destroy(gameObject, destroyDelay);
        }
    }
}