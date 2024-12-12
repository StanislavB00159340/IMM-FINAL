using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;

public class WinScript : MonoBehaviour
{
    public TextMeshProUGUI uiText; // Reference to the TextMeshPro UI text for "You WIN"
    public int winScore = 10; // Public value for the win requirement
    private bool hasWon = false; // To prevent win logic from executing multiple times

    void Update()
    {
        // Check if the win condition is met and hasn't already triggered
        if (!hasWon && GameManager.Instance != null && GameManager.Instance.Score >= winScore)
        {
            hasWon = true; // Mark as won to prevent multiple executions
            ExecuteWINLogic();
        }
    }

    private void ExecuteWINLogic()
    {
        // Display "You WIN" on the UI
        if (uiText != null)
        {
            uiText.text = "You WIN";
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