using UnityEngine;

public class Bulletenemy : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Check if the object the bullet collided with has the "Enemy" tag
        if (other.CompareTag("Enemy"))
        {
            // Destroy the enemy
            Destroy(other.gameObject);

            // Destroy the bullet itself
            Destroy(gameObject);

            // Notify the GameManager to increase the score
            GameManager.Instance?.AddScore(1);
        }
    }
}
