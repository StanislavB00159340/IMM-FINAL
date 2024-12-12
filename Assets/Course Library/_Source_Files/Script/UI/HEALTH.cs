using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;

public class HEALTH : MonoBehaviour
{
    public Slider healthSlider; // Reference to the health slider UI element
    public TextMeshProUGUI uiText; // Reference to the UI Text element
    public float maxHealth = 100f; // Maximum health
    private float currentHealth; // Current health value

    private bool isDead = false; // Prevent multiple triggers

    void Start()
    {
        // Initialize health
        currentHealth = maxHealth;

        // Update health UI
        UpdateHealthUI();
    }

    void Update()
    {
        // Check if health is zero
        if (healthSlider != null && currentHealth <= 0 && !isDead)
        {
            isDead = true; // Prevent multiple "You Died" calls
            ExecuteDeathLogic();
        }
    }

    public void TakeDamage(float damage)
    {
        // Reduce health
        currentHealth -= damage;

        // Clamp health to be non-negative
        currentHealth = Mathf.Max(currentHealth, -1);

        // Update the health slider
        UpdateHealthUI();
    }

    private void UpdateHealthUI()
    {
        if (healthSlider != null)
        {
            healthSlider.value = currentHealth / maxHealth;
        }
    }

    private void ExecuteDeathLogic()
    {
        // Display "You Died" on the UI
        if (uiText != null)
        {
            uiText.text = "You Died";
            uiText.gameObject.SetActive(true); // Ensure the text is visible
        }

        // Start scene restart coroutine
        StartCoroutine(RestartScene());
    }

    private IEnumerator RestartScene()
    {
        yield return new WaitForSeconds(3); // Wait for 3 seconds
        SceneManager.LoadScene(1); // Reload the scene by build index or name
    }
}
