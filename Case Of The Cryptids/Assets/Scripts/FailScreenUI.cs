using UnityEngine;
using UnityEngine.SceneManagement;

public class FailScreenUI : MonoBehaviour
{
    public GameObject failPanel;

    private bool isFailScreenShowing = false;

    public void ShowFailScreen()
    {
        if (failPanel != null)
        {
            failPanel.SetActive(true);
        }

        isFailScreenShowing = true;
        Time.timeScale = 0f;
    }

    private void Update()
    {
        if (isFailScreenShowing && Input.GetKeyDown(KeyCode.R))
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("SampleScene");
        }
    }
}