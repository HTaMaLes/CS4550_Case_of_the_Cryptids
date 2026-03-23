using UnityEngine;

public class PlayerStealth : MonoBehaviour
{
    public bool isHidden = false;

    public void SetHidden(bool hidden)
    {
        isHidden = hidden;
        Debug.Log("Player hidden state: " + isHidden);
    }
}