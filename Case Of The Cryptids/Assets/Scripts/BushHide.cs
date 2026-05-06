using UnityEngine;

public class BushHide : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerStealth playerStealth = other.GetComponentInParent<PlayerStealth>();

        if (playerStealth != null)
        {
            playerStealth.EnterHidingBush();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        PlayerStealth playerStealth = other.GetComponentInParent<PlayerStealth>();

        if (playerStealth != null)
        {
            playerStealth.ExitHidingBush();
        }
    }
}