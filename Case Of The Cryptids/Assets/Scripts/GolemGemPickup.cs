using UnityEngine;

public class GolemGemPickup : MonoBehaviour
{
    public AudioClip pickupSound;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;

        PlayerInventory inventory = other.GetComponentInParent<PlayerInventory>();

        if (inventory != null)
        {
            inventory.CollectGolemGem();

            if (pickupSound != null)
            {
                AudioSource.PlayClipAtPoint(pickupSound, transform.position);
            }

            InventoryUI ui = FindFirstObjectByType<InventoryUI>();
            if (ui != null)
            {
                ui.ShowPickupMessage("Golem Gem Acquired!");
                ui.RefreshInventory();
            }

            Destroy(gameObject);
        }
    }
}
