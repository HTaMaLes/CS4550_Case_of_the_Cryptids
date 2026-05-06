using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public int damageAmount = 4;
    public int healAmount = 1;

    public float damageInterval = 1f;
    public float healInterval = 5f;

    public HealthBar healthBar;

    [Header("Restart Settings")]
    public string sceneToRestart = "SampleScene";

    private float damageTimer;
    private float healTimer;

    private bool isDetected;
    private bool hasRestarted = false;

    void Start()
    {
        currentHealth = maxHealth;

        if (healthBar != null)
        {
            healthBar.SetMaxHealth(maxHealth);
            healthBar.SetHealth(currentHealth);
        }
    }

    void Update()
    {
        if (hasRestarted)
            return;

        if (isDetected)
        {
            healTimer = 0f;
            damageTimer += Time.deltaTime;

            if (damageTimer >= damageInterval)
            {
                TakeDamage(damageAmount);
                damageTimer = 0f;
            }
        }
        else
        {
            damageTimer = 0f;
            healTimer += Time.deltaTime;

            if (healTimer >= healInterval)
            {
                Heal(healAmount);
                healTimer = 0f;
            }
        }
    }

    public void SetDetected(bool detected)
    {
        isDetected = detected;
    }

    void TakeDamage(int amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        if (healthBar != null)
        {
            healthBar.SetHealth(currentHealth);
        }

        Debug.Log("Player health: " + currentHealth);

        if (currentHealth <= 0)
        {
            RestartTutorial();
        }
    }

    void Heal(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        if (healthBar != null)
        {
            healthBar.SetHealth(currentHealth);
        }

        Debug.Log("Player health: " + currentHealth);
    }

    public void RestartTutorial()
    {
        if (hasRestarted)
            return;

        hasRestarted = true;

        Debug.Log("Player failed. Showing fail screen.");

        FailScreenUI failUI = FindFirstObjectByType<FailScreenUI>();

        if (failUI != null)
        {
            failUI.ShowFailScreen();
        }
        else
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(sceneToRestart);
        }
    }
}