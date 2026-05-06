using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreenUI : MonoBehaviour
{
    public GameObject endPanel;
    public AudioSource audioSource;
    public AudioClip levelCompleteSound;

    public void ShowEndScreen()
    {
        if (endPanel != null)
        {
            endPanel.SetActive(true);
        }

        if (audioSource != null && levelCompleteSound != null)
        {
            audioSource.PlayOneShot(levelCompleteSound);
        }
    }

    void Update()
    {
        if (endPanel != null && endPanel.activeSelf && Input.GetKeyDown(KeyCode.R))
        {
            RestartTutorial();
        }
    }

    public void RestartTutorial()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("SampleScene");
    }
}