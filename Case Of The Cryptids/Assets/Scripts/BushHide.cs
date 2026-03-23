using UnityEngine;

public class BushHide : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerStealth playerStealth = other.GetComponent<PlayerStealth>();

            if (playerStealth != null)
            {
                playerStealth.SetHidden(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerStealth playerStealth = other.GetComponent<PlayerStealth>();

            if (playerStealth != null)
            {
                playerStealth.SetHidden(false);
            }
        }
    }
}
