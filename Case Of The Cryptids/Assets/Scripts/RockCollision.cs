using UnityEngine;
using System.Collections;

public class RockCollision : MonoBehaviour
{
    public GameObject breakEffect; // optional
    public float endDelay = 1.5f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Fence"))
        {
            Debug.Log("Fence hit!");

            Transform fenceRoot = collision.transform.root;

            if (breakEffect != null && collision.contacts.Length > 0)
            {
                Instantiate(breakEffect, collision.contacts[0].point, Quaternion.identity);
            }

            Destroy(fenceRoot.gameObject);

            EndLevel();

            Destroy(gameObject);
        }
    }

    void EndLevel()
    {
        Debug.Log("Level Complete!");
        StartCoroutine(EndRoutine());
    }

    IEnumerator EndRoutine()
    {
        EndScreenUI ui = FindFirstObjectByType<EndScreenUI>();

        if (ui != null)
        {
            ui.ShowEndScreen();
        }

        yield return new WaitForSeconds(endDelay);

        Time.timeScale = 0f;
    }
}