using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;

public class NetCatchPlayerWithDisplay : MonoBehaviour
{
    public TextMeshProUGUI uiText; // Reference to the UI Text element

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object that collided has the "Player" tag
        if (other.CompareTag("Player")) // Use CompareTag for performance
        {
            // Display "You Died" on the UI
            if (uiText != null)
            {
                uiText.text = "You Died";
                uiText.gameObject.SetActive(true); // Ensure the text is visible
                StartCoroutine(RestartScene()); // Start the coroutine
            }
        }
    }

    private IEnumerator RestartScene()
    {
        yield return new WaitForSeconds(3); // Wait for 3 seconds
        SceneManager.LoadScene(1); // Reload the scene by build index or name
    }
}
