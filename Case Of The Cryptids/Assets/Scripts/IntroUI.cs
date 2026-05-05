using UnityEngine;

public class IntroUI : MonoBehaviour
{
    public GameObject introPanel;

    void Start()
    {
        if (introPanel != null)
        {
            introPanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    void Update()
    {
        if (introPanel != null && introPanel.activeSelf && Input.GetKeyDown(KeyCode.Return))
        {
            introPanel.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}