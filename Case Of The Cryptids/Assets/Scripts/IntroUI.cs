using UnityEngine;

public class IntroUI : MonoBehaviour
{
    public GameObject introPanel;

    private static bool hasShownIntro = false;

    void Start()
    {
        if (introPanel == null)
            return;

        if (hasShownIntro)
        {
            introPanel.SetActive(false);
            Time.timeScale = 1f;
        }
        else
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
            hasShownIntro = true;
        }
    }
}