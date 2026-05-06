using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class StartMenu : MonoBehaviour
{
    public AudioSource musicSource;   // for looping atmosphere music
    public AudioClip startSFX;        // for button press sound

    public void StartGame()
    {
        StartCoroutine(PlayAndLoad());
    }

    IEnumerator PlayAndLoad()
    {
        musicSource.PlayOneShot(startSFX);  // plays SFX on top of music
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("SampleScene");
    }
}