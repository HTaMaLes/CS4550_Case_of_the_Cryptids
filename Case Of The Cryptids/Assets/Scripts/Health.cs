using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public int damageAmount = 4;
    public int healAmount = 1;

    public float damageInterval = 1f;
    public float healInterval = 5f;

    public HealthBar healthBar;

    private float damageTimer;
    private float healTimer;

    private bool isDetected;

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
}