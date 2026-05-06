using UnityEngine;

public class PlayerStealth : MonoBehaviour
{
    public bool isHidden = false;

    private int hiddenBushCount = 0;

    public void EnterHidingBush()
    {
        hiddenBushCount++;
        UpdateHiddenState();

        Debug.Log("Entered bush. Bush count: " + hiddenBushCount);
    }

    public void ExitHidingBush()
    {
        hiddenBushCount--;

        if (hiddenBushCount < 0)
            hiddenBushCount = 0;

        UpdateHiddenState();

        Debug.Log("Exited bush. Bush count: " + hiddenBushCount);
    }

    private void UpdateHiddenState()
    {
        isHidden = hiddenBushCount > 0;
        Debug.Log("Player hidden state: " + isHidden);
    }
}