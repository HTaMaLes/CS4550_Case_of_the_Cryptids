using UnityEngine;

public class EndScreenUI : MonoBehaviour
{
    public GameObject endPanel;

    public void ShowEndScreen()
    {
        if (endPanel != null)
        {
            endPanel.SetActive(true);
        }
    }
}