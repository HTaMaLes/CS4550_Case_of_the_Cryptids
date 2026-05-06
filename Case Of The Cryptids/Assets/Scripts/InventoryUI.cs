using UnityEngine;
using TMPro;
using System.Collections;

public class InventoryUI : MonoBehaviour
{
    public PlayerInventory playerInventory;

    public GameObject inventoryPanel;
    public TextMeshProUGUI pickupMessageText;
    public TextMeshProUGUI golemGemText;

    public KeyCode inventoryKey = KeyCode.I;
    public float messageTime = 2f;

    private Coroutine messageRoutine;

    void Start()
    {
        inventoryPanel.SetActive(false);
        pickupMessageText.text = "";
        RefreshInventory();
    }

    void Update()
    {
        if (Input.GetKeyDown(inventoryKey))
        {
            inventoryPanel.SetActive(!inventoryPanel.activeSelf);
            RefreshInventory();
        }
    }

    public void RefreshInventory()
    {
        if (playerInventory == null)
            return;

        golemGemText.text = playerInventory.hasGolemGem
            ? "Golem Gem: Collected"
            : "Golem Gem: Not Collected";
    }

    public void ShowPickupMessage(string message)
    {
        if (messageRoutine != null)
            StopCoroutine(messageRoutine);

        messageRoutine = StartCoroutine(ShowMessageRoutine(message));
    }

    private IEnumerator ShowMessageRoutine(string message)
    {
        pickupMessageText.text = message;

        yield return new WaitForSeconds(messageTime);

        pickupMessageText.text = "";
    }
}