using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // Required for scene management
using System.Collections;
using TMPro; // Required for TextMeshPro

public class DeathsScript : MonoBehaviour
{
    public Slider healthSlider; // Reference to the health slider
    public TextMeshProUGUI uiText; // Reference to the TextMeshPro UI text for "You Died"

    private bool isDead = false; // To prevent death logic from executing multiple times

    void Update()
    {
        if (healthSlider != null && healthSlider.value <= 0 && !isDead)
        {
            isDead = true; // Mark as dead to prevent multiple executions
            ExecuteDeathLogic();
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
