using UnityEngine;
using UnityEngine.UI; // Required for UI components like Slider

public class takedamage : MonoBehaviour
{
    public float damageAmount = 10f; // Amount of damage to apply to the player
    public Slider healthSlider; // Reference to the UI Slider representing health

    void Start()
    {
        if (healthSlider == null)
        {
            Debug.LogWarning("Health Slider is not assigned in TakeDamage script!");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger has the "Enemy" tag
        if (other.CompareTag("Enemy"))
        {
            if (healthSlider != null)
            {
                // Reduce the slider's value by the damage amount
                healthSlider.value -= damageAmount;

                // Clamp the slider value to ensure it doesn't go below 0
                if (healthSlider.value <= 0)
                {
                    healthSlider.value = 0;
                    Debug.Log("Player health reached zero!");
                }

                Debug.Log("Player took damage from enemy! Remaining health: " + healthSlider.value);
            }
        }
    }
}
