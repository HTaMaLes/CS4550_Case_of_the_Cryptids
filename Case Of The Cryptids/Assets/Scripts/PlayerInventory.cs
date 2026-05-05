using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public bool hasGolemGem = false;

    public void CollectGolemGem()
    {
        hasGolemGem = true;
        Debug.Log("Golem gem collected!");
    }
}